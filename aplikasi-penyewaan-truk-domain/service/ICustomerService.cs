using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using aplikasi_penyewaan_truk_domain.model;

namespace aplikasi_penyewaan_truk_domain.service
{
    public interface ICustomerService
    {
        Customer simpan(Customer customer);
        Customer ubah(Customer customer);
        Customer delete(Customer customer);
        Customer cari(String id);
        IList<Customer> cariDaftarCustomer(String search);
    }
}
