using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace domain.model
{
    public class Rute
    {
        private String id;
        private String nama;

        // Constructor.
        public Rute() { }

        public Rute(String id)
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

    }
}
