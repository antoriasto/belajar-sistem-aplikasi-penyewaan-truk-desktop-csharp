using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;
using desktop.utilities;

namespace desktop.view.popup
{
    public partial class EditHargaRuteTruk : Form
    {
        private String harga;

        public String Harga
        {
            get { return harga; }
            set { harga = value; }
        }

        public EditHargaRuteTruk()
        {
            InitializeComponent();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            String value = txtHarga.Text;
            //txtHarga.Text = FormatRupiah.ToRupiah(Convert.ToInt32(value));
            Harga = txtHarga.Text;
            this.Dispose();
        }

        private void txtHarga_KeyPress(object sender, KeyPressEventArgs e)
        {
            /// Disable Penggunaan karakter di textbox
            if (char.IsDigit(e.KeyChar) || (int)e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

    }
}
