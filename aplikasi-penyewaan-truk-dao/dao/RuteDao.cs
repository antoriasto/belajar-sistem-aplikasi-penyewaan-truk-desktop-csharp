using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using domain.model;
using MySql.Data.MySqlClient;
using core.utilities;

namespace core.dao
{
    public class RuteDao
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
        private readonly string insertQuery = "INSERT INTO rute (RUTE_ID, NAMA_RUTE) values(@1,@2)";

        private readonly string updateQuery = "UPDATE rute " +
            "set NAMA_RUTE=@2 " + "where RUTE_ID=@1";

        private readonly string deleteQuery = "DELETE from rute " +
            "where RUTE_ID=@1";

        private readonly string generateIdQuery = "SELECT RUTE_ID " +
            "from rute " +
            "ORDER BY RUTE_ID DESC";

        private readonly string findByIdQuery = "SELECT RUTE_ID, NAMA_RUTE " +
            "from rute " +
            "where RUTE_ID= @1";

        private readonly string countAllDataQuery =
                    "SELECT count(ID)" +
                    "from rute";

        private readonly string countAllDataSearchQuery = "SELECT count(RUTE_ID)" +
                    "from rute " +
                    "where NAMA_RUTE like @1";

        private readonly string findAllDataPagingAndSearchQuery = "SELECT RUTE_ID, NAMA_RUTE " +
            "from rute where NAMA_RUTE like @1 limit @2, @3";

        #endregion

        #region Dao Data Acces Object

        /// <summary>
        /// Poin engine ada disini save ke database.
        /// Gunain koneksi (MySql) privatenya yang diatas.
        /// </summary>

        public Rute save(Rute rute)
        {
            Console.WriteLine(insertQuery);
            using (MySqlCommand cmd = new MySqlCommand(insertQuery, connection))
            {
                cmd.Parameters.AddWithValue("@1", rute.Id);
                cmd.Parameters.AddWithValue("@2", rute.Nama);

                int x = cmd.ExecuteNonQuery();
                return rute;
            }
        }

        public Rute update(Rute rute)
        {
            using (MySqlCommand cmd = new MySqlCommand(updateQuery, connection))
            {
                cmd.Parameters.AddWithValue("@2", rute.Nama);
                cmd.Parameters.AddWithValue("@1", rute.Id);

                int x = cmd.ExecuteNonQuery();
                return rute;
            }
        }

        public Rute delete(Rute rute)
        {
            using (MySqlCommand cmd = new MySqlCommand(deleteQuery, connection))
            {
                cmd.Parameters.AddWithValue("@1", rute.Id);

                int x = cmd.ExecuteNonQuery();
                return rute;
            }
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
                        String id = UtilsLeftRightMid.Mid(mdr.GetString("RUTE_ID"), 1, 4);
                        Int32 nilai = Convert.ToInt32(id) + 1;

                        String AN = UtilsLeftRightMid.Right("0000", 4 - nilai.ToString().Length) + nilai;
                        return "R" + AN.ToString();
                    }
                    else
                    {
                        truk.Id = "R0001";
                        return truk.Id;
                    }
                }
            }
        }

        public Rute findById(String ruteId)
        {
            using (MySqlCommand cmd = new MySqlCommand(findByIdQuery, connection))
            {
                cmd.Parameters.AddWithValue("@1", ruteId);
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

        public long countAllData()
        {
            int jumlahbaris = 0;

            using (MySqlCommand cmd = new MySqlCommand(countAllDataQuery, connection))
            {
                using (MySqlDataReader mdr = cmd.ExecuteReader())
                {
                    if (mdr.Read())
                    {
                        jumlahbaris = mdr.GetInt32("count(RUTE_ID)");
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
                        jumlahbaris = mdr.GetInt32("count(RUTE_ID)");
                    }
                }
            }
            return jumlahbaris;
        }

        public List<Rute> findAllData(String search)
        {
            List<Rute> daftarRute = new List<Rute>();

            using (MySqlCommand cmd = new MySqlCommand(findAllDataPagingAndSearchQuery, connection))
            {
                cmd.Parameters.AddWithValue("@1", "%" + search + "%");
                cmd.Parameters.AddWithValue("@2", 0);
                cmd.Parameters.AddWithValue("@3", 300);

                using (MySqlDataReader mdr = cmd.ExecuteReader())
                {
                    while (mdr.Read())
                    {
                        daftarRute.Add(mappingKeObject(mdr));
                    }
                }
            }
            return daftarRute;
        }

        #endregion

        private Rute mappingKeObject(MySqlDataReader mdr)
        {
            Rute r = new Rute();
            r.Id = mdr.GetString("RUTE_ID");
            r.Nama = mdr.GetString("NAMA_RUTE");

            return r;
        }
    }
}
