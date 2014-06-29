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
    public class JenisTrukServiceImpl : IJenisTrukService
    {
        private JenisTrukDao jenisTrukDao;
        private MySqlConnection connection = null;

        // Constructor
        public JenisTrukServiceImpl()
        {
            // Initialize new Implementation.
            jenisTrukDao = new JenisTrukDao();
            // Setting koneksi string mysql (liat static class di Utilities > Database Connection).
            connection = new MySqlConnection(DataBaseConnection.stringMySqlConnection);
            Console.WriteLine("Jenis Truk Dao Initialize");
        }


        public JenisTruk simpan(JenisTruk jenisTruk)
        {
            try
            {
                // Setting koneksi dan buka koneksi.
                jenisTrukDao.setConnection = connection;
                connection.Open();
                jenisTruk.Id = jenisTrukDao.nomorOtomatis();
                return jenisTrukDao.save(jenisTruk);
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

        public JenisTruk hapus(JenisTruk domain)
        {
            try
            {
                // Setting koneksi dan buka koneksi.
                jenisTrukDao.setConnection = connection;
                connection.Open();
                return jenisTrukDao.delete(domain);
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

        public JenisTruk cari(string id)
        {
            try
            {
                // Setting koneksi dan buka koneksi di class Dao dari sini.
                jenisTrukDao.setConnection = connection;
                connection.Open();
                return jenisTrukDao.findById(id);
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
            throw new NotImplementedException();
        }

        public IList<JenisTruk> cariDaftarJenisTruk(String search)
        {
            try
            {
                // Setting koneksi dan buka koneksi di class Dao dari sini.
                jenisTrukDao.setConnection = connection;
                connection.Open();
                return jenisTrukDao.findAllData(search);
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


        public JenisTruk ubah(JenisTruk domain)
        {
            try
            {
                // Setting koneksi dan buka koneksi.
                jenisTrukDao.setConnection = connection;
                connection.Open();
                return jenisTrukDao.update(domain);
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
