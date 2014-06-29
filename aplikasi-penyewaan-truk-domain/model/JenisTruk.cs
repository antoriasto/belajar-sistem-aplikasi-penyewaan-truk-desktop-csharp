using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace domain.model
{
    public class JenisTruk
    {
        private String id;
        private String nama;
        private Int32 kubikasi;
        private Decimal tonase;

        public JenisTruk() { }

        public JenisTruk(String id) 
        {
            this.id = id;
        }

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

        public Int32 Kubikasi
        {
            get { return kubikasi; }
            set { kubikasi = value; }
        }

        public Decimal Tonase
        {
            get { return tonase; }
            set { tonase = value; }
        }
    }
}
