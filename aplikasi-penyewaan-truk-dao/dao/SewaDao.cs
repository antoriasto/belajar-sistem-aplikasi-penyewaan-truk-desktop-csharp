using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using domain.model;
using core.utilities;

namespace core.dao
{
    public class SewaDao
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
        private readonly string insertQuery = "INSERT INTO Sewa (SEWA_ID, TANGGAL_SEWA, HARGA_TOTAL, HARGA_TOTAL_SUPIR, CUSTOMER_ID) values(@1,@2,@3,@4,@5)";

        private readonly string generateIdQuery = "SELECT SEWA_ID " +
            "from Sewa " +
            "ORDER BY SEWA_ID DESC";

        private readonly string findByIdQuery = "SELECT SEWA_ID, TANGGAL_SEWA, HARGA_TOTAL, HARGA_TOTAL_SUPIR, CUSTOMER_ID " +
            "from sewa " +
            "where SEWA_ID= @1";

        private readonly string countAllDataQuery =
                    "SELECT count(SEWA_ID)" +
                    "from Sewa";

        private readonly string countAllDataSearchQuery = "SELECT count(SEWA_ID)" +
                    "from Sewa " +
                    "where SEWA_ID like @1";

        private readonly string findAllDataQuery = "SELECT SEWA_ID, TANGGAL_SEWA, HARGA_TOTAL, HARGA_TOTAL_SUPIR, CUSTOMER_ID " +
            "from sewa where CUSTOMER_ID like @1 limit @2, @3";

        private readonly string findAllDataNotInSuratJalanQuery = "SELECT SEWA_ID, TANGGAL_SEWA, HARGA_TOTAL, HARGA_TOTAL_SUPIR, CUSTOMER_ID FROM sewa " + 
            "WHERE SEWA_ID NOT IN ( SELECT SEWA_ID FROM surat_jalan);";

        #endregion

        #region Dao Data Acces Object

        /// <summary>
        /// Poin engine ada disini save ke database.
        /// Gunain koneksi (MySql) privatenya yang diatas.
        /// </summary>

        public Sewa save(Sewa sewa)
        {
            Console.WriteLine(insertQuery);
            using (MySqlCommand cmd = new MySqlCommand(insertQuery, connection))
            {
                cmd.Parameters.AddWithValue("@1", sewa.Id);
                cmd.Parameters.AddWithValue("@2", sewa.Tanggal);
                cmd.Parameters.AddWithValue("@3", sewa.TotalHarga);
                cmd.Parameters.AddWithValue("@4", sewa.TotalHargaSupir);
                cmd.Parameters.AddWithValue("@5", sewa.Customer.Id);

                int x = cmd.ExecuteNonQuery();
                return sewa;
            }
        }

        public Sewa findById(String sewaId)
        {
            Console.WriteLine(findByIdQuery);
            using (MySqlCommand cmd = new MySqlCommand(findByIdQuery, connection))
            {
                cmd.Parameters.AddWithValue("@1", sewaId);
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
                        jumlahbaris = mdr.GetInt32("count(SEWA_ID)");
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
                        String id = UtilsLeftRightMid.Mid(mdr.GetString("SEWA_ID"), 2, 13);
                        Int32 nilai = Convert.ToInt32(id) + 1;

                        String AN = UtilsLeftRightMid.Right("SE0000000000000", 13 - nilai.ToString().Length) + nilai;
                        return "SE" + AN.ToString();
                    }
                    else
                    {
                        truk.Id = "SE0000000000001";
                        return truk.Id;
                    }
                }
            }
        }

        public List<Sewa> findAllData(String search)
        {
            Console.WriteLine(findAllDataQuery);

            List<Sewa> daftarKernet = new List<Sewa>();
            using (MySqlCommand cmd = new MySqlCommand(findAllDataNotInSuratJalanQuery, connection))
            {
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

        private Sewa mappingKeObject(MySqlDataReader mdr)
        {
            Sewa s = new Sewa();
            s.Id = mdr.GetString("SEWA_ID");
            s.Tanggal = mdr.GetDateTime("TANGGAL_SEWA");
            s.TotalHarga = mdr.GetDecimal("HARGA_TOTAL");
            s.TotalHargaSupir = mdr.GetDecimal("HARGA_TOTAL_SUPIR");
            s.Customer = new Customer(mdr.GetString("CUSTOMER_ID"));

            return s;
        }

        #endregion

    }
}
