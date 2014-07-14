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
using desktop.utilities;

namespace desktop.view.entry
{
    public partial class RuteEntryForm : Form
    {
        IRuteService ruteService;

        public RuteEntryForm(Rute rute)
        {
            InitializeComponent();
            ruteService = new RuteServiceImpl();
            initializeForm(rute);
        }

        private void initializeForm(Rute rute)
        {
            if (rute != null)
            {
                Rute r = ruteService.cari(rute.Id);
                txtRuteId.Text = r.Id;
                txtNamaRute.Text = r.Nama;

                btnHapus.Show();
                btnSimpan.Text = "Ubah";
            }
        }

        private Boolean validasi()
        {
            if (txtNamaRute.Text.Equals(""))
            {
                MessageCustom.messageWarning("Rute", "Nama Rute Belum Di Isi");
            }
            return true;
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (validasi())
            {
                Rute rute = new Rute();
                rute.Nama = txtNamaRute.Text;

                if (txtRuteId.Text.Equals(""))
                {
                    if (ruteService.simpan(rute) != null)
                    {
                        MessageCustom.messageInfo("Rute", "Data Berhasil Di Simpan");
                        this.Dispose();
                    }
                    else
                    {
                        MessageCustom.messageCritical("Rute", "Data Gagal Di Simpan");
                    }

                }
                else
                {
                    rute.Id = txtRuteId.Text;
                    if (ruteService.ubah(rute) != null)
                    {
                        MessageCustom.messageInfo("Rute", "Data Berhasil Di Ubah");
                        this.Dispose();
                    }
                    else
                    {
                        MessageCustom.messageCritical("Rute", "Data Gagal Di Ubah");
                    }
                }

            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (!txtRuteId.Text.Equals(""))
            {
                Rute rute = new Rute();
                rute.Id = txtRuteId.Text;
                if (ruteService.hapus(rute) != null)
                {
                    MessageCustom.messageInfo("Rute", "Data Berhasil Di Hapus");
                    this.Dispose();
                }
                else
                {
                    MessageCustom.messageCritical("Rute", "Data Gagal Di Hapus");
                }
            }
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

    }
}
