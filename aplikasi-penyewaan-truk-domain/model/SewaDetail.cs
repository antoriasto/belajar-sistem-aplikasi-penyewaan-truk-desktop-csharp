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

        // custom field.
        private Truk truk;

        public SewaDetail() { }

        public SewaDetail(String id, Decimal price, Truk truk) {
            this.id = id;
            this.price = price;
            this.truk = truk;
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

        public Truk Truk
        {
            get { return truk; }
            set { truk = value; }
        }

    }
}
