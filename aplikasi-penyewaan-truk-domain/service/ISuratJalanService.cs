﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using domain.model;

namespace domain.service
{
    public interface ISuratJalanService
    {
        SuratJalan save(SuratJalan suratJalan);
        SuratJalan findById(String suratJalanId);
        IList<SuratJalan> findAllData();
        String autoNumber();
    }
}
