using System;
using System.Threading;
using System.Windows;

namespace iDemo.MutexDemo
{
    public static class Program
    {
        private static readonly Mutex mutex;

        static Program()
        {
            var ownerType = typeof(Program);
            mutex = new Mutex(true, ownerType.Name);
        }

        [STAThread]
        private static int Main(string[] args)
        {
            var result = 0;
            var signal = mutex.WaitOne(0);
            if (!signal)
            {
                //MessageBox.Show("应用程序已启动");
                return result;
            }
            var app = new App();
            app.InitializeComponent();
            result = app.Run();
            return result;
        }
    }
}