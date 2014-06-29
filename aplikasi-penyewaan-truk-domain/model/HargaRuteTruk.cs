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

        // Custom field.
        private Truk truk;
        private Rute rute;

        // Additional feld.
        private Command status;

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

        public Command Status
        {
            get { return status; }
            set { status = value; }
        }

    }
}
