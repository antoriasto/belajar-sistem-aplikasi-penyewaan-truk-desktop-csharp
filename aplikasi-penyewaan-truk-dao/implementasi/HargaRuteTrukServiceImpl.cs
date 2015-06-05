using System;
using System.Collections.Generic;
using System.Text;
using domain.service;
using core.dao;
using MySql.Data.MySqlClient;
using core.utilities;
using domain.model;

namespace core.implementasi
{
    public class HargaRuteTrukServiceImpl : IHargaRuteTrukService
    {
        private HargaRuteTrukDao hargaRuteTrukDao;
        private MySqlConnection connection = null;

        // Constructor.
        public HargaRuteTrukServiceImpl()
        {
            // Initialize new Implementation.
            hargaRuteTrukDao = new HargaRuteTrukDao();
            // Setting koneksi string mysql (liat static class di Utilities > Database Connection).
            connection = new MySqlConnection(DataBaseConnection.stringMySqlConnection);
            Console.WriteLine("Customer Dao Initialize");
        }

        public IList<HargaRuteTruk> findAllDataByTrukId(string trukId)
        {
            try
            {
                Console.WriteLine("Truk Service: Cari Daftar Truk");
                // Setting koneksi dan buka koneksi di class Dao dari sini.
                hargaRuteTrukDao.setConnection = connection;
                connection.Open();
                return hargaRuteTrukDao.findAllDataByTrukId(trukId);
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



        public void saveUpdateOrDelete(IList<HargaRuteTruk> listTruk)
        {
            try
            {
                Console.WriteLine("Save Or Update Or Delete");
                // Setting koneksi dan buka koneksi di class Dao dari sini.
                hargaRuteTrukDao.setConnection = connection;
                connection.Open();
                hargaRuteTrukDao.doMultipleJob(listTruk);
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
        }


        public HargaRuteTruk save(HargaRuteTruk domain)
        {
            try
            {
                Console.WriteLine("Save Or Update Or Delete");
                // Setting koneksi dan buka koneksi di class Dao dari sini.
                hargaRuteTrukDao.setConnection = connection;
                connection.Open();
                return hargaRuteTrukDao.save(domain);
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

        public HargaRuteTruk update(HargaRuteTruk domain)
        {
            try
            {
                Console.WriteLine("Save Or Update Or Delete");
                // Setting koneksi dan buka koneksi di class Dao dari sini.
                hargaRuteTrukDao.setConnection = connection;
                connection.Open();
                return hargaRuteTrukDao.update(domain);
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

        public HargaRuteTruk delete(HargaRuteTruk domain)
        {
            try
            {
                Console.WriteLine("Save Or Update Or Delete");
                // Setting koneksi dan buka koneksi di class Dao dari sini.
                hargaRuteTrukDao.setConnection = connection;
                connection.Open();
                return hargaRuteTrukDao.delete(domain);
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


        public long countAllData(Truk domain)
        {
            try
            {
                Console.WriteLine("Save Or Update Or Delete");
                // Setting koneksi dan buka koneksi di class Dao dari sini.
                hargaRuteTrukDao.setConnection = connection;
                connection.Open();
                return hargaRuteTrukDao.countAllData(domain);
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
            return 0;
        }


        public IList<HargaRuteTruk> findAllDataByRuteId(String ruteId)
        {
            try
            {
                Console.WriteLine("Truk Service: Cari Daftar Truk");
                // Setting koneksi dan buka koneksi di class Dao dari sini.
                hargaRuteTrukDao.setConnection = connection;
                connection.Open();
                return hargaRuteTrukDao.findAllDataByRuteId(ruteId);
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


        public void deleteByTrukId(String trukId)
        {
            try
            {
                // Setting koneksi dan buka koneksi di class Dao dari sini.
                hargaRuteTrukDao.setConnection = connection;
                connection.Open();
                hargaRuteTrukDao.deleteByTrukId(trukId);
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
        }

        public HargaRuteTruk findById(String id)
        {
            try
            {
                // Setting koneksi dan buka koneksi di class Dao dari sini.
                hargaRuteTrukDao.setConnection = connection;
                connection.Open();
                return hargaRuteTrukDao.findById(id);
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

    }
}
