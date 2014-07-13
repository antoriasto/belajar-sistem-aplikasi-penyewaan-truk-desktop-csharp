using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using desktop.view.popup;
using domain.service;
using core.implementasi;
using domain.model;
using domain.model.enumerasi;
using desktop.view.entry;
using desktop.utilities;

namespace desktop.view
{
    public partial class Index : Form
    {
        // Form List Master.
        TrukListForm trukListForm;
        KernetListForm kernetListForm;
        SupirListForm supirListForm;
        RuteListForm ruteListForm;
        CustomerListForm customerListForm;
        JenisTrukListForm jenisTrukListForm;

        // Form Transaksi.
        SewaEntryForm sewaEntryForm;
        SuratJalanEntryForm suratJalanEntryForm;
        InvoiceEntryForm invoiceEntryForm;

        // Node Click Variable.
        String nodeCaption = "";

        public Index()
        {
            InitializeComponent();
            treeView1.ExpandAll();
            
        }

        #region Handler Component

        // Navigasi Treeview Click.
        private void navigateHandler(String node)
        {
            switch (node) {
                case "NodeTruk":
                    trukHandler();
                    lblNodeInfo.Text = "Data Truk";
                    break;
                case "NodeJenisTruk":
                    jenisTrukHandler();
                    lblNodeInfo.Text = "Data Jenis Truk";
                    break;
                case "NodeRute":
                    ruteHandler();
                    lblNodeInfo.Text = "Data Rute";
                    break;
                case "NodeSupir":
                    supirHandler();
                    lblNodeInfo.Text = "Data Supir";
                    break;
                case "NodeKernet":
                    kernetHandler();
                    lblNodeInfo.Text = "Data Kernet";
                    break;
                case "NodeCustomer":
                    customerHandler();
                    lblNodeInfo.Text = "Data Customer";
                    break;
                default:
                    lblNodeInfo.Text = "";
                    break;
            }
        }

        private void kernetHandler()
        {
            if (this.kernetListForm == null || this.kernetListForm.IsDisposed)
            {
                kernetListForm = new KernetListForm(ProfilForm.Menu);
                kernetListForm.MdiParent = this;
                kernetListForm.WindowState = FormWindowState.Maximized;
                kernetListForm.Show();
            }
            else if (this.kernetListForm != null)
            {
                kernetListForm.MdiParent = this;
                this.kernetListForm.BringToFront();
                kernetListForm.Show();
            }
        }

        private void trukHandler()
        {
            if (this.trukListForm == null || this.trukListForm.IsDisposed)
            {
                trukListForm = new TrukListForm(ProfilForm.Menu);
                trukListForm.MdiParent = this;
                trukListForm.WindowState = FormWindowState.Maximized;
                trukListForm.Show();
            }
            else if (this.trukListForm != null)
            {
                trukListForm.MdiParent = this;
                this.trukListForm.BringToFront();
                trukListForm.Show();
            }
        }

        private void supirHandler()
        {
            if (this.supirListForm == null || this.supirListForm.IsDisposed)
            {
                supirListForm = new SupirListForm(utilities.ProfilForm.Menu);
                supirListForm.MdiParent = this;
                supirListForm.WindowState = FormWindowState.Maximized;
                supirListForm.Show();
            }
            else if (this.supirListForm != null)
            {
                supirListForm.MdiParent = this;
                this.supirListForm.BringToFront();
                supirListForm.Show();
            }
        }

        private void ruteHandler()
        {
            if (this.ruteListForm == null || this.ruteListForm.IsDisposed)
            {
                ruteListForm = new RuteListForm(ProfilForm.Menu);
                ruteListForm.MdiParent = this;
                ruteListForm.WindowState = FormWindowState.Maximized;
                ruteListForm.Show();
            }
            else if (this.ruteListForm != null)
            {
                ruteListForm.MdiParent = this;
                this.ruteListForm.BringToFront();
                ruteListForm.Show();
            }
        }

        private void customerHandler()
        {
            if (this.customerListForm == null || this.customerListForm.IsDisposed)
            {
                customerListForm = new CustomerListForm(ProfilForm.Menu);
                customerListForm.MdiParent = this;
                customerListForm.WindowState = FormWindowState.Maximized;
                customerListForm.Show();
            }
            else if (this.ruteListForm != null)
            {
                customerListForm.MdiParent = this;
                this.customerListForm.BringToFront();
                customerListForm.Show();
            }
        }

        private void jenisTrukHandler()
        {
            if (this.jenisTrukListForm == null || this.jenisTrukListForm.IsDisposed)
            {
                jenisTrukListForm = new JenisTrukListForm(ProfilForm.Menu);
                jenisTrukListForm.MdiParent = this;
                jenisTrukListForm.WindowState = FormWindowState.Maximized;
                jenisTrukListForm.Show();
            }
            else if (this.ruteListForm != null)
            {
                jenisTrukListForm.MdiParent = this;
                this.jenisTrukListForm.BringToFront();
                jenisTrukListForm.Show();
            }
        }

        #endregion

        private void trukToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            trukHandler();
        }

        private void kernetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            kernetHandler();
        }

        private void sewaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.sewaEntryForm == null || this.sewaEntryForm.IsDisposed)
            {
                sewaEntryForm = new SewaEntryForm();
                sewaEntryForm.Show();
            }
            else if (this.sewaEntryForm != null)
            {
                sewaEntryForm.Show();
            }
        }

        private void supirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            supirHandler();
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            nodeCaption = e.Node.Name;
            navigateHandler(nodeCaption);
        }

        private void suratJalanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.suratJalanEntryForm == null || this.suratJalanEntryForm.IsDisposed)
            {
                suratJalanEntryForm = new SuratJalanEntryForm();
                suratJalanEntryForm.Show();
            }
            else if (this.suratJalanEntryForm != null)
            {
                suratJalanEntryForm.Show();
            }
        }

        private void invoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.invoiceEntryForm == null || this.invoiceEntryForm.IsDisposed)
            {
                invoiceEntryForm = new InvoiceEntryForm();
                invoiceEntryForm.Show();
            }
            else if (this.invoiceEntryForm != null)
            {
                invoiceEntryForm.Show();
            }
        }

    }
}
