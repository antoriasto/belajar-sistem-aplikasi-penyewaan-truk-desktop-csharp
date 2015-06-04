using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using aplikasi_penyewaan_truk_domain.service;
using aplikasi_penyewaan_truk_domain.model;
using core.dao;
using MySql.Data.MySqlClient;
using core.utilities;

namespace core.implementasi
{
    public class DphServiceImpl : IDphService
    {
        private DphDao dphDao = new DphDao();
        private MySqlConnection connection;

        public DphServiceImpl()
        {
            connection = new MySqlConnection(DataBaseConnection.stringMySqlConnection);
        }

        public Dph save(Dph domain)
        {
            try
            {
                // Setting koneksi dan buka koneksi.
                dphDao.setConnection = connection;
                connection.Open();
                return dphDao.save(domain);
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


        public String autoNumber()
        {
            try
            {
                // Setting koneksi dan buka koneksi.
                dphDao.setConnection = connection;
                connection.Open();
                return dphDao.nomorOtomatis();
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

    }
}
