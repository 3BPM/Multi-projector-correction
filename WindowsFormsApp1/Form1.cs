using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using WindowsFormsApp1.othercs;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            Application.Exit();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form fm = new inputdata();
            fm.Owner = this;
            fm.StartPosition = FormStartPosition.CenterScreen;
            if (!fm.IsDisposed)
                fm.ShowDialog(this);
            else
                Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form pic1 = new draw1();

            pic1.Owner = this;
            pic1.StartPosition = FormStartPosition.CenterScreen;
            this.Hide();
            if (!pic1.IsDisposed)
            {
                pic1.ShowDialog(this);
            }
            else
                Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form calib = new calibration();
            calib.Owner = this;
            calib.StartPosition = FormStartPosition.CenterScreen;
            if (!calib.IsDisposed)
                calib.ShowDialog(this);
            else
                Application.Exit();
        }

     
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
