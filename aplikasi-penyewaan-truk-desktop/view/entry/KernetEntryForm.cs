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

namespace desktop.view.entry
{
    public partial class KernetEntryForm : Form
    {
        IKernetService kernetService = new KernetServiceImpl();
        Kernet kernet;

        public KernetEntryForm(Kernet kernet)
        {
            InitializeComponent();
            this.kernet = kernet;
            initializeForm(kernet);
        }

        private void initializeForm(Kernet kernet)
        {
            if (kernet == null)
            {
                lblKernetId.Hide();
                txtKernetId.Hide();
                btnHapus.Hide();
            }
            else
            {
                kernet = kernetService.cari(kernet.Id);
                txtKernetId.Text = kernet.Id;
                txtNama.Text = kernet.Nama;
                txtAlamat.Text = kernet.Alamat;
                txtNoTelefon.Text = kernet.NomorHp;
                btnSimpan.Text = "Update";
                btnHapus.Show();
            }
            
        }

        private Boolean validasi()
        {
            if (txtNama.Text.Equals(""))
            {
                messageWarning("Validasi", "Nama Kernet Belum Di Isi");
                return false;
            }
            else if (txtNoTelefon.Text.Equals(""))
            {
                messageWarning("Validasi", "Nomor Telefon Belum Di Isi");
                return false;
            }
            else if (txtAlamat.Text.Equals(""))
            {
                messageWarning("Validasi", "Alamat Belum Di Isi");
                return false;
            }

            return true;
        }

        private void messageWarning(String judul, String pesan)
        {
            MessageBox.Show(pesan,
                            judul,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation,
                            MessageBoxDefaultButton.Button1);
        }

        private void messageCritical(String judul, String pesan)
        {
            MessageBox.Show(pesan,
                            judul,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error,
                            MessageBoxDefaultButton.Button1);
        }

        private void messageInfo(String judul, String pesan)
        {
            MessageBox.Show(pesan,
                            judul,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button1);
        }

        private void txtNoTelefon_KeyPress(object sender, KeyPressEventArgs e)
        {
            /// Disable Penggunaan karakter di textbox
            if (char.IsDigit(e.KeyChar) || (int)e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (validasi())
            {
                Kernet kernet = new Kernet();
                kernet.Nama = txtNama.Text;
                kernet.NomorHp = txtNoTelefon.Text;
                kernet.Alamat = txtAlamat.Text;

                // Jika Kernet Null Save.
                // Kalo Ga Null Update.
                if (this.kernet == null)
                {
                    kernet.Id = kernetService.nomorOtomatis();
                    if (kernetService.simpan(kernet) != null)
                    {
                        messageInfo("Kernet Service","Data Berhasil Disimpan");
                        this.Dispose();
                    }
                    else
                    {
                        messageWarning("Kernet Service", "Data Gagal Disimpan");
                    }
                }
                else
                {
                    kernet.Id = txtKernetId.Text;
                    if (kernetService.ubah(kernet) != null)
                    {
                        messageInfo("Kernet Service", "Data Berhasil Diubah");
                        this.Dispose();
                    }
                    else
                    {
                        messageWarning("Kernet Service", "Data Gagal Diubah");
                    }
                }
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (!txtKernetId.Text.Equals(""))
            {
                Kernet kernet = new Kernet();
                kernet.Id = txtKernetId.Text;
                if (kernetService.hapus(kernet) != null)
                {
                    messageInfo("Kernet Service", "Data Berhasil Dihapus");
                    this.Dispose();
                }
                else
                {
                    messageWarning("Kernet Service", "Data Gagal Dihapus");
                }
            }
        }

    }
}
