using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

using System.IO;
namespace WindowsFormsApp1.othercs
{
    class graydetect : Form
    {
        private System.ComponentModel.IContainer components = null;
        private Pen pen;
        private Pen pen1;
        private Graphics g;
        private System.Windows.Forms.Button exit;
        private ListBox screensListBox;
        List<string> lines = new List<string>(File.ReadAllLines("data.txt"));

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        //draw1  -------for Form1
        public graydetect()
        {
            InitializeComponent();
            pen = new Pen(Color.Gold, 1);
            pen1 = new Pen(Color.Yellow, 1);
            // pen.DashStyle = DashStyle.Custom;
            //pen.DashPattern = new float[] { 4f, 40f };
            g = this.CreateGraphics();
            this.screensListBox = new ListBox();
            this.screensListBox.Dock = DockStyle.Fill;
            this.Controls.Add(this.screensListBox);

            foreach (var screen in Screen.AllScreens)
            {
                string screenInfo = $"Projector {screen.DeviceName} [{screen.Bounds.Width}x{screen.Bounds.Height}]";
                this.screensListBox.Items.Add(screenInfo);
            }
        }

        private void InitializeComponent()
        {
            exit = new Button();
            screensListBox = new ListBox();
            SuspendLayout();
            // 
            // exit
            // 
            exit.Location = new Point(44, 185);
            exit.Margin = new Padding(6, 8, 6, 8);
            exit.Name = "exit";
            exit.Size = new Size(150, 58);
            exit.TabIndex = 0;
            exit.Text = "exit";
            exit.UseVisualStyleBackColor = true;
            exit.Click += button1_Click;
            // 
            // screensListBox
            // 
            screensListBox.FormattingEnabled = true;
            screensListBox.ItemHeight = 30;
            screensListBox.Location = new Point(44, 30);
            screensListBox.Name = "screensListBox";
            screensListBox.Size = new Size(194, 64);
            screensListBox.TabIndex = 1;
            screensListBox.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // draw1
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(2797, 1800);
            Controls.Add(screensListBox);
            Controls.Add(exit);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            KeyPreview = true;
            Margin = new Padding(6, 8, 6, 8);
            Name = "draw1";
            Text = "draw1";
            Load += calibration_Load;
            ResumeLayout(false);
        }

        public static void Delay(int milliSecond)
        {
            int start = Environment.TickCount;
            while (Math.Abs(Environment.TickCount - start) < milliSecond)
            {
                Application.DoEvents();
            }
        }

        int drawpic_num = 1;
        protected override void OnPaint(PaintEventArgs e)
        {
            string folderPath = Properties.Settings.Default.gray图片文件夹;
            string fileName = "newdata";

            string path = Path.Combine(folderPath, fileName);

            path += System.Convert.ToString(drawpic_num) + ".txt";
            drawpic(@path);
            base.OnPaint(e);
        }

        private void calibration_Load(object sender, EventArgs e)
        {
            this.Paint += calibration_Paint;
        }
        void calibration_Paint(object sender, PaintEventArgs e)
        {
            if (drawpic_num < 8)
                drawpic_num++;

            else
                drawpic_num = 1;
            Delay(200);
            this.Invalidate();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Dispose();
        }
        private void changecolor(int color)
        {
            switch (color)
            {
                case 0: pen.Color = Color.Gold; break;
                case 1: pen.Color = Color.Chocolate; break;
                case 2: pen.Color = Color.AliceBlue; break;
                case 3: pen.Color = Color.Purple; break;
                case 4: pen.Color = Color.GreenYellow; break;
                case 5: pen.Color = Color.Orange; break;
                case 6: pen.Color = Color.DeepSkyBlue; break;
                case 7: pen.Color = Color.IndianRed; break;
                case 8: pen.Color = Color.Magenta; break;
                case 9: pen.Color = Color.SaddleBrown; break;
                case 10: pen.Color = Color.LightSeaGreen; break;
                case 11: pen.Color = Color.Crimson; break;
                case 12: pen.Color = Color.SpringGreen; break;
                case 13: pen.Color = Color.Violet; break;
                default: pen.Color = Color.Red; break;
            }
        }

        private void convert(List<string> lines, int row, int col, double z1, double z2)
        {
            string[] cor_ref1 = lines[(row - 1) * 26 + col * 2 - 2].Split();
            string[] cor_ref2 = lines[(row - 1) * 26 + col * 2 - 1].Split();
            int x1 = (Convert.ToInt32(cor_ref1[3]) > Convert.ToInt32(cor_ref2[3])) ? Convert.ToInt32(cor_ref1[3]) : Convert.ToInt32(cor_ref2[3]);
            int y1 = (Convert.ToInt32(cor_ref1[4]) > Convert.ToInt32(cor_ref2[4])) ? Convert.ToInt32(cor_ref1[4]) : Convert.ToInt32(cor_ref2[4]);
            int x2 = (Convert.ToInt32(cor_ref1[3]) < Convert.ToInt32(cor_ref2[3])) ? Convert.ToInt32(cor_ref1[3]) : Convert.ToInt32(cor_ref2[3]);
            int y2 = (Convert.ToInt32(cor_ref1[4]) < Convert.ToInt32(cor_ref2[4])) ? Convert.ToInt32(cor_ref1[4]) : Convert.ToInt32(cor_ref2[4]);
            int _x1, _y1, _x2, _y2;
            _x1 = (int)((x1 - x2) * z1 + x2);
            _y1 = (int)((y1 - y2) * z1 + y2);
            _x2 = (int)((x1 - x2) * z2 + x2);
            _y2 = (int)((y1 - y2) * z2 + y2);
            if (row > 7)
            {
                _x1 += 1280;
                _x2 += 1280;
            }
            g.DrawLine(pen, _x1, _y1, _x2, _y2);
        }
        private void drawpic(string path)
        {
            String input;
            int row, col, color;
            double z1, z2;
            //路径为数据文本所在文件夹
            StreamReader sr = File.OpenText(path);
            while ((input = sr.ReadLine()) != null)
            {
                string[] arrays_sr = input.Split();
                if (arrays_sr.Count() == 5)
                {
                    row = Convert.ToInt32(arrays_sr[0]);
                    col = Convert.ToInt32(arrays_sr[1]);
                    z1 = Convert.ToDouble(arrays_sr[2]);
                    z2 = Convert.ToDouble(arrays_sr[3]);
                    color = Convert.ToInt32(arrays_sr[4]);
                    if (color != 0)
                        changecolor(color);
                    convert(lines, row, col, z1, z2);
                }
            }

            sr.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
