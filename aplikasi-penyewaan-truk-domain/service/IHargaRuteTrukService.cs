using System;
using System.Collections.Generic;
using System.Text;
using domain.model;

namespace domain.service
{
    public interface IHargaRuteTrukService
    {
        IList<HargaRuteTruk> findAllDataByTrukId(String trukId);
        IList<HargaRuteTruk> findAllDataByRuteId(String ruteId);
        HargaRuteTruk save(HargaRuteTruk domain);
        HargaRuteTruk update(HargaRuteTruk domain);
        HargaRuteTruk delete(HargaRuteTruk domain);
        HargaRuteTruk findById(String id);
        void deleteByTrukId(String trukId);
        long countAllData(Truk domain);
        void saveUpdateOrDelete(IList<HargaRuteTruk> listTruk); 
    }
}
