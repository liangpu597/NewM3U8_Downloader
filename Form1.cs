using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Microsoft.WindowsAPICodePack.Taskbar;
using Microsoft.WindowsAPICodePack.Shell;
using System.Runtime.InteropServices;

namespace 仿照M3U8
{

    //1.定义委托
    public delegate void DelReadStdOutput(string result);
    public delegate void DelReadErrOutput(string result);
    public partial class Form1 : Form
    {
        Double before = 0, now = 0;           //定义两个全局变量 在两个计时器中存储对应的下载文件大小 从而计算出下载速度
        int ffmpeg = -1;                      //由于是多进程 将当前进程的id给它 到时候关闭的时候可以通过这个杀死对应的进程id
        private TaskbarManager windowsTaskbar = TaskbarManager.Instance;         //任务栏进度条
        //2.定义委托事件
        public event DelReadStdOutput ReadStdOutput;
        public event DelReadErrOutput ReadErrOutput;
        public Form1()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            InitializeComponent();
            Init();
        }
        private void Init()
        {
            //3.将相应函数注册到委托事件中
            ReadStdOutput += new DelReadStdOutput(ReadStdOutputAction);    //这里相当于重载了该函数
            ReadErrOutput += new DelReadErrOutput(ReadErrOutputAction);            
        }
        protected override void WndProc(ref Message m)    //让窗口可以移动
        {
            switch (m.Msg)
            {
                case 0x4e:
                case 0xd:
                case 0xe:
                case 0x14:
                    base.WndProc(ref m);
                    break;
                case 0x84://鼠标点任意位置后可以拖动窗体
                    this.DefWndProc(ref m);
                    if (m.Result.ToInt32() == 0x01)
                    {
                        m.Result = new IntPtr(0x02);
                    }
                    break;
                case 0xA3://禁止双击最大化
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }
        private void label6_Click(object sender, EventArgs e)
        {}
        private void button5_Click(object sender, EventArgs e)    //下载按钮
        {
            if (!Directory.Exists(@"download"))              //所有下载的文件都存放在当前目录下的download文件夹
            {
                Directory.CreateDirectory("download");           //创建download文件夹
            }
            textBox_Information.Text = "";
            label_Fenbianlv.Visible = true;
            label_TotalTime.Visible = true;
            label_DownloadSpeed.Visible = true;
            label_Downloaded.Visible = true;
            label_Process.Visible = true;
            ProgressBar.Visible = true;
            var currentFilePath = Directory.GetCurrentDirectory() + @"\download";
            string houzhui="";
            if (radioButton1.Checked == true) { houzhui = "flv"; }
            else if (radioButton2.Checked == true) { houzhui = "mp4"; }
            else if (radioButton3.Checked == true) { houzhui = "mkv"; }
            else if (radioButton4.Checked == true) { houzhui = "ts"; }

            timer1.Enabled = true;
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
            ffmpeg = CmdProcess.Id;                 //因为是多线程 所以 主线程关了的话可能其他的线程还是没有关闭
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
            timer1.Enabled = false;
            timer2.Enabled = false;
            MessageBox.Show("执行结束");                //这里一旦ffmpeg 执行结束后 就会自动调用这个事件
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Process.Start(textBox_Download_Adress.Text);           //打开特定的文件夹
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
            label_Fenbianlv.Visible = false;
            label_TotalTime.Visible = false;
            label_DownloadSpeed.Visible = false;
            label_Downloaded.Visible = false;
            label_Process.Visible = false;
            ProgressBar.Visible = false;  
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try {
                if (Process.GetProcessById(ffmpeg) != null)
                {
                    Process.GetProcessById(ffmpeg).Kill();
                    Dispose();
                    Application.Exit();
                }   
            }
            catch {   //在杀不死进程的时候 直接强行关闭
                Dispose();
                Application.Exit();
            }
            //Application.Exit();  //只对主线程有效 当有其他线程的时候会失效
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
                label_Downloaded.Text = "已下载:[" + hadDownloadedTime.OfType<Match>().Last().Value.Replace("time=", "")+" "+ FormatFileSize((Convert.ToDouble(hadDownloadedSize.OfType<Match>().Last().Value.Replace(@"kB time", ""))) ) + "]";
                label_Process.Text = "已完成:[" +String.Format("{0:F}", (hadDownload/totalTimes)*100) +"%]";
                Double Progress = (hadDownload / totalTimes) * 100;
                ProgressBar.Value = Convert.ToInt32(Progress);            //注意 ： 这里 ProgressBar是图中控件的名字而已  但是只要这样写了 系统就可以自动进行调用了 进行自动显示进度条了
                windowsTaskbar.SetProgressValue(Convert.ToInt32(Progress), 100, this.Handle);       //这样一写 在任务进度栏里面也有了
            }   
        }
        private static String FormatFileSize(double filesize)      //此程序最大可以计算到GB 其他的不能再进行计算了
        {
            //MessageBox.Show(Convert.ToString(filesize));
            if (filesize < 0)
            {
                throw new ArgumentOutOfRangeException("filesize");
            }
            //else if (filesize >= 1024 * 1024*1024 && filesize < 1024 * 1024 * 1024*1024)    //这里不能再进行乘了 会显示溢出
            //{
            //    return string.Format("{0:0.00} GB", (double)filesize / (1024 * 1024));
            //}
            else if (filesize >= 1024 * 1024 && filesize < 1024 * 1024 * 1024) //文件大小大于或等于1024MB  
            {
                return string.Format("{0:0.00} GB", filesize / (1024 * 1024));
            }
            else if (filesize >= 1024 && filesize < 1024 * 1024) //文件大小大于或等于1024KB  
            {
                return string.Format("{0:0.00} MB", filesize / 1024);
            }
            else if (filesize >= 0 && filesize < 1024) //文件大小大于等于1024bytes  
            {
                return string.Format("{0:0.00} KB", filesize);
            }
            else    //这个else必须要加上 如果不加上的话 会显示： 并非所有的代码路径都有返回值的说法
            {
                return string.Format("{0:0.00} bytes", filesize);
            }
        }
        private void ProgressBar_Click(object sender, EventArgs e)
        {}
        private void timer1_Tick(object sender, EventArgs e)
        {
            ////label_DownloadSpeed;
            Regex process = new Regex(@"(size=\s+)(\d+)");
            var hadProcess = process.Matches(textBox_Information.Text);
            if (hadProcess.Count > 0)
            {
                var temp = hadProcess.OfType<Match>().Last().Value;
                now = Convert.ToDouble( Regex.Replace(temp, @"(size=\s+)(\d+)", "$2"));

                //label_DownloadSpeed.Text= hadProcess.OfType<Match>().Last().Value.Replace(@"(size=\s+)(\d+)", "$2");
                // MessageBox.Show(temp);
                label_DownloadSpeed.Text = "下载速度:[" + FormatFileSize((now-before)/1000) + "/s]";
                //这里为什么会需要除以1000 如果不除以1000的出来的不是这么多
                //这里显示的是11211 但是好像不对
                //MessageBox.Show(Convert.ToString(now - before));
            }
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            before = now;
        }
        private void button_About_Click(object sender, EventArgs e)
        {
            MessageBox.Show("V1.0 BY 蒲良\n2019-11", "关于");
        }
        private void button3_Click(object sender, EventArgs e)
        {
            //OpenFileDialog openFileDialog1 = new OpenFileDialog();
            //if (openFileDialog1.ShowDialog() == DialogResult.OK)
            //{
            //    textBox_Download_Adress.Text = openFileDialog1.FileName;
            //}
            //FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)      //这里必须要先拖一个folderBrowserDialog控件才可以 不可以直接写一个new  注意这里与前面的打开文件夹的不一样
            {
                textBox_Download_Adress.Text = folderBrowserDialog1.SelectedPath;
            }
        }
        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {}
        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (Process.GetProcessById(ffmpeg) != null)
                {
                    Process.GetProcessById(ffmpeg).Kill();
                    Dispose();
                    Application.Exit();
                }
            }
            catch
            {   //在杀不死进程的时候 直接强行关闭
                Dispose();
                Application.Exit();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void textBox_Address_DragEnter(object sender, DragEventArgs e)        //光这样写还不行 还需要设置textbox的ALLOWDORP = true
        {
            e.Effect = DragDropEffects.All;
        }
        private void textBox_Address_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }
        private void textBox_Address_DragDrop(object sender, DragEventArgs e)         //但是经过测试 发现下载的.m3u8文件里面根本没有地址 不但不能播放 而且使用ffmpeg也不能进行下载
        {
            var fileNames = (string[])e.Data.GetData(DataFormats.FileDrop);
            e.Effect = DragDropEffects.All;
            textBox_Address.Text = fileNames[0];
        }
        private void label_DownloadSpeed_Click(object sender, EventArgs e)
        {}
    }
}
