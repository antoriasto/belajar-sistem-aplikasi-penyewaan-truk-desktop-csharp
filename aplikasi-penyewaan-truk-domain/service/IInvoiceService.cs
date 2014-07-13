using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using domain.model;

namespace domain.service
{
    public interface IInvoiceService
    {
        Invoice save(Invoice invoice, IList<Truk> listTruk);
        String autoNumber();
    }
}
