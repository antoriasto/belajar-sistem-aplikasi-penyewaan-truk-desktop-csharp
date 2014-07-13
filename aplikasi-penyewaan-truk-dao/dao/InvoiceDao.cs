using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using domain.model;
using core.utilities;

namespace core.dao
{
    public class InvoiceDao
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
        private readonly string insertQuery = "INSERT INTO invoice (INVOICE_ID, TANGGAL_INVOICE, SURAT_JALAN_ID) values(@1,@2,@4)";

        private readonly string generateIdQuery = "SELECT INVOICE_ID " +
            "from invoice " +
            "ORDER BY INVOICE_ID DESC";

        private readonly string findByIdQuery = "SELECT SURAT_JALAN_ID, TANGGAL_SURAT_JALAN, KETERANGAN, SEWA_ID " +
            "from surat_jalan " +
            "where SURAT_JALAN_ID= @1";

        private readonly string countAllDataQuery =
                    "SELECT count(SURAT_JALAN_ID)" +
                    "from surat_jalan";

        private readonly string countAllDataSearchQuery = "SELECT count(SURAT_JALAN_ID)" +
                    "from surat_jalan " +
                    "where SURAT_JALAN_ID like @1";

        private readonly string findAllDataQuery = "SURAT_JALAN_ID, TANGGAL_SURAT_JALAN, SEWA_ID " +
            "from surat_jalan where SURAT_JALAN_ID like @1 limit @2, @3";

        #endregion

        #region Dao Data Acces Object

        /// <summary>
        /// Poin engine ada disini save ke database.
        /// Gunain koneksi (MySql) privatenya yang diatas.
        /// </summary>

        public Invoice save(Invoice invoice)
        {
            Console.WriteLine(insertQuery);
            using (MySqlCommand cmd = new MySqlCommand(insertQuery, connection))
            {
                cmd.Parameters.AddWithValue("@1", invoice.Id);
                cmd.Parameters.AddWithValue("@2", invoice.Tanggal);
                cmd.Parameters.AddWithValue("@4", invoice.SuratJalan.Id);

                int x = cmd.ExecuteNonQuery();
                return invoice;
            }
        }

        public SuratJalan findById(String sewaId)
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
                        jumlahbaris = mdr.GetInt32("count(SURAT_JALAN_ID)");
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
                        jumlahbaris = mdr.GetInt32("count(SURAT_JALAN_ID)");
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
                        String id = UtilsLeftRightMid.Mid(mdr.GetString("INVOICE_ID"), 2, 13);
                        Int32 nilai = Convert.ToInt32(id) + 1;

                        String AN = UtilsLeftRightMid.Right("IN0000000000000", 13 - nilai.ToString().Length) + nilai;
                        return "IN" + AN.ToString();
                    }
                    else
                    {
                        autoNumber = "IN0000000000001";
                        return autoNumber;
                    }
                }
            }
        }

        public List<SuratJalan> findAllData(String search)
        {
            Console.WriteLine(findAllDataQuery);

            List<SuratJalan> daftarSuratJalan = new List<SuratJalan>();
            using (MySqlCommand cmd = new MySqlCommand(findAllDataQuery, connection))
            {
                cmd.Parameters.AddWithValue("@1", "%" + search + "%");
                cmd.Parameters.AddWithValue("@2", 0);
                cmd.Parameters.AddWithValue("@3", 300);

                using (MySqlDataReader mdr = cmd.ExecuteReader())
                {
                    while (mdr.Read())
                    {
                        daftarSuratJalan.Add(mappingKeObject(mdr));
                    }
                }
            }
            return daftarSuratJalan;
        }

        private SuratJalan mappingKeObject(MySqlDataReader mdr)
        {
            SuratJalan s = new SuratJalan();
            s.Id = mdr.GetString("SURAT_JALAN_ID");
            s.Tanggal = mdr.GetDateTime("TANGGAL_SURAT_JALAN");
            s.Sewa = new Sewa(mdr.GetString("SEWA_ID"));

            return s;
        }

        #endregion
    }
}
