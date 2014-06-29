using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using domain.model;
using core.utilities;

namespace core.dao
{
    public class KernetDao
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
        private readonly string insertQuery = "INSERT INTO kernet (KERNET_ID, NAMA_KERNET, ALAMAT_KERNET, NOMOR_HP_KERNET) values(@1,@2,@3,@4)";

        private readonly string updateQuery = "UPDATE kernet " +
            "set NAMA_KERNET=@2, ALAMAT_KERNET=@3, NOMOR_HP_KERNET=@4 " + "where KERNET_ID=@1";

        private readonly string deleteQuery = "DELETE from kernet " +
            "where KERNET_ID=@1";

        private readonly string generateIdQuery = "SELECT KERNET_ID " +
            "from kernet " +
            "ORDER BY KERNET_ID DESC";

        private readonly string findByIdQuery = "SELECT KERNET_ID, NAMA_KERNET, ALAMAT_KERNET, NOMOR_HP_KERNET " +
            "from kernet " +
            "where KERNET_ID= @1";

        private readonly string countAllDataQuery =
                    "SELECT count(KERNET_ID)" +
                    "from kernet";

        private readonly string countAllDataSearchQuery = "SELECT count(KERNET_ID)" +
                    "from kernet " +
                    "where NAMA_KERNET like @1";

        private readonly string findAllDataQuery = "SELECT KERNET_ID, NAMA_KERNET, ALAMAT_KERNET, NOMOR_HP_KERNET " +
            "from kernet where NAMA_KERNET like @1 limit @2, @3";

        #endregion

        #region Dao Data Acces Object

        /// <summary>
        /// Poin engine ada disini save ke database.
        /// Gunain koneksi (MySql) privatenya yang diatas.
        /// </summary>

        public Kernet save(Kernet kernet)
        {
            Console.WriteLine(insertQuery);
            using (MySqlCommand cmd = new MySqlCommand(insertQuery, connection))
            {
                cmd.Parameters.AddWithValue("@1", kernet.Id);
                cmd.Parameters.AddWithValue("@2", kernet.Nama);
                cmd.Parameters.AddWithValue("@3", kernet.Alamat);
                cmd.Parameters.AddWithValue("@4", kernet.NomorHp);

                int x = cmd.ExecuteNonQuery();
                return kernet;
            }
        }

        public Kernet update(Kernet kernet)
        {
            using (MySqlCommand cmd = new MySqlCommand(updateQuery, connection))
            {
                cmd.Parameters.AddWithValue("@2", kernet.Nama);
                cmd.Parameters.AddWithValue("@3", kernet.Alamat);
                cmd.Parameters.AddWithValue("@4", kernet.NomorHp);
                cmd.Parameters.AddWithValue("@1", kernet.Id);

                int x = cmd.ExecuteNonQuery();
                return kernet;
            }
        }

        public Kernet delete(Kernet kernet)
        {
            using (MySqlCommand cmd = new MySqlCommand(deleteQuery, connection))
            {
                cmd.Parameters.AddWithValue("@1", kernet.Id);

                int x = cmd.ExecuteNonQuery();
                return kernet;
            }
        }

        public Kernet findById(String kernetId)
        {
            Console.WriteLine(findByIdQuery);
            using (MySqlCommand cmd = new MySqlCommand(findByIdQuery, connection))
            {
                cmd.Parameters.AddWithValue("@1", kernetId);
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
                        jumlahbaris = mdr.GetInt32("count(KERNET_ID)");
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
                        jumlahbaris = mdr.GetInt32("count(KERNET_ID)");
                    }
                }
            }
            return jumlahbaris;
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
                        String id = UtilsLeftRightMid.Mid(mdr.GetString("KERNET_ID"), 1, 4);
                        Int32 nilai = Convert.ToInt32(id) + 1;

                        String AN = UtilsLeftRightMid.Right("0000", 4 - nilai.ToString().Length) + nilai;
                        return "K" + AN.ToString();
                    }
                    else
                    {
                        truk.Id = "K0001";
                        return truk.Id;
                    }
                }
            }
        }

        public List<Kernet> findAllData(String search)
        {
            Console.WriteLine(findAllDataQuery);

            List<Kernet> daftarKernet = new List<Kernet>();
            using (MySqlCommand cmd = new MySqlCommand(findAllDataQuery, connection))
            {
                cmd.Parameters.AddWithValue("@1", "%" + search + "%");
                cmd.Parameters.AddWithValue("@2", 0);
                cmd.Parameters.AddWithValue("@3", 300);

                using (MySqlDataReader mdr = cmd.ExecuteReader())
                {
                    while (mdr.Read())
                    {
                        daftarKernet.Add(mappingKeObject(mdr));
                    }
                }
            }
            return daftarKernet;
        }

        private Kernet mappingKeObject(MySqlDataReader mdr)
        {
            Kernet k = new Kernet();
            k.Id = mdr.GetString("KERNET_ID");
            k.Nama = mdr.GetString("NAMA_KERNET");
            k.Alamat = mdr.GetString("ALAMAT_KERNET");
            k.NomorHp = mdr.GetString("NOMOR_HP_KERNET");

            return k;
        }

        #endregion

    }
}
