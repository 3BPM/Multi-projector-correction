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


namespace WindowsFormsApp1.othercs
{
    public partial class inputdata : Form
    {
        private StreamWriter filewrite;
        //FileStream output;
        private VideoCapture _capture;
        //Graphics g;
        private Pen pen = new Pen(Color.Red, 1);
        private System.Drawing.Point p = new System.Drawing.Point(1000, 500);
        int circlewidth = 1;
        int movewidth = 10;
        public inputdata()
        {
            InitializeComponent();
            _capture = new VideoCapture(0, VideoCaptureAPIs.DSHOW); // 使用默认摄像头设备

            //if (_capture != null)
            //{
            //    _capture.Open(0); // 打开摄像头

            //    if (_capture.IsOpened())
            //    {
            //        // 设置图像宽度和高度
            //        _capture.FrameWidth = 640;
            //        _capture.FrameHeight = 480;

            //        // 开始捕获视频帧
            //        Application.Idle += CaptureFrame;
            //    }
            //}
            KeyPreview = true;
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
            this.MouseClick += pictureBox1_Click;
            this.MouseDoubleClick += pictureBox1_MouseDoubleClick;
            this.KeyDown += inputdata_KeyDown;
            //g = this.CreateGraphics();
            this.x.Text = "1000";
            this.y.Text = "500";
        }


        void inputdata_MouseClick(object sender, MouseEventArgs e)
        {
            //p.X = e.X;
            //p.Y = e.Y;
            //p = this.PointToScreen(p);
            //this.x.Text = e.X.ToString();
            //this.y.Text = e.Y.ToString();
        }

        void inputdata_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //this.panel1.Left = e.X;
            //this.panel1.Top = e.Y;
            //this.Focus();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
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

                    // 可以在此处对图像进行进一步处理或保存等操作
                }
            }
            System.Drawing.Point mousePosition = pictureBox1.PointToClient(Cursor.Position);
            p.X = mousePosition.X;
            p.Y = mousePosition.Y;
           
            p = this.PointToScreen(p);
            this.x.Text = mousePosition.X.ToString();
            this.y.Text = mousePosition.Y.ToString();
        }
        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.panel1.Left = e.X;
            this.panel1.Top = e.Y;
            this.Focus();
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

        private void button5_Click(object sender, EventArgs e)
        {
            string data = this.row.Text + " " + this.col.Text + " " + this.z.Text + " " + this.x.Text + " " + this.y.Text + " " + this.widCir.Text + " " + this.color.Text;
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

        // private void InitializeComponent()
        // {
        //     this.SuspendLayout();
        //     //
        //     // inputdata
        //     //
        //     this.ClientSize = new System.Drawing.Size(276, 236);
        //     this.Name = "inputdata";
        //     this.Load += new System.EventHandler(this.inputdata_Load);
        //     this.ResumeLayout(false);

        // }

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


    }
  }

