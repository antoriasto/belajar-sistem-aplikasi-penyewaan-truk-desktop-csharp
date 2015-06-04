using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using domain.model;

namespace aplikasi_penyewaan_truk_domain.model
{
    public class Dph
    {
        private String id;
        private DateTime tanggal;
        private Customer customer;

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

        public Customer Customer
        {
            get { return customer; }
            set { customer = value; }
        }
             
    }
}
