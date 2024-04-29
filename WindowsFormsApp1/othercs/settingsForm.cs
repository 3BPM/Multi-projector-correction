using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Properties;
namespace WindowsFormsApp1.othercs
{
    public partial class settingsForm : Form
    {
        public settingsForm()
        {
            InitializeComponent();

            // 显示当前设置
            textBox1.Text = Properties.Settings.Default.特征图像aruco码位置;
            textBox2.Text = Properties.Settings.Default.log文件保存位置;
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.特征图像aruco码位置 = textBox1.Text;
            Properties.Settings.Default.Save();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.log文件保存位置 = textBox2.Text;
            Properties.Settings.Default.Save();
        }

        private void settingsForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
