using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace domain.model
{
    public class Truk
    {
        private String id;
        private String nomorPolisi;
        private String status;

        // Custom field.
        private Supir supir;
        private JenisTruk jenisTruk;
        private IList<HargaRuteTruk> listHargaRuteTruk;

        // Constructor.
        public Truk() { }

        public Truk(String id)
        {
            this.id = id;
        }

        public String Id
        {
            get { return id; }
            set { id = value; }
        }

        public String Status
        {
            get { return status; }
            set { status = value; }
        }

        public String NomorPolisi
        {
            get { return nomorPolisi; }
            set { nomorPolisi = value; }
        }

        public Supir Supir
        {
            get { return supir; }
            set { supir = value; }
        }

        public JenisTruk JenisTruk
        {
            get { return jenisTruk; }
            set { jenisTruk = value; }
        }

        public IList<HargaRuteTruk> ListHargaRuteTruk
        {
            get { return listHargaRuteTruk; }
            set { listHargaRuteTruk = value; }
        }

    }
}
