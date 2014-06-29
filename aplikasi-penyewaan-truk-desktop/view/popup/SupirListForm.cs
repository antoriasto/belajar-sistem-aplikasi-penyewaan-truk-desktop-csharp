using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using domain.service;
using core.implementasi;
using domain.model;
using ComponentOwl.BetterListView;
using desktop.utilities;
using desktop.view.entry;

namespace desktop.view.popup
{
    public partial class SupirListForm : Form
    {
        ISupirService supirService;
        IKernetService kernetService;
        ProfilForm profilForm;
        private Supir supir;

        public Supir GetSupir
        {
            get { return supir; }
        }

        public SupirListForm(ProfilForm profilForm)
        {
            InitializeComponent();
            supirService = new SupirServiceImpl();
            kernetService = new KernetServiceImpl();

            this.profilForm = profilForm;


            inisialisasiListView(supirService.cariDaftarSupir(""));

            if (profilForm == ProfilForm.Menu)
            {
                statusStrip1.Hide();
            }
        }

        #region Validasi

        private Boolean validasiListKosongAtauGa(IList<Truk> list)
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
        
        private void inisialisasiListView(IList<Supir> list)
        {
            lvSupir.Items.Clear();
            if (list != null)
            {
                if (list.Count > 0)
                {
                    foreach (Supir s in list)
                    {
                        BetterListViewItem items = new BetterListViewItem(s.Id);
                        items.SubItems.Add(s.Nama);
                        items.SubItems.Add(s.Alamat);
                        items.SubItems.Add(s.NomorHp);
                        if (s.Kernet != null)
                        {
                            Kernet kernet = kernetService.cari(s.Kernet.Id);
                            if (kernet != null)
                            {
                                items.SubItems.Add(kernet.Id);
                                items.SubItems.Add(kernet.Nama);
                            }
                        }
                        else
                        {
                            items.SubItems.Add("-");
                            items.SubItems.Add("-");
                        }
                        lvSupir.Items.Add(items);
                    }
                }
            }
        }

        private void lvSupir_DoubleClick(object sender, EventArgs e)
        {
            if (lvSupir.SelectedItems.Count == 1 && profilForm == ProfilForm.Unknow)
            {
                int x = lvSupir.SelectedIndices[0];
                Supir s = new Supir();
                s.Id = lvSupir.Items[x].Text;
                s.Nama = lvSupir.Items[x].SubItems[1].Text;
                this.supir = s;

                this.Close();
            }
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            SupirEntryForm s = new SupirEntryForm(null);
            s.ShowDialog(this);
            inisialisasiListView(supirService.cariDaftarSupir(""));
        }

        private void lvSupir_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvSupir.SelectedItems.Count == 1 && profilForm == ProfilForm.Menu)
            {
                btnEdit.Enabled = true;
            }
            else
            {
                btnEdit.Enabled = false;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            if (lvSupir.SelectedItems.Count == 1 && profilForm == ProfilForm.Menu)
            {
                int x = lvSupir.SelectedIndices[0];

                SupirEntryForm s = new SupirEntryForm(new Supir(lvSupir.Items[x].Text));
                s.ShowDialog(this);
                inisialisasiListView(supirService.cariDaftarSupir(""));
            }
           
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            inisialisasiListView(supirService.cariDaftarSupir(""));
        }

    }
}
