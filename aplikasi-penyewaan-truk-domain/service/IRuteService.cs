using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using domain.model;

namespace domain.service
{
    public interface IRuteService
    {
        Rute simpan(Rute domain);
        Rute ubah(Rute domain);
        Rute hapus(Rute domain);
        Rute cari(String id);
        String nomorOtomatis();
        IList<Rute> cariDaftarRute(String search);
    }
}
