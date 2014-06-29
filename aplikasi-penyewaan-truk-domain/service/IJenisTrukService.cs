using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using domain.model;

namespace domain.service
{
    public interface IJenisTrukService
    {
        JenisTruk simpan(JenisTruk domain);
        JenisTruk ubah(JenisTruk domain);
        JenisTruk hapus(JenisTruk domain);
        JenisTruk cari(String id);
        String nomorOtomatis();
        IList<JenisTruk> cariDaftarJenisTruk(String search);
    }
}
