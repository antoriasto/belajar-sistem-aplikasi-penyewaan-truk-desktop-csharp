using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using domain.model;

namespace desktop.view.popup
{
    public partial class EditKeteranganSewaDetail : Form
    {
        private String keterangan;
        public String Keterangan
        {
            set { this.keterangan = value; }
            get { return this.keterangan; }
        }

        public EditKeteranganSewaDetail(String jenisTruk, String rute)
        {
            InitializeComponent();
            if (jenisTruk != null && rute != null) {
                txtJenisTruk.Text = jenisTruk;
                txtRute.Text = rute;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (!txtKeterangan.Text.Equals("")) {
                this.keterangan = txtKeterangan.Text;
                this.Dispose();
            }
        }

        private void txtKeterangan_TextChanged(object sender, EventArgs e)
        {

        }

        

    }
}
