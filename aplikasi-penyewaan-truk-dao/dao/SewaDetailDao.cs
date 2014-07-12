using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using domain.model;
using MySql.Data.MySqlClient;

namespace core.dao
{
    public class SewaDetailDao
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
        private readonly string insertQuery = "INSERT INTO sewa_detail (SEWA_ID, TRUK_ID, HARGA, KETERANGAN) values(@1,@2,@3,@4)";

        private readonly string findByIdQuery = "SELECT SEWA_ID, TANGGAL_SEWA, HARGA " +
            "from Sewa " +
            "where SEWA_ID= @1";

        private readonly string countAllDataQuery =
                    "SELECT count(SEWA_ID)" +
                    "from Sewa";

        private readonly string countAllDataSearchQuery = "SELECT count(SEWA_ID)" +
                    "from sewa_detail " +
                    "where SEWA_ID like @1";

        private readonly string findAllDataQuery = "SELECT SEWA_ID, TRUK_ID, HARGA, KETERANGAN " +
            "from sewa_detail where SEWA_ID like @1 limit @2, @3";

        #endregion

        #region Dao Data Acces Object

        /// <summary>
        /// Poin engine ada disini save ke database.
        /// Gunain koneksi (MySql) privatenya yang diatas.
        /// </summary>

        public SewaDetail save(SewaDetail sewaDetail)
        {
            Console.WriteLine(insertQuery);
            using (MySqlCommand cmd = new MySqlCommand(insertQuery, connection))
            {
                cmd.Parameters.AddWithValue("@1", sewaDetail.Id);
                cmd.Parameters.AddWithValue("@2", sewaDetail.Truk.Id);
                cmd.Parameters.AddWithValue("@3", sewaDetail.Price);

                int x = cmd.ExecuteNonQuery();
                return sewaDetail;
            }
        }

        public SewaDetail findById(String sewaId)
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
                        jumlahbaris = mdr.GetInt32("count(SEWA_ID)");
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

        public List<SewaDetail> findAllData(String search)
        {
            Console.WriteLine(findAllDataQuery);

            List<SewaDetail> daftarSewaDetail = new List<SewaDetail>();
            using (MySqlCommand cmd = new MySqlCommand(findAllDataQuery, connection))
            {
                cmd.Parameters.AddWithValue("@1", "%" + search + "%");
                cmd.Parameters.AddWithValue("@2", 0);
                cmd.Parameters.AddWithValue("@3", 300);

                using (MySqlDataReader mdr = cmd.ExecuteReader())
                {
                    while (mdr.Read())
                    {
                        daftarSewaDetail.Add(mappingKeObject(mdr));
                    }
                }
            }
            return daftarSewaDetail;
        }

        private SewaDetail mappingKeObject(MySqlDataReader mdr)
        {
            SewaDetail s = new SewaDetail();
            s.Id = mdr.GetString("SEWA_ID");
            s.Truk = new Truk(mdr.GetString("TRUK_ID"));
            s.Price = mdr.GetDecimal("HARGA");
            s.Keterangan = mdr.GetString("KETERANGAN");
            return s;
        }

        #endregion

        internal void save(IList<SewaDetail> sewaDetail) {
            Console.WriteLine(insertQuery);
            
            foreach (SewaDetail s in sewaDetail) {
                using (MySqlCommand cmd = new MySqlCommand(insertQuery, connection)) {
                
                    cmd.Parameters.AddWithValue("@1", s.Id);
                    cmd.Parameters.AddWithValue("@2", s.Truk.Id);
                    cmd.Parameters.AddWithValue("@3", s.Price);
                    cmd.Parameters.AddWithValue("@4", s.Keterangan);
                    
                    int x = cmd.ExecuteNonQuery();
                }
            }
        }



    }
}
