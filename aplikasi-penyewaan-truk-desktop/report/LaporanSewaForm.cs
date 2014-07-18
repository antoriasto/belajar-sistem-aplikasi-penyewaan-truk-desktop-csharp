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
    public partial class LaporanSewaForm : Form
    {
        public LaporanSewaForm()
        {
            InitializeComponent();
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnCetak_Click(object sender, EventArgs e)
        {

        }
    }
}
