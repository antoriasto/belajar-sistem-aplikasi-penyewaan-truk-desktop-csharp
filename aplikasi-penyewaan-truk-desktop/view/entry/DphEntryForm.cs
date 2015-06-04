using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using aplikasi_penyewaan_truk_domain.service;
using core.implementasi;
using desktop.view.popup;
using desktop.utilities;
using domain.model;
using domain.service;
using aplikasi_penyewaan_truk_domain.model;

namespace desktop.view.entry
{
    public partial class DphEntryForm : Form
    {
        IDphService dphService = new DphServiceImpl();
        ICustomerService customerService = new CustomerServiceImpl();

        public DphEntryForm()
        {
            InitializeComponent();
            txtNoDph.Text = dphService.autoNumber();
        }

        private void btnCariCustomer_Click(object sender, EventArgs e)
        {
            CustomerListForm c = new CustomerListForm(ProfilForm.Unknow);
            c.ShowDialog();

            if (c.GetCustomer != null)
            {
                String id = c.GetCustomer.Id;
                if (!id.Equals(""))
                {
                    Customer cst = customerService.cari(id);
                    txtCustomerId.Text = cst.Id;
                    txtCustomerNama.Text = cst.Nama;
                    txtCustomerTelefon.Text = cst.Telefon;
                    txtCustomerAlamat.Text = cst.Alamat;
                }
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (validasiSave())
            {
                Dph dph = new Dph();
                dph.Id = dphService.autoNumber();
                dph.Tanggal = new DateTime();
                dph.Customer = new Customer(txtCustomerId.Text);

                if (dphService.save(dph) != null)
                {
                    MessageCustom.messageInfo("DPH", "Data Berhasil Disimpan");
                    this.Dispose();
                }
                else
                {
                    MessageCustom.messageCritical("DPH", "Data Gagal Disimpan");
                    this.Dispose();
                }
            }
        }

        private Boolean validasiSave()
        {
            if (txtCustomerId.Text.Equals(""))
            {
                MessageCustom.messageWarning("DPH", "Customer Belum Dipilih");
                return false;
            }

            return true;
        }
    
    }
}
