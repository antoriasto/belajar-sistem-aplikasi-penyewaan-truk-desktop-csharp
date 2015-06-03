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
    public class KwitansiSupirServiceImpl : IKwitansiSupirService
    {
        private KwitansiSupirDao kwitansiSupirDao = new KwitansiSupirDao();
        private MySqlConnection connection;

        public KwitansiSupirServiceImpl()
        {
            connection = new MySqlConnection(DataBaseConnection.stringMySqlConnection);
        }

        public KwitansiSupir save(KwitansiSupir kwitansiSupir)
        {
            try
            {
                // Setting koneksi dan buka koneksi.
                kwitansiSupirDao.setConnection = connection;
                connection.Open();
                kwitansiSupir.Id = kwitansiSupirDao.nomorOtomatis();
                kwitansiSupirDao.save(kwitansiSupir);
                return kwitansiSupir;
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

        public IList<KwitansiSupir> findAllData()
        {
            try
            {
                // Setting koneksi dan buka koneksi.
                kwitansiSupirDao.setConnection = connection;
                connection.Open();
                return kwitansiSupirDao.findAllData("");
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
                kwitansiSupirDao.setConnection = connection;
                connection.Open();
                return kwitansiSupirDao.nomorOtomatis();
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


        public KwitansiSupir findById(String kwitansiSupirId)
        {
            try
            {
                // Setting koneksi dan buka koneksi.
                kwitansiSupirDao.setConnection = connection;
                connection.Open();
                return kwitansiSupirDao.findById(kwitansiSupirId);
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
