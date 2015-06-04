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
using desktop.view.entry;
using domain.model;
using ComponentOwl.BetterListView;
using desktop.utilities;

namespace desktop.view.popup
{
    public partial class KernetListForm : Form
    {
        IKernetService kernetService;
        ProfilForm profilForm;
        private Kernet kernet;

        public Kernet GetKernet
        {
            get { return kernet; }
            set { kernet = value; }
        }

        

        public KernetListForm(ProfilForm pf)
        {
            InitializeComponent();
            this.profilForm = pf;
            kernetService = new KernetServiceImpl();
            initializeListView();

            if (pf == ProfilForm.Menu)
            {
                statusStrip1.Hide();
            }
            else
            {
                toolStrip1.Hide();
            }

        }


        public KernetListForm(ProfilForm pf, IList<Supir> supirList)
        {
            InitializeComponent();
            this.profilForm = pf;
            kernetService = new KernetServiceImpl();
            initializeListView(supirList);

            if (pf == ProfilForm.Menu)
            {
                statusStrip1.Hide();
            }
            else
            {
                toolStrip1.Hide();
            }

        }


        private void btnTambah_Click(object sender, EventArgs e)
        {
            KernetEntryForm k = new KernetEntryForm(null);
            k.ShowDialog(null);
            initializeListView();
        }

        private void initializeListView()
        {
            lvKernet.Items.Clear();
            IList<Kernet> list =  kernetService.cariDaftarKernet("");
            if (list != null)
            {
                if (list.Count > 0)
                {
                    foreach (Kernet k in list)
                    {
                        BetterListViewItem items = new BetterListViewItem(k.Id);
                        items.SubItems.Add(k.Nama);
                        items.SubItems.Add(k.Alamat);
                        items.SubItems.Add(k.NomorHp);

                        lvKernet.Items.Add(items);
                    }
                }
            }
            
        }

        private void initializeListView(IList<Supir> supirList)
        {
            lvKernet.Items.Clear();
            IList<Kernet> list = kernetService.cariDaftarKernet("");
            if (list != null)
            {
                if (list.Count > 0)
                {
                    foreach (Kernet k in list)
                    {
                            if (!isHaving(supirList, k.Id))
                            {
                                BetterListViewItem items = new BetterListViewItem(k.Id);
                                items.SubItems.Add(k.Nama);
                                items.SubItems.Add(k.Alamat);
                                items.SubItems.Add(k.NomorHp);

                                lvKernet.Items.Add(items);
                            }
                    }
                }
            }

        }

        private Boolean isHaving(IList<Supir> supirList, String id)
        {
            foreach (Supir s in supirList)
            {
                if (s.Kernet.Id.Equals(id))
                {
                    return true;
                }
            }
            return false;
        }

        private void lvKernet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvKernet.SelectedItems.Count == 1)
            {
                int x = lvKernet.SelectedIndices[0];
                for (int y = 0; y < lvKernet.Items.Count; y++)
                {
                    this.Refresh();
                    btnEdit.Enabled = true;
                    lblInfoId.Text = lvKernet.Items[x].Text;
                    lblInfoNama.Text = lvKernet.Items[x].SubItems[1].Text;
                }
            }
            else
            {
                btnEdit.Enabled = false;
                lblInfoId.Text = "";
                lblInfoNama.Text = "";
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            KernetEntryForm k = new KernetEntryForm(new Kernet(lblInfoId.Text));
            k.ShowDialog(null);
            initializeListView();
        }

        private void lvKernet_DoubleClick(object sender, EventArgs e)
        {
            if (lvKernet.SelectedItems.Count == 1)
            {
                int x = lvKernet.SelectedIndices[0];
                Kernet k = new Kernet();
                k.Id = lvKernet.Items[x].Text;
                k.Nama = lvKernet.Items[x].SubItems[1].Text;
                this.kernet = k;

                this.Close();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            initializeListView();
        }

        private void initializeListView(IList<Kernet> iList)
        {
           
        }

    }
}
