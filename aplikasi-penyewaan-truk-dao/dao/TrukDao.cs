using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using aplikasi_penyewaan_truk_domain.model;
using aplikasi_penyewaan_truk_dao.utilities;

namespace aplikasi_penyewaan_truk_dao.dao
{
    public class TrukDao
    {
        private MySqlConnection connection;

        // Variabel mysql koneksi, koneksi privatenya yang dipake di semua method.
        public MySqlConnection setConnection
        {
            get { return connection; }
            set { this.connection = value; }
        }

        #region Query

        // Script semua Query yang diapake.
        // Create, Find, Update, Delete.
        // ----------------------------
        private readonly string insertQuery = "INSERT INTO truk (ID, NOMOR_POLISI, SUPIR_ID, JENIS_TRUK_ID) values(@1,@2,@3,@4)";

        private readonly string updateQuery = "UPDATE truk " +
            "set NOMOR_POLISI=@2, SUPIR_ID=@3, JENIS_TRUK_ID=@4 " + "where ID=@1";

        private readonly string deleteQuery = "DELETE from truk " +
            "where ID=@1";

        private readonly string findByIdQuery = "SELECT ID, NOMOR_POLISI, SUPIR_ID, JENIS_TRUK_ID " +
            "from truk " +
            "where ID= @1";

        private readonly string generateIdQuery = "SELECT ID " +
            "from truk " +
            "ORDER BY ID DESC";

        private readonly string countAllDataQuery =
                    "SELECT count(ID)" +
                    "from truk";

        private readonly string countAllDataSearchQuery = "SELECT count(ID)" +
                    "from truk " +
                    "where NOMOR_POLISI like @1";

        private readonly string findAllDataByTrukIdQuery = "SELECT RUTE_ID, TRUK_ID AS TRUK_ID, HARGA, rute.NAMA as NAMA " +
            "from truk_rute INNER JOIN rute ON RUTE_ID = rute.ID " +
            "where truk_rute.TRUK_ID= @1";

        private readonly string findAllDataQuery = "SELECT NOMOR_POLISI, supir.NAMA AS SUPIR_NAMA, jenis_truk.NAMA AS JENIS_TRUK_NAMA," +
            "truk.ID AS TRUK_ID, truk.STATUS, jenis_truk.ID AS JENIS_TRUK_ID, supir.ID AS SUPIR_ID FROM truk " +
            "LEFT JOIN supir ON supir.ID = truk.SUPIR_ID " +
            "LEFT JOIN jenis_truk ON jenis_truk.ID = truk.JENIS_TRUK_ID " +
            "WHERE (truk.NOMOR_POLISI LIKE @1) OR " +
            "(supir.NAMA LIKE @2) OR " +
            "(jenis_truk.NAMA LIKE @3) OR (truk.STATUS LIKE @4)";

        #endregion

        #region Dao Data Acces Object

        /// <summary>
        /// Poin engine ada disini save ke database.
        /// Gunain koneksi (MySql) privatenya yang diatas.
        /// </summary>

        public Truk save(Truk truk)
        {
            Console.WriteLine(insertQuery);
            using (MySqlCommand cmd = new MySqlCommand(insertQuery, connection))
            {
                cmd.Parameters.AddWithValue("@1", truk.Id);
                cmd.Parameters.AddWithValue("@2", truk.NomorPolisi);
                cmd.Parameters.AddWithValue("@3", truk.Supir.Id);
                cmd.Parameters.AddWithValue("@4", truk.JenisTruk.Id);

                int x = cmd.ExecuteNonQuery();
                return truk;
            }
        }

        public Truk update(Truk truk)
        {
            using (MySqlCommand cmd = new MySqlCommand(updateQuery, connection))
            {
                cmd.Parameters.AddWithValue("@2", truk.NomorPolisi);
                cmd.Parameters.AddWithValue("@2", truk.NomorPolisi);
                cmd.Parameters.AddWithValue("@3", truk.Supir.Id);
                cmd.Parameters.AddWithValue("@4", truk.JenisTruk.Id);

                int x = cmd.ExecuteNonQuery();
                return truk;
            }
        }

        public Truk delete(Truk truk)
        {
            using (MySqlCommand cmd = new MySqlCommand(deleteQuery, connection))
            {
                cmd.Parameters.AddWithValue("@1", truk.Id);

                int x = cmd.ExecuteNonQuery();
                return truk;
            }
        }

        public Truk cari(String id)
        {
            using (MySqlCommand cmd = new MySqlCommand(findByIdQuery, connection))
            {
                cmd.Parameters.AddWithValue("@1", id);
                using (MySqlDataReader mdr = cmd.ExecuteReader())
                {
                    if (mdr.Read())
                    {
                        return mappingKeObject(mdr);
                    }
                }
            }
            return null;
        }

        public String nomorOtomatis()
        {
            using (MySqlCommand cmd = new MySqlCommand(generateIdQuery, connection))
            {
                using (MySqlDataReader mdr = cmd.ExecuteReader())
                {
                    Truk truk = new Truk();
                    if (mdr.Read())
                    {
                        String id = UtilsLeftRightMid.Mid(mdr.GetString("ID"), 1, 4);
                        //Console.WriteLine("ID: " + id);
                        //truk.Id = mdr.GetString("ID") + 1;
                        return id;
                    }
                    else
                    {
                        truk.Id = "T0001";
                        return truk.Id;
                    }
                }
            }
        }

        public long countAllData()
        {
            int jumlahbaris = 0;

            using (MySqlCommand cmd = new MySqlCommand(countAllDataQuery, connection))
            {
                using (MySqlDataReader mdr = cmd.ExecuteReader())
                {
                    if (mdr.Read())
                    {
                        jumlahbaris = mdr.GetInt32("count(ID)");
                    }
                }
            }
            return jumlahbaris;
        }

        public long countAllData(String search)
        {
            int jumlahbaris = 0;

            using (MySqlCommand cmd = new MySqlCommand(countAllDataSearchQuery, connection))
            {
                cmd.Parameters.AddWithValue("@1", "%" + search + "%");
                using (MySqlDataReader mdr = cmd.ExecuteReader())
                {
                    if (mdr.Read())
                    {
                        jumlahbaris = mdr.GetInt32("count(ID)");
                    }
                }
            }
            return jumlahbaris;
        }

        public List<Truk> findAllData(String search)
        {
            List<Truk> daftarTruk = new List<Truk>();

            using (MySqlCommand cmd = new MySqlCommand(findAllDataQuery, connection))
            {
                cmd.Parameters.AddWithValue("@1", "%" + search + "%");
                cmd.Parameters.AddWithValue("@2", "%" + search + "%");
                cmd.Parameters.AddWithValue("@3", "%" + search + "%");
                cmd.Parameters.AddWithValue("@4", "%" + search + "%");

                using (MySqlDataReader mdr = cmd.ExecuteReader())
                {
                    while (mdr.Read())
                    {
                        daftarTruk.Add(mappingKeObject(mdr));
                    }
                }
            }
            return daftarTruk;
        }

        private Truk mappingKeObject(MySqlDataReader mdr) 
        {
            Truk truk = new Truk();
            truk.Id = mdr.GetString("TRUK_ID");
            truk.NomorPolisi = mdr.GetString("NOMOR_POLISI");

            var ordinalSupir = mdr.GetOrdinal("SUPIR_ID");
            var ordinalJenisTruk = mdr.GetOrdinal("JENIS_TRUK_ID");

            if (!mdr.IsDBNull(ordinalSupir))
            {
                if (!mdr.GetString("SUPIR_ID").Equals(""))
                {
                    Supir supir = new Supir();
                    supir.Id = mdr.GetString("SUPIR_ID");
                    supir.Nama = mdr.GetString("SUPIR_NAMA");
                    truk.Supir = supir;
                }
            }

            if (!mdr.IsDBNull(ordinalJenisTruk))
            {
                if (!mdr.GetString("JENIS_TRUK_ID").Equals(""))
                {
                    JenisTruk j = new JenisTruk();
                    j.Id = mdr.GetString("JENIS_TRUK_ID");
                    j.Nama = mdr.GetString("JENIS_TRUK_NAMA");
                    truk.JenisTruk = j;
                }
            }

            return truk;
        }

        #endregion
    }
}
