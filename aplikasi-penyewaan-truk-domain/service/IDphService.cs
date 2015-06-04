using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using aplikasi_penyewaan_truk_domain.model;

namespace aplikasi_penyewaan_truk_domain.service
{
    public interface IDphService
    {
        Dph save(Dph domain);
        String autoNumber();
    }
}
