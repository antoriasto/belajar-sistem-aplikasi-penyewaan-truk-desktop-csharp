using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using domain.model;

namespace domain.service
{
    public interface IKwitansiSupirService
    {
        KwitansiSupir save(KwitansiSupir kwitansiSupir);
        KwitansiSupir findById(String kwitansiSupir);
        IList<KwitansiSupir> findAllData();
        String autoNumber();
    }
}
