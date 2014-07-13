using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using domain.model;
using core.utilities;
using domain.model.enumerasi;

namespace core.dao
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
        private readonly string insertQuery = "INSERT INTO Truk (TRUK_ID, NOMOR_POLISI, STATUS, SUPIR_ID, JENIS_TRUK_ID) values(@1,@2,@3,@4,@5)";

        private readonly string updateQuery = "UPDATE truk " +
            "set NOMOR_POLISI=@1, STATUS=@2, SUPIR_ID=@3, JENIS_TRUK_ID=@4 " + "where TRUK_ID=@5";

        private readonly string updateStatusTrukQuery = "UPDATE Truk " +
            "set STATUS=@2 " + "where TRUK_ID=@5";

        private readonly string deleteQuery = "DELETE from Truk " +
            "where TRUK_ID=@1";

        private readonly string findByIdQuery = "SELECT TRUK_ID, NOMOR_POLISI, SUPIR_ID, JENIS_TRUK_ID, STATUS " +
            "from Truk " +
            "where TRUK_ID= @1";

        private readonly string validatePoliceNumberQuery = "SELECT NOMOR_POLISI " +
            "from Truk " +
            "where NOMOR_POLISI= @1";

        private readonly string generateIdQuery = "SELECT TRUK_ID " +
            "from Truk " +
            "ORDER BY TRUK_ID DESC";

        private readonly string countAllDataQuery =
                    "SELECT count(TRUK_ID)" +
                    "from Truk";

        private readonly string countAllDataSearchQuery = "SELECT count(ID)" +
                    "from Truk " +
                    "where NOMOR_POLISI like @1";

        private readonly string findAllDataQuery = "SELECT TRUK_ID, NOMOR_POLISI, SUPIR_ID, JENIS_TRUK_ID, STATUS " +
            "from Truk " +
            "where NOMOR_POLISI LIKE @1 OR SUPIR_ID =@2 OR JENIS_TRUK_ID =@3 OR STATUS =@4";

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
                cmd.Parameters.AddWithValue("@3", truk.Status);
                cmd.Parameters.AddWithValue("@4", truk.Supir.Id);
                cmd.Parameters.AddWithValue("@5", truk.JenisTruk.Id);

                cmd.ExecuteNonQuery();

                return truk;
            }
        }

        public Truk saveTrukAndPriceRute(Truk truk, IList<HargaRuteTruk> list)
        {
            save(truk);
            HargaRuteTrukDao h = new HargaRuteTrukDao();
            h.setConnection = this.connection;

            h.doMultipleJob(list);

            return truk;
        }

        

        public Truk update(Truk truk)
        {
            Console.WriteLine(updateQuery);
            using (MySqlCommand cmd = new MySqlCommand(updateQuery, connection))
            {
                cmd.Parameters.AddWithValue("@1", truk.NomorPolisi);
                cmd.Parameters.AddWithValue("@2", truk.Status);
                cmd.Parameters.AddWithValue("@3", truk.Supir.Id);
                cmd.Parameters.AddWithValue("@4", truk.JenisTruk.Id);
                cmd.Parameters.AddWithValue("@5", truk.Id);

                int x = cmd.ExecuteNonQuery();
                return truk;
            }
        }

        public Truk updateStatusTruk(Truk truk)
        {
            using (MySqlCommand cmd = new MySqlCommand(updateStatusTrukQuery, connection))
            {
                cmd.Parameters.AddWithValue("@2", truk.Status);
                cmd.Parameters.AddWithValue("@5", truk.Id);

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

        public Boolean validatePoliceNumber(String policeNumber) {

            using (MySqlCommand cmd = new MySqlCommand(validatePoliceNumberQuery, connection))
            {
                cmd.Parameters.AddWithValue("@1", policeNumber);
                using (MySqlDataReader mdr = cmd.ExecuteReader())
                {
                    if (mdr.Read())
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public Truk cariTrukDanHargaRute(String id)
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
                        String id = UtilsLeftRightMid.Mid(mdr.GetString("TRUK_ID"), 1, 4);
                        Int32 nilai = Convert.ToInt32(id) + 1;

                        String AN = UtilsLeftRightMid.Right("0000", 4 - nilai.ToString().Length) + nilai;
                        return "T" + AN.ToString();
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
                        jumlahbaris = mdr.GetInt32("count(TRUK_ID)");
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
                cmd.Parameters.AddWithValue("@2", "%" + "" + "%");
                cmd.Parameters.AddWithValue("@3", "%" + "" + "%");
                cmd.Parameters.AddWithValue("@4", "%" + "" + "%");

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
                    truk.Supir = supir;
                }
            }

            if (!mdr.IsDBNull(ordinalJenisTruk))
            {
                if (!mdr.GetString("JENIS_TRUK_ID").Equals(""))
                {
                    JenisTruk j = new JenisTruk();
                    j.Id = mdr.GetString("JENIS_TRUK_ID");
                    truk.JenisTruk = j;
                }
            }

            truk.Status = mdr.GetString("STATUS");

            return truk;
        }

        #endregion

        internal void update(IList<Truk> listTruk)
        {
            foreach(Truk t in listTruk) {
                t.Status = StatusTruk.Sedang_Beroperasi.ToString();
                updateStatusTruk(t);
            }
        }
    }
}
