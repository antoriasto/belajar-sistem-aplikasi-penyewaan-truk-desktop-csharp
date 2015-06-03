using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace domain.model
{
    public class SewaDetail
    {
        private String id;
        private Decimal price;
        private String keterangan;
        private Decimal harga_supir;


        // custom field.
        private Truk truk;

        private HargaRuteTruk hargaRuteTruk;

        public SewaDetail() { }

        public SewaDetail(String id, Decimal price, Decimal harga_supir, Truk truk) {
            this.id = id;
            this.price = price;
            this.harga_supir = harga_supir;
            this.truk = truk;
        }

        public HargaRuteTruk HargaRuteTruk
        {
            get { return hargaRuteTruk; }
            set { hargaRuteTruk = value; }
        }

        public String Id
        {
            get { return id; }
            set { id = value; }
        }

        public Decimal Price
        {
            get { return price; }
            set { price = value; }
        }

        public Decimal Harga_supir
        {
            get { return harga_supir; }
            set { harga_supir = value; }
        }

        public Truk Truk
        {
            get { return truk; }
            set { truk = value; }
        }

        public String Keterangan
        {
            get { return keterangan; }
            set { keterangan = value; }
        }

    }
}
