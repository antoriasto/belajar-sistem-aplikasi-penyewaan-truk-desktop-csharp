using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using core.utilities;
using domain.model;

namespace core.dao
{
    public class KwitansiSupirDao
    {
        private MySqlConnection connection;

        // Variabel mysql koneksi, koneksi privatenya yang dipake di semua method.
        public MySqlConnection setConnection
        {
            set { this.connection = value; }
        }

        #region Query

        // Script semua Query yang diapake.
        // Create, Find, Update, Delete.
        // ----------------------------
        private readonly string insertQuery = "INSERT INTO kwitansi_supir (KWITANSI_SUPIR_ID, TANGGAL_KWITANSI_SUPIR, SEWA_ID) values(@1,@2,@4)";

        private readonly string generateIdQuery = "SELECT KWITANSI_SUPIR_ID " +
            "from kwitansi_supir " +
            "ORDER BY KWITANSI_SUPIR_ID DESC";

        private readonly string findByIdQuery = "SELECT KWITANSI_SUPIR_ID, TANGGAL_KWITANSI_SUPIR, SEWA_ID " +
            "from kwitansi_supir " +
            "where KWITANSI_SUPIR_ID= @1";

        private readonly string countAllDataQuery =
                    "SELECT count(KWITANSI_SUPIR_ID)" +
                    "from kwitansi_supir";

        private readonly string countAllDataSearchQuery = "SELECT count(KWITANSI_SUPIR_ID)" +
                    "from kwitansi_supir " +
                    "where KWITANSI_SUPIR_ID like @1";

        private readonly string findAllDataQuery = "KWITANSI_SUPIR_ID, TANGGAL_KWITANSI_SUPIR, SEWA_ID " +
            "from kwitansi_supir where KWITANSI_SUPIR_ID like @1 limit @2, @3";

        private readonly string findAllDataNotInInvoiceQuery = "SELECT KWITANSI_SUPIR_ID, TANGGAL_KWITANSI_SUPIR, SEWA_ID FROM kwitansi_supir " +
            "WHERE KWITANSI_SUPIR_ID NOT IN ( SELECT KWITANSI_SUPIR_ID FROM invoice);";

        #endregion

        #region Dao Data Acces Object

        /// <summary>
        /// Poin engine ada disini save ke database.
        /// Gunain koneksi (MySql) privatenya yang diatas.
        /// </summary>

        public KwitansiSupir save(KwitansiSupir kwitansiSupir)
        {
            Console.WriteLine(insertQuery);
            using (MySqlCommand cmd = new MySqlCommand(insertQuery, connection))
            {
                cmd.Parameters.AddWithValue("@1", kwitansiSupir.Id);
                cmd.Parameters.AddWithValue("@2", kwitansiSupir.Tanggal);
                cmd.Parameters.AddWithValue("@4", kwitansiSupir.Sewa.Id);

                int x = cmd.ExecuteNonQuery();
                return kwitansiSupir;
            }
        }

        public KwitansiSupir findById(String kwitansiSupirId)
        {
            Console.WriteLine(findByIdQuery);
            using (MySqlCommand cmd = new MySqlCommand(findByIdQuery, connection))
            {
                cmd.Parameters.AddWithValue("@1", kwitansiSupirId);
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
                        jumlahbaris = mdr.GetInt32("count(KWITANSI_SUPIR_ID)");
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
                        jumlahbaris = mdr.GetInt32("count(KWITANSI_SUPIR_ID)");
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
                    String autoNumber = "";
                    if (mdr.Read())
                    {
                        String id = UtilsLeftRightMid.Mid(mdr.GetString("KWITANSI_SUPIR_ID"), 2, 13);
                        Int32 nilai = Convert.ToInt32(id) + 1;

                        String AN = UtilsLeftRightMid.Right("KS0000000000000", 13 - nilai.ToString().Length) + nilai;
                        return "KS" + AN.ToString();
                    }
                    else
                    {
                        autoNumber = "KS0000000000001";
                        return autoNumber;
                    }
                }
            }
        }

        public List<KwitansiSupir> findAllData(String search)
        {
            Console.WriteLine(findAllDataNotInInvoiceQuery);

            List<KwitansiSupir> daftarKwitansiSupir = new List<KwitansiSupir>();
            using (MySqlCommand cmd = new MySqlCommand(findAllDataNotInInvoiceQuery, connection))
            {

                using (MySqlDataReader mdr = cmd.ExecuteReader())
                {
                    while (mdr.Read())
                    {
                        daftarKwitansiSupir.Add(mappingKeObject(mdr));
                    }
                }
            }
            return daftarKwitansiSupir;
        }

        private KwitansiSupir mappingKeObject(MySqlDataReader mdr)
        {
            KwitansiSupir s = new KwitansiSupir();
            s.Id = mdr.GetString("KWITANSI_SUPIR_ID");
            s.Tanggal = mdr.GetDateTime("TANGGAL_KWITANSI_SUPIR");
            s.Sewa = new Sewa(mdr.GetString("SEWA_ID"));

            return s;
        }

        #endregion
    }
}
