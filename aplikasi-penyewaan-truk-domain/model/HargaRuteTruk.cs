using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using domain.model.enumerasi;

namespace domain.model
{
    public class HargaRuteTruk
    {
        private String id;
        private Decimal harga;
        private Decimal harga_supir;

        // Custom field.
        private Truk truk;
        private Rute rute;

        // Additional feld.
        private Command status;

        // Field Tambahan, ini salah konsep.
        private String keterangan;

        public HargaRuteTruk() { }

        public HargaRuteTruk(String id) { this.id = id; }

        public String Keterangan
        {
            get { return keterangan; }
            set { keterangan = value; }
        }

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

        public Rute Rute
        {
            get { return rute; }
            set { rute = value; }
        }

        public Command Status
        {
            get { return status; }
            set { status = value; }
        }

    }
}
