﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace domain.model
{
    public class SuratJalan
    {
        private String id;
        private Sewa sewa;
        private DateTime tanggal;

        public SuratJalan() { }

        public SuratJalan(String id) {
            this.id = id;
        }

        public String Id
        {
            get { return id; }
            set { id = value; }
        }

        public Sewa Sewa
        {
            get { return sewa; }
            set { sewa = value; }
        }

        public DateTime Tanggal
        {
            get { return tanggal; }
            set { tanggal = value; }
        }


    }
}