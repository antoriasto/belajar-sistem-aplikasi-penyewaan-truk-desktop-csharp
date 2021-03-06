﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using core.implementasi;
using domain.service;
using domain.model;
using desktop.view.popup;
using desktop.utilities;

namespace desktop.view.entry
{
    public partial class SupirEntryForm : Form
    {
        ISupirService supirService;
        IKernetService kernetService;

        public SupirEntryForm(Supir supir)
        {
            InitializeComponent();
            supirService = new SupirServiceImpl();
            kernetService = new KernetServiceImpl();

            initializeForm(supir);
        }

        private void initializeForm(Supir supir)
        {
            if (supir != null)
            {
                Supir sup = supirService.cari(supir.Id);
                if (sup != null)
                {
                    btnSimpan.Text = "Ubah";
                    btnHapus.Show();

                    txtSupirId.Text = sup.Id;
                    txtNama.Text = sup.Nama;
                    txtAlamat.Text = sup.Alamat;
                    txtNoTelefon.Text = sup.NomorHp;

                    if (sup.Kernet != null)
                    {
                        Kernet kernet = kernetService.cari(sup.Kernet.Id);
                        if (kernet != null)
                        {
                            txtKernetId.Text = kernet.Id;
                            txtNamaKernet.Text = kernet.Nama;
                        }
                        else
                        {
                            txtKernetId.Clear();
                            txtNamaKernet.Clear();
                        }
                        
                    }
                    
                }
            }
        }

        private Boolean validasi()
        {
            if (txtNama.Text.Equals(""))
            {
                MessageBox.Show("Nama Supir Belum Di Input");
                return false;
            } 
            else if (txtAlamat.Text.Equals("")) 
            {
                MessageBox.Show("Alamat Supir Belum Di Input");
                return false;
            }
            else if (txtNoTelefon.Text.Equals(""))
            {
                MessageBox.Show("Nomor Telefon Belum Di Input");
                return false;
            }
            else
            {
                return true;
            }
            
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (validasi()) {
                Supir supir = new Supir();
                supir.Nama = txtNama.Text;
                supir.NomorHp = txtNoTelefon.Text;
                supir.Alamat = txtAlamat.Text;
                Kernet kernet = new Kernet();

                if (!txtKernetId.Text.Equals("")) {
                    kernet.Id = txtKernetId.Text;
                }

                supir.Kernet = kernet;

                if (txtSupirId.Text.Equals("")) {
                    if (supirService.simpan(supir) != null) {
                        MessageCustom.messageInfo("Supir", "Data Berhasil Di Simpan");
                        this.Dispose();
                    }
                    else {
                        MessageCustom.messageCritical("", "Data Gagal Di Simpan");
                    }
                } else {
                    supir.Id = txtSupirId.Text;
                    if (supirService.ubah(supir) != null) {
                        MessageBox.Show(supir.Kernet.Id);
                        MessageCustom.messageInfo("Supir", "Data Berhasil Di Ubah");
                        this.Dispose();
                    } else {
                        MessageCustom.messageCritical("Supir", "Data Gagal Di Ubah");
                    }
                }

            }
        }

        private void messageWarning(String judul, String pesan)
        {
            MessageBox.Show(pesan,
                            judul,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation,
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

        private void txtNoTelefon_Keypress(object sender, KeyPressEventArgs e)
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

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (!txtSupirId.Text.Equals(""))
            {
                Supir supir = new Supir();
                supir.Id = txtSupirId.Text;
                if (supirService.hapus(supir) != null)
                {
                    messageInfo("Supir Service", "Data Berhasil Dihapus");
                    this.Dispose();
                }
                else
                {
                    messageWarning("Supir Service", "Data Gagal Dihapus");
                }
            }
        }

        private void btnCariKernet_Click(object sender, EventArgs e)
        {
            KernetListForm j = null;
            if (j == null) {
                j = new KernetListForm(ProfilForm.Unknow, supirService.cariDaftarSupir(""));
                j.ShowDialog(this);

                if (j.GetKernet != null) {
                    txtKernetId.Text = j.GetKernet.Id;
                    txtNamaKernet.Text = j.GetKernet.Nama;

                    j.Dispose();

                }
            }
        }

        private void txtKernetId_TextChanged(object sender, EventArgs e)
        {
            if (txtKernetId.Text.Equals(""))
            {
                linkLblHapusKernet.Hide();
            }
            else
            {
                linkLblHapusKernet.Show();
            }
        }

        private void linkLblHapusKernet_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtKernetId.Text = "";
            txtNamaKernet.Text = "";
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void txtNoTelefon_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNoTelefon_KeyPress_1(object sender, KeyPressEventArgs e)
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

    }
}
