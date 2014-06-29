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
    public class SupirServiceImpl : ISupirService
    {
        private SupirDao supirDao;
        private MySqlConnection connection = null;

        public SupirServiceImpl()
        {
            // Initialize new Implementation.
            supirDao = new SupirDao();
            // Setting koneksi string mysql (liat static class di Utilities > Database Connection).
            connection = new MySqlConnection(DataBaseConnection.stringMySqlConnection);
            Console.WriteLine("Supir Dao Initialize");
        }

        #region Method Untuk Akses Dao

        /// <summary>
        /// Ini method Akses Dao, bisa dibilang controllernya ada disini.
        /// Kalo Ada Kesalahan di Class DAO, class ini ngebalikin nilai null atau default ke View.
        /// </summary>

        public Supir simpan(Supir supir)
        {
            try
            {
                // Setting koneksi dan buka koneksi di class Dao dari sini.
                supirDao.setConnection = connection;
                connection.Open();
                supir.Id = supirDao.nomorOtomatis();
                return supirDao.save(supir);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                // Tutup Koneksi.
                connection.Close();
            }
            return null;
        }

        public Supir ubah(Supir supir)
        {
            try
            {
                // Setting koneksi dan buka koneksi di class Dao dari sini.
                supirDao.setConnection = connection;
                connection.Open();
                return supirDao.update(supir);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                // Tutup Koneksi.
                connection.Close();
            }
            return null;
        }

        public Supir hapus(Supir supir)
        {
            try
            {
                // Setting koneksi dan buka koneksi di class Dao dari sini.
                supirDao.setConnection = connection;
                connection.Open();
                return supirDao.delete(supir);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                // Tutup Koneksi.
                connection.Close();
            }
            return null;
        }

        public Supir cari(string id)
        {
            try
            {
                // Setting koneksi dan buka koneksi di class Dao dari sini.
                supirDao.setConnection = connection;
                connection.Open();
                return supirDao.findById(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                connection.Close();
            }
            finally
            {
                // Tutup Koneksi.
                connection.Close();
            }
            return null;
        }

        public string nomorOtomatis()
        {
            try
            {
                // Setting koneksi dan buka koneksi di class Dao dari sini.
                supirDao.setConnection = connection;
                connection.Open();
                return supirDao.nomorOtomatis();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                connection.Close();
            }
            finally
            {
                // Tutup Koneksi.
                connection.Close();
            }
            return null;
        }

        public IList<Supir> cariDaftarSupir(String search)
        {
            try
            {
                // Setting koneksi dan buka koneksi di class Dao dari sini.
                supirDao.setConnection = connection;
                connection.Open();
                return supirDao.findAllData(search);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                connection.Close();
            }
            finally
            {
                // Tutup Koneksi.
                connection.Close();
            }
            return null;
        }

        #endregion


    }
}
