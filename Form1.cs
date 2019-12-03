﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace 仿照M3U8
{
    //1.定义委托
    public delegate void DelReadStdOutput(string result);
    public delegate void DelReadErrOutput(string result);
    public partial class Form1 : Form
    {
        //2.定义委托事件
        public event DelReadStdOutput ReadStdOutput;
        public event DelReadErrOutput ReadErrOutput;

        public Form1()
        {
            InitializeComponent();
            Init();
        }
        private void Init()
        {
            //3.将相应函数注册到委托事件中
            ReadStdOutput += new DelReadStdOutput(ReadStdOutputAction);    //这里相当于重载了该函数
            ReadErrOutput += new DelReadErrOutput(ReadErrOutputAction);            
        }

 
        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)    //下载按钮
        {
            if (!Directory.Exists(@"download"))              //所有下载的文件都存放在当前目录下的download文件夹
            {
                Directory.CreateDirectory("download");           //创建download文件夹
            }
            var currentFilePath = Directory.GetCurrentDirectory() + @"\download";
            string houzhui="";
            if (radioButton1.Checked == true) { houzhui = "flv"; }
            else if (radioButton2.Checked == true) { houzhui = "mp4"; }
            else if (radioButton3.Checked == true) { houzhui = "mkv"; }
            else if (radioButton4.Checked == true) { houzhui = "ts"; }

            var order = "-threads 0 -i " + "\"" + textBox_Address.Text + "\"" + " -c copy -y -bsf:a aac_adtstoasc -movflags +faststart" + " \"" + currentFilePath + "\\"+textBox_Name.Text + "." + houzhui;
            RealAction(@"Tools\ffmpeg.exe", order);
        }
        private void RealAction(string StartFileName, string StartFileArg)
        {
            Process CmdProcess = new Process();        //需要引入 System.Diagnostics;
            CmdProcess.StartInfo.FileName = StartFileName;   //需要执行的程序
            CmdProcess.StartInfo.Arguments = StartFileArg;   //命令
            CmdProcess.StartInfo.CreateNoWindow = true;         // 不创建新窗口
            CmdProcess.StartInfo.UseShellExecute = false;
            CmdProcess.StartInfo.RedirectStandardInput = true;  // 重定向输入
            CmdProcess.StartInfo.RedirectStandardOutput = true; // 重定向标准输出
            CmdProcess.StartInfo.RedirectStandardError = true;  // 重定向错误输出
            //CmdProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

            CmdProcess.OutputDataReceived += new DataReceivedEventHandler(p_OutputDataReceived);
            CmdProcess.ErrorDataReceived += new DataReceivedEventHandler(p_ErrorDataReceived);

            CmdProcess.EnableRaisingEvents = true;                      // 启用Exited事件
            CmdProcess.Exited += new EventHandler(CmdProcess_Exited);   // 注册进程结束事件

            CmdProcess.Start();
            CmdProcess.BeginOutputReadLine();
            CmdProcess.BeginErrorReadLine();


        }
        private void p_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data != null)
            {
                //4.异步调用 需要invke
                this.Invoke(ReadStdOutput, new object[] { e.Data });
            }
        }
        private void p_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data != null)
            {
                //4.异步调用 需要invoke
                this.Invoke(ReadStdOutput, new object[] { e.Data });
            }
        }
        private void ReadStdOutputAction(string result)
        {
            textBox_Information.AppendText(result + "\r\n");
        }
        private void ReadErrOutputAction(string result)
        {
            textBox_Information.AppendText(result + "\r\n");
        }
        private void CmdProcess_Exited(object sender, EventArgs e)
        {
            MessageBox.Show("执行结束");                //这里一旦ffmpeg 执行结束后 就会自动调用这个事件
        }
        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //首先看看有没有ffmpeg这个程序
            if (!File.Exists(@"tools\ffmpeg.exe"))
            {
                MessageBox.Show("在当前tool目录下面没有找到ffmpeg 请加载", "错误显示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Dispose();
                Application.Exit();

            }
            else    //如果文件存在 那么就要获取当前下载路径 并显示
            {
                textBox_Download_Adress.Text = Directory.GetCurrentDirectory()+@"\download";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();  //只对主线程有效 当有其他线程的时候会失效
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_Download_Adress_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox_Information_TextChanged(object sender, EventArgs e)
        {
            if (textBox_Information.Lines.GetUpperBound(0) > 5)
            {
                textBox_Information.ScrollBars = ScrollBars.Vertical;
            }
            //文本格式是: Duration: 00:45:22.56, start: 1.400000, bitrate: 0 kb/s  总时长是这个
            Regex duration = new Regex(@"Duration: (\d{2}[.:]){3}\d{2}");
            //label_TotalTime.Text = "[总时长: "+duration.Matches(textBox_Information.Text).Value
            var totalTime = duration.Matches(textBox_Information.Text);
            double totalTimes = 0;
            if (totalTime.Count > 0)
            {
                var temp1 = totalTime.OfType<Match>().Last().Value.Replace("Duration: ", "");


                totalTimes = (Convert.ToDouble(temp1.Substring(0, 2)))*3600+ (Convert.ToDouble(temp1.Substring(3, 2)) )* 60+ (Convert.ToDouble(temp1.Substring(6, 2)))+Convert.ToDouble(temp1.Substring(9, 2))/100;

                label_TotalTime.Text = "总时长: [" + totalTime.OfType<Match>().Last().Value.Replace("Duration: ", "")+" ]";
                //totalTimes = totalTime.OfType<Match>().Last().Value.Replace("Duration: ", "")
            }

            //原格式：frame= 8776 fps=1194 q=-1.0 Lsize=   20341kB time=00:05:51.09 bitrate= 474.6kbits/s speed=47.8x 

            Regex fenbianlv = new Regex(@"\d{2,}x\d{2,}");
            label_Fenbianlv.Text ="分辨率:["+ fenbianlv.Match(textBox_Information.Text).Value+" ]";

            Regex DownloadedTime = new Regex(@"time=(\d{2}[.:]){3}\d{2}");
            var hadDownloadedTime = DownloadedTime.Matches(textBox_Information.Text);

            Regex DownloadedSize = new Regex(@"(\d+)kB time");
            var hadDownloadedSize = DownloadedSize.Matches(textBox_Information.Text);
            double hadDownload = 0;
            if (hadDownloadedTime.Count > 0 & hadDownloadedSize.Count>0)
            {
                var temp2 = hadDownloadedTime.OfType<Match>().Last().Value.Replace("time=", "");
                hadDownload = (Convert.ToDouble(temp2.Substring(0, 2))) * 3600 + (Convert.ToDouble(temp2.Substring(3, 2))) * 60 + Convert.ToDouble(temp2.Substring(6, 2)) + Convert.ToDouble(temp2.Substring(9, 2))/100;
                label_Downloaded.Text = "已下载: [" + hadDownloadedTime.OfType<Match>().Last().Value.Replace("time=", "")+" "+ hadDownloadedSize.OfType<Match>().Last().Value.Replace(@"kB time", "") + " ]";
                label_Process.Text = "已完成: [" +String.Format("{0:F}", hadDownload/totalTimes) +"%]";

            }

            Regex process = new Regex(@"(Lsize=\s+)(\d+)");
            var hadProcess = process.Matches(textBox_Information.Text);



        }
    }
}
