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
using ComponentOwl.BetterListView;
using desktop.utilities;
using desktop.report;
using CrystalDecisions.ReportSource;

namespace desktop.view.entry
{
    public partial class SuratJalanEntryForm : Form
    {
        ISewaService sewaService = new SewaServiceImpl();
        ISuratJalanService suratJalanService = new SuratJalanServiceImpl();
        ICustomerService customerService = new CustomerServiceImpl();
        ISewaDetailService sewaDetailService = new SewaDetailServiceImpl();
        ITrukService trukService = new TrukServiceImpl();
        IJenisTrukService jenisTrukService = new JenisTrukServiceImpl();
        IHargaRuteTrukService hargaRuteTrukService = new HargaRuteTrukServiceImpl();
        IRuteService ruteService = new RuteServiceImpl();

        IList<SewaDetail> listSewaDetail;

        public SuratJalanEntryForm()
        {
            InitializeComponent();
            txtNoSuratJalan.Text = suratJalanService.autoNumber();
        }

        private void btnCariSewa_Click(object sender, EventArgs e)
        {
            SewaListForm s = new SewaListForm();
            s.ShowDialog();
            if (s.GetSewaId != null) 
            {
                if (!s.GetSewaId.Equals("")) {
                    MessageBox.Show(s.GetSewaId);
                    Sewa sewa = sewaService.findById(s.GetSewaId);
                    txtNoSewa.Text = sewa.Id;
                    txtNamaCustomer.Text = customerService.cari(sewa.Customer.Id).Nama;
                    txtHargaTotal.Text = FormatRupiah.ToRupiah(Convert.ToInt64(sewa.TotalHarga.ToString()));

                    // Isi data ke listview surat jalan pake parameter SEWA_ID
                    listSewaDetail = sewaDetailService.findAllData(s.GetSewaId);
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
                        items.SubItems.Add(s.Truk.Id);
                        Truk truk = trukService.cari(s.Truk.Id);
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
                MessageCustom.messageWarning("Surat Jalan", "Nomor Sewa Belum Di Input");
                return;
            } else {
                SuratJalan sj = new SuratJalan();
                sj.Id = txtNoSuratJalan.Text;
                sj.Tanggal = new DateTime();
                sj.Sewa = new Sewa(txtNoSewa.Text);

                if (suratJalanService.save(sj) != null) {
                    MessageCustom.messageInfo("Surat Jalan", "Data Berhasil Di Simpan");
                    printedReport();
                    this.Dispose();
                } else {
                    MessageCustom.messageCritical("Surat Jalan", "Data Gagal Di Simpan");
                }
            }
        }

        private void printedReport() {
            // Create a CrystalReport1 object 
            SuratJalanPrinted myReport = new SuratJalanPrinted(); 
            // Set the DataSource of the report 
            //myReport.SetDataSource(custDB); 
            // Set the Report Source to ReportView 
            ShowReportForm sf = new ShowReportForm();
            sf.crystalReportViewer1.ReportSource = myReport;
            sf.ShowDialog();
        }


    }
}
