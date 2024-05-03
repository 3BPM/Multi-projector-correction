namespace WindowsFormsApp1.othercs
{
    partial class settingsForm
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
            textBox1 = new System.Windows.Forms.TextBox();
            textBox2 = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            button1 = new System.Windows.Forms.Button();
            button2 = new System.Windows.Forms.Button();
            buttonOK = new System.Windows.Forms.Button();
            SuspendLayout();
            //
            // textBox1
            //
            textBox1.Location = new System.Drawing.Point(268, 89);
            textBox1.Name = "textBox1";
            textBox1.Size = new System.Drawing.Size(397, 35);
            textBox1.TabIndex = 0;
            textBox1.TextChanged += textBox1_TextChanged;
            //
            // textBox2
            //
            textBox2.Location = new System.Drawing.Point(268, 163);
            textBox2.Name = "textBox2";
            textBox2.Size = new System.Drawing.Size(397, 35);
            textBox2.TabIndex = 1;
            textBox2.TextChanged += textBox2_TextChanged;
            //
            // label1
            //
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(30, 89);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(219, 30);
            label1.TabIndex = 2;
            label1.Text = "特征图像aruco码位置";
            label1.Click += label1_Click;
            //
            // label2
            //
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(30, 166);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(174, 30);
            label2.TabIndex = 3;
            label2.Text = "log文件保存位置";
            //
            // button1
            //
            button1.Location = new System.Drawing.Point(671, 89);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(131, 40);
            button1.TabIndex = 4;
            button1.Text = "位置";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            //
            // button2
            //
            button2.Location = new System.Drawing.Point(671, 156);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(131, 40);
            button2.TabIndex = 5;
            button2.Text = "位置";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            //
            // buttonOK
            //
            buttonOK.Location = new System.Drawing.Point(437, 385);
            buttonOK.Name = "buttonOK";
            buttonOK.Size = new System.Drawing.Size(131, 40);
            buttonOK.TabIndex = 6;
            buttonOK.Text = "确定";
            buttonOK.UseVisualStyleBackColor = true;
            buttonOK.Click += buttonOK_Click;
            //
            // settingsForm
            //
            AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(buttonOK);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Name = "settingsForm";
            Text = "settingsForm";
            Load += settingsForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button buttonOK;
    }
}