using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using desktop.utilities;
using domain.service;
using domain.model;
using ComponentOwl.BetterListView;
using core.implementasi;
using desktop.view.entry;

namespace desktop.view.popup
{
    public partial class RuteListForm : Form
    {
        IRuteService ruteService;
        IList<HargaRuteTruk> daftarHargaRuteTruk = new List<HargaRuteTruk>();
        ProfilForm profilForm;

        public IList<HargaRuteTruk> DaftarHargaRuteTruk
        {
            get { return daftarHargaRuteTruk; }
            set { daftarHargaRuteTruk = value; }
        }

        public RuteListForm(ProfilForm pf)
        {
            InitializeComponent();
            ruteService = new RuteServiceImpl();

            this.profilForm = pf;
            visibleOrInvisibleComponent(pf);
            initializeListView(ruteService.cariDaftarRute(""));
            if (profilForm == ProfilForm.Menu) {
                statusStrip1.Hide();
                this.ControlBox = false;
            }
        }

        private void initializeListView(IList<Rute> listRute)
        {
            lvRute.Items.Clear();
            if (listRute != null)
            {
                if (listRute.Count > 0)
                {
                    foreach (Rute r in listRute) 
                    {
                        BetterListViewItem items = new BetterListViewItem(r.Id.ToString());
                        items.SubItems.Add(r.Nama);
                        lvRute.Items.Add(items);
                    }
                }
            }
        }

        private void visibleOrInvisibleComponent(ProfilForm p)
        {
            if (p.Equals(ProfilForm.Menu)) 
            {
                toolStrip1.Show();
                statusStrip1.Hide();
                lvRute.CheckBoxes = BetterListViewCheckBoxes.Hide;
            }
            else if (p.Equals(ProfilForm.Unknow))
            {
                toolStrip1.Hide();
                statusStrip1.Show();
                lvRute.CheckBoxes = BetterListViewCheckBoxes.TwoState;
            }
        }

        private void lvRute_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvRute.SelectedItems.Count == 1)
            {
                int x = lvRute.SelectedIndices[0];
                for (int y = 0; y < lvRute.Items.Count; y++)
                {
                    this.Refresh();
                    lblRuteId.Text = lvRute.Items[x].Text;
                    lblRuteNama.Text = lvRute.Items[x].SubItems[1].Text;

                    btnEdit.Enabled = true;
                }
            }
            else
            {
                lblRuteId.Text = "";
                lblRuteNama.Text = "";
                btnEdit.Enabled = false;
            }
            
        }

        private void RuteListForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Kalo Form di Close Check.
            for (int y = 0; y < lvRute.Items.Count; y++)
            {
                if (lvRute.Items[y].Checked.Equals(true))
                {
                    HargaRuteTruk hrg = new HargaRuteTruk();
                    Rute rute = new Rute();

                    rute.Id = lvRute.Items[y].Text;
                    rute.Nama = lvRute.Items[y].SubItems[1].Text;
                    
                    hrg.Rute = rute;
                    DaftarHargaRuteTruk.Add(hrg);
                }
            }
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            RuteEntryForm r = new RuteEntryForm(null);
            r.ShowDialog(this);
            initializeListView(ruteService.cariDaftarRute(""));
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvRute.SelectedItems.Count == 1)
            {
                int x = lvRute.SelectedIndices[0];
                RuteEntryForm r = new RuteEntryForm(new Rute(lvRute.Items[x].Text));
                r.ShowDialog(this);
                initializeListView(ruteService.cariDaftarRute(""));
            }
           
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {

        }
       
    }
}
