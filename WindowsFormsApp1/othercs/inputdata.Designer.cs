using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1.othercs
{
    partial class inputdata
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            widMov = new TextBox();
            widMovLabel = new Label();
            color = new TextBox();
            label2 = new Label();
            z = new TextBox();
            zlabel = new Label();
            exit = new Button();
            col = new TextBox();
            label1 = new Label();
            widCir = new TextBox();
            widCirLable = new Label();
            cancel = new Button();
            save = new Button();
            row = new TextBox();
            length = new Label();
            y = new TextBox();
            ylable = new Label();
            x = new TextBox();
            xlabel = new Label();
            pictureBox1 = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AllowDrop = true;
            panel1.Controls.Add(widMov);
            panel1.Controls.Add(widMovLabel);
            panel1.Controls.Add(color);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(z);
            panel1.Controls.Add(zlabel);
            panel1.Controls.Add(exit);
            panel1.Controls.Add(col);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(widCir);
            panel1.Controls.Add(widCirLable);
            panel1.Controls.Add(cancel);
            panel1.Controls.Add(save);
            panel1.Controls.Add(row);
            panel1.Controls.Add(length);
            panel1.Controls.Add(y);
            panel1.Controls.Add(ylable);
            panel1.Controls.Add(x);
            panel1.Controls.Add(xlabel);
            panel1.Location = new Point(90, 62);
            panel1.Margin = new Padding(6, 8, 6, 8);
            panel1.Name = "panel1";
            panel1.Size = new Size(400, 445);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // widMov
            // 
            widMov.Location = new Point(284, 225);
            widMov.Margin = new Padding(6, 8, 6, 8);
            widMov.Name = "widMov";
            widMov.Size = new Size(74, 35);
            widMov.TabIndex = 22;
            widMov.Text = "1";
            widMov.TextChanged += textBox1_TextChanged_1;
            // 
            // widMovLabel
            // 
            widMovLabel.AutoSize = true;
            widMovLabel.ForeColor = SystemColors.Control;
            widMovLabel.Location = new Point(198, 232);
            widMovLabel.Margin = new Padding(6, 0, 6, 0);
            widMovLabel.Name = "widMovLabel";
            widMovLabel.Size = new Size(86, 30);
            widMovLabel.TabIndex = 21;
            widMovLabel.Text = "widMov";
            widMovLabel.Click += widMov_Click;
            // 
            // color
            // 
            color.Location = new Point(88, 225);
            color.Margin = new Padding(6, 8, 6, 8);
            color.Name = "color";
            color.Size = new Size(90, 35);
            color.TabIndex = 20;
            color.Text = "0";
            color.TextChanged += color_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = SystemColors.Control;
            label2.Location = new Point(12, 232);
            label2.Margin = new Padding(6, 0, 6, 0);
            label2.Name = "label2";
            label2.Size = new Size(59, 30);
            label2.TabIndex = 19;
            label2.Text = "color";
            // 
            // z
            // 
            z.Location = new Point(44, 158);
            z.Margin = new Padding(6, 8, 6, 8);
            z.Name = "z";
            z.Size = new Size(134, 35);
            z.TabIndex = 18;
            z.Text = "1";
            z.TextChanged += textBox6_TextChanged;
            // 
            // zlabel
            // 
            zlabel.AutoSize = true;
            zlabel.ForeColor = SystemColors.Control;
            zlabel.Location = new Point(10, 165);
            zlabel.Margin = new Padding(6, 0, 6, 0);
            zlabel.Name = "zlabel";
            zlabel.Size = new Size(23, 30);
            zlabel.TabIndex = 17;
            zlabel.Text = "z";
            // 
            // exit
            // 
            exit.Location = new Point(14, 370);
            exit.Margin = new Padding(6, 8, 6, 8);
            exit.Name = "exit";
            exit.Size = new Size(116, 58);
            exit.TabIndex = 16;
            exit.Text = "exit";
            exit.UseVisualStyleBackColor = true;
            exit.Click += exit_Click;
            // 
            // col
            // 
            col.Location = new Point(266, 90);
            col.Margin = new Padding(6, 8, 6, 8);
            col.Name = "col";
            col.Size = new Size(92, 35);
            col.TabIndex = 15;
            col.Text = "0";
            col.TextChanged += col_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(198, 98);
            label1.Margin = new Padding(6, 0, 6, 0);
            label1.Name = "label1";
            label1.Size = new Size(40, 30);
            label1.TabIndex = 14;
            label1.Text = "col";
            // 
            // widCir
            // 
            widCir.Location = new Point(284, 158);
            widCir.Margin = new Padding(6, 8, 6, 8);
            widCir.Name = "widCir";
            widCir.Size = new Size(74, 35);
            widCir.TabIndex = 13;
            widCir.Text = "1";
            widCir.TextChanged += textBox4_TextChanged;
            // 
            // widCirLable
            // 
            widCirLable.AutoSize = true;
            widCirLable.ForeColor = SystemColors.Control;
            widCirLable.Location = new Point(198, 165);
            widCirLable.Margin = new Padding(6, 0, 6, 0);
            widCirLable.Name = "widCirLable";
            widCirLable.Size = new Size(70, 30);
            widCirLable.TabIndex = 12;
            widCirLable.Text = "widCir";
            // 
            // cancel
            // 
            cancel.Location = new Point(266, 370);
            cancel.Margin = new Padding(6, 8, 6, 8);
            cancel.Name = "cancel";
            cancel.Size = new Size(128, 58);
            cancel.TabIndex = 11;
            cancel.Text = "cancel";
            cancel.UseVisualStyleBackColor = true;
            cancel.Click += button6_Click;
            // 
            // save
            // 
            save.Location = new Point(156, 370);
            save.Margin = new Padding(6, 8, 6, 8);
            save.Name = "save";
            save.Size = new Size(88, 58);
            save.TabIndex = 10;
            save.Text = "save";
            save.UseVisualStyleBackColor = true;
            save.Click += button5_Click;
            // 
            // row
            // 
            row.Location = new Point(266, 15);
            row.Margin = new Padding(6, 8, 6, 8);
            row.Name = "row";
            row.Size = new Size(92, 35);
            row.TabIndex = 7;
            row.Text = "0";
            row.TextChanged += row_TextChanged;
            // 
            // length
            // 
            length.AutoSize = true;
            length.ForeColor = SystemColors.Control;
            length.Location = new Point(198, 22);
            length.Margin = new Padding(6, 0, 6, 0);
            length.Name = "length";
            length.Size = new Size(47, 30);
            length.TabIndex = 6;
            length.Text = "row";
            length.Click += length_Click;
            // 
            // y
            // 
            y.Location = new Point(44, 82);
            y.Margin = new Padding(6, 8, 6, 8);
            y.Name = "y";
            y.Size = new Size(136, 35);
            y.TabIndex = 5;
            y.Text = "0";
            y.TextChanged += textBox1_TextChanged;
            // 
            // ylable
            // 
            ylable.AutoSize = true;
            ylable.ForeColor = SystemColors.Control;
            ylable.Location = new Point(8, 90);
            ylable.Margin = new Padding(6, 0, 6, 0);
            ylable.Name = "ylable";
            ylable.Size = new Size(23, 30);
            ylable.TabIndex = 4;
            ylable.Text = "y";
            // 
            // x
            // 
            x.Location = new Point(44, 15);
            x.Margin = new Padding(6, 8, 6, 8);
            x.Name = "x";
            x.Size = new Size(136, 35);
            x.TabIndex = 3;
            x.Text = "0";
            x.TextChanged += textBox1_TextChanged;
            // 
            // xlabel
            // 
            xlabel.AutoSize = true;
            xlabel.ForeColor = SystemColors.Control;
            xlabel.Location = new Point(10, 22);
            xlabel.Margin = new Padding(6, 0, 6, 0);
            xlabel.Name = "xlabel";
            xlabel.Size = new Size(23, 30);
            xlabel.TabIndex = 2;
            xlabel.Text = "x";
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(2560, 1800);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // inputdata
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.MenuText;
            ClientSize = new Size(2560, 1800);
            Controls.Add(panel1);
            Controls.Add(pictureBox1);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            KeyPreview = true;
            Margin = new Padding(6, 8, 6, 8);
            Name = "inputdata";
            Text = "inputdata";
            Load += inputdata_Load_1;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox row;
        private System.Windows.Forms.Label length;
        private System.Windows.Forms.TextBox y;
        private System.Windows.Forms.Label ylable;
        private System.Windows.Forms.TextBox x;
        private System.Windows.Forms.Label xlabel;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.TextBox widCir;
        private System.Windows.Forms.Label widCirLable;
        private System.Windows.Forms.TextBox col;
        private System.Windows.Forms.Label label1;
        private Button exit;
        private TextBox z;
        private Label zlabel;
        private TextBox color;
        private Label label2;
        private TextBox widMov;
        private Label widMovLabel;
        private PictureBox pictureBox1;
    }
}