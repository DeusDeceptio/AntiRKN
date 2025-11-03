using System.Diagnostics;
using System.Drawing.Imaging;
using System.Reflection;

namespace AntiRKN
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (Mutex mutex = new Mutex(false, "Global\\" + "AntiRKN"))
            {
                if (!mutex.WaitOne(0, false))
                {
                    return;
                }
                // To customize application configuration such as set high DPI settings or default font,
                // see https://aka.ms/applicationconfiguration.
                ApplicationConfiguration.Initialize();
                Application.Run(new Form1());
            }
        }
    }
}