using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using domain.model;

namespace domain.service
{
    public interface IKernetService
    {
        Kernet simpan(Kernet domain);
        Kernet ubah(Kernet domain);
        Kernet hapus(Kernet domain);
        Kernet cari(String id);
        String nomorOtomatis();
        IList<Kernet> cariDaftarKernet(String search);
    }
}
