using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using aplikasi_penyewaan_truk_domain.service;
using aplikasi_penyewaan_truk_domain.model;
using aplikasi_penyewaan_truk_dao.dao;
using MySql.Data.MySqlClient;
using aplikasi_penyewaan_truk_dao.utilities;

namespace aplikasi_penyewaan_truk_dao.implementasi
{
    public class TrukServiceImpl : ITrukService
    {
        private TrukDao trukDao = new TrukDao();
        private MySqlConnection connection = new MySqlConnection(DataBaseConnection.stringMySqlConnection);

        public Truk simpan(Truk truk)
        {
            throw new NotImplementedException();
        }

        public Truk ubah(Truk truk)
        {
            throw new NotImplementedException();
        }

        public Truk delete(Truk customer)
        {
            throw new NotImplementedException();
        }

        public Truk cari(string id)
        {
            throw new NotImplementedException();
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
    }
}
