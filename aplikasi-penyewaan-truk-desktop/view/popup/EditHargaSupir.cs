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
    public partial class EditHargaSupir : Form
    {
        private String harga_supir;

        public String Harga_supir
        {
            get { return harga_supir; }
            set { harga_supir = value; }
        }

        public EditHargaSupir()
        {
            InitializeComponent();
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

        private void EditHargaSupir_Load(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click_1(object sender, EventArgs e)
        {
            String value = txtHarga.Text;
            //txtHarga.Text = FormatRupiah.ToRupiah(Convert.ToInt32(value));
            Harga_supir = txtHarga.Text;
            this.Dispose();
        }

        private void btnBatal_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
