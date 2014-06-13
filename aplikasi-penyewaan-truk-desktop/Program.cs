using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using aplikasi_penyewaan_truk_desktop.view;

namespace aplikasi_penyewaan_truk_desktop
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Index());
        }
    }
}
