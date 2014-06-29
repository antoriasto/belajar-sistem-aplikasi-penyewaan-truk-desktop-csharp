using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using domain.model;

namespace domain.service
{
    public interface ICustomerService
    {
        Customer save(Customer domain);
        Customer update(Customer domain);
        Customer hapus(Customer domain);
        String nomorOtomatis();
        Customer cari(String id);
        IList<Customer> cariDaftarCustomer(String search);
    }
}
