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
using desktop.view.entry;
using desktop.utilities;

namespace desktop.view.popup
{
    public partial class TrukListForm : Form
    {
        ITrukService trukService = new TrukServiceImpl();
        IJenisTrukService jenisTrukService = new JenisTrukServiceImpl();
        ISupirService supirService = new SupirServiceImpl();
        ProfilForm profilForm;

        public TrukListForm(ProfilForm pf)
        {
            InitializeComponent();
            initializeForm(pf);
            this.profilForm = pf;
            IList<Truk> daftarTruk = trukService.cariDaftarTruk("");
            if (validasiListKosongAtauGa(daftarTruk))
            {
                initializeListView(daftarTruk);
            }
            
        }

        private void initializeForm(ProfilForm pf)
        {
            if (pf == ProfilForm.Menu) {
                statusStrip1.Hide();
                this.ControlBox = false;
            }
        }


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

        private void initializeListView(IList<Truk> daftarTruk)
        {
            lvTruk.Items.Clear();
            lvTruk.ImageList = imageList1;
            lvTruk.Columns[0].ImageIndex = 0;

            foreach (Truk t in daftarTruk)
            {
                BetterListViewItem items = new BetterListViewItem(t.Id);
                items.SubItems.Add(t.NomorPolisi);

                if (t.JenisTruk != null)
                {
                    items.SubItems.Add(t.JenisTruk.Id);
                    JenisTruk jt = jenisTrukService.cari(t.JenisTruk.Id);
                    items.SubItems.Add(jt.Nama);
                    
                }
                else
                {
                    items.SubItems.Add("");
                    items.SubItems.Add("");
                }

                if (t.Supir != null)
                {
                    items.SubItems.Add(t.Supir.Id);
                    Supir su = supirService.cari(t.Supir.Id);
                    items.SubItems.Add(su.Nama);
                }
                else
                {
                    items.SubItems.Add("");
                    items.SubItems.Add("");
                }
                items.SubItems.Add(t.Status);
                lvTruk.Items.Add(items);
            }
        }

        private void lvTruk_ItemSelectionChanged(object sender, BetterListViewItemSelectionChangedEventArgs eventArgs)
        {

        }

        private void lvTruk_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (lvTruk.SelectedItems.Count == 1)
            {
                int index = lvTruk.SelectedIndices[0];
                btnEdit.Enabled = true;
                if (!lvTruk.Items[index].SubItems[2].Text.Equals(""))
                {
                    btnEditHargaRuteTruk.Enabled = true;
                } 
                else 
                {
                    btnEditHargaRuteTruk.Enabled = false;
                }
            }
            else
            {
                btnEdit.Enabled = false;
                btnEditHargaRuteTruk.Enabled = false;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvTruk.SelectedItems.Count == 1)
            {
                int index = lvTruk.SelectedIndices[0];
                Truk truk = new Truk();

                truk.Id = lvTruk.Items[index].Text;
                truk.NomorPolisi = lvTruk.Items[index].SubItems[1].Text;

                JenisTruk j = new JenisTruk();
                j.Id = lvTruk.Items[index].SubItems[2].Text;
                j.Nama = lvTruk.Items[index].SubItems[3].Text;

                Supir s = new Supir();
                s.Id = lvTruk.Items[index].SubItems[4].Text;
                s.Nama = lvTruk.Items[index].SubItems[5].Text;

                truk.Supir = s;
                truk.JenisTruk = j;

                TrukEntryForm t = new TrukEntryForm(truk);
                t.ShowDialog();
                initializeListView(trukService.cariDaftarTruk(""));
            }
            
        }

        private void btnEditHargaRuteTruk_Click(object sender, EventArgs e)
        {
            if (lvTruk.SelectedItems.Count == 1)
            {
                int index = lvTruk.SelectedIndices[0];
                Truk truk = new Truk();

                truk.Id = lvTruk.Items[index].Text;
                truk.NomorPolisi = lvTruk.Items[index].SubItems[1].Text;

                JenisTruk j = new JenisTruk();
                j.Id = lvTruk.Items[index].SubItems[2].Text;
                j.Nama = lvTruk.Items[index].SubItems[3].Text;

                truk.JenisTruk = j;

                HargaRuteTrukEntryForm t = new HargaRuteTrukEntryForm(truk);
                t.ShowDialog();
                initializeListView(trukService.cariDaftarTruk(""));
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            initializeListView(trukService.cariDaftarTruk(""));
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            TrukEntryForm t = new TrukEntryForm(null);
            t.ShowDialog();
            initializeListView(trukService.cariDaftarTruk(""));
        }

        private void TrukListForm_Load(object sender, EventArgs e)
        {

        }

    }
}
