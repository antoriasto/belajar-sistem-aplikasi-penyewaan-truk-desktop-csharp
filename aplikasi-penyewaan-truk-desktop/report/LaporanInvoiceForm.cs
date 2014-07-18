using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace desktop.report
{
    public partial class LaporanInvoiceForm : Form
    {
        public LaporanInvoiceForm()
        {
            InitializeComponent();
        }


        private void btnBatal_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnCetak_Click(object sender, EventArgs e)
        {
            printedReport();
        }

         /*
         * ------------
         * Cetak Report
         * ------------
         * */
        private void printedReport()
        {
            // Create a CrystalReport1 object 
            InvoiceReport myReport = new InvoiceReport();
            myReport.SetParameterValue("PARAM_START_DATE", dtpStart.Value);

            myReport.SetParameterValue("PARAM_END_DATE", dtpEnd.Value);
            // Set the DataSource of the report 
            //myReport.SetDataSource(custDB); 
            // Set the Report Source to ReportView 
            ShowReportForm sf = new ShowReportForm();
            sf.crystalReportViewer1.ReportSource = myReport;
            sf.crystalReportViewer1.Zoom(100);
            sf.Show();
        }
    }
}
