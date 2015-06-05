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
using desktop.view.popup;
using domain.model;
using desktop.utilities;
using ComponentOwl.BetterListView;
using desktop.report;

namespace desktop.view.entry
{
    public partial class InvoiceEntryForm : Form
    {
        ISewaService sewaService = new SewaServiceImpl();
        ISuratJalanService suratJalanService = new SuratJalanServiceImpl();
        ICustomerService customerService = new CustomerServiceImpl();
        ISewaDetailService sewaDetailService = new SewaDetailServiceImpl();
        ITrukService trukService = new TrukServiceImpl();
        IJenisTrukService jenisTrukService = new JenisTrukServiceImpl();
        IHargaRuteTrukService hargaRuteTrukService = new HargaRuteTrukServiceImpl();
        IRuteService ruteService = new RuteServiceImpl();
        IInvoiceService invoiceService = new InvoiceServiceImpl();

        IList<SewaDetail> listSewaDetail;

        public InvoiceEntryForm()
        {
            InitializeComponent();
            txtNoInvoice.Text = invoiceService.autoNumber();
        }

        private void btnCariSuratJalan_Click(object sender, EventArgs e)
        {
            SuratJalanListForm sj = new SuratJalanListForm();
            sj.ShowDialog();
            if (sj.SuratJalanId != null) 
            {
                if (!sj.SuratJalanId.Equals("")) {
                    SuratJalan suratJalan = suratJalanService.findById(sj.SuratJalanId);
                    txtNoSuratJalan.Text = suratJalan.Id;
                    Sewa sewa = sewaService.findById(suratJalan.Sewa.Id);
                    txtNamaCustomer.Text = customerService.cari(sewa.Customer.Id).Nama;
                    txtHargaTotal.Text = FormatRupiah.ToRupiah(Convert.ToInt64(sewa.TotalHarga.ToString()));

                    // Isi data ke listview surat jalan pake parameter SEWA_ID
                    listSewaDetail = sewaDetailService.findAllData(suratJalan.Sewa.Id);
                    initializeListView();
                }
            }
        }

        private void initializeListView() 
        {
            lvSuratJalan.Items.Clear();
            if (listSewaDetail != null) {
                if (listSewaDetail.Count > 0) {
                    foreach (SewaDetail s in listSewaDetail) {
                        BetterListViewItem items = new BetterListViewItem(s.Id);
                        items.SubItems.Add(s.HargaRuteTruk.Id);
                        HargaRuteTruk h = hargaRuteTrukService.findById(s.HargaRuteTruk.Id);

                        Truk truk = trukService.cari(h.Truk.Id);
                        JenisTruk jenisTruk = jenisTrukService.cari(truk.JenisTruk.Id);
                        items.SubItems.Add(truk.NomorPolisi);
                        items.SubItems.Add(truk.JenisTruk.Id);
                        items.SubItems.Add(jenisTruk.Nama);
                        items.SubItems.Add(FormatRupiah.ToRupiah(Convert.ToInt64(s.Price.ToString())));
                        items.SubItems.Add(s.Keterangan);

                        lvSuratJalan.Items.Add(items);
                    }
                }
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (txtNoSuratJalan.Text.Equals("")) {
                MessageCustom.messageWarning("Invoice", "Nomor Surat Jalan Belum Di Cari");
                return;
            }
            
            Invoice invoice = new Invoice();
            invoice.Id = txtNoInvoice.Text;
            invoice.Tanggal = DateTime.Now;
            invoice.SuratJalan = new SuratJalan(txtNoSuratJalan.Text);

            IList<Truk> listTruk = new List<Truk>();
            if (listTruk.Count > 0)
            {
                foreach (SewaDetail s in listSewaDetail)
                {
                    listTruk.Add(new Truk(s.Truk.Id));
                }
            }
            

            if (invoiceService.save(invoice, listTruk)!= null) {
                MessageCustom.messageInfo("Invoice", "Data Berhasil Di Simpan");
                printedReport();
                this.Dispose();
            } else {
                MessageCustom.messageCritical("Invoice", "Data Gagal Di Simpan");
            }
        }

        private void printedReport() {
            // Create a CrystalReport1 object 
            InvoicePrinted myReport = new InvoicePrinted();
            myReport.SetParameterValue("PARAM_NO_INVOICE", txtNoInvoice.Text);
            // Set the DataSource of the report 
            //myReport.SetDataSource(custDB); 
            // Set the Report Source to ReportView 
            ShowReportForm sf = new ShowReportForm();
            sf.crystalReportViewer1.ReportSource = myReport;
            sf.ShowDialog();
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }



    }
}
