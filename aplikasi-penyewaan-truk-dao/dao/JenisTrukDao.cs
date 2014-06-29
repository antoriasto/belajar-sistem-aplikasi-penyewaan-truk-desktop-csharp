using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using domain.model;
using core.utilities;

namespace core.dao
{
    public class JenisTrukDao
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
        private readonly string insertQuery = "INSERT INTO jenis_truk (JENIS_TRUK_ID, NAMA_JENIS_TRUK, KUBIKASI, TONASE) values(@1,@2,@3,@4)";

        private readonly string updateQuery = "UPDATE jenis_truk " +
            "set NAMA_JENIS_TRUK=@2, KUBIKASI=@3, TONASE=@4 " + "where JENIS_TRUK_ID=@1";

        private readonly string deleteQuery = "DELETE from jenis_truk " +
            "where JENIS_TRUK_ID=@1";

        private readonly string findByIdQuery = "SELECT JENIS_TRUK_ID, NAMA_JENIS_TRUK, KUBIKASI, TONASE " +
            "from jenis_truk " +
            "where JENIS_TRUK_ID= @1";

        private readonly string generateIdQuery = "SELECT JENIS_TRUK_ID " +
            "from jenis_truk " +
            "ORDER BY JENIS_TRUK_ID DESC";

        private readonly string countAllDataQuery =
                    "SELECT count(JENIS_TRUK_ID)" +
                    "from jenis_truk";

        private readonly string countAllDataSearchQuery = "SELECT count(JENIS_TRUK_ID)" +
                    "from jenis_truk " +
                    "where NAMA_JENIS_TRUK like @1";

        private readonly string findAllDataQuery = "SELECT ID, NAMA, KUBIKASI, TONASE " +
            "from jenis_truk";

        private readonly string findAllDataSearchQuery = "SELECT JENIS_TRUK_ID, NAMA_JENIS_TRUK, KUBIKASI, TONASE " +
            "from jenis_truk where NAMA_JENIS_TRUK like @1 limit @2, @3";

        #endregion

        #region Dao Data Acces Object

        /// <summary>
        /// Poin engine ada disini save ke database.
        /// Gunain koneksi (MySql) privatenya yang diatas.
        /// </summary>

        public JenisTruk save(JenisTruk jenisTruk)
        {
            Console.WriteLine(insertQuery);
            using (MySqlCommand cmd = new MySqlCommand(insertQuery, connection))
            {
                cmd.Parameters.AddWithValue("@1", jenisTruk.Id);
                cmd.Parameters.AddWithValue("@2", jenisTruk.Nama);
                cmd.Parameters.AddWithValue("@3", jenisTruk.Kubikasi);
                cmd.Parameters.AddWithValue("@4", jenisTruk.Tonase);

                int x = cmd.ExecuteNonQuery();
                return jenisTruk;
            }
        }

        public JenisTruk update(JenisTruk JenisTruk)
        {
            using (MySqlCommand cmd = new MySqlCommand(updateQuery, connection))
            {
                cmd.Parameters.AddWithValue("@2", JenisTruk.Nama);
                cmd.Parameters.AddWithValue("@3", JenisTruk.Kubikasi);
                cmd.Parameters.AddWithValue("@4", JenisTruk.Tonase);
                cmd.Parameters.AddWithValue("@1", JenisTruk.Id);

                int x = cmd.ExecuteNonQuery();
                return JenisTruk;
            }
        }

        public JenisTruk delete(JenisTruk JenisTruk)
        {
            using (MySqlCommand cmd = new MySqlCommand(deleteQuery, connection))
            {
                cmd.Parameters.AddWithValue("@1", JenisTruk.Id);

                int x = cmd.ExecuteNonQuery();
                return JenisTruk;
            }
        }

        public JenisTruk findById(String JenisTrukId)
        {
            using (MySqlCommand cmd = new MySqlCommand(findByIdQuery, connection))
            {
                cmd.Parameters.AddWithValue("@1", JenisTrukId);
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
                        String id = UtilsLeftRightMid.Mid(mdr.GetString("JENIS_TRUK_ID"), 1, 4);
                        Int32 nilai = Convert.ToInt32(id) + 1;

                        String AN = UtilsLeftRightMid.Right("0000", 4 - nilai.ToString().Length) + nilai;
                        return "J" + AN.ToString();
                    }
                    else
                    {
                        truk.Id = "J0001";
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
                        jumlahbaris = mdr.GetInt32("count(JENIS_TRUK_ID)");
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
                        jumlahbaris = mdr.GetInt32("count(JENIS_TRUK_ID)");
                    }
                }
            }
            return jumlahbaris;
        }

        public List<JenisTruk> findAllData(String search)
        {
            List<JenisTruk> daftarJenisTruk = new List<JenisTruk>();

            using (MySqlCommand cmd = new MySqlCommand(findAllDataSearchQuery, connection))
            {
                cmd.Parameters.AddWithValue("@1", "%" + search + "%");
                cmd.Parameters.AddWithValue("@2", 0);
                cmd.Parameters.AddWithValue("@3", 300);

                using (MySqlDataReader mdr = cmd.ExecuteReader())
                {
                    while (mdr.Read())
                    {
                        daftarJenisTruk.Add(mappingKeObject(mdr));
                    }
                }
            }
            return daftarJenisTruk;
        }

        private JenisTruk mappingKeObject(MySqlDataReader mdr)
        {
            JenisTruk jenisTruk = new JenisTruk();
            jenisTruk.Id = mdr.GetString(0);
            jenisTruk.Nama = mdr.GetString(1);
            jenisTruk.Kubikasi = mdr.GetInt32(2);
            jenisTruk.Tonase = mdr.GetDecimal(3);

            return jenisTruk;
        }
        #endregion
    }
}
