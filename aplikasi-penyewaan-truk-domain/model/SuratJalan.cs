using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace domain.model
{
    public class SuratJalan
    {
        private String id;

        public String Id
        {
            get { return id; }
            set { id = value; }
        }
        private Sewa sewa;

        public Sewa Sewa
        {
            get { return sewa; }
            set { sewa = value; }
        }
        private DateTime tanggal;

        public DateTime Tanggal
        {
            get { return tanggal; }
            set { tanggal = value; }
        }


    }
}
