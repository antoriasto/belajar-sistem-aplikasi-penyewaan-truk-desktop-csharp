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
    public class KernetServiceImpl : IKernetService
    {
        private KernetDao kernetDao;
        private MySqlConnection connection = null;

        public KernetServiceImpl()
        {
            // Initialize new Implementation.
            kernetDao = new KernetDao();
            // Setting koneksi string mysql (liat static class di Utilities > Database Connection).
            connection = new MySqlConnection(DataBaseConnection.stringMySqlConnection);
            Console.WriteLine("Kernet Dao Initialize");
        }

        #region Method Untuk Akses Dao

        /// <summary>
        /// Ini method Akses Dao, bisa dibilang controllernya ada disini.
        /// Kalo Ada Kesalahan di Class DAO, class ini ngebalikin nilai null atau default ke View.
        /// </summary>
        /// 
        #endregion

        public Kernet simpan(Kernet kernet)
        {
            try
            {
                // Setting koneksi dan buka koneksi.
                kernetDao.setConnection = connection;
                connection.Open();
                return kernetDao.save(kernet);
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

        public Kernet ubah(Kernet kernet)
        {
            try
            {
                // Setting koneksi dan buka koneksi di class Dao dari sini.
                kernetDao.setConnection = connection;
                connection.Open();
                return kernetDao.update(kernet);
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

        public Kernet hapus(Kernet kernet)
        {
            try
            {
                // Setting koneksi dan buka koneksi di class Dao dari sini.
                kernetDao.setConnection = connection;
                connection.Open();
                return kernetDao.delete(kernet);
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

        public string nomorOtomatis()
        {
            try
            {
                // Setting koneksi dan buka koneksi di class Dao dari sini.
                kernetDao.setConnection = connection;
                connection.Open();
                return kernetDao.nomorOtomatis();
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

        public IList<Kernet> cariDaftarTruk(String search)
        {
            try
            {
                // Setting koneksi dan buka koneksi di class Dao dari sini.
                kernetDao.setConnection = connection;
                connection.Open();
                return kernetDao.findAllData(search);
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

        public Kernet cari(String id)
        {
            try
            {
                // Setting koneksi dan buka koneksi di class Dao dari sini.
                kernetDao.setConnection = connection;
                connection.Open();
                return kernetDao.findById(id);
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
    }
}
