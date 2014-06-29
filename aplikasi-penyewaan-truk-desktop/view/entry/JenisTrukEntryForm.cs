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
using desktop.utilities;
using domain.model;

namespace desktop.view.entry
{
    public partial class JenisTrukEntryForm : Form
    {
        IJenisTrukService jenisTrukService;

        public JenisTrukEntryForm(JenisTruk jenisTruk)
        {
            InitializeComponent();
            jenisTrukService = new JenisTrukServiceImpl();

            nuTonase.Value = 1;
            nuTonase.Minimum = -10;
            nuTonase.Increment = .01m;    //  decimal
            nuTonase.DecimalPlaces = 2;

            initializeForm(jenisTruk);

        }

        private void initializeForm(JenisTruk jenisTruk)
        {
            if (jenisTruk == null) {
                lblJenisTrukId.Hide();
                txtJenisTrukId.Hide();
            } else {
                JenisTruk j = jenisTrukService.cari(jenisTruk.Id);
                if (j != null) {
                    txtJenisTrukId.Text = j.Id;
                    txtNamaJenis.Text = j.Nama;
                    nuKubikasi.Value = j.Kubikasi;
                    nuTonase.Value = j.Tonase;

                    btnSimpan.Text = "Ubah";
                    btnHapus.Show();
                }
            }
        }

        private Boolean validasi()
        {
            if (txtNamaJenis.Text.Equals("")) {
                MessageCustom.messageWarning("Jenis Truk", "Jenis Truk Belum Di Isi");
                return false;
            }

            return true;
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (validasi()) {
                JenisTruk jenisTruk = new JenisTruk();
                jenisTruk.Nama = txtNamaJenis.Text;
                jenisTruk.Kubikasi = Convert.ToInt32(nuKubikasi.Value);
                jenisTruk.Tonase = nuTonase.Value;

                if (txtJenisTrukId.Text.Equals("")) {
                    if (jenisTrukService.simpan(jenisTruk) != null) {
                        MessageCustom.messageInfo("Jenis Truk", "Data Berhasil Disimpan");
                        this.Dispose();
                    } else {
                        MessageCustom.messageCritical("Jenis Truk", "Data Gagal Disimpan");
                    }
                } else if (!txtJenisTrukId.Text.Equals("")) {
                    jenisTruk.Id = txtJenisTrukId.Text;
                    if (jenisTrukService.ubah(jenisTruk) != null) {
                        MessageCustom.messageInfo("Jenis Truk", "Data Berhasil Di Ubah");
                        this.Dispose();
                    } else {
                        MessageCustom.messageCritical("Jenis Truk", "Data Gagal Di Ubah");
                    }
                }
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (!txtJenisTrukId.Text.Equals("")) {
                JenisTruk jenisTruk = new JenisTruk();
                jenisTruk.Id = txtJenisTrukId.Text;

                if (jenisTrukService.hapus(jenisTruk) != null) {
                    MessageCustom.messageInfo("Jenis Truk", "Data Berhasil Di Hapus");
                } else {
                    MessageCustom.messageCritical("Jenis Truk", "Data Gagal Di Hapus");
                }
            }
        }

    }
}
