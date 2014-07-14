using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using domain.service;
using core.dao;
using MySql.Data.MySqlClient;
using core.utilities;
using domain.model;

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
            try
            {
                // Setting koneksi dan buka koneksi.
                suratJalanDao.setConnection = connection;
                connection.Open();
                return suratJalanDao.findAllData("");
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


        public string autoNumber()
        {
            try
            {
                // Setting koneksi dan buka koneksi.
                suratJalanDao.setConnection = connection;
                connection.Open();
                return suratJalanDao.nomorOtomatis();
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


        public SuratJalan findById(String suratJalanId)
        {
            try
            {
                // Setting koneksi dan buka koneksi.
                suratJalanDao.setConnection = connection;
                connection.Open();
                return suratJalanDao.findById(suratJalanId);
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
