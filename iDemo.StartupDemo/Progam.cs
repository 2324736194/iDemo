using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace iDemo.StartupDemo
{
    class Program
    {
        private static readonly Stopwatch stopwatch;

        static Program()
        {
            stopwatch = new Stopwatch();
        }

        [STAThread]
        [DebuggerNonUserCode]
        [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
        public static void Main()
        {
            stopwatch.Start();
            var app = new App();
            app.InitializeComponent();
            app.Run();
        }

        public static void ShowStartupTime()
        {
            stopwatch.Stop();
            MessageBox.Show(stopwatch.Elapsed.TotalSeconds.ToString());
        }
    }
}
