namespace 仿照M3U8
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.label_Process = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_Address = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_Name = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_Download_Adress = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button_Download = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.label_Fenbianlv = new System.Windows.Forms.Label();
            this.label_TotalTime = new System.Windows.Forms.Label();
            this.label_Downloaded = new System.Windows.Forms.Label();
            this.textBox_Information = new System.Windows.Forms.TextBox();
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.label11 = new System.Windows.Forms.Label();
            this.label_DownloadSpeed = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.button_About = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "M3U8 Downloader";
            // 
            // label_Process
            // 
            this.label_Process.AutoSize = true;
            this.label_Process.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Process.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.label_Process.Location = new System.Drawing.Point(261, 9);
            this.label_Process.Name = "label_Process";
            this.label_Process.Size = new System.Drawing.Size(58, 21);
            this.label_Process.TabIndex = 1;
            this.label_Process.Text = "已完成";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(768, -5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "MIN";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Red;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(840, -4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "EXIT";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label4.Location = new System.Drawing.Point(13, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "拖拽或键入地址";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_Address
            // 
            this.textBox_Address.AllowDrop = true;
            this.textBox_Address.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.textBox_Address.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_Address.ForeColor = System.Drawing.Color.White;
            this.textBox_Address.Location = new System.Drawing.Point(12, 64);
            this.textBox_Address.Multiline = true;
            this.textBox_Address.Name = "textBox_Address";
            this.textBox_Address.Size = new System.Drawing.Size(258, 85);
            this.textBox_Address.TabIndex = 6;
            this.textBox_Address.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox_Address.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBox_Address_DragDrop);
            this.textBox_Address.DragEnter += new System.Windows.Forms.DragEventHandler(this.textBox_Address_DragEnter);
            this.textBox_Address.DragOver += new System.Windows.Forms.DragEventHandler(this.textBox_Address_DragOver);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label5.Location = new System.Drawing.Point(12, 154);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 17);
            this.label5.TabIndex = 7;
            this.label5.Text = "存储的后缀";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_Name
            // 
            this.textBox_Name.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.textBox_Name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_Name.ForeColor = System.Drawing.Color.White;
            this.textBox_Name.Location = new System.Drawing.Point(108, 183);
            this.textBox_Name.Name = "textBox_Name";
            this.textBox_Name.Size = new System.Drawing.Size(162, 21);
            this.textBox_Name.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label6.Location = new System.Drawing.Point(13, 207);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 17);
            this.label6.TabIndex = 9;
            this.label6.Text = "下载路径";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // textBox_Download_Adress
            // 
            this.textBox_Download_Adress.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.textBox_Download_Adress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_Download_Adress.ForeColor = System.Drawing.Color.White;
            this.textBox_Download_Adress.Location = new System.Drawing.Point(12, 227);
            this.textBox_Download_Adress.Multiline = true;
            this.textBox_Download_Adress.Name = "textBox_Download_Adress";
            this.textBox_Download_Adress.Size = new System.Drawing.Size(258, 65);
            this.textBox_Download_Adress.TabIndex = 10;
            this.textBox_Download_Adress.TextChanged += new System.EventHandler(this.textBox_Download_Adress_TextChanged);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Green;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.Color.Black;
            this.button3.Location = new System.Drawing.Point(12, 314);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(92, 40);
            this.button3.TabIndex = 11;
            this.button3.Text = "更改下载路径";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Green;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(172, 314);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(98, 40);
            this.button4.TabIndex = 12;
            this.button4.Text = "打开下载路径";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button_Download
            // 
            this.button_Download.BackColor = System.Drawing.Color.Green;
            this.button_Download.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Download.Location = new System.Drawing.Point(16, 372);
            this.button_Download.Name = "button_Download";
            this.button_Download.Size = new System.Drawing.Size(88, 47);
            this.button_Download.TabIndex = 13;
            this.button_Download.Text = "下载";
            this.button_Download.UseVisualStyleBackColor = false;
            this.button_Download.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.Green;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Location = new System.Drawing.Point(172, 372);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(98, 47);
            this.button6.TabIndex = 14;
            this.button6.Text = "退出";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // label_Fenbianlv
            // 
            this.label_Fenbianlv.AutoSize = true;
            this.label_Fenbianlv.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Fenbianlv.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label_Fenbianlv.Location = new System.Drawing.Point(287, 44);
            this.label_Fenbianlv.Name = "label_Fenbianlv";
            this.label_Fenbianlv.Size = new System.Drawing.Size(44, 17);
            this.label_Fenbianlv.TabIndex = 16;
            this.label_Fenbianlv.Text = "分辨率";
            this.label_Fenbianlv.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_TotalTime
            // 
            this.label_TotalTime.AutoSize = true;
            this.label_TotalTime.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_TotalTime.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label_TotalTime.Location = new System.Drawing.Point(402, 44);
            this.label_TotalTime.Name = "label_TotalTime";
            this.label_TotalTime.Size = new System.Drawing.Size(44, 17);
            this.label_TotalTime.TabIndex = 17;
            this.label_TotalTime.Text = "总时长";
            this.label_TotalTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Downloaded
            // 
            this.label_Downloaded.AutoSize = true;
            this.label_Downloaded.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Downloaded.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label_Downloaded.Location = new System.Drawing.Point(565, 44);
            this.label_Downloaded.Name = "label_Downloaded";
            this.label_Downloaded.Size = new System.Drawing.Size(44, 17);
            this.label_Downloaded.TabIndex = 18;
            this.label_Downloaded.Text = "已下载";
            this.label_Downloaded.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_Downloaded.Click += new System.EventHandler(this.label10_Click);
            // 
            // textBox_Information
            // 
            this.textBox_Information.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.textBox_Information.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_Information.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.textBox_Information.Location = new System.Drawing.Point(290, 64);
            this.textBox_Information.Multiline = true;
            this.textBox_Information.Name = "textBox_Information";
            this.textBox_Information.Size = new System.Drawing.Size(591, 336);
            this.textBox_Information.TabIndex = 19;
            this.textBox_Information.Text = "下载信息在这里进行显示";
            this.textBox_Information.TextChanged += new System.EventHandler(this.textBox_Information_TextChanged);
            // 
            // ProgressBar
            // 
            this.ProgressBar.BackColor = System.Drawing.SystemColors.ControlText;
            this.ProgressBar.Location = new System.Drawing.Point(290, 406);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(591, 23);
            this.ProgressBar.TabIndex = 20;
            this.ProgressBar.Click += new System.EventHandler(this.ProgressBar_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.ForeColor = System.Drawing.Color.LightGray;
            this.radioButton1.Location = new System.Drawing.Point(108, 155);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(41, 16);
            this.radioButton1.TabIndex = 21;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "FLV";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.ForeColor = System.Drawing.Color.LightGray;
            this.radioButton2.Location = new System.Drawing.Point(151, 155);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(41, 16);
            this.radioButton2.TabIndex = 22;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "MP4";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.ForeColor = System.Drawing.Color.LightGray;
            this.radioButton3.Location = new System.Drawing.Point(198, 155);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(41, 16);
            this.radioButton3.TabIndex = 23;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "MKV";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.ForeColor = System.Drawing.Color.LightGray;
            this.radioButton4.Location = new System.Drawing.Point(238, 155);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(35, 16);
            this.radioButton4.TabIndex = 24;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "TS";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label11.Location = new System.Drawing.Point(9, 183);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(80, 17);
            this.label11.TabIndex = 25;
            this.label11.Text = "存储的文件名";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_DownloadSpeed
            // 
            this.label_DownloadSpeed.AutoSize = true;
            this.label_DownloadSpeed.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_DownloadSpeed.ForeColor = System.Drawing.Color.Red;
            this.label_DownloadSpeed.Location = new System.Drawing.Point(739, 44);
            this.label_DownloadSpeed.Name = "label_DownloadSpeed";
            this.label_DownloadSpeed.Size = new System.Drawing.Size(32, 17);
            this.label_DownloadSpeed.TabIndex = 26;
            this.label_DownloadSpeed.Text = "速度";
            this.label_DownloadSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_DownloadSpeed.Click += new System.EventHandler(this.label_DownloadSpeed_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // button_About
            // 
            this.button_About.BackColor = System.Drawing.SystemColors.GrayText;
            this.button_About.FlatAppearance.BorderSize = 0;
            this.button_About.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_About.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_About.ForeColor = System.Drawing.Color.White;
            this.button_About.Location = new System.Drawing.Point(696, -4);
            this.button_About.Name = "button_About";
            this.button_About.Size = new System.Drawing.Size(75, 23);
            this.button_About.TabIndex = 27;
            this.button_About.Text = "About";
            this.button_About.UseVisualStyleBackColor = false;
            this.button_About.Click += new System.EventHandler(this.button_About_Click);
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.HelpRequest += new System.EventHandler(this.folderBrowserDialog1_HelpRequest);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(914, 450);
            this.Controls.Add(this.button_About);
            this.Controls.Add(this.label_DownloadSpeed);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.radioButton4);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.ProgressBar);
            this.Controls.Add(this.textBox_Information);
            this.Controls.Add(this.label_Downloaded);
            this.Controls.Add(this.label_TotalTime);
            this.Controls.Add(this.label_Fenbianlv);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button_Download);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.textBox_Download_Adress);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox_Name);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox_Address);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label_Process);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_Process;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_Address;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_Name;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_Download_Adress;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button_Download;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label_Fenbianlv;
        private System.Windows.Forms.Label label_TotalTime;
        private System.Windows.Forms.Label label_Downloaded;
        private System.Windows.Forms.TextBox textBox_Information;
        private System.Windows.Forms.ProgressBar ProgressBar;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label_DownloadSpeed;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Button button_About;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}

