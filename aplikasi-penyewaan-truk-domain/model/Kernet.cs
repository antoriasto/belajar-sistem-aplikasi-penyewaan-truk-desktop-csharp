using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace aplikasi_penyewaan_truk_domain.model
{
    public class Kernet
    {
        private String id;
        private String nama;
        private String alamat;
        private String nomorHp;

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

        public String Alamat
        {
            get { return alamat; }
            set { alamat = value; }
        }

        public String NomorHp
        {
            get { return nomorHp; }
            set { nomorHp = value; }
        }

    }
}
