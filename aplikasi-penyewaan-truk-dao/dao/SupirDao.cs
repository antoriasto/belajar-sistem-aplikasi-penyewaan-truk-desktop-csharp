using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using domain.model;
using core.utilities;

namespace core.dao
{
    public class SupirDao
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
        private readonly string insertQuery = "INSERT INTO supir (SUPIR_ID, NAMA_SUPIR, ALAMAT_SUPIR, NOMOR_HP_SUPIR, KERNET_ID) values(@1,@2,@3,@4,@5)";

        private readonly string updateQuery = "UPDATE supir " +
            "set NAMA_SUPIR=@3, ALAMAT_SUPIR=@4, NOMOR_HP_SUPIR=@5, KERNET_ID=@2  " + "where SUPIR_ID=@1";

        private readonly string deleteQuery = "DELETE from supir " +
            "where SUPIR_ID=@1";

        private readonly string generateIdQuery = "SELECT SUPIR_ID " +
            "from supir " +
            "ORDER BY SUPIR_ID DESC";

        private readonly string findByIdQuery = "SELECT SUPIR_ID, NAMA_SUPIR, ALAMAT_SUPIR, NOMOR_HP_SUPIR, KERNET_ID " +
            "from supir " +
            "where SUPIR_ID=@1";

        private readonly string countAllDataQuery =
                    "SELECT count(SUPIR_ID)" +
                    "from supir";

        private readonly string countAllDataSearchQuery = "SELECT count(SUPIR_ID)" +
                    "from supir " +
                    "where NAMA like @1";

        private readonly string findAllDataSearchQuery = "SELECT SUPIR_ID, NAMA_SUPIR, ALAMAT_SUPIR, NOMOR_HP_SUPIR, KERNET_ID " +
            "from supir where NAMA_SUPIR like @1 limit @2, @3";

        #endregion

        #region Dao Data Acces Object

        /// <summary>
        /// Poin engine ada disini save ke database.
        /// Gunain koneksi (MySql) privatenya yang diatas.
        /// </summary>

        public Supir save(Supir supir)
        {
            Console.WriteLine(insertQuery);
            using (MySqlCommand cmd = new MySqlCommand(insertQuery, connection))
            {
                cmd.Parameters.AddWithValue("@1", supir.Id);
                cmd.Parameters.AddWithValue("@2", supir.Nama);
                cmd.Parameters.AddWithValue("@3", supir.Alamat);
                cmd.Parameters.AddWithValue("@4", supir.NomorHp);
                cmd.Parameters.AddWithValue("@5", supir.Kernet.Id);

                int x = cmd.ExecuteNonQuery();
                return supir;
            }
        }

        public Supir update(Supir supir)
        {
            Console.WriteLine(updateQuery);
            using (MySqlCommand cmd = new MySqlCommand(updateQuery, connection))
            {
                cmd.Parameters.AddWithValue("@3", supir.Nama);
                cmd.Parameters.AddWithValue("@4", supir.Alamat);
                cmd.Parameters.AddWithValue("@5", supir.NomorHp);
                cmd.Parameters.AddWithValue("@2", supir.Kernet.Id);
                cmd.Parameters.AddWithValue("@1", supir.Id);

                int x = cmd.ExecuteNonQuery();
                return supir;
            }
        }

        public Supir delete(Supir supir)
        {
            using (MySqlCommand cmd = new MySqlCommand(deleteQuery, connection))
            {
                cmd.Parameters.AddWithValue("@1", supir.Id);

                int x = cmd.ExecuteNonQuery();
                return supir;
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
                        String id = UtilsLeftRightMid.Mid(mdr.GetString("SUPIR_ID"), 1, 4);
                        Int32 nilai = Convert.ToInt32(id) + 1;

                        String AN = UtilsLeftRightMid.Right("0000", 4 - nilai.ToString().Length) + nilai;
                        return "S" + AN.ToString();
                    }
                    else
                    {
                        truk.Id = "S0001";
                        return truk.Id;
                    }
                }
            }
        }

        public Supir findById(String supirId)
        {
            using (MySqlCommand cmd = new MySqlCommand(findByIdQuery, connection))
            {
                cmd.Parameters.AddWithValue("@1", supirId);
                using (MySqlDataReader mdr = cmd.ExecuteReader())
                {
                    if (mdr.Read())
                    {
                        return mappingKeObject(mdr);
                    }
                    else
                    {
                        return null;
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
                        jumlahbaris = mdr.GetInt32("count(SUPIR_ID)");
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
                        jumlahbaris = mdr.GetInt32("count(SUPIR_ID)");
                    }
                }
            }
            return jumlahbaris;
        }

        public List<Supir> findAllData(String search)
        {
            List<Supir> daftarSupir = new List<Supir>();

            using (MySqlCommand cmd = new MySqlCommand(findAllDataSearchQuery, connection))
            {
                cmd.Parameters.AddWithValue("@1", "%" + search + "%");
                cmd.Parameters.AddWithValue("@2", 0);
                cmd.Parameters.AddWithValue("@3", 200);

                using (MySqlDataReader mdr = cmd.ExecuteReader())
                {
                    while (mdr.Read())
                    {
                        daftarSupir.Add(mappingKeObject(mdr));
                    }
                }
            }
            return daftarSupir;
        }

        private Supir mappingKeObject(MySqlDataReader mdr)
        {
            Supir supir = new Supir();
            supir.Id = mdr.GetString("SUPIR_ID");
            supir.Nama = mdr.GetString("NAMA_SUPIR");
            supir.Alamat = mdr.GetString("ALAMAT_SUPIR");
            supir.NomorHp = mdr.GetString("NOMOR_HP_SUPIR");

            var ordinalKernet = mdr.GetOrdinal("KERNET_ID");

            if (!mdr.IsDBNull(ordinalKernet))
            {
                if (!mdr.GetString("KERNET_ID").Equals(""))
                {
                    Kernet kernet = new Kernet();
                    kernet.Id = mdr.GetString("KERNET_ID");

                    supir.Kernet = kernet;
                }
            }

            return supir;
        }

        #endregion
    }
}
