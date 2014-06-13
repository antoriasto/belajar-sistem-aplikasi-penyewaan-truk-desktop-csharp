using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using aplikasi_penyewaan_truk_domain.service;
using aplikasi_penyewaan_truk_dao.implementasi;
using aplikasi_penyewaan_truk_domain.model;
using ComponentOwl.BetterListView;
using aplikasi_penyewaan_truk_desktop.view.entry;

namespace aplikasi_penyewaan_truk_desktop.view.popup
{
    public partial class TrukListForm : Form
    {
        ITrukService trukService = new TrukServiceImpl();

        public TrukListForm()
        {
            InitializeComponent();

            IList<Truk> daftarTruk = trukService.cariDaftarTruk("");
            if (validasiListKosongAtauGa(daftarTruk))
            {
                initializeListView(daftarTruk);
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
            foreach (Truk t in daftarTruk)
            {
                BetterListViewItem items = new BetterListViewItem(t.Id);
                items.SubItems.Add(t.NomorPolisi);

                if (t.JenisTruk != null)
                {
                    items.SubItems.Add(t.JenisTruk.Id);
                    items.SubItems.Add(t.JenisTruk.Nama);
                }
                else
                {
                    items.SubItems.Add("");
                    items.SubItems.Add("");
                }

                if (t.Supir != null)
                {
                    items.SubItems.Add(t.Supir.Id);
                    items.SubItems.Add(t.Supir.Nama);
                }
                else
                {
                    items.SubItems.Add("");
                    items.SubItems.Add("");
                }

                lvTruk.Items.Add(items);
            }
        }

        private void lvTruk_ItemSelectionChanged(object sender, BetterListViewItemSelectionChangedEventArgs eventArgs)
        {

        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            TrukEntryForm t = new TrukEntryForm();
            t.ShowDialog();
        }

    }
}
