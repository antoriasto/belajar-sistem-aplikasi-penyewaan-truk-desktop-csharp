using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace domain.model
{
    public class Sewa
    {
        private String id;
        private DateTime tanggal;
        private Decimal totalHarga;

        // custom field.
        private Customer customer;

        public Sewa() { }

        public Sewa(String id) {
            this.id = id;
        }

        public String Id
        {
            get { return id; }
            set { id = value; }
        }

        public DateTime Tanggal
        {
            get { return tanggal; }
            set { tanggal = value; }
        }

        public Decimal TotalHarga
        {
            get { return totalHarga; }
            set { totalHarga = value; }
        }

        public Customer Customer
        {
            get { return customer; }
            set { customer = value; }
        }

    }
}
