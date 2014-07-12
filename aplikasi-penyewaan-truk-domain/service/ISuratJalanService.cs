using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using aplikasi_penyewaan_truk_domain.model;

namespace domain.service
{
    public interface ISuratJalanService
    {
        SuratJalan save(SuratJalan suratJalan);
        IList<SuratJalan> findAllData();
    }
}
