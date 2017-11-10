using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.IO;


namespace SVC
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static Mutex mutex = new Mutex(false, Application.ProductName);
        [STAThread]
        static void Main()
        {
            if (!mutex.WaitOne(TimeSpan.FromSeconds(0), false))
            {
                MessageBox.Show(Application.ProductName + " la ventana seleccionada esta en uso.", Application.ProductName + "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new frmQuejasySugerencias());
            }
            finally
            {
                mutex.ReleaseMutex();
            }
        }
       
    }
    

}

