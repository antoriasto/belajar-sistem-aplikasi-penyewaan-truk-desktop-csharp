using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using domain.service;
using domain.model;
using core.implementasi;
using ComponentOwl.BetterListView;

namespace desktop.view.popup
{
    public partial class SewaListKwitansiForm : Form
    {
        IList<Sewa> listSewa = new List<Sewa>();
        ISewaService sewaService = new SewaServiceImpl();
        ICustomerService customerService = new CustomerServiceImpl();
        private String sewaId;

        public String GetSewaId
        {
            get { return this.sewaId; }
        }

        public SewaListKwitansiForm()
        {
            InitializeComponent();
            listSewa = sewaService.findAllData("");
            initializeListView();
        }

        private void initializeListView()
        {
            lvSewaKwitansi.Items.Clear();
            if (listSewa != null)
            {
                if (listSewa.Count > 0)
                {
                    foreach (Sewa sewa in listSewa)
                    {
                        BetterListViewItem items = new BetterListViewItem(sewa.Id);
                        items.SubItems.Add(sewa.Tanggal);
                        items.SubItems.Add(sewa.TotalHargaSupir);
                        items.SubItems.Add(sewa.Customer.Id);
                        items.SubItems.Add(customerService.cari(sewa.Customer.Id).Nama);
                        lvSewaKwitansi.Items.Add(items);
                    }
                }
            }
        }

        private void lvSewaKwitansi_DoubleClick(object sender, EventArgs e)
        {
            if (lvSewaKwitansi.SelectedItems.Count == 1)
            {
                int x = lvSewaKwitansi.SelectedIndices[0];
                this.sewaId = lvSewaKwitansi.Items[x].Text;

                this.Close();
            }
        }
        private void SewaListKwitansiForm_Load(object sender, EventArgs e)
        {

        }

        private void lvSewaKwitansi_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnPilih_Click(object sender, EventArgs e)
        {
            if (lvSewaKwitansi.SelectedItems.Count == 1)
            {
                int x = lvSewaKwitansi.SelectedIndices[0];
                this.sewaId = lvSewaKwitansi.Items[x].Text;

                this.Close();
            }
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
