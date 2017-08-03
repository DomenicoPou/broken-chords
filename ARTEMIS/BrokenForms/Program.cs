using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Midi;
using System.IO.Ports;
using System.Threading;

namespace BrokenForms
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try {
                CameraImaging mainCameraObject = new CameraImaging();
                //bool isPaused = new bool();

                Thread threadForUI = new Thread(ThreadDebuggingForm.SystemThread);
                //threadForUI.Start(mainCameraObject);
                
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1(mainCameraObject, threadForUI));

            } catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}
