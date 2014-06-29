using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using domain.model;

namespace domain.service
{
    public interface ITrukService
    {
        Truk simpan(Truk domain);
        Truk simpanTrukAndPriceRute(Truk domain, IList<HargaRuteTruk> daftarHargaRuteTruk);
        Truk ubah(Truk domain);
        Truk hapus(Truk domain);
        Truk deleteTrukAndHargaRuteTruk(Truk domain);
        Truk cari(String id);
        Boolean validatePoliceNumber(String policeNumber);
        String nomorOtomatis();
        IList<Truk> cariDaftarTruk(String search); 
    }
}
