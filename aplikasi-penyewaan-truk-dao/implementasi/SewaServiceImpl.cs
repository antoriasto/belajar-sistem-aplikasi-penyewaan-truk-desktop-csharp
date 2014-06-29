using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using domain.service;
using domain.model;
using MySql.Data.MySqlClient;
using core.dao;
using core.utilities;

namespace core.implementasi
{
    public class SewaServiceImpl : ISewaService
    {
        private SewaDao sewaDao;
        private SewaDetailDao sewaDetailDao;
        private MySqlConnection connection;

        public SewaServiceImpl() {
            sewaDao = new SewaDao();
            sewaDetailDao = new SewaDetailDao();
            connection = new MySqlConnection(DataBaseConnection.stringMySqlConnection);
        }

        public Sewa save(Sewa sewa)
        {
            try
            {
                // Setting koneksi dan buka koneksi.
                sewaDao.setConnection = connection;
                sewaDetailDao.setConnection = connection;
                connection.Open();
                sewa.Id = sewaDao.nomorOtomatis();
                sewaDao.save(sewa);
                return sewa;
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

        public Sewa findById(string id)
        {
            throw new NotImplementedException();
        }

        public string autoNumber() {
            try {
                // Setting koneksi dan buka koneksi.
                sewaDao.setConnection = connection;
                sewaDetailDao.setConnection = connection;
                connection.Open();
                return sewaDao.nomorOtomatis();
            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            }
            finally {
                connection.Close();
            }
            return null;
        }

        public IList<Sewa> findAllData(string search)
        {
            throw new NotImplementedException();
        }


        public Sewa save(Sewa sewa, IList<SewaDetail> detailSewa)
        {
            try
            {
                // Setting koneksi dan buka koneksi.
                sewaDao.setConnection = connection;
                sewaDetailDao.setConnection = connection;
                connection.Open();
                sewa.Id = sewaDao.nomorOtomatis();
                sewaDao.save(sewa);
                sewaDetailDao.save(detailSewa);
                return sewa;
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
