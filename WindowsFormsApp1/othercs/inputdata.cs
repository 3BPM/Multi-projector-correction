using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using System.Drawing.Drawing2D;
using System.Text.RegularExpressions;
using WindowsFormsApp1.Properties;
using OpenCvSharp;
using OpenCvSharp.Extensions;

using Windows.Media.Capture;
using System.Threading;
using System.Runtime.InteropServices;
using System.Security;
using System.Management;
using System.Security.Cryptography;
using static System.Net.Mime.MediaTypeNames;

namespace WindowsFormsApp1.othercs
{
    public partial class inputdata : Form
    {
        private StreamWriter filewrite;
        private VideoCapture _capture;

        //Graphics g;
        private Pen pen = new Pen(Color.Red, 5);//宽度1像素
        private System.Drawing.Point p = new System.Drawing.Point(1000, 500);
        int circlewidth = 1;
        int movewidth = 1;//像素级调整
        static bool isDrawingL = false;
        static System.Drawing.Point LineStartPoint;
        private static bool Vopen_flag; //视频打开关闭状态
        Thread Video_thread; //视频播放线程
        private int VideoCapture_id = 0;//摄像头设备号，默认0，可根据下拉框调整
        List<CameraDevice> cameras;

        private float widthx = 0.0f;//ratio
        private float heighty = 0.0f;
        List<System.Drawing.Point> points = new List<System.Drawing.Point>(); // 用于存储折线的各个点
        List<OpenCvSharp.Point2f> fourcorners = new List<OpenCvSharp.Point2f>();
        //int frameWidth = 1920;
        //int frameHeight = 1080;
        int frameWidth = Properties.Settings.Default.camsizew;
        int frameHeight = Properties.Settings.Default.camsizeh;

        private List<Line> lines = new List<Line>(); // To store drawn lines

        private bool isDrawingLine = false; // To indicate if a line is being drawn

        public inputdata()
        {
            InitializeComponent();

            _capture = new VideoCapture(this.VideoCapture_id, VideoCaptureAPIs.DSHOW);
            _capture.Set(VideoCaptureProperties.FrameWidth, this.frameWidth);
            _capture.Set(VideoCaptureProperties.FrameHeight, this.frameHeight);

            try
            {
                //output = new FileStream(path, FileMode.Append, FileAccess.Write);
                filewrite = File.AppendText(Properties.Settings.Default.log文件保存位置);


                //MessageBox.Show("Open/Create success!");
            }
            catch (IOException)
            {
                MessageBox.Show("Error Opening File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            cameras = GetAllConnectedCameras();

            // 绑定数据源
            comboBox1.DataSource = cameras;
            comboBox1.DisplayMember = "Name";


            this.x.Text = "0";
            this.y.Text = "0";
        }

        private void writecamsetting()
        {
            this.frameWidth = (int)_capture.Get(VideoCaptureProperties.FrameWidth);
            this.frameHeight = (int)_capture.Get(VideoCaptureProperties.FrameHeight);
            filewrite.WriteLine($"Camera Resolution: {frameWidth}x{frameHeight}");
        }

        private void inputdataClick(object sender, EventArgs e)
        {
            int scaledWidth = pictureBox1.Width;
            int scaledHeight = pictureBox1.Height;

            var graphics = pictureBox1.CreateGraphics();

            // 在点击 PictureBox 时进行拍摄
            if (_capture != null && _capture.IsOpened())
            {
                Mat frame = new Mat();
                _capture.Read(frame); // 读取视频帧

                if (!frame.Empty())
                {

                    // 缩放图像
                    Mat resizedFrame = new Mat();
                    Cv2.Resize(frame, resizedFrame, new OpenCvSharp.Size(scaledWidth, scaledHeight));
                    // 将图像转换为 Bitmap 并显示在 PictureBox 中
                    pictureBox1.Image = resizedFrame.ToBitmap();
                }
            }
            System.Drawing.Point mousePosition = pictureBox1.PointToClient(Cursor.Position);
            p.X = mousePosition.X;
            p.Y = mousePosition.Y;

            this.widthx = (float)mousePosition.X / (float)scaledWidth;
            this.x.Text = ((int)(this.widthx * this.frameWidth)).ToString();
            this.heighty = (float)mousePosition.Y / (float)scaledHeight;
            this.y.Text = ((int)(this.heighty * this.frameHeight)).ToString();
            fourcorners.Add(new OpenCvSharp.Point2f((int)(this.widthx * this.frameWidth), (int)(this.heighty * this.frameHeight)));
            // Add the new mouse click location to the list
            points.Add(mousePosition);
            isDrawingL = true;
            // 设置直线起点为鼠标位置
            LineStartPoint = mousePosition;
            pictureBox1.Invalidate();

            this.Focus();
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {

            if (isDrawingL)
            {

                // Create a new line object with startPoint and current mouse location
                Line line = new Line(LineStartPoint, e.Location);

                // Check that points.Count is a valid index for the lines array
                if (points.Count >= 0 && points.Count < lines.Count)
                {
                    // Update the lines array at the points.Count index with the new line
                    lines[points.Count] = line;
                }
                else
                {
                    lines.Add(line);
                }



                // Redraw the points and lines on the PictureBox
                pictureBox1.Invalidate();
            }


        }

        private void inputdataMouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.panel1.Left = e.X;
            this.panel1.Top = e.Y;
        }


        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            //MessageBox.Show("按下！");
            //if (isDrawingL)
            //{
            //    // 结束矩形绘制
            //    isDrawingL = false;
            //    var pictureBox = (PictureBox)sender;
            //    pictureBox.Invalidate();
            //}
        }
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Left || keyData == Keys.Right || keyData == Keys.Up || keyData == Keys.Down)
            {
                return false;
            }
            else
            {
                return base.ProcessDialogKey(keyData);
            }
        }

        private void inputdata_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    p.X -= movewidth;
                    this.x.Text = (Convert.ToDouble(this.x.Text) - movewidth).ToString();
                    //MessageBox.Show("left");
                    break;
                case Keys.Right:
                    p.X += movewidth;
                    this.x.Text = (Convert.ToDouble(this.x.Text) + movewidth).ToString();
                    // MessageBox.Show("right");
                    break;
                case Keys.Up:
                    p.Y -= movewidth;
                    this.y.Text = (Convert.ToDouble(this.y.Text) - movewidth).ToString();
                    // MessageBox.Show("up");
                    break;
                case Keys.Down:
                    p.Y += movewidth;
                    this.y.Text = (Convert.ToDouble(this.y.Text) + movewidth).ToString();
                    //MessageBox.Show("down");
                    break;
                default:
                    break;

            }
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.FillEllipse(new SolidBrush(Color.Red),
                new RectangleF(p, new SizeF(circlewidth, circlewidth)));
            base.OnPaint(e);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void savebutton_Click(object sender, EventArgs e)//save
        {
            // string data = this.row.Text + " " + this.col.Text + " " + this.z.Text + " " + this.x.Text + " " + this.y.Text + " " + this.widCir.Text + " " + this.color.Text;
            int xValue = Convert.ToInt32(this.x.Text);
            int yValue = Convert.ToInt32(this.y.Text);

            string data = this.x.Text + " " + this.y.Text;
            filewrite.WriteLine(data);
            MessageBox.Show("save successfully");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            filewrite.Close();

            List<string> lines = new List<string>(File.ReadAllLines("data.txt"));

            lines.RemoveAt(lines.Count() - 1);

            File.WriteAllLines("data.txt", lines.ToArray());
            MessageBox.Show("delete successfully one recent data");
            try
            {
                //output = new FileStream(path, FileMode.Append, FileAccess.Write);
                filewrite = File.AppendText("data.txt");
                //MessageBox.Show("Open/Create success!");
            }
            catch (IOException)
            {
                MessageBox.Show("Error Opening File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.widCir.Text))
                circlewidth = Convert.ToInt32(this.widCir.Text);
        }
        private void inputdata_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show("dddd", "dff", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult.Yes != dr)
            {
                e.Cancel = true;
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (e.KeyCode == Keys.F11)
            {
                // 按下 F11 键时，切换到全屏模式
                if (WindowState == FormWindowState.Normal)
                {
                    WindowState = FormWindowState.Maximized;
                    FormBorderStyle = FormBorderStyle.None;
                }
                else
                {
                    WindowState = FormWindowState.Normal;
                    FormBorderStyle = FormBorderStyle.Sizable;
                }
            }
        }

        private void length_Click(object sender, EventArgs e)
        {

        }

        private void exit_Click(object sender, EventArgs e)
        {
            //filewrite.Flush();
            filewrite.Close();
            //output.Close();
            this.Dispose();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void row_TextChanged(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(row.Text))
            {
                int newWidth = Convert.ToInt32(row.Text);
                // Change the image width of _capture using OpenCvSharp
                _capture.Set(VideoCaptureProperties.FrameWidth, newWidth);
                writecamsetting();
            }


        }

        private void color_TextChanged(object sender, EventArgs e)
        {
            switch (color.Text)
            {
                case "紫": pen.Color = Color.Purple; break;
                case "红": pen.Color = Color.Pink; break;
                case "蓝": pen.Color = Color.Aqua; break;
                default: pen.Color = Color.Red; break;
            }
        }

        private void col_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(col.Text))
            {
                int newHeight = Convert.ToInt32(col.Text);
                // Change the image width of _capture using OpenCvSharp
                _capture.Set(VideoCaptureProperties.FrameHeight, newHeight);
                writecamsetting();
            }

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.widMov.Text))
                movewidth = Convert.ToInt32(this.widMov.Text);
        }

        private void widMov_Click(object sender, EventArgs e)
        {
            lines.Clear();
            points.Clear();
            fourcorners.Clear();
            isDrawingL = false;

        }



        private void inputdata_Load(object sender, EventArgs e)
        {



        }

        private void inputdata_Load_1(object sender, EventArgs e)
        {

        }

        private void CaptureFrame(object sender, EventArgs e)
        {
            Mat frame = new Mat();
            _capture.Read(frame); // 读取视频帧

            if (!frame.Empty())
            {
                // 将图像转换为 Bitmap 并显示在 PictureBox 中
                pictureBox1.Image = frame.ToBitmap();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_capture != null && _capture.IsOpened())
            {
                // 停止捕获视频帧并释放资源
                System.Windows.Forms.Application.Idle -= CaptureFrame;
                _capture.Release();
                _capture.Dispose();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {

                CameraDevice cameraDevice = (CameraDevice)comboBox1.SelectedValue;
                if (cameraDevice != null)
                {
                    this.VideoCapture_id = cameraDevice.OpenCvId;
                }
                MessageBox.Show("VideoCapture_id已更改！" + this.VideoCapture_id);
                // 释放旧的视频捕获对象
                if (_capture != null)
                {
                    _capture.Dispose();
                }

                // 创建新的视频捕获对象
                _capture = new VideoCapture(this.VideoCapture_id, VideoCaptureAPIs.DSHOW);
                _capture.Set(VideoCaptureProperties.FrameWidth, this.frameWidth);
                _capture.Set(VideoCaptureProperties.FrameHeight, this.frameHeight);
                this.frameWidth = (int)_capture.Get(VideoCaptureProperties.FrameWidth);
                this.frameHeight = (int)_capture.Get(VideoCaptureProperties.FrameHeight);

            }
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            // Create a Graphics object using the PictureBox's graphics
            using (Graphics g = pictureBox1.CreateGraphics())
            {
                // Draw each point in the points list as a black circle
                foreach (System.Drawing.Point point in points)
                {
                    g.DrawEllipse(Pens.Black, point.X, point.Y, 5, 5);
                }

                // Draw each line in the lines list
                foreach (Line line in lines)
                {
                    // g.DrawLine(line.Pen, line.StartPoint, line.EndPoint);
                    int x = Math.Min(line.StartPoint.X, line.EndPoint.X);
                    int y = Math.Min(line.StartPoint.Y, line.EndPoint.Y);
                    int width = Math.Abs(line.StartPoint.X - line.EndPoint.X);
                    int height = Math.Abs(line.StartPoint.Y - line.EndPoint.Y);

                    Rectangle rectangle = new Rectangle(x, y, width, height);

                    // 使用 Graphics 对象绘制矩形

                    g.DrawRectangle(Pens.Red, rectangle);

                }
            }
        }
        public static List<CameraDevice> GetAllConnectedCameras()
        {
            var cameras = new List<CameraDevice>();
            using (var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity WHERE (PNPClass = 'Image' OR PNPClass = 'Camera')"))
            {
                int openCvIndex = 0;
                foreach (ManagementObject device in searcher.Get())
                {
                    // Extract camera properties
                    string name = device["Caption"].ToString();
                    string status = device["Status"].ToString();
                    string deviceId = device["DeviceId"].ToString();

                    // Check if the device is a camera and enabled
                    if (name.ToLower().Contains("camera") && status.Equals("OK", StringComparison.OrdinalIgnoreCase))
                    {
                        cameras.Add(new CameraDevice
                        {
                            Name = name,
                            Status = status,
                            DeviceId = deviceId,
                            OpenCvId = openCvIndex // Assign OpenCV ID based on the loop index
                        });

                        openCvIndex++; // Increment the OpenCV device ID for the next iteration
                    }
                }

            }
            return cameras;
        }

        public class CameraDevice
        {
            public int OpenCvId { get; set; }

            public string Name { get; set; }
            public string DeviceId { get; set; }
            public string Status { get; set; }
        }
        public class Line
        {
            public System.Drawing.Point StartPoint { get; set; }
            public System.Drawing.Point EndPoint { get; set; }
            public Pen Pen { get; set; }

            public Line(System.Drawing.Point startPoint, System.Drawing.Point endPoint)
            {
                StartPoint = startPoint;
                EndPoint = endPoint;
                Pen = new Pen(Color.Red); // Set default pen color to black
            }
        }

        private void widCirLable_Click(object sender, EventArgs e)
        {
            Mat frame = new Mat();
            _capture.Read(frame); // 读取视频帧
            string currentFolderPath = Path.GetDirectoryName(Environment.CurrentDirectory);

            //Mat generated_aruco_img = Cv2.ImRead(@"C:\Users\robert\Documents\aruco15.png");
            string arucodir = Properties.Settings.Default.特征图像aruco码位置;
            Mat generated_aruco_img = Cv2.ImRead(arucodir);
            //System.Drawing.Image myImage = Properties.Resources.aruco15;
            //Mat generated_aruco_img = myImage.ToMat();
            if (generated_aruco_img == null)
            {
                throw new Exception("file could not be read, check with os.path.exists()");
            }

            int height = generated_aruco_img.Height;
            int width = generated_aruco_img.Width;
            int ch = generated_aruco_img.Channels();


            OpenCvSharp.Point2f[] pts1 = new OpenCvSharp.Point2f[] { new OpenCvSharp.Point2f(0, 0), new OpenCvSharp.Point2f(width, 0), new OpenCvSharp.Point2f(width, height), new OpenCvSharp.Point2f(0, height) };
            // 读取左上角和右下角两个点
            OpenCvSharp.Point2f topLeft = fourcorners[0];
            OpenCvSharp.Point2f bottomRight = fourcorners[1];

            // 生成矩形的四个顶点
            OpenCvSharp.Point2f topRight = new OpenCvSharp.Point2f(bottomRight.X, topLeft.Y);
            OpenCvSharp.Point2f bottomLeft = new OpenCvSharp.Point2f(topLeft.X, bottomRight.Y);

            // 清空四个角点列表
            fourcorners.Clear();

            // 添加生成的四个矩形顶点
            fourcorners.Add(topLeft);
            fourcorners.Add(topRight);
            fourcorners.Add(bottomRight);
            fourcorners.Add(bottomLeft);

            OpenCvSharp.Point2f[] pts2 = fourcorners.ToArray();


            Mat M = Cv2.GetPerspectiveTransform(pts1, pts2);
            Mat dst = new Mat();
            Cv2.WarpPerspective(generated_aruco_img, dst, M, new OpenCvSharp.Size(frameWidth, frameHeight));
            Mat frameWithAruco = new Mat();
            Cv2.AddWeighted(frame, 0.5, dst, 0.5, 0, frameWithAruco);
            Cv2.ImWrite("./pic2.png", dst);
            if (!frameWithAruco.Empty())
            {

                // 缩放图像
                Mat resizedFrame = new Mat();
                Cv2.Resize(frameWithAruco, resizedFrame, new OpenCvSharp.Size(pictureBox1.Width, pictureBox1.Height));
                // 将图像转换为 Bitmap 并显示在 PictureBox 中
                pictureBox1.Image = resizedFrame.ToBitmap();
            }
        }

        private void readdatalabel_Click(object sender, EventArgs e)
        {

            filewrite.Close();
            fourcorners.Clear();
            string[] linesToRead = File.ReadAllLines("data.txt");
            for (int i = 0; i < 4 && i < linesToRead.Length; i++)
            {
                string line = linesToRead[linesToRead.Length - 4 + i];
                string[] parts = line.Split(' ');
                if (parts.Length >= 2)
                {
                    float x = float.Parse(parts[0]);
                    float y = float.Parse(parts[1]);
                    fourcorners.Add(new OpenCvSharp.Point2f(x, y));
                }
            }
            foreach (var point in fourcorners)
            {
                points.Clear();
                points.Add(new System.Drawing.Point((int)point.X * pictureBox1.Width / this.frameWidth, (int)point.Y * pictureBox1.Height / this.frameHeight));
            }
            pictureBox1.Refresh();


        }

        private void textBox1_TextChanged_2(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}



