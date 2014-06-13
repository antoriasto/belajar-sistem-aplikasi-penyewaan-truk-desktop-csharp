using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace aplikasi_penyewaan_truk_domain.model
{
    public class Customer
    {
        private String id;
        private String nama;
        private String alamat;
        private String telefon;

        public String Id
        {
            get { return id; }
            set { id = value; }
        }

        public String Nama
        {
            get { return nama; }
            set { nama = value; }
        }

        public String Telefon
        {
            get { return telefon; }
            set { telefon = value; }
        }

        public String Alamat
        {
            get { return alamat; }
            set { alamat = value; }
        }

    }
}
