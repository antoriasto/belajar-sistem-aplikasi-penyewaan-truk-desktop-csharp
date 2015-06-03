using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using domain.service;
using domain.model;
using core.dao;
using MySql.Data.MySqlClient;
using core.utilities;
using System.Data;

namespace core.implementasi
{
    public class TrukServiceImpl : ITrukService
    {
        private TrukDao trukDao = new TrukDao();
        private HargaRuteTrukDao hargaRuteTrukDao = new HargaRuteTrukDao();
        private MySqlConnection connection = new MySqlConnection(DataBaseConnection.stringMySqlConnection);

        public Truk simpan(Truk truk)
        {
            try
            {
                // Setting koneksi dan buka koneksi.
                trukDao.setConnection = connection;
                connection.Open();
                truk.Id = trukDao.nomorOtomatis();
                return trukDao.save(truk);
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

        public Truk ubah(Truk truk)
        {
            try
            {
                // Setting koneksi dan buka koneksi di class Dao dari sini.
                trukDao.setConnection = connection;
                connection.Open();
                return trukDao.update(truk);
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

        public Truk hapus(Truk truk)
        {
            try
            {
                // Setting koneksi dan buka koneksi di class Dao dari sini.
                trukDao.setConnection = connection;
                connection.Open();
                return trukDao.delete(truk);
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

        public Truk cari(String id)
        {
            try
            {
                // Setting koneksi dan buka koneksi di class Dao dari sini.
                trukDao.setConnection = connection;
                connection.Open();
                return trukDao.cari(id);
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

        public String nomorOtomatis()
        {
            try
            {
                Console.WriteLine("Truk Service: Cari Daftar Truk");
                // Setting koneksi dan buka koneksi di class Dao dari sini.
                trukDao.setConnection = connection;
                connection.Open();
                return trukDao.nomorOtomatis();
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

        public IList<Truk> cariDaftarTruk(String search)
        {
            try
            {
                Console.WriteLine("Truk Service: Cari Daftar Truk");
                // Setting koneksi dan buka koneksi di class Dao dari sini.
                trukDao.setConnection = connection;
                connection.Open();
                return trukDao.findAllData(search);
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


        public Truk simpanTrukAndPriceRute(Truk truk, IList<HargaRuteTruk> daftarHargaRuteTruk)
        {
            try
            {
                Console.WriteLine("Truk Service: Cari Daftar Truk");
                // Setting koneksi dan buka koneksi di class Dao dari sini.
                trukDao.setConnection = connection;
                connection.Open();
                truk.Id = trukDao.nomorOtomatis();
                return trukDao.saveTrukAndPriceRute(truk, daftarHargaRuteTruk);
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


        public Truk deleteTrukAndHargaRuteTruk(Truk domain)
        {
            trukDao.setConnection = connection;
            hargaRuteTrukDao.setConnection = connection;
            connection.Open();

            using (IDbTransaction tran = connection.BeginTransaction())
            {
                try
                {
                    // Lakuin method disini
                    hargaRuteTrukDao.deleteByTrukId(domain.Id);
                    trukDao.delete(domain);
                    tran.Commit();
                    return domain;
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    Console.WriteLine(ex);
                    return null;
                }
                finally
                {
                    connection.Close();
                    trukDao.setConnection = null;
                    hargaRuteTrukDao.setConnection = null;
                }
            }
        }


        public Boolean validatePoliceNumber(String policeNumber)
        {
            try {
                trukDao.setConnection = connection;
                connection.Open();
                return trukDao.validatePoliceNumber(policeNumber);
            } catch (Exception ex) {
                Console.WriteLine(ex.ToString());
                return true;
            } finally {
                connection.Close();
                trukDao.setConnection = null;
                hargaRuteTrukDao.setConnection = null;
            }
        }


        public long countAllDataByJenisTruk(string jenisTrukId)
        {
            try
            {
                trukDao.setConnection = connection;
                connection.Open();
                return trukDao.countAllDataByJenisTruk(jenisTrukId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return 0;
            }
            finally
            {
                connection.Close();
                trukDao.setConnection = null;
                hargaRuteTrukDao.setConnection = null;
            }
        }

        public long countAllDataByJenisTrukAndStatus(string jenisTrukId, domain.model.enumerasi.StatusTruk statusTruk)
        {
            try
            {
                trukDao.setConnection = connection;
                connection.Open();
                return trukDao.countAllDataByJenisTrukAndStatus(jenisTrukId, statusTruk);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return 0;
            }
            finally
            {
                connection.Close();
                trukDao.setConnection = null;
                hargaRuteTrukDao.setConnection = null;
            }
        }
    }
}
