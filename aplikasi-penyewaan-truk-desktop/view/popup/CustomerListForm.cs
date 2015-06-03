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
using core.implementasi;
using domain.model;
using ComponentOwl.BetterListView;
using desktop.view.entry;

namespace desktop.view.popup
{
    public partial class CustomerListForm : Form
    {
        ICustomerService customerService;
        ProfilForm profilForm;
        IList<Customer> listCustomer;
        Customer customer = null;

        public CustomerListForm(ProfilForm pf) {
            InitializeComponent();
            
            customerService = new CustomerServiceImpl();
            listCustomer = new List<Customer>();
            this.profilForm = pf;
            initializeDataListView();

            if (pf == ProfilForm.Menu) {
                this.ControlBox = false;
            } else {
                this.statusStrip1.Show();
                this.toolStrip1.Hide();
            }

        }

        public void initializeDataListView() {
            lvCustomer.Items.Clear();
            listCustomer = customerService.cariDaftarCustomer("");
            if (listCustomer != null) {
                foreach (Customer c in listCustomer) {
                    BetterListViewItem items = new BetterListViewItem(c.Id);
                    items.SubItems.Add(c.Nama);
                    items.SubItems.Add(c.Telefon);
                    items.SubItems.Add(c.Alamat);
                    items.SubItems.Add(c.Telefon);

                    lvCustomer.Items.Add(items);
                }
            }
        }

        private void btnTambah_Click(object sender, EventArgs e) {
            CustomerEntryForm k = new CustomerEntryForm(null);
            k.ShowDialog(null);
            initializeDataListView();
        }

        private void lvCustomer_SelectedIndexChanged(object sender, EventArgs e) {
            if (lvCustomer.SelectedItems.Count == 1) {
                int x = lvCustomer.SelectedIndices[0];
                lblInfoId.Text = lvCustomer.Items[x].Text;
                lblInfoNama.Text = lvCustomer.Items[x].SubItems[1].Text;
                btnEdit.Enabled = true;
            }
            else {
                btnEdit.Enabled = false;
                lblInfoId.Text = "";
                lblInfoNama.Text = "";
            }
        }

        private void btnEdit_Click(object sender, EventArgs e) {
            if (lvCustomer.SelectedItems.Count == 1) {
                CustomerEntryForm k = new CustomerEntryForm(new Customer(lblInfoId.Text));
                k.ShowDialog(this);
                initializeDataListView();
            }
        }

        private void lvCustomer_DoubleClick(object sender, EventArgs e) {
            if (lvCustomer.SelectedItems.Count == 1) {
                customer = new Customer(lblInfoId.Text);
                this.Close();
            }
        }

        public Customer GetCustomer {
            get { return this.customer; }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            initializeDataListView();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

    }
}
