using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using core.implementasi;
using domain.service;
using domain.model;
using ComponentOwl.BetterListView;
using desktop.utilities;
using desktop.view.entry;

namespace desktop.view.popup
{
    public partial class JenisTrukListForm : Form
    {
        private JenisTruk jenisTruk;
        IJenisTrukService jenisTrukService;
        ITrukService trukService;

        public JenisTruk GetJenisTruk
        {
            get { return jenisTruk; }
        }

        public JenisTrukListForm(ProfilForm pf)
        {
            InitializeComponent();
            jenisTrukService = new JenisTrukServiceImpl();
            trukService = new TrukServiceImpl();
            if (pf == ProfilForm.Menu) {
                statusStrip1.Hide();
                this.ControlBox = false;
            }
            inisialisasiListView(jenisTrukService.cariDaftarJenisTruk(""));
        }

        #region Validasi

        private Boolean validasiListKosongAtauGa(IList<JenisTruk> list)
        {
            if (list != null)
            {
                if (list.Count != 0)
                {
                    return true;
                }
            }

            return false;
        }

        #endregion

        private void inisialisasiListView(IList<JenisTruk> list)
        {
            lvJenisTruk.Items.Clear();
            if (list != null)
            {
                if (list.Count > 0)
                {
                    foreach (JenisTruk j in list)
                    {
                        BetterListViewItem items = new BetterListViewItem(j.Id);
                        items.SubItems.Add(j.Nama);
                        items.SubItems.Add(j.Kubikasi);
                        items.SubItems.Add(j.Tonase);

                        items.SubItems.Add(trukService.countAllDataByJenisTruk(j.Id));
                        items.SubItems.Add(trukService.countAllDataByJenisTrukAndStatus(j.Id, domain.model.enumerasi.StatusTruk.Tersedia));
                        items.SubItems.Add(trukService.countAllDataByJenisTrukAndStatus(j.Id, domain.model.enumerasi.StatusTruk.Sedang_Beroperasi));

                        lvJenisTruk.Items.Add(items);
                    }
                }
            }
        }

        private void lvJenisTruk_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvJenisTruk.SelectedItems.Count == 1)
            {
                int x = lvJenisTruk.SelectedIndices[0];

                lblId.Text = lvJenisTruk.Items[x].Text;
                lblNama.Text = lvJenisTruk.Items[x].SubItems[1].Text;
                btnEdit.Enabled = true;
            }
            else
            {
                lblId.Text = "";
                lblNama.Text = "";
                btnEdit.Enabled = false;
            }
        }

        private void lvJenisTruk_DoubleClick(object sender, EventArgs e)
        {
            if (lvJenisTruk.SelectedItems.Count == 1)
            {
                int x = lvJenisTruk.SelectedIndices[0];
                JenisTruk j = new JenisTruk();
                j.Id = lvJenisTruk.Items[x].Text;
                j.Nama = lvJenisTruk.Items[x].SubItems[1].Text;
                this.jenisTruk = j;

                this.Close();
            }
            
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            JenisTrukEntryForm j = new JenisTrukEntryForm(null);
            j.ShowDialog();
            inisialisasiListView(jenisTrukService.cariDaftarJenisTruk(""));
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvJenisTruk.SelectedItems.Count == 1)
            {
                int x = lvJenisTruk.SelectedIndices[0];
                lblId.Text = lvJenisTruk.Items[x].Text;

                JenisTrukEntryForm j = new JenisTrukEntryForm(new JenisTruk(lvJenisTruk.Items[x].Text));
                j.ShowDialog();
                inisialisasiListView(jenisTrukService.cariDaftarJenisTruk(""));
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            inisialisasiListView(jenisTrukService.cariDaftarJenisTruk(""));
        }


    }
}
