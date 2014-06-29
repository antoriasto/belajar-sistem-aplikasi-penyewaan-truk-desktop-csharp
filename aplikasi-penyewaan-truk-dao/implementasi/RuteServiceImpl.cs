using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using domain.service;
using domain.model;
using core.dao;
using MySql.Data.MySqlClient;
using core.utilities;

namespace core.implementasi
{
    public class RuteServiceImpl : IRuteService
    {
        private RuteDao ruteDao = new RuteDao();
        private MySqlConnection connection = null;

        // Constructor
        public RuteServiceImpl()
        {
            // Setting koneksi string mysql (liat static class di Utilities > Database Connection).
            connection = new MySqlConnection(DataBaseConnection.stringMySqlConnection);
            Console.WriteLine("Rute Dao Initialize");
        }

        #region Method Untuk Akses Dao

        /// <summary>
        /// Ini method Akses Dao, bisa dibilang controllernya ada disini.
        /// Kalo Ada Kesalahan di Class DAO, class ini ngebalikin nilai null atau default ke View.
        /// </summary>

        #endregion


        public Rute simpan(Rute rute)
        {
            try
            {
                // Setting koneksi dan buka koneksi.
                ruteDao.setConnection = connection;
                connection.Open();
                rute.Id = ruteDao.nomorOtomatis();
                return ruteDao.save(rute);
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

        public Rute ubah(Rute rute)
        {
            try
            {
                // Setting koneksi dan buka koneksi.
                ruteDao.setConnection = connection;
                connection.Open();
                return ruteDao.update(rute);
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

        public Rute hapus(Rute rute)
        {
            try
            {
                // Setting koneksi dan buka koneksi.
                ruteDao.setConnection = connection;
                connection.Open();
                return ruteDao.delete(rute);
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

        public string nomorOtomatis()
        {
            try
            {
                // Setting koneksi dan buka koneksi.
                ruteDao.setConnection = connection;
                connection.Open();
                return ruteDao.nomorOtomatis();
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

        public IList<Rute> cariDaftarRute(String search)
        {
            try
            {
                // Setting koneksi dan buka koneksi.
                ruteDao.setConnection = connection;
                connection.Open();
                return ruteDao.findAllData(search);
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


        public Rute cari(string id)
        {
            try
            {
                // Setting koneksi dan buka koneksi.
                ruteDao.setConnection = connection;
                connection.Open();
                return ruteDao.findById(id);
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
