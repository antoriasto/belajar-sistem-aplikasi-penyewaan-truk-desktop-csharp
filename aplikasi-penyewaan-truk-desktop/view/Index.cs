using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using aplikasi_penyewaan_truk_desktop.view.popup;
using aplikasi_penyewaan_truk_domain.service;
using aplikasi_penyewaan_truk_dao.implementasi;

namespace aplikasi_penyewaan_truk_desktop.view
{
    public partial class Index : Form
    {
        TrukListForm trukListForm;

        public Index()
        {
            InitializeComponent();
            ITrukService ts = new TrukServiceImpl();
            MessageBox.Show( ts.nomorOtomatis());
            
        }

        private void trukToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (this.trukListForm == null || this.trukListForm.IsDisposed)
            {
                trukListForm = new TrukListForm();
                trukListForm.MdiParent = this;
                trukListForm.WindowState = FormWindowState.Maximized;
                trukListForm.Show();
            }
            else if (this.trukListForm != null)
            {
                trukListForm.MdiParent = this;
                this.trukListForm.BringToFront();
                trukListForm.Show();
            }
        }

      



    }
}
