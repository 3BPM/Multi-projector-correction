using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge;
using AForge.Video.DirectShow;
namespace WindowsFormsApp1.othercs
{
    public partial class Videocallpy : Form
    {

        public Videocallpy()
        {
            InitializeComponent();
            button3.Enabled = false;
            //先检测电脑所有的摄像头
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            OpenVideo(1);
            comboBox1.BeginUpdate();
            for (int i = 1; i <= videoDevices.Count; i++)
            {
                comboBox1.Items.Add("摄像头" + i);
            }
            comboBox1.EndUpdate();
            if (videoDevices.Count <= 0)
            {
                MessageBox.Show("没有摄像头");
            }
            else
            {
                comboBox1.Text = "摄像头1";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "打开摄像头")
            {
                OpenVideo(1);
                button1.Text = "关闭摄像头";
            }
            else
            {
                ShutCamera();
                button1.Text = "打开摄像头";
            }
        }
        // 打开摄像头
        public void OpenVideo(int n)
        {
            if (videoDevices.Count >= n)
            {
                videoSource = new VideoCaptureDevice(videoDevices[n - 1].MonikerString);
                videoSourcePlayer1.VideoSource = videoSource;
                videoSourcePlayer1.Start();
            }
        }
        // 关闭并释放摄像头
        public void ShutCamera()
        {
            if (videoSourcePlayer1.VideoSource != null)
            {
                videoSourcePlayer1.SignalToStop();
                videoSourcePlayer1.WaitForStop();
                videoSourcePlayer1.VideoSource = null;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            img = videoSourcePlayer1.GetCurrentVideoFrame();//拍摄
            button3.Enabled = true; // 开启“保存”功能
        }

        // "保存"按钮click事件
        private void button3_Click(object sender, EventArgs e)
        {
            SaveImage(true);
        }
        public void SaveImage(bool changeName = false)
        {
            if (img == null)
                return;
            try
            {
                //以当前时间为文件名，保存为jpg格式
                //图片路径在程序bin目录下的Debug下
                TimeSpan tss = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
                long a = Convert.ToInt64(tss.TotalMilliseconds) / 1000;  //以秒为单位
                if (changeName)
                    img.Save(string.Format("{0}.jpg", a.ToString()));
                else
                    img.Save("xx.jpg");
                button3.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str = comboBox1.Text;
            int camr = Convert.ToInt32(str[3]) - '0'; // Encoding.ASCII.GetBytes(str);
            if (button1.Text != "打开摄像头" && camr <= videoDevices.Count)
            {
                ShutCamera();
                OpenVideo(camr);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            RunPythonFaceRecgn("test.py");
        }
        // 调用系统命令
        void RunPythonFaceRecgn(string cmd)
        {
            try
            {
                using (System.Diagnostics.Process p = new System.Diagnostics.Process())
                {
                    p.StartInfo.FileName = @"python3"; //python会运行错误，提示没有face_recognition，需要制定python3的安装路径
                    p.StartInfo.Arguments = cmd;//python命令的参数
                    p.StartInfo.UseShellExecute = false;
                    p.StartInfo.RedirectStandardOutput = true;
                    p.StartInfo.RedirectStandardInput = true;
                    p.StartInfo.RedirectStandardError = true;
                    p.StartInfo.CreateNoWindow = true;
                    p.Start();//启动进程
                    Console.WriteLine("Start");

                    // p.StandardInput.WriteLine(@"exit()");
                    StreamReader reader = p.StandardOutput;
                    if (reader == null)
                        Console.WriteLine("reader is null");
                    else
                    {
                        string output = reader.ReadToEnd();  // ReadToEnd/ReadLine
                        Console.WriteLine("face output : " + output);
                        string error = p.StandardError.ReadToEnd();
                        if (error != null && error != "")
                            Console.WriteLine("face err : " + error);
                    }
                    p.WaitForExit(); // 等待控制台程序执行完成
                    Console.WriteLine("执行完毕！");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        bool RunFaceRecgn = false;
        private void button5_Click(object sender, EventArgs e)
        {
            if (RunFaceRecgn)
                RunFaceRecgn = false;
            else
                RunFaceRecgn = true;

            Task.Run(() =>
            {
                while (RunFaceRecgn)
                {
                    img = videoSourcePlayer1.GetCurrentVideoFrame();//拍摄
                    SaveImage();
                    RunPythonFaceRecgn("test.py");
                    System.Threading.Thread.Sleep(500);
                }
            });
        }

        private void videoSourcePlayer1_Click(object sender, EventArgs e)
        {

        }
    }
}
