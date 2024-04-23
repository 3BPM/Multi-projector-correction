using OpenCvSharp;
using System.Diagnostics;
using System.Windows.Forms;
namespace WindowsFormsApp1.othercs
{
    public class camsetting : Form
    {
        int VideoCapture_id = 0;

        public camsetting()
        {
            var cap = new VideoCapture(this.VideoCapture_id, VideoCaptureAPIs.DSHOW);
            //double fps = 60;
            //cap.Set(CaptureProperty.Fps, fps);    //I think fps set didn't work on my webcam
            int sleepTime = 1;  //(int)Math.Round(1000 / fps);
            var sw = Stopwatch.StartNew();
            var counter = 0;
            using (Window window = new Window("capture"))
            using (Mat image = new Mat())
            {
                while (true)
                {
                    cap.Read(image);
                    if (image.Empty())
                        break;
                    counter++;
                    double frame = (double)counter / sw.ElapsedMilliseconds * 1000;
                    Cv2.PutText(image, $"FPS:{frame:F}", new Point(10, 40), HersheyFonts.HersheySimplex, 1, Scalar.Red);
                    window.ShowImage(image);
                    Cv2.WaitKey(sleepTime);

                    if (counter % 1299721 == 0) //random pick 100001st prime
                    {
                        counter = 0;
                        sw.Reset();
                    }
                }
            }
            cap.Release();
        }

        private void InitializeComponent()
        {
            label1 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(74, 68);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(68, 30);
            label1.TabIndex = 0;
            label1.Text = "label1";
            label1.Click += label1_Click;
            // 
            // camsetting
            // 
            ClientSize = new System.Drawing.Size(276, 236);
            Controls.Add(label1);
            Name = "camsetting";
            Load += camsetting_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private void camsetting_Load(object sender, System.EventArgs e)
        {

        }

        private void label1_Click(object sender, System.EventArgs e)
        {

        }

        private Label label1;
        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Environment.Exit(0);
        }
    }
}


