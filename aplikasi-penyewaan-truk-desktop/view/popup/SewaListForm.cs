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
    public partial class SewaListForm : Form
    {
        IList<Sewa> listSewa = new List<Sewa>();
        ISewaService sewaService = new SewaServiceImpl();
        ICustomerService customerService = new CustomerServiceImpl();
        private String sewaId;

        public String GetSewaId
        {
            get { return this.sewaId; }
        }


        public SewaListForm()
        {
            InitializeComponent();
            listSewa = sewaService.findAllData("");
            initializeListView();
        }

        private void initializeListView() {
            lvSewa.Items.Clear();
            if (listSewa != null) 
            {
                if (listSewa.Count > 0) 
                {
                    foreach (Sewa sewa in listSewa) {
                        BetterListViewItem items = new BetterListViewItem(sewa.Id);
                        items.SubItems.Add(sewa.Tanggal);
                        items.SubItems.Add(sewa.TotalHarga);
                        items.SubItems.Add(sewa.Customer.Id);
                        items.SubItems.Add(customerService.cari(sewa.Customer.Id).Nama);
                        lvSewa.Items.Add(items);
                    }
                }
            }
        }

        private void lvSewa_DoubleClick(object sender, EventArgs e)
        {
            if (lvSewa.SelectedItems.Count == 1)
            {
                int x = lvSewa.SelectedIndices[0];
                this.sewaId = lvSewa.Items[x].Text;

                this.Close();
            }
        }


    }
}
