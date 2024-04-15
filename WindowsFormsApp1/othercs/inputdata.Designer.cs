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
            label3 = new Label();
            comboBox1 = new ComboBox();
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
            panel1.BackColor = SystemColors.InfoText;
            panel1.Controls.Add(label3);
            panel1.Controls.Add(comboBox1);
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
            panel1.Location = new Point(91, 62);
            panel1.Margin = new Padding(5, 8, 5, 8);
            panel1.Name = "panel1";
            panel1.Size = new Size(400, 446);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = SystemColors.Control;
            label3.Location = new Point(20, 306);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new Size(105, 30);
            label3.TabIndex = 23;
            label3.Text = "camselect";
            label3.Click += label3_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(159, 302);
            comboBox1.Margin = new Padding(4, 4, 4, 4);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(200, 38);
            comboBox1.TabIndex = 2;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // widMov
            // 
            widMov.Location = new Point(284, 225);
            widMov.Margin = new Padding(5, 8, 5, 8);
            widMov.Name = "widMov";
            widMov.Size = new Size(73, 35);
            widMov.TabIndex = 22;
            widMov.Text = "1";
            widMov.TextChanged += textBox1_TextChanged_1;
            // 
            // widMovLabel
            // 
            widMovLabel.AutoSize = true;
            widMovLabel.ForeColor = SystemColors.Control;
            widMovLabel.Location = new Point(197, 232);
            widMovLabel.Margin = new Padding(5, 0, 5, 0);
            widMovLabel.Name = "widMovLabel";
            widMovLabel.Size = new Size(86, 30);
            widMovLabel.TabIndex = 21;
            widMovLabel.Text = "widMov";
            widMovLabel.Click += widMov_Click;
            // 
            // color
            // 
            color.Location = new Point(88, 225);
            color.Margin = new Padding(5, 8, 5, 8);
            color.Name = "color";
            color.Size = new Size(89, 35);
            color.TabIndex = 20;
            color.Text = "0";
            color.TextChanged += color_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = SystemColors.Control;
            label2.Location = new Point(12, 232);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(59, 30);
            label2.TabIndex = 19;
            label2.Text = "color";
            // 
            // z
            // 
            z.Location = new Point(44, 158);
            z.Margin = new Padding(5, 8, 5, 8);
            z.Name = "z";
            z.Size = new Size(135, 35);
            z.TabIndex = 18;
            z.Text = "1";
            z.TextChanged += textBox6_TextChanged;
            // 
            // zlabel
            // 
            zlabel.AutoSize = true;
            zlabel.ForeColor = SystemColors.Control;
            zlabel.Location = new Point(11, 165);
            zlabel.Margin = new Padding(5, 0, 5, 0);
            zlabel.Name = "zlabel";
            zlabel.Size = new Size(23, 30);
            zlabel.TabIndex = 17;
            zlabel.Text = "z";
            // 
            // exit
            // 
            exit.Location = new Point(13, 370);
            exit.Margin = new Padding(5, 8, 5, 8);
            exit.Name = "exit";
            exit.Size = new Size(116, 58);
            exit.TabIndex = 16;
            exit.Text = "exit";
            exit.UseVisualStyleBackColor = true;
            exit.Click += exit_Click;
            // 
            // col
            // 
            col.Location = new Point(267, 90);
            col.Margin = new Padding(5, 8, 5, 8);
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
            label1.Location = new Point(185, 94);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(75, 30);
            label1.TabIndex = 14;
            label1.Text = "colsize";
            // 
            // widCir
            // 
            widCir.Location = new Point(284, 158);
            widCir.Margin = new Padding(5, 8, 5, 8);
            widCir.Name = "widCir";
            widCir.Size = new Size(73, 35);
            widCir.TabIndex = 13;
            widCir.Text = "1";
            widCir.TextChanged += textBox4_TextChanged;
            // 
            // widCirLable
            // 
            widCirLable.AutoSize = true;
            widCirLable.ForeColor = SystemColors.Control;
            widCirLable.Location = new Point(197, 165);
            widCirLable.Margin = new Padding(5, 0, 5, 0);
            widCirLable.Name = "widCirLable";
            widCirLable.Size = new Size(70, 30);
            widCirLable.TabIndex = 12;
            widCirLable.Text = "widCir";
            // 
            // cancel
            // 
            cancel.Location = new Point(267, 370);
            cancel.Margin = new Padding(5, 8, 5, 8);
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
            save.Margin = new Padding(5, 8, 5, 8);
            save.Name = "save";
            save.Size = new Size(88, 58);
            save.TabIndex = 10;
            save.Text = "save";
            save.UseVisualStyleBackColor = true;
            save.Click += button5_Click;
            // 
            // row
            // 
            row.Location = new Point(267, 15);
            row.Margin = new Padding(5, 8, 5, 8);
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
            length.Location = new Point(185, 22);
            length.Margin = new Padding(5, 0, 5, 0);
            length.Name = "length";
            length.Size = new Size(82, 30);
            length.TabIndex = 6;
            length.Text = "rowsize";
            length.Click += length_Click;
            // 
            // y
            // 
            y.Location = new Point(44, 82);
            y.Margin = new Padding(5, 8, 5, 8);
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
            ylable.Margin = new Padding(5, 0, 5, 0);
            ylable.Name = "ylable";
            ylable.Size = new Size(23, 30);
            ylable.TabIndex = 4;
            ylable.Text = "y";
            // 
            // x
            // 
            x.Location = new Point(44, 15);
            x.Margin = new Padding(5, 8, 5, 8);
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
            xlabel.Location = new Point(11, 22);
            xlabel.Margin = new Padding(5, 0, 5, 0);
            xlabel.Name = "xlabel";
            xlabel.Size = new Size(23, 30);
            xlabel.TabIndex = 2;
            xlabel.Text = "x";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.InactiveBorder;
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(2560, 1102);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            pictureBox1.KeyDown += inputdata_KeyDown;
            pictureBox1.Click += inputdataClick;
            pictureBox1.MouseDoubleClick += inputdataMouseDoubleClick;
            pictureBox1.MouseMove += this.pictureBox1_MouseMove;
            pictureBox1.MouseUp += this.pictureBox1_MouseDown;
            // 
            // inputdata
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.MenuText;
            ClientSize = new Size(2560, 1102);
            Controls.Add(panel1);
            Controls.Add(pictureBox1);
            DoubleBuffered = true;
            KeyPreview = true;
            Margin = new Padding(5, 8, 5, 8);
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
        private Label label3;
        private ComboBox comboBox1;
    }
}