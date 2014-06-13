using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace aplikasi_penyewaan_truk_domain.model
{
    public class HargaRuteTruk
    {
        private String id;
        private Decimal harga;

        // Custom field.
        private Truk truk;
        private Rute rute;

        public String Id
        {
            get { return id; }
            set { id = value; }
        }

        public Decimal Harga
        {
            get { return harga; }
            set { harga = value; }
        }

        public Truk Truk
        {
            get { return truk; }
            set { truk = value; }
        }

        public Rute Rute
        {
            get { return rute; }
            set { rute = value; }
        }
    }
}
