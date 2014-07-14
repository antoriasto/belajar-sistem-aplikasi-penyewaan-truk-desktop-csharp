using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using domain.model;
using domain.service;
using core.implementasi;
using ComponentOwl.BetterListView;

namespace desktop.view.popup
{
    public partial class SuratJalanListForm : Form
    {
        ISuratJalanService suratJalanService = new SuratJalanServiceImpl();
        IList<SuratJalan> listSuratJalan = new List<SuratJalan>();
        private String suratJalanId;

        public String SuratJalanId
        {
            get { return this.suratJalanId; }
            set { suratJalanId = value; }
        }

        public SuratJalanListForm()
        {
            InitializeComponent();
            listSuratJalan = suratJalanService.findAllData();
            initializeListView();
        }

        private void initializeListView() {
            lvSuratJalan.Items.Clear();
            if (listSuratJalan != null) 
            {
                if (listSuratJalan.Count > 0) 
                {
                    foreach (SuratJalan s in listSuratJalan) {
                        BetterListViewItem items = new BetterListViewItem(s.Id);
                        items.SubItems.Add(s.Tanggal);
                        items.SubItems.Add(s.Sewa.Id);
                        lvSuratJalan.Items.Add(items);
                    }
                }
            }
        }

        private void lvSuratJalan_DoubleClick(object sender, EventArgs e)
        {
            if (lvSuratJalan.SelectedItems.Count == 1)
            {
                int x = lvSuratJalan.SelectedIndices[0];
                this.suratJalanId = lvSuratJalan.Items[x].Text;

                this.Close();
            }
        }

        private void lvSuratJalan_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
