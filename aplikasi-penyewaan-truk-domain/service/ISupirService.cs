using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using domain.model;

namespace domain.service
{
    public interface ISupirService
    {
        Supir simpan(Supir domain);
        Supir ubah(Supir domain);
        Supir hapus(Supir domain);
        Supir cari(String id);
        String nomorOtomatis();
        IList<Supir> cariDaftarSupir(String search);
    }
}
