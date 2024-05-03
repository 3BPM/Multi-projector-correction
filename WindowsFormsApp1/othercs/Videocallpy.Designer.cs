using AForge.Video.DirectShow;
using System.Drawing;

namespace WindowsFormsApp1.othercs
{
    partial class Videocallpy
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


        #endregion
        private void InitializeComponent()
        {
            videoSourcePlayer1 = new AForge.Controls.VideoSourcePlayer();
            button1 = new System.Windows.Forms.Button();
            button2 = new System.Windows.Forms.Button();
            button3 = new System.Windows.Forms.Button();
            comboBox1 = new System.Windows.Forms.ComboBox();
            button4 = new System.Windows.Forms.Button();
            button5 = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // videoSourcePlayer1
            // 
            videoSourcePlayer1.Location = new Point(62, 180);
            videoSourcePlayer1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            videoSourcePlayer1.Name = "videoSourcePlayer1";
            videoSourcePlayer1.Size = new Size(1398, 1142);
            videoSourcePlayer1.TabIndex = 7;
            videoSourcePlayer1.Text = "videoSourcePlayer1";
            videoSourcePlayer1.VideoSource = null;
            videoSourcePlayer1.Click += videoSourcePlayer1_Click;
            // 
            // button1
            // 
            button1.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(1056, 44);
            button1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            button1.Name = "button1";
            button1.Size = new Size(216, 94);
            button1.TabIndex = 8;
            button1.Text = "关闭摄像头";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button2.Location = new Point(546, 44);
            button2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            button2.Name = "button2";
            button2.Size = new Size(216, 94);
            button2.TabIndex = 9;
            button2.Text = "拍照";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button3.Location = new Point(801, 44);
            button3.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            button3.Name = "button3";
            button3.Size = new Size(216, 94);
            button3.TabIndex = 10;
            button3.Text = "保存图片";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // comboBox1
            // 
            comboBox1.DropDownHeight = 100;
            comboBox1.FormattingEnabled = true;
            comboBox1.IntegralHeight = false;
            comboBox1.ItemHeight = 30;
            comboBox1.Location = new Point(1311, 74);
            comboBox1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(180, 38);
            comboBox1.TabIndex = 11;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // button4
            // 
            button4.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button4.Location = new Point(36, 44);
            button4.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            button4.Name = "button4";
            button4.Size = new Size(216, 94);
            button4.TabIndex = 12;
            button4.Text = "人脸识别";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button5.Location = new Point(291, 44);
            button5.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            button5.Name = "button5";
            button5.Size = new Size(216, 94);
            button5.TabIndex = 13;
            button5.Text = "实时扫描";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // Videocallpy
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new Size(1518, 1346);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(comboBox1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(videoSourcePlayer1);
            Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            Name = "Videocallpy";
            Text = "video";
            ResumeLayout(false);
        }

        private AForge.Controls.VideoSourcePlayer videoSourcePlayer1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;

        FilterInfoCollection videoDevices;//摄像头设备集合
        VideoCaptureDevice videoSource;//捕获设备源
        Bitmap img;//处理图片

    }
}