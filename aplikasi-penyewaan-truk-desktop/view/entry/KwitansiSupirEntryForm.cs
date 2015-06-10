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
    public partial class KwitansiSupirEntryForm : Form
    {
        ISewaService sewaService = new SewaServiceImpl();
        IKwitansiSupirService kwitansiSupirService = new KwitansiSupirServiceImpl();
        ICustomerService customerService = new CustomerServiceImpl();
        ISewaDetailService sewaDetailService = new SewaDetailServiceImpl();
        ITrukService trukService = new TrukServiceImpl();
        IJenisTrukService jenisTrukService = new JenisTrukServiceImpl();
        IHargaRuteTrukService hargaRuteTrukService = new HargaRuteTrukServiceImpl();
        IRuteService ruteService = new RuteServiceImpl();

        IList<SewaDetail> listSewaDetail;

        public KwitansiSupirEntryForm()
        {
            InitializeComponent();
            txtNoKwitansiSupir.Text = kwitansiSupirService.autoNumber();
        }

        private void btnCariSewa_Click(object sender, EventArgs e)
        {
            
        }

        private void initializeListView()
        {
            lvKwitansiSupir.Items.Clear();
            if (listSewaDetail != null)
            {
                if (listSewaDetail.Count > 0)
                {
                    foreach (SewaDetail s in listSewaDetail)
                    {
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

                        lvKwitansiSupir.Items.Add(items);
                    }
                }
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
           
        }

        private void KwitansiSupirEntryForm_Load(object sender, EventArgs e)
        {

        }

        private void btnCariSewa_Click_1(object sender, EventArgs e)
        {
            SewaListKwitansiForm h = new SewaListKwitansiForm();
            h.ShowDialog();
            if (h.GetSewaId != null)
            {
                if (!h.GetSewaId.Equals(""))
                {
                    //MessageBox.Show(s.GetSewaId);
                    Sewa sewa = sewaService.findById(h.GetSewaId);
                    txtNoSewa.Text = sewa.Id;
                    txtNamaCustomer.Text = customerService.cari(sewa.Customer.Id).Nama;
                    txtHargaTotal.Text = FormatRupiah.ToRupiah(Convert.ToInt64(sewa.TotalHargaSupir.ToString()));

                    // Isi data ke listview kwitansi pake parameter SEWA_ID
                    listSewaDetail = sewaDetailService.findAllData(h.GetSewaId);
                    initializeListView();
                }
            }
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSimpan_Click_1(object sender, EventArgs e)
        {   
            if (txtNoKwitansiSupir.Text.Equals(""))
            {
                MessageCustom.messageWarning("Kwitansi Supir", "Nomor Sewa Belum Di Input");
                return;
            }
            else
            {
                KwitansiSupir ks = new KwitansiSupir();
                ks.Id = txtNoKwitansiSupir.Text;
                ks.Tanggal = DateTime.Now;
                ks.Sewa = new Sewa(txtNoSewa.Text);

                if (kwitansiSupirService.save(ks) != null)
                {
                    MessageCustom.messageInfo("Kwitansi Supir", "Data Berhasil Di Simpan");
                    printedReport();
                    this.Dispose();
                }
                else
                {
                    MessageCustom.messageCritical("Kwitansi Supir", "Data Gagal Di Simpan");
                }
            }
        }

        private void printedReport()
        {
            // Create a CrystalReport1 object 
            KwitansiSupirPrinted myReport = new KwitansiSupirPrinted();
            myReport.SetParameterValue("PARAM_KWITANSI_SUPIR", txtNoKwitansiSupir.Text);
            // Set the DataSource of the report 
            //myReport.SetDataSource(custDB); 
            // Set the Report Source to ReportView 
            ShowReportForm sf = new ShowReportForm();
            sf.crystalReportViewer1.ReportSource = myReport;
            sf.ShowDialog();
        }

        private void btnCariSewa_MouseClick(object sender, MouseEventArgs e)
        {

        }
    }
}
