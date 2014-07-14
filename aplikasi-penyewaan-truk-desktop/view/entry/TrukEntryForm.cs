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

namespace desktop.view.entry
{
    public partial class TrukEntryForm : Form
    {
        ITrukService trukService = new TrukServiceImpl();
        IHargaRuteTrukService hargaRuteTrukService;
        ISupirService supirService;
        IRuteService ruteService;
        IJenisTrukService jenisTrukService;
        Truk temporaryTruk;

        long totalDataRuteTruk = 0;

        public TrukEntryForm(Truk truk)
        {
            InitializeComponent();
            // Initialize Service.
            trukService = new TrukServiceImpl();
            hargaRuteTrukService = new HargaRuteTrukServiceImpl();
            supirService = new SupirServiceImpl();
            ruteService = new RuteServiceImpl();
            jenisTrukService = new JenisTrukServiceImpl();


            initializeForm(truk);
        }

        private void initializeForm(Truk truk)
        {
            if (truk != null)
            {
                this.temporaryTruk = truk;
                txtTrukId.Text = truk.Id;
                txtTrukId.Show();
                lblTrukId.Show();
                txtNomorPolisi.Text = truk.NomorPolisi;
                if (truk.JenisTruk != null)
                {
                    if (truk.JenisTruk.Id != "")
                    {
                        JenisTruk j = jenisTrukService.cari(truk.JenisTruk.Id);
                        txtJenisTrukId.Text = j.Id;
                        txtJenisTruk.Text = j.Nama;
                        txtKubikasi.Text = j.Kubikasi.ToString();
                        txtTonase.Text = j.Tonase.ToString();
                        this.temporaryTruk.JenisTruk = j;
                    }
                    
                }

                if (truk.Supir != null)
                {
                    if (truk.Supir.Id != "")
                    {
                        Supir supir = supirService.cari(truk.Supir.Id);
                        txtSupirId.Text = supir.Id;
                        txtNamaSupir.Text = supir.Nama;
                        this.temporaryTruk.Supir = supir;
                    }
                    
                }

                totalDataRuteTruk = hargaRuteTrukService.countAllData(truk);
                //MessageBox.Show(totalDataRuteTruk.ToString());
                if (totalDataRuteTruk != 0)
                {
                    cbRute.Text = "Memiliki " + totalDataRuteTruk.ToString() + " Rute";
                }

                btnSimpan.Text = "Update";
                btnHapus.Show();
            }
        }

        private Boolean validasi()
        {
            if (txtNomorPolisi.Text.Equals(""))
            {
                MessageCustom.messageWarning("Truk", "Nomor Polisi Belum Di Isi");
                return false;
            }
            return true;
        }

        private Boolean validasiUpdate()
        {
            if (txtJenisTrukId.Text.Equals("") && totalDataRuteTruk > 0)
            {
                MessageCustom.messageWarning("Truk", "Jenis Truk Belum Diisi");
                return false;
            }
            return true;
        }

        private void txtTrukId_TextChanged(object sender, EventArgs e)
        {
            if (!txtTrukId.Text.Equals(""))
            {
                txtTrukId.Show();
                lblTrukId.Show();
            }
        }

        private void txtJenisTrukId_TextChanged(object sender, EventArgs e)
        {
            if (!txtJenisTrukId.Equals(""))
            {
                lblTonase.Show();
                lblKubikasi.Show();
                txtTonase.Show();
                txtKubikasi.Show();
                linkLblBatalJenisTruk.Show();
            }
        }

        private void txtSupirId_TextChanged(object sender, EventArgs e)
        {
            if (!txtSupirId.Text.Equals(""))
            {
                linkLblSupir.Show();
            }
        }

        private void btnCariJenisTruk_Click(object sender, EventArgs e)
        {
            JenisTrukListForm j = null;
            if (j == null)
            {
                j = new JenisTrukListForm(ProfilForm.Unknow);
                j.ShowDialog(this);

                if (j.GetJenisTruk != null)
                {
                    if (!j.GetJenisTruk.Id.Equals(""))
                    {
                        JenisTruk jenisTruk = jenisTrukService.cari(j.GetJenisTruk.Id);
                        if (jenisTruk != null)
                        {
                            txtJenisTrukId.Text = j.GetJenisTruk.Id;
                            txtJenisTruk.Text = j.GetJenisTruk.Nama;
                            txtKubikasi.Text = jenisTruk.Kubikasi.ToString();
                            txtTonase.Text = jenisTruk.Tonase.ToString();
                            j.Dispose();
                        }

                    }
                }
            }

        }

        private void btnCariSupir_Click(object sender, EventArgs e)
        {
            SupirListForm s = null;

            if (s == null)
            {
                s = new SupirListForm(ProfilForm.Unknow);
                s.ShowDialog(this);

                if (s.GetSupir != null)
                {
                    if (!s.GetSupir.Id.Equals(""))
                    {
                        txtSupirId.Text = s.GetSupir.Id;
                        txtNamaSupir.Text = s.GetSupir.Nama;
                        s.Dispose();
                    }
                }
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (validasi())
            {
                Truk truk = new Truk();
                truk.NomorPolisi = txtNomorPolisi.Text;
                Supir supir = new Supir();
                JenisTruk jenisTruk = new JenisTruk();
                

                if (!txtSupirId.Text.Equals(""))
                {
                    supir.Id = (txtSupirId.Text);
                }
                
                if (!txtJenisTrukId.Text.Equals(""))
                {
                    jenisTruk.Id = txtJenisTrukId.Text;
                }
                
                truk.Status = StatusTruk.Tersedia.ToString();
                truk.Supir = supir;
                truk.JenisTruk = jenisTruk;

                if (txtTrukId.Text.Equals(""))
                {
                    if (trukService.simpan(truk) != null)
                    {
                        MessageCustom.messageInfo("Truk", "Data Berhasil Disimpan");
                        this.Dispose();
                    }
                    else
                    {
                        MessageCustom.messageCritical("Truk", "Data Gagal Disimpan");
                    }
                }
                else
                {
                    if (validasiUpdate())
                    {
                        truk.Id = txtTrukId.Text;
                        if (!txtSupirId.Text.Equals(""))
                        {
                            truk.Supir = new Supir(txtSupirId.Text);
                        }
                
                        if (!txtJenisTrukId.Text.Equals(""))
                        {
                            truk.JenisTruk = new JenisTruk(txtJenisTrukId.Text);
                        }

                        if (trukService.ubah(truk) != null)
                        {
                            MessageCustom.messageInfo("Truk", "Data Berhasil Diubah");
                            this.Dispose();
                        }
                        else
                        {
                            MessageCustom.messageCritical("Truk", "Data Gagal Diubah");
                        }
                        
                    }
                        

                }
            }
            

        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (!txtTrukId.Text.Equals(""))
            {
                DialogResult result1 = MessageBox.Show("Apakah Anda Yakin Ingin Menghapus Data Truk?",
                                                        "Important Question",
                                                        MessageBoxButtons.YesNo);

                if (result1 == DialogResult.Yes)
                {
                    if (trukService.deleteTrukAndHargaRuteTruk(new Truk(txtTrukId.Text)) != null)
                    {
                        MessageCustom.messageInfo("Truk", "Data Berhasil Dihapus");
                        this.Dispose();
                    }
                    else
                    {
                        MessageCustom.messageCritical("Truk", "Data Gagal Dihapus");
                    }
                }
                else
                {
                    MessageBox.Show("Membatalkan Hapus Data Truk");
                }
            }
        }

        private void linkLblBatalJenisTruk_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtJenisTrukId.Clear();
            txtJenisTruk.Clear();
            txtKubikasi.Clear();
            txtTonase.Clear();
            txtKubikasi.Hide();
            txtTonase.Hide();
            lblKubikasi.Hide();
            lblTonase.Hide();
        }

        private void txtNomorPolisi_TextChanged(object sender, EventArgs e)
        {
            if (!txtNomorPolisi.Text.Equals("")) {

                if (!trukService.validatePoliceNumber(txtNomorPolisi.Text)) {
                    lblNomorPolisiWarning.Text = "Truk dengan nomor polisi '" + txtNomorPolisi.Text + "' sudah pernah di input";
                    lblNomorPolisiWarning.Show();
                    btnSimpan.Enabled = false;
                } else {
                    lblNomorPolisiWarning.Text = "";
                    lblNomorPolisiWarning.Hide();
                    btnSimpan.Enabled = true;
                }
            }

            if (temporaryTruk != null) {
                if (temporaryTruk.NomorPolisi.Equals(txtNomorPolisi.Text)) {
                    lblNomorPolisiWarning.Text = "";
                    lblNomorPolisiWarning.Hide();
                    btnSimpan.Enabled = true;
                }
            }
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void linkLblSupir_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtSupirId.Clear();
            txtNamaSupir.Clear();
        }

        private void TrukEntryForm_Load(object sender, EventArgs e)
        {

        }
    }
}
