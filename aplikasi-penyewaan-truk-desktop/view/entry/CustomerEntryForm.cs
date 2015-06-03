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
    public partial class CustomerEntryForm : Form
    {
        ICustomerService customerService;

        public CustomerEntryForm(Customer customer)
        {
            InitializeComponent();
            customerService = new CustomerServiceImpl();
            initializeForm(customer);
        }

        private void initializeForm(Customer customer) {

            if (customer == null) {
                lblKernetId.Hide();
                txtCustomerId.Hide();
                btnHapus.Hide();
            } else {
                Customer c = customerService.cari(customer.Id);
                txtCustomerId.Text = c.Id;
                txtNama.Text = c.Nama;
                txtAlamat.Text = c.Alamat;
                txtNoTelefon.Text = c.Telefon;
                btnHapus.Show();
                btnSimpan.Text = "Ubah";
            }

        }

        private void txtNoTelefon_KeyPress(object sender, KeyPressEventArgs e)
        {
            /// Disable Penggunaan karakter di textbox
            if (char.IsDigit(e.KeyChar) || (int)e.KeyChar == 8) {
                e.Handled = false;
            } else {
                e.Handled = true;
            }
        }

        private Boolean validasi() {

            if (txtNama.Text.Equals("")) {
                MessageCustom.messageWarning("Validasi", "Nama Kernet Belum Di Isi");
                return false;
            }
            else if (txtNoTelefon.Text.Equals("")) {
                MessageCustom.messageWarning("Validasi", "Nomor Telefon Belum Di Isi");
                return false;
            }
            else if (txtAlamat.Text.Equals("")) {
                MessageCustom.messageWarning("Validasi", "Alamat Belum Di Isi");
                return false;
            }

            return true;
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (validasi()) {
                Customer c = new Customer();
                c.Nama = txtNama.Text;
                c.Telefon = txtNoTelefon.Text;
                c.Alamat = txtAlamat.Text;

                if (txtCustomerId.Text.Equals("")) {
                    c.Id = customerService.nomorOtomatis();
                    if (customerService.save(c) != null) {
                        MessageCustom.messageInfo("Customer", "Data Berhasil Disimpan");
                        this.Dispose();
                    } else {
                        MessageCustom.messageCritical("Customer", "Data Gagal Disimpan");
                    }
                } else if (!txtCustomerId.Text.Equals("")) {
                    c.Id = txtCustomerId.Text;
                    if (customerService.update(c) != null) {
                        MessageCustom.messageInfo("Customer", "Data Berhasil Diubah");
                        this.Dispose();
                    } else {
                        MessageCustom.messageCritical("Customer", "Data Gagal Diubah");
                    }
                }

            }

        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (!txtCustomerId.Text.Equals(""))
            {
                Customer customer = new Customer();
                customer.Id = txtCustomerId.Text;
                if (customerService.hapus(customer) != null)
                {
                    messageInfo("Customer Service", "Data Berhasil Dihapus");
                    this.Dispose();
                }
                else
                {
                    messageWarning("Customer Service", "Data Gagal Dihapus");
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

        private void txtAlamat_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
