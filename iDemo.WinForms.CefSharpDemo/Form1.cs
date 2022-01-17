using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CefSharp.WinForms;


namespace iDemo.WinForms.CefSharpDemo
{
    public partial class Form1 : Form
    {
        private const string address1 = "www.baidu.com";
        // 网页加载时间 3775.4063
        private const string address2 = "https://course-fore.huijiaoyun.com/index.html#/bookDetail?platformcode=420000&ptoken=1313168B621EAA6252F968FAD0A891ED30BD85142E7A22A7507718E00501AFA1D0E471F4EE8FC822F072DB71112EF5B4CBD743B96B2B494BBB42124C58CAD21706EBCAC48E2717ADD083DB93C00DF795F7F33596E538E44B9D51880C9343C8C660728B6503337A1B3A555AB65B5CA09D4E3B0FD63278C800546CCC359A65D771&isWeb=pcm&loginPlatformCode=888888&authPlatformCode=&subjectId=jcsub01&periodId=cz&orgName=%e5%8d%8e%e4%b8%ad%e7%a7%91%e6%8a%80%e5%a4%a7%e5%ad%a6%e9%99%84%e5%b1%9e%e4%b8%ad%e5%ad%a6&bookId=10001240";
        // 网页加载时间 11 毫秒
        private const string address3 = "https://www.cnblogs.com/";
        private readonly ChromiumWebBrowser browser = new ChromiumWebBrowser(address3);
        private readonly Stopwatch stopwatch= new Stopwatch();

        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            browser.Dock = DockStyle.Fill;
            browser.FrameLoadStart += Browser_FrameLoadStart;
            browser.FrameLoadEnd += Browser_FrameLoadEnd;
            panel1.Controls.Add(browser);
        }

        private void Browser_FrameLoadEnd(object sender, CefSharp.FrameLoadEndEventArgs e)
        {
            stopwatch.Stop();
            Invoke(new Action(() =>
            {
                var builder = new StringBuilder();
                builder.AppendFormat("网页地址：{0}\r\n", e.Url);
                builder.AppendFormat("加载时间：{0} 毫秒\r\n",stopwatch.Elapsed.TotalMilliseconds);
                richTextBox1.AppendText(builder.ToString());
            }));
        }

        private void Browser_FrameLoadStart(object sender, CefSharp.FrameLoadStartEventArgs e)
        {
            stopwatch.Restart();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            browser.LoadUrl(address2);
        }
    }
}
