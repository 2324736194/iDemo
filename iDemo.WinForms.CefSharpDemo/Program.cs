using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;

namespace iDemo.WinForms.CefSharpDemo
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {

            InitializeCefSharp();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        static void InitializeCefSharp()
        {
            #region 置顶，请不要更新代码顺序

            CefRuntime.SubscribeAnyCpuAssemblyResolver();

            #endregion

            var settings = new CefSettings();
           
            // 禁用 GPU 加速：主要作用是修复网页显示不全 winForm
            //settings.CefCommandLineArgs.Add("disable-gpu", "1");
            Cef.Initialize(settings);
            //Cef.EnableHighDPISupport();
        }
    }
}


