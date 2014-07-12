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
using desktop.view.popup;
using domain.model;
using ComponentOwl.BetterListView;

namespace desktop.view.entry
{
    public partial class SuratJalanEntryForm : Form
    {
        ISewaService sewaService = new SewaServiceImpl();
        ISuratJalanService suratJalanService = new SuratJalanServiceImpl();
        ISewaDetailService sewaDetailService = new SewaDetailServiceImpl();
        ITrukService trukService = new TrukServiceImpl();
        IJenisTrukService jenisTrukService = new JenisTrukServiceImpl();
        IHargaRuteTrukService hargaRuteTrukService = new HargaRuteTrukServiceImpl();
        IRuteService ruteService = new RuteServiceImpl();

        IList<SewaDetail> listSewaDetail;

        public SuratJalanEntryForm()
        {
            InitializeComponent();
        }

        private void btnCariSewa_Click(object sender, EventArgs e)
        {
            SewaListForm s = new SewaListForm();
            s.ShowDialog();
            if (s.GetSewaId != null) 
            {
                if (!s.GetSewaId.Equals("")) {
                    MessageBox.Show(s.GetSewaId);
                    // Isi data ke listview surat jalan pake parameter SEWA_ID
                    listSewaDetail = sewaDetailService.findAllData();
                    initializeListView();
                }
            }
        }

        private void initializeListView() 
        {
            lvSuratJalan.Items.Clear();
            if (listSewaDetail != null) {
                if (listSewaDetail.Count > 0) {
                    foreach (SewaDetail s in listSewaDetail) {
                        BetterListViewItem items = new BetterListViewItem(s.Id);
                        items.SubItems.Add(s.Truk.Id);
                        Truk truk = trukService.cari(s.Truk.Id);
                        JenisTruk jenisTruk = jenisTrukService.cari(truk.JenisTruk.Id); 
                        items.SubItems.Add(truk.NomorPolisi);
                        items.SubItems.Add(truk.JenisTruk.Id);
                        items.SubItems.Add(jenisTruk.Nama);
                        items.SubItems.Add(s.Price);
                        items.SubItems.Add(s.Keterangan);

                        lvSuratJalan.Items.Add(items);
                    }
                }
            }
        }
    }
}
