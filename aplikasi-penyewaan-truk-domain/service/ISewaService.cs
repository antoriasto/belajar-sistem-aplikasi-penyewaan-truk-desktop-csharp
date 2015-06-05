using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using domain.model;

namespace domain.service
{
    public interface ISewaService
    {
        Sewa save(Sewa sewa);
        Sewa save(Sewa sewa, IList<SewaDetail> detailSewa);
        Sewa findById(String id);
        String autoNumber();
        IList<Sewa> findAllData(String search);
        IList<Sewa> findAllDataNotInKwitansi();
    }
}
