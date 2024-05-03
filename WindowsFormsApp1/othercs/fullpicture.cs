using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.othercs
{
    public partial class fullpicture : Form
    {
        public fullpicture()
        {
            InitializeComponent();


            // 设置窗体为全屏
            this.WindowState = FormWindowState.Maximized; // 最大化窗体
            this.FormBorderStyle = FormBorderStyle.None;   // 无边框
            this.TopMost = true;                          // 窗体在最顶层

            // 显示图片
            ShowFullScreenImage("path_to_your_image.jpg");
        }

        private void ShowFullScreenImage(string imagePath)
        {
            PictureBox pictureBox = new PictureBox
            {
                Image = Image.FromFile(imagePath),
                Dock = DockStyle.Fill,
                SizeMode = PictureBoxSizeMode.StretchImage  // 或使用 PictureBoxSizeMode.Zoom 保持图片比例
            };
            this.Controls.Add(pictureBox);
        }

        private void fullpicture_Load(object sender, EventArgs e)
        {

        }
    }
}
