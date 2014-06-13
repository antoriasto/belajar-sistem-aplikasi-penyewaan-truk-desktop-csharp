using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace aplikasi_penyewaan_truk_domain.model
{
    public class DetailSewaTruk
    {
        private String id;
        private Decimal subTotal;

        // custom field.
        private Customer customer;

        public String Id
        {
            get { return id; }
            set { id = value; }
        }

        public Decimal SubTotal
        {
            get { return subTotal; }
            set { subTotal = value; }
        }

        public Customer Customer
        {
            get { return customer; }
            set { customer = value; }
        }

    }
}
