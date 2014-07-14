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
using desktop.view.popup;
using desktop.utilities;
using domain.model.enumerasi;
using ComponentOwl.BetterListView;

namespace desktop.view.entry
{
    public partial class HargaRuteTrukEntryForm : Form
    {
        IList<HargaRuteTruk> listHargaRuteTruk;
        ITrukService trukService;
        IHargaRuteTrukService hargaRuteTrukService;
        IJenisTrukService jenisTrukService;
        IRuteService ruteService;

        public HargaRuteTrukEntryForm(Truk truk)
        {
            InitializeComponent();
            trukService = new TrukServiceImpl();
            hargaRuteTrukService = new HargaRuteTrukServiceImpl();
            jenisTrukService = new JenisTrukServiceImpl();
            ruteService = new RuteServiceImpl();
            listHargaRuteTruk = new List<HargaRuteTruk>();

            initializeForm(truk);
        }

        private void initializeForm(Truk truk)
        {
            if (truk != null)
            {
                txtTrukId.Text = truk.Id;
                txtTrukId.Show();
                lblTrukId.Show();
                txtNomorPolisi.Text = truk.NomorPolisi;
                if (truk.JenisTruk != null)
                {
                    JenisTruk j = jenisTrukService.cari(truk.JenisTruk.Id);
                    txtJenisTrukId.Text = j.Id;
                    txtJenisTrukNama.Text = j.Nama;
                }

                IList<HargaRuteTruk> listHargaRuteTruk = hargaRuteTrukService.findAllDataByTrukId(truk.Id);
                if (listHargaRuteTruk != null)
                {
                    if (listHargaRuteTruk.Count > 0)
                    {
                        this.listHargaRuteTruk = listHargaRuteTruk;
                    }
                }
                initializeListView();
            }
        }

        private void initializeListView()
        {
            lvHargaRute.Items.Clear();
            if (listHargaRuteTruk.Count > 0)
            {
                foreach (HargaRuteTruk h in listHargaRuteTruk)
                {
                    BetterListViewItem items = new BetterListViewItem(h.Id);
                    items.SubItems.Add(h.Rute.Id);
                    items.SubItems.Add(ruteService.cari(h.Rute.Id).Nama);
                    items.SubItems.Add(h.Harga);
                    items.SubItems.Add(h.Status);
                    
                    lvHargaRute.Items.Add(items);
                }
            }
            overrideItemsListView();
        }

        private void overrideItemsListView()
        {
            foreach (BetterListViewItem items in lvHargaRute.Items) 
            {
                String harga = FormatRupiah.ToRupiah(Convert.ToInt64(items.SubItems[3].Text));
                items.SubItems[3].Text = harga;

                if (items.SubItems[4].Text == Command.None.ToString())
                {
                    items.SubItems[4].Text = "";
                }
                else if (items.SubItems[4].Text == Command.New.ToString())
                {
                    items.SubItems[4].ForeColor = Color.Green;
                }

            }
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            RuteListForm r = new RuteListForm(ProfilForm.Unknow);
            r.ShowDialog();

            // Jika ada data yang dipilih di popup rute.
            if (r.DaftarHargaRuteTruk.Count > 0)
            {
                foreach (HargaRuteTruk h in r.DaftarHargaRuteTruk)
                {
                    // Jika data rute ga duplicate sama item lvHargaRute.
                    if (!validasiDataRuteSama(h))
                    {
                        h.Status = Command.New;
                        h.Truk = new Truk(txtTrukId.Text);
                        listHargaRuteTruk.Add(h);

                        //hargaRuteTruk.Status = (Command)Enum.Parse(typeof(Command), lvHargaRute.Items[x].SubItems[5].Text);
                    }
                }

                initializeListView();
            }
        }


        /**
         * Kebutuhan Pas Buka Popup.
         * Kirim data ke popup buat invisible item yang udah ada.
         * Validasi data sama.
         * */
        private Boolean validasiDataRuteSama(HargaRuteTruk h)
        {
            if (listHargaRuteTruk.Count > 0)
            {
                foreach (HargaRuteTruk compare in listHargaRuteTruk)
                {
                    if (compare.Rute.Id == h.Rute.Id)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private void searchDataInList(String id, String harga, Command command)
        {
            foreach (HargaRuteTruk compare in listHargaRuteTruk)
            {
                if (compare.Rute.Id.Equals(id))
                {
                    compare.Harga = Convert.ToDecimal(harga);
                    if (compare.Id != null && command == Command.Update)
                    {
                        compare.Status = command;
                    }
                    else if (compare.Id != null && command == Command.Delete)
                    {
                        compare.Status = command;
                    }
                }
            }
            initializeListView();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvHargaRute.SelectedItems.Count == 1)
            {
                int index = lvHargaRute.SelectedIndices[0];
                String ruteId = lvHargaRute.Items[index].SubItems[1].Text;
                EditHargaRuteTruk eh = new EditHargaRuteTruk();
                eh.ShowDialog();

                if (!String.IsNullOrEmpty(eh.Harga))
                {
                    if (!lvHargaRute.Items[index].Text.Equals(""))
                    {
                        //lvHargaRute.Items[index].SubItems[1].ImageIndex = 1;
                        searchDataInList(ruteId, eh.Harga, Command.Update);
                        //lvHargaRute.Items[index].SubItems[5].Text = Command.Update.ToString();
                    }
                    else
                    {
                        searchDataInList(ruteId, eh.Harga, Command.New);
                    }
                    //lvHargaRute.Items[index].SubItems[4].Text = eh.Harga;
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvHargaRute.SelectedItems.Count > 0)
            {
                foreach (BetterListViewItem items in lvHargaRute.SelectedItems)
                {
                    String ruteId = items.SubItems[1].Text;
                    MessageBox.Show(items.Text);

                    for (int x = 0; x < listHargaRuteTruk.Count; x++ )
                    {
                        if (ruteId.Equals(listHargaRuteTruk[x].Rute.Id) && !items.Text.Equals(""))
                        {
                            listHargaRuteTruk[x].Status = Command.Delete;
                        }
                        else if (ruteId.Equals(listHargaRuteTruk[x].Rute.Id) && items.Text.Equals(""))
                        {
                            listHargaRuteTruk.RemoveAt(x);
                        }
                    }
                }

                initializeListView();
            }
        }

        private void lvHargaRute_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvHargaRute.SelectedItems.Count == 1)
            {
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
            }
            else if (lvHargaRute.SelectedItems.Count > 1)
            {
                btnDelete.Enabled = true;
                btnEdit.Enabled = false;
            }
            else
            {
                btnDelete.Enabled = false;
                btnEdit.Enabled = false;
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            foreach (HargaRuteTruk h in listHargaRuteTruk)
            {
                switch (h.Status)
                {
                    case Command.New:
                        hargaRuteTrukService.save(h);
                        break;
                    case Command.Update:
                        hargaRuteTrukService.update(h);
                        break;
                    case Command.Delete:
                        hargaRuteTrukService.delete(h);
                        break;
                    default:
                        break;
                }
            }

            MessageCustom.messageInfo("Rute Truk", "Data Rute Truk Berhasil Di Update");
            this.Dispose();
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

    }
}
