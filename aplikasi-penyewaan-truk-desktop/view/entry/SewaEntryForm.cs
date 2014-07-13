using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using domain.model;
using desktop.view.popup;
using domain.service;
using core.implementasi;
using ComponentOwl.BetterListView;
using desktop.utilities;

namespace desktop.view.entry
{
    public partial class SewaEntryForm : Form
    {
        // Service.
        IRuteService ruteService;
        IHargaRuteTrukService hargaRuteTrukService;
        ITrukService trukService;
        ISupirService supirService;
        IKernetService kernetService;
        IJenisTrukService jenisTrukService;
        ISewaService sewaService;
        ICustomerService customerService;

        IList<Sewa> cart = new List<Sewa>();
        IList<HargaRuteTruk> cartTruk;

        public SewaEntryForm()
        {
            InitializeComponent();
            ruteService = new RuteServiceImpl();
            trukService = new TrukServiceImpl();
            supirService = new SupirServiceImpl();
            kernetService = new KernetServiceImpl();
            jenisTrukService = new JenisTrukServiceImpl();
            hargaRuteTrukService = new HargaRuteTrukServiceImpl();
            sewaService = new SewaServiceImpl();
            customerService = new CustomerServiceImpl();

            cartTruk = new List<HargaRuteTruk>();
            addToCart();
            txtNoSewa.Text = sewaService.autoNumber();
        }

        private void addToCart()
        {
            //HargaRuteTruk items = new HargaRuteTruk();
            //items.Harga = 70000;

            //Truk truk = new Truk();
            //truk.Id = "T00001";
            //truk.NomorPolisi = "B909234";

            //Rute rute = new Rute();
            //rute.Id = "R00001";
            //rute.Nama = "Bandung";

            //items.Truk = truk;
            //items.Rute = rute;

            //cartTruk.Add(items);
            //cartTruk.Add(items);
            //cartTruk.Add(items);

            //DataTable dt = ToDataTable<HargaRuteTruk>(cartTruk);

            //dt.Columns["Rute"].ColumnName = "Rute";
            //dt.Columns["Harga"].DataType = typeof(Decimal);
            ////dt.Columns["Rute"].DefaultValue = "Nama";
            ////dt.Columns["Rute"].Expression = "Rute.Nama";
            ////dt.Columns["Rute"].Caption = "Rute.Nama";

            //dataGridView1.DataSource = dt;
            ////dataGridView1.Rows.Add(

        }

        private void deleteCartTruk(String id) {
            for (int x = 0; x < cartTruk.Count; x++ ) {
                  if (cartTruk[x].Id.Equals(id)) {
                      cartTruk.RemoveAt(x);
                      return;
                  }
            }
        }

        private Boolean validasiSave() {
            if (txtCustomerId.Text.Equals("")) {
                MessageCustom.messageWarning("Sewa", "Customer Belum Dipilih");
                return false;
            } else if (cartTruk == null) {
                MessageCustom.messageWarning("Sewa", "List Sewa Truk Masih Kosong");
                return false;
            } else if (cartTruk != null) {
                if (cartTruk.Count == 0) {
                    MessageCustom.messageWarning("Sewa", "List Sewa Truk Masih Kosong");
                    return false;
                }
            }

            for (int x=0; x<lvCartTruk.Items.Count; x++) {
                if (lvCartTruk.Items[x].SubItems[13].Text.Equals("")) {
                    MessageCustom.messageWarning("Sewa", "Keterangan Truk Belum Di Isi. \n Nomor Polisi: " + lvCartTruk.Items[x].SubItems[2].Text);
                    return false;
                }
            }

            return true;
        }

        private Boolean validasiTrukCartSama(String hargaRuteTrukId)
        {
            if (cartTruk.Count != 0) {
                foreach (HargaRuteTruk h in cartTruk) {
                    if (h.Id.Equals(hargaRuteTrukId)) {
                        return false;
                    }
                }
            }
            return true;
        }

        private void initializeListView()
        {
            Decimal hargaTotal = 0;
            lvCartTruk.Items.Clear();

            foreach (HargaRuteTruk h in cartTruk) {
                Truk truk = trukService.cari(h.Truk.Id);

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
                items.SubItems.Add(FormatRupiah.ToRupiah(Convert.ToInt64(h.Harga.ToString())));
                items.SubItems[1].AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Right;
                //this.betterListViewSubItem2.BackColor = System.Drawing.Color.Cyan;
                //this.betterListViewSubItem2.ForeColor = System.Drawing.Color.Maroon;
                items.SubItems[1].ForeColor = System.Drawing.Color.Maroon;
                items.SubItems[1].BackColor = System.Drawing.Color.Maroon;

                items.SubItems.Add(truk.Supir.Id);
                Supir supir = supirService.cari(truk.Supir.Id);
                items.SubItems.Add(supir.Nama);

                if (supir.Kernet != null) {
                    Kernet kernet = kernetService.cari(supir.Kernet.Id);
                    items.SubItems.Add(supir.Kernet.Id);
                    items.SubItems.Add(kernet.Nama);
                    items.SubItems.Add("");
                } else {
                    items.SubItems.Add("");
                    items.SubItems.Add("");
                    items.SubItems.Add("");
                }
                
                lvCartTruk.Items.Add(items);
                hargaTotal += h.Harga;
                lblJumlahTruk.Text = cartTruk.Count.ToString() + " Unit";
            }

            lblJumlahTruk.Text = cartTruk.Count.ToString() + " Unit";
            lblHargaTotal.Text = FormatRupiah.ToRupiah(Convert.ToInt64(hargaTotal.ToString()));
        }

        public DataTable ToDataTable<T>(IList<T> Data)
        {
            if (null == Data) return null;

            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));
            var retVal = new DataTable();

            try
            {
                for (int i = 0; i < props.Count; i++)
                {
                    PropertyDescriptor prop = props[i];
                    retVal.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
                }

                object[] values = new object[props.Count];
                foreach (T item in Data)
                {
                    for (int i = 0; i < values.Length; i++)
                    {
                        values[i] = props[i].GetValue(item) ?? DBNull.Value;
                    }

                    retVal.Rows.Add(values);
                }
            }
            catch (Exception)
            {
                retVal.Dispose();
                throw;
            }

            return retVal;
        }

        private Decimal getTotalPrice() {
            Decimal total = 0;
            foreach (HargaRuteTruk h in cartTruk) {
                total += h.Harga;
            }
            return total;
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            TrukPopUpForm tpuf = new TrukPopUpForm();

            if (cartTruk.Count > 0) {
                IList<Truk> list = new List<Truk>();
                foreach (HargaRuteTruk h in cartTruk) {
                    list.Add(new Truk(h.Truk.Id));
                }
                tpuf.SourceCompareTruk = list;
            }

            tpuf.ShowDialog();

            if (tpuf.GetHargaRuteTruk != null)
            {
                if (validasiTrukCartSama(tpuf.GetHargaRuteTruk.Id)) {
                    cartTruk.Add(tpuf.GetHargaRuteTruk);

                    initializeListView();
                }
                
            }
        }

        private void btnCariCustomer_Click(object sender, EventArgs e)
        {
            CustomerListForm c = new CustomerListForm(ProfilForm.Unknow);
            c.ShowDialog();
            String id = c.GetCustomer.Id;
            if (!id.Equals("")) {
                Customer cst = customerService.cari(id);
                txtCustomerId.Text = cst.Id;
                txtCustomerNama.Text = cst.Nama;
                txtCustomerTelefon.Text = cst.Telefon;
                txtCustomerAlamat.Text = cst.Alamat;
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (validasiSave()) {

                Sewa sewa = new Sewa();
                sewa.Id = sewaService.autoNumber();
                sewa.Tanggal = new DateTime();
                sewa.TotalHarga = getTotalPrice();
                sewa.Customer = new Customer(txtCustomerId.Text);
                IList<SewaDetail> listSewaDetail = new List<SewaDetail>();
                foreach (HargaRuteTruk h in cartTruk) {
                    SewaDetail s = new SewaDetail(sewa.Id, h.Harga, new Truk(h.Truk.Id));
                    s.Keterangan = getKeterangan(h.Truk.Id);
                    listSewaDetail.Add(s);
                }

                if (sewaService.save(sewa, listSewaDetail) != null) {
                    MessageCustom.messageInfo("Sewa", "Data Berhasil Disimpan");
                    this.Dispose();
                } else {
                    MessageCustom.messageCritical("Sewa", "Data Gagal Disimpan");
                }
            }
        }

        private void btnCariCustomer_Click_1(object sender, EventArgs e)
        {
            CustomerListForm c = new CustomerListForm(ProfilForm.Unknow);
            c.ShowDialog();
            
            if (c.GetCustomer != null ) {
                String id = c.GetCustomer.Id;
                if (!id.Equals("")) {
                    Customer cst = customerService.cari(id);
                    txtCustomerId.Text = cst.Id;
                    txtCustomerNama.Text = cst.Nama;
                    txtCustomerTelefon.Text = cst.Telefon;
                    txtCustomerAlamat.Text = cst.Alamat;
                }
            }
        }

        private void lvCartTruk_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvCartTruk.SelectedItems.Count > 0) {
                btnDelete.Enabled = true;
            } else {
                btnDelete.Enabled = false;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            foreach (BetterListViewItem items in lvCartTruk.SelectedItems) {
                String id = items.Text;
                MessageBox.Show(items.Text);
                deleteCartTruk(id);
            }
            initializeListView();
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvCartTruk.SelectedItems.Count == 1) {
                int x = lvCartTruk.SelectedIndices[0];
                String id = lvCartTruk.Items[x].Text;
                MessageBox.Show(id);
                EditKeteranganSewaDetail ek = new EditKeteranganSewaDetail(lvCartTruk.Items[x].SubItems[7].Text,
                    lvCartTruk.Items[x].SubItems[5].Text);
                ek.ShowDialog();
                if (ek.Keterangan != null) {
                    addKeterangan(id, ek.Keterangan);
                }
            }
        }

        private void addKeterangan(String id, String keterangan) 
        {
            for (int x=0; x < lvCartTruk.Items.Count; x++) {
                if (lvCartTruk.Items[x].Text.Equals(id)){
                    lvCartTruk.Items[x].SubItems[13].Text = keterangan;
                }
            }
        }

        private String getKeterangan(String id) {
            String keteranagan = "";
            for (int x=0; x < lvCartTruk.Items.Count; x++) {
                if (lvCartTruk.Items[x].SubItems[1].Text.Equals(id)) {
                    keteranagan = lvCartTruk.Items[x].SubItems[13].Text;
                }
            }
            return keteranagan;
        }

      
    }
}
