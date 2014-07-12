using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using domain.service;
using core.dao;
using MySql.Data.MySqlClient;
using core.utilities;
using aplikasi_penyewaan_truk_domain.model;

namespace core.implementasi
{
    public class SuratJalanServiceImpl : ISuratJalanService
    {
        private SuratJalanDao suratJalanDao = new SuratJalanDao();
        private MySqlConnection connection;

        public SuratJalanServiceImpl() {
            connection = new MySqlConnection(DataBaseConnection.stringMySqlConnection);
        }

        public SuratJalan save(SuratJalan suratJalan)
        {
            try
            {
                // Setting koneksi dan buka koneksi.
                suratJalanDao.setConnection = connection;
                connection.Open();
                suratJalan.Id = suratJalanDao.nomorOtomatis();
                suratJalanDao.save(suratJalan);
                return suratJalan;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                connection.Close();
            }
            return null;
        }

        public IList<SuratJalan> findAllData()
        {
            throw new NotImplementedException();
        }
    }
}
