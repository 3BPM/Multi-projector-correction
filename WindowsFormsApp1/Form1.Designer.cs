

namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>



        private void InitializeComponent()
        {
            button1 = new System.Windows.Forms.Button();
            button2 = new System.Windows.Forms.Button();
            button3 = new System.Windows.Forms.Button();
            button4 = new System.Windows.Forms.Button();
            button5 = new System.Windows.Forms.Button();
            settingsbutton = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            button1.Location = new System.Drawing.Point(46, 100);
            button1.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(150, 58);
            button1.TabIndex = 0;
            button1.Text = "找点";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new System.Drawing.Point(46, 202);
            button2.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(150, 58);
            button2.TabIndex = 1;
            button2.Text = "gray码拍摄";
            button2.UseVisualStyleBackColor = true;
            button2.Click += gray_Click;
            // 
            // button3
            // 
            button3.BackColor = System.Drawing.SystemColors.GrayText;
            button3.Location = new System.Drawing.Point(46, 307);
            button3.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            button3.Name = "button3";
            button3.Size = new System.Drawing.Size(150, 58);
            button3.TabIndex = 2;
            button3.Text = "目标图像生成";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new System.Drawing.Point(0, 0);
            button4.Name = "button4";
            button4.Size = new System.Drawing.Size(75, 23);
            button4.TabIndex = 0;
            // 
            // button5
            // 
            button5.Location = new System.Drawing.Point(56, 410);
            button5.Name = "button5";
            button5.Size = new System.Drawing.Size(131, 40);
            button5.TabIndex = 3;
            button5.Text = "videocap";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // settingsbutton
            // 
            settingsbutton.Location = new System.Drawing.Point(370, 547);
            settingsbutton.Name = "settingsbutton";
            settingsbutton.Size = new System.Drawing.Size(131, 40);
            settingsbutton.TabIndex = 4;
            settingsbutton.Text = "设置";
            settingsbutton.UseVisualStyleBackColor = true;
            settingsbutton.Click += settingsbutton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(568, 652);
            Controls.Add(settingsbutton);
            Controls.Add(button5);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            Name = "Form1";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "3D reconstruction";
            Load += Form1_Load;
            ResumeLayout(false);
        }
        #endregion

        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button settingsbutton;
    }
}

