using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace domain.model
{
    public class Supir
    {
        private String id;
        private String nama;
        private String alamat;
        private String nomorHp;

        // kernet field
        private Kernet kernet;

        public Supir() { }

        public Supir(String id)
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

        public Kernet Kernet
        {
            get { return kernet; }
            set { kernet = value; }
        }
    }
}
