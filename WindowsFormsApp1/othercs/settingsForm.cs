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
            textBox1.Text = Properties.Settings.Default.图像位置_原aruco;
            textBox2.Text = Properties.Settings.Default.log文件保存位置;
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.图像位置_原aruco = textBox1.Text;
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
        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Application.StartupPath; // 初始目录
                openFileDialog.Filter = "Image files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png|All files (*.*)|*.*"; // 文件筛选器
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // 获取选中文件的路径
                    textBox1.Text = openFileDialog.FileName;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Application.StartupPath; // 初始目录

                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // 获取选中文件的路径
                    textBox2.Text = openFileDialog.FileName;
                }
            }
        }


        private void buttonOK_Click(object sender, EventArgs e)
        {
            // 这里可以添加保存设置的代码
            SaveSettings();  // 假设你有一个SaveSettings方法来处理设置的保存

            this.Close();  // 关闭窗口
        }

        // 假设的保存设置方法
        private void SaveSettings()
        {
            // 保存设置的逻辑
            // 例如，保存textBoxPath.Text到配置文件或数据库
            Console.WriteLine("设置已保存: " + textBox1.Text);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.log文件保存位置 = textBox4.Text;
            Properties.Settings.Default.Save();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.内接矩形图片 = textBox3.Text;
            Properties.Settings.Default.Save();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Application.StartupPath; // 初始目录

                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // 获取选中文件的路径
                    textBox3.Text = openFileDialog.FileName;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Application.StartupPath; // 初始目录

                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // 获取选中文件的路径
                    textBox4.Text = openFileDialog.FileName;
                }
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.锚点保存位置 = textBox4.Text;
            Properties.Settings.Default.Save();
        }
    }
}
