using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace desktop.utilities
{
    public static class MessageCustom
    {
        public static void messageWarning(String judul, String pesan)
        {
            MessageBox.Show(pesan,
                            judul,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation,
                            MessageBoxDefaultButton.Button1);
        }

        public static void messageCritical(String judul, String pesan)
        {
            MessageBox.Show(pesan,
                            judul,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error,
                            MessageBoxDefaultButton.Button1);
        }

        public static void messageInfo(String judul, String pesan)
        {
            MessageBox.Show(pesan,
                            judul,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button1);
        }
    }
}
