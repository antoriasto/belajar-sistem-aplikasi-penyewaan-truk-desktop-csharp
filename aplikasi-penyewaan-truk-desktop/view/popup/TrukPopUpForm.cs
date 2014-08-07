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
using domain.model.enumerasi;

namespace desktop.view.popup
{
    public partial class TrukPopUpForm : Form
    {
        IRuteService ruteService;
        IHargaRuteTrukService hargaRuteTrukService;
        ITrukService trukService;
        ISupirService supirService;
        IKernetService kernetService;
        IJenisTrukService jenisTrukService;

        HargaRuteTruk hargaRuteTruk;

        IList<Rute> listRute;
        IList<HargaRuteTruk> listHargaRuteTruk;
        IList<Truk> sourceCompareTruk;

        public IList<Truk> SourceCompareTruk {
            get { return sourceCompareTruk; }
            set { sourceCompareTruk = value; }
        }

        public HargaRuteTruk GetHargaRuteTruk {
            get { return hargaRuteTruk; }
            set { hargaRuteTruk = value; }
        }

        public TrukPopUpForm()
        {
            InitializeComponent();
            ruteService = new RuteServiceImpl();
            trukService = new TrukServiceImpl();
            supirService = new SupirServiceImpl();
            kernetService = new KernetServiceImpl();
            jenisTrukService = new JenisTrukServiceImpl();
            hargaRuteTrukService = new HargaRuteTrukServiceImpl();

            listRute = new List<Rute>();
            listHargaRuteTruk = new List<HargaRuteTruk>();

            initializeTreeRute(); 
        }


        private void initializeTreeRute()
        {
            listRute = ruteService.cariDaftarRute("");

            foreach (Rute r in listRute) {
                tvRute.Nodes[0].Nodes.Add(r.Id, r.Nama);
            }
        }

        private void initializeListView(String ruteId)
        {
            lvHargaRuteTruk.Items.Clear();
            listHargaRuteTruk = hargaRuteTrukService.findAllDataByRuteId(ruteId);
            if (listHargaRuteTruk.Count > 0)
            {
                lvHargaRuteTruk.Items.Clear();
                foreach (HargaRuteTruk h in listHargaRuteTruk) {
                    if (validasiDataSudahAda(h.Truk.Id)) {

                        Truk truk = trukService.cari(h.Truk.Id);
                    
                        if (truk.Status == StatusTruk.Tersedia.ToString() && truk.Supir != null) {
                            BetterListViewItem items = new BetterListViewItem(h.Id);
                            items.SubItems.Add(h.Truk.Id);
                            items.SubItems.Add(truk.NomorPolisi);
                            items.SubItems.Add(truk.Status);

                            Rute rute = ruteService.cari(h.Rute.Id);
                            items.SubItems.Add(rute.Id);
                            items.SubItems.Add(rute.Nama);

                            JenisTruk jenis = jenisTrukService.cari(truk.JenisTruk.Id);
                            items.SubItems.Add(jenis.Id);
                            items.SubItems.Add(jenis.Nama);
                            items.SubItems.Add(h.Harga);

                            items.SubItems.Add(truk.Supir.Id);
                            Supir supir = supirService.cari(truk.Supir.Id);
                            items.SubItems.Add(supir.Nama);
                            if (supir.Kernet != null)
                            {
                                Kernet kernet = kernetService.cari(supir.Kernet.Id);
                                items.SubItems.Add(supir.Kernet.Id);
                                items.SubItems.Add(kernet.Nama);
                            }


                            lvHargaRuteTruk.Items.Add(items);
                        }
                    }
                   

                }
            }
        }

        private Boolean validasiDataSudahAda(String trukId) 
        {
            if (sourceCompareTruk != null) {
                if (sourceCompareTruk.Count > 0) {
                    foreach (Truk t in sourceCompareTruk) {
                        if (t.Id.Equals(trukId)) {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        private HargaRuteTruk getHargaRuteTrukFromList(String hargaRuteTrukId)
        {
            foreach (HargaRuteTruk h in listHargaRuteTruk)
            {
                if (h.Id.Equals(hargaRuteTrukId))
                {
                    return h;
                }
            }
            return null;
        }

        private void tvRute_AfterSelect(object sender, TreeViewEventArgs e)
        {
            initializeListView(e.Node.Name);
        }

        private void lvHargaRuteTruk_DoubleClick(object sender, EventArgs e)
        {
            if (lvHargaRuteTruk.SelectedItems.Count == 1)
            {
                int x = lvHargaRuteTruk.SelectedIndices[0];
                GetHargaRuteTruk = getHargaRuteTrukFromList(lvHargaRuteTruk.Items[x].Text);
                this.Close();
            }
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
