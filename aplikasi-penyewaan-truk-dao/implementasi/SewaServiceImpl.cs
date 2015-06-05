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
        private TrukDao trukDao;
        private MySqlConnection connection;

        public SewaServiceImpl() {
            sewaDao = new SewaDao();
            sewaDetailDao = new SewaDetailDao();
            trukDao = new TrukDao();
            connection = new MySqlConnection(DataBaseConnection.stringMySqlConnection);
        }

        public Sewa save(Sewa sewa)
        {
            try
            {
                // Setting koneksi dan buka koneksi.
                sewaDao.setConnection = connection;
                sewaDetailDao.setConnection = connection;
                trukDao.setConnection = connection;
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

        public Sewa findById(String id)
        {
            try
            {
                // Setting koneksi dan buka koneksi.
                sewaDao.setConnection = connection;
                connection.Open();
                return sewaDao.findById(id);
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

        public IList<Sewa> findAllData(String search)
        {
            try
            {
                // Setting koneksi dan buka koneksi.
                sewaDao.setConnection = connection;
                connection.Open();
                return sewaDao.findAllData("");
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

        public IList<Sewa> findAllDataNotInKwitansi()
        {
            try
            {
                // Setting koneksi dan buka koneksi.
                sewaDao.setConnection = connection;
                connection.Open();
                return sewaDao.findAllDataNotInKwitansi();
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


        public Sewa save(Sewa sewa, IList<SewaDetail> detailSewa)
        {
            try
            {
                // Setting koneksi dan buka koneksi.
                sewaDao.setConnection = connection;
                sewaDetailDao.setConnection = connection;
                trukDao.setConnection = connection;
                connection.Open();
                sewa.Id = sewaDao.nomorOtomatis();
                sewaDao.save(sewa);
                sewaDetailDao.save(detailSewa);
                IList<Truk> listTruk = new List<Truk>();
                foreach (SewaDetail s in detailSewa) {
                    listTruk.Add(new Truk(s.Truk.Id));
                }
                trukDao.update(listTruk);
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
