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
//using System.Windows.Media;
using OpenCvSharp;
using OpenCvSharp.Extensions;

using Windows.Media.Capture;
using System.Threading;
using System.Runtime.InteropServices;
using System.Security;
using System.Management;

namespace WindowsFormsApp1.othercs
{
    public partial class inputdata : Form
    {
        private StreamWriter filewrite;
        private VideoCapture _capture;
        //Graphics g;
        private Pen pen = new Pen(Color.Red, 1);
        private System.Drawing.Point p = new System.Drawing.Point(1000, 500);
        int circlewidth = 1;
        int movewidth = 1;//像素级调整
        static bool isDrawingRect = false;
        static System.Drawing.Point rectStartPoint;
        private static bool Vopen_flag; //视频打开关闭状态
        Thread Video_thread; //视频播放线程
        private int VideoCapture_id = 0;//摄像头设备号，默认0，可根据下拉框调整
        List<CameraDevice> cameras;
        private float widthRatio = 1.0f;
        private float heightRatio = 1.0f;
        private float widthx = 0.0f;
        private float heighty = 0.0f;
        public inputdata()
        {
            InitializeComponent();

            // string imagePath = @"bg5.jpg";
            //this.BackgroundImage = Image.FromFile(imagePath);
            // this.BackgroundImageLayout = ImageLayout.Stretch;
            _capture = new VideoCapture(VideoCapture_id, VideoCaptureAPIs.DSHOW); // 使用默认摄像头设备
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
            cameras = GetAllConnectedCameras();

            // 绑定数据源
            comboBox1.DataSource = cameras;
            comboBox1.DisplayMember = "Name";

            //// 创建自定义项模板
            //ComboBoxItemTemplate template = new ComboBoxItemTemplate();
            //template.Text = "${Name} - ${Status}";

            //// 将模板应用于 ComboBox
            //comboBox1.ItemTemplate = template;

            //g = this.CreateGraphics();

            this.x.Text = "0";
            this.y.Text = "0";
        }



        private void inputdataClick(object sender, EventArgs e)
        {
            // 在点击 PictureBox 时进行拍摄
            if (_capture != null && _capture.IsOpened())
            {
                Mat frame = new Mat();
                _capture.Read(frame); // 读取视频帧

                if (!frame.Empty())
                {
                    // 将图像转换为 Bitmap 并显示在 PictureBox 中
                    pictureBox1.Image = frame.ToBitmap();
                    // 计算缩放倍率
                    widthRatio = (float)pictureBox1.Width / (float)frame.Width;
                    heightRatio = (float)pictureBox1.Height / (float)frame.Height;
                    float scaleRatio = Math.Min(widthRatio, heightRatio);

                    // 缩放图像
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                    pictureBox1.Width = (int)(frame.Width * scaleRatio);
                    pictureBox1.Height = (int)(frame.Height * scaleRatio);

                    // 获取缩放后的宽度和高度
                    int scaledWidth = pictureBox1.Width;
                    int scaledHeight = pictureBox1.Height;

                    // 可以在此处对图像进行进一步处理或保存等操作
                    // 可以在此处对图像进行进一步处理或保存等操作
                }
            }
            System.Drawing.Point mousePosition = pictureBox1.PointToClient(Cursor.Position);

            p.X = mousePosition.X;
            p.Y = mousePosition.Y;

            p = this.PointToScreen(p);
            this.widthx = mousePosition.X * widthRatio;
            this.x.Text = this.widthx.ToString();
            this.heighty = mousePosition.Y * heightRatio;
            this.y.Text = this.heighty.ToString();

            // 开始绘制矩形
            isDrawingRect = true;

            // 设置矩形起点为鼠标位置
            rectStartPoint = mousePosition;

            this.Focus();
        }
        private void inputdataMouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.panel1.Left = e.X;
            this.panel1.Top = e.Y;
        }
        static void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {

            if (isDrawingRect)
            {
                // 在鼠标移动时绘制矩形
                var pictureBox = (PictureBox)sender;
                var rectEnd = e.Location;
                var rect = new Rectangle(rectStartPoint, new System.Drawing.Size(rectEnd.X - rectStartPoint.X, rectEnd.Y - rectStartPoint.Y));
                pictureBox.Invalidate();
                pictureBox.CreateGraphics().DrawRectangle(Pens.Red, rect);
            }
        }


        static void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            //MessageBox.Show("按下！");
            //if (isDrawingRect)
            //{
            //    // 结束矩形绘制
            //    isDrawingRect = false;
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

        private void button5_Click(object sender, EventArgs e)//save
        {
            // string data = this.row.Text + " " + this.col.Text + " " + this.z.Text + " " + this.x.Text + " " + this.y.Text + " " + this.widCir.Text + " " + this.color.Text;
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

        }

        private void color_TextChanged(object sender, EventArgs e)
        {
            switch (color.Text)
            {
                case "1": pen.Color = Color.Purple; break;
                case "2": pen.Color = Color.Pink; break;
                case "3": pen.Color = Color.Aqua; break;
                default: pen.Color = Color.Red; break;
            }
        }

        private void col_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.widMov.Text))
                movewidth = Convert.ToInt32(this.widMov.Text);
        }

        private void widMov_Click(object sender, EventArgs e)
        {

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
                Application.Idle -= CaptureFrame;
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
                //_capture.Set(VideoCaptureProperty.FrameWidth, 640);
                //_capture.Set(VideoCaptureProperty.FrameHeight, 480);
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
    }
}



