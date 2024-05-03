//using OpenCvSharp;
//using OpenCvSharp.Extensions;
using Emgu.CV;
using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Emgu.CV.Structure;
using System.Drawing;




namespace WindowsFormsApp1.othercs
{
    public class camsetting : Form
    {
        int VideoCapture_id = 0;
        private PictureBox pictureBox1;
        private TrackBar trackBar1;
        private VideoCapture _capture;
        String win1 = "Test Window (Press any key to close)"; //The name of the window
        public camsetting()
        {
         
            CvInvoke.NamedWindow(win1); //Create the window using the specific name
            InitializeComponent();
            _capture = new VideoCapture(this.VideoCapture_id);//, VideoCaptureAPIs.DSHOW
            //double fps = 60;
            //capture.Set(capturetureProperty.Fps, fps);    //I think fps set didn't work on my webcam
            _capture.ImageGrabbed += ProcessFrame;
            _capture.Start();
        }
        //private void startcapture()
        //{
        //    Task.Run(() =>
        //    {
        //        int sleepTime = 1;  //(int)Math.Round(1000 / fps);
        //        var sw = Stopwatch.StartNew();
        //        var counter = 0;
        //        Mat image = new Mat();
        //        while (true)
        //        {
        //            _capture.Read(image);
        //            if (!image.Empty())
        //            {
        //                counter++;
        //                double frame = (double)counter / sw.ElapsedMilliseconds * 1000;
        //                Cv2.PutText(image, $"FPS:{frame:F}", new Point(10, 40), HersheyFonts.HersheySimplex, 1, Scalar.Red);
        //                if (pictureBox1.IsHandleCreated)
        //                {
        //                    pictureBox1.Invoke(new Action(() =>
        //                {
        //                    pictureBox1.Image?.Dispose(); // Dispose previous image
        //                    pictureBox1.Image = image.ToBitmap();
        //                    Console.WriteLine("UI updated"); // Debug information
        //                }));
        //                }
        //            }
        //        }

        //    });
        //}
        private void ProcessFrame(object sender, EventArgs arg)
        {
            if (_capture != null && _capture.Ptr != IntPtr.Zero)
            {
                var frame = new Emgu.CV.Mat();
                _capture.Retrieve(frame, 0);

             
                
                CvInvoke.Imshow(win1, frame);

            }
        }
        private void InitializeComponent()
        {
            label1 = new Label();
            trackBarExposure = new TrackBar();
            trackBarBrightness = new TrackBar();
            trackBarISO = new TrackBar();
            trackBarContrast = new TrackBar();
            trackBarSaturation = new TrackBar();
            trackBarHue = new TrackBar();
            trackBarGain = new TrackBar();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)trackBarExposure).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarBrightness).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarISO).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarContrast).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarSaturation).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarHue).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarGain).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Location = new System.Drawing.Point(0, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(100, 23);
            label1.TabIndex = 9;
            // 
            // trackBarExposure
            // 
            trackBarExposure.Location = new System.Drawing.Point(193, 219);
            trackBarExposure.Name = "trackBarExposure";
            trackBarExposure.Size = new System.Drawing.Size(140, 80);
            trackBarExposure.TabIndex = 1;
            trackBarExposure.Scroll += trackBarExposure_Scroll_1;
            // 
            // trackBarBrightness
            // 
            trackBarBrightness.Location = new System.Drawing.Point(193, 290);
            trackBarBrightness.Name = "trackBarBrightness";
            trackBarBrightness.Size = new System.Drawing.Size(140, 80);
            trackBarBrightness.TabIndex = 2;
            trackBarBrightness.Scroll += trackBarBrightness_Scroll;
            // 
            // trackBarISO
            // 
            trackBarISO.Location = new System.Drawing.Point(193, 363);
            trackBarISO.Name = "trackBarISO";
            trackBarISO.Size = new System.Drawing.Size(140, 80);
            trackBarISO.TabIndex = 3;
            trackBarISO.Scroll += trackBarISO_Scroll;
            // 
            // trackBarContrast
            // 
            trackBarContrast.Location = new System.Drawing.Point(193, 470);
            trackBarContrast.Name = "trackBarContrast";
            trackBarContrast.Size = new System.Drawing.Size(140, 80);
            trackBarContrast.TabIndex = 4;
            trackBarContrast.Scroll += trackBarContrast_Scroll;
            // 
            // trackBarSaturation
            // 
            trackBarSaturation.Location = new System.Drawing.Point(193, 576);
            trackBarSaturation.Name = "trackBarSaturation";
            trackBarSaturation.Size = new System.Drawing.Size(140, 80);
            trackBarSaturation.TabIndex = 5;
            trackBarSaturation.Scroll += trackBarSaturation_Scroll;
            // 
            // trackBarHue
            // 
            trackBarHue.Location = new System.Drawing.Point(193, 673);
            trackBarHue.Name = "trackBarHue";
            trackBarHue.Size = new System.Drawing.Size(140, 80);
            trackBarHue.TabIndex = 6;
            trackBarHue.Scroll += trackBarHue_Scroll;
            // 
            // trackBarGain
            // 
            trackBarGain.Location = new System.Drawing.Point(193, 779);
            trackBarGain.Name = "trackBarGain";
            trackBarGain.Size = new System.Drawing.Size(140, 80);
            trackBarGain.TabIndex = 7;
            trackBarGain.Scroll += trackBarGain_Scroll;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            pictureBox1.Image = Properties.Resources.aruco15;
            pictureBox1.Location = new System.Drawing.Point(503, 210);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(772, 735);
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // camsetting
            // 
            ClientSize = new System.Drawing.Size(1494, 1296);
            Controls.Add(pictureBox1);
            Controls.Add(trackBarGain);
            Controls.Add(trackBarHue);
            Controls.Add(trackBarSaturation);
            Controls.Add(trackBarContrast);
            Controls.Add(trackBarISO);
            Controls.Add(trackBarBrightness);
            Controls.Add(trackBarExposure);
            Controls.Add(label1);
            Name = "camsetting";
            Load += camsetting_Load;
            ((System.ComponentModel.ISupportInitialize)trackBarExposure).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarBrightness).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarISO).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarContrast).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarSaturation).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarHue).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarGain).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void camsetting_Load(object sender, System.EventArgs e)
        {

        }


        private TrackBar trackBarExposure;
        private TrackBar trackBarBrightness;
        private TrackBar trackBarISO;
        private TrackBar trackBarContrast;
        private TrackBar trackBarSaturation;
        private TrackBar trackBarHue;
        private TrackBar trackBarGain;
        private Label label1;
        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            //_capture?.Release();
            _capture?.Stop();

            _capture?.Dispose();
            System.Environment.Exit(0);
        }


        private void trackBarExposure_Scroll(object sender, EventArgs e)
        {
            //_capture.Set(VideoCaptureProperties.Exposure, trackBarExposure.Value);
            TrackBar tb = sender as TrackBar;
            if (_capture != null)
                _capture.Set(Emgu.CV.CvEnum.CapProp.Exposure, tb.Value);
        }

        private void trackBarBrightness_Scroll(object sender, EventArgs e)
        {
            TrackBar tb = sender as TrackBar;
            if (_capture != null)
                _capture.Set(Emgu.CV.CvEnum.CapProp.Brightness, tb.Value);
        }

        private void trackBarISO_Scroll(object sender, EventArgs e)
        {
            TrackBar tb = sender as TrackBar;
            if (_capture != null)
                _capture.Set(Emgu.CV.CvEnum.CapProp.IsoSpeed, tb.Value);
        }

        private void trackBarContrast_Scroll(object sender, EventArgs e)
        {
            TrackBar tb = sender as TrackBar;
            if (_capture != null)
                _capture.Set(Emgu.CV.CvEnum.CapProp.Contrast, tb.Value);
        }

        private void trackBarSaturation_Scroll(object sender, EventArgs e)
        {
            TrackBar tb = sender as TrackBar;
            if (_capture != null)
                _capture.Set(Emgu.CV.CvEnum.CapProp.Saturation, tb.Value);
        }

        private void trackBarHue_Scroll(object sender, EventArgs e)
        {
            TrackBar tb = sender as TrackBar;
            if (_capture != null)
                _capture.Set(Emgu.CV.CvEnum.CapProp.Hue, tb.Value);
        }

        private void trackBarGain_Scroll(object sender, EventArgs e)
        {
            TrackBar tb = sender as TrackBar;
            if (_capture != null)
                _capture.Set(Emgu.CV.CvEnum.CapProp.Gain, tb.Value);
        }


        // Add similar methods for other controls/settings

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            _capture.Dispose();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void trackBarExposure_Scroll_1(object sender, EventArgs e)
        {

        }
    }
}



