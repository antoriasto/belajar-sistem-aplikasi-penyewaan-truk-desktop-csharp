using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using aplikasi_penyewaan_truk_domain.model;

namespace aplikasi_penyewaan_truk_domain.service
{
    public interface ITrukService
    {
        Truk simpan(Truk truk);
        Truk ubah(Truk truk);
        Truk delete(Truk customer);
        Truk cari(String id);
        String nomorOtomatis();
        IList<Truk> cariDaftarTruk(String search);
    }
}
