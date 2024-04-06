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
    class draw1 : Form
    {
        private System.ComponentModel.IContainer components = null;
        private Pen pen;
        private Pen pen1;
        private Graphics g;
        private System.Windows.Forms.Button exit;
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
        public draw1()
        {
            InitializeComponent();
            pen = new Pen(Color.Gold, 1);
            pen1 = new Pen(Color.Yellow, 1);
            // pen.DashStyle = DashStyle.Custom;
            //pen.DashPattern = new float[] { 4f, 40f };
            g = this.CreateGraphics();
        }

        private void InitializeComponent()
        {
            this.exit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // exit
            //
            this.exit.Location = new System.Drawing.Point(12, 12);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(75, 23);
            this.exit.TabIndex = 0;
            this.exit.Text = "exit";
            this.exit.UseVisualStyleBackColor = true;
            this.exit.Click += new System.EventHandler(this.button1_Click);
            //
            // draw1
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(2560, 720);
            this.Controls.Add(this.exit);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "draw1";
            this.Text = "draw1";
            this.Load += new System.EventHandler(this.calibration_Load);
            this.ResumeLayout(false);

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
            string folderPath = "..\\..\\dataset\\4_29\\";
            string fileName = "4_29";

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

    }
}
