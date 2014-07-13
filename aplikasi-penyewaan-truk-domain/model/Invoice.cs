using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using domain.model;

namespace domain.model
{
    public class Invoice
    {
        private String id;
        private DateTime tanggal;
        private SuratJalan suratJalan;

        public String Id
        {
            get { return id; }
            set { id = value; }
        }
        
        public DateTime Tanggal
        {
            get { return tanggal; }
            set { tanggal = value; }
        }
        
        public SuratJalan SuratJalan
        {
            get { return suratJalan; }
            set { suratJalan = value; }
        }
    }
}
