using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using core.utilities;
using domain.model;
using domain.model.enumerasi;

namespace core.dao
{
    public class HargaRuteTrukDao
    {
        private MySqlConnection connection;

        // Variabel mysql koneksi, koneksi privatenya yang dipake di semua method.
        public MySqlConnection setConnection
        {
            set { this.connection = value; }
        }

        #region Query Yang Kepake Buat KKP

        // Script semua Query yang diapake.
        // Create, Find, Update, Delete.
        // ----------------------------
        private readonly string insertQuery = "INSERT INTO harga_truk_rute (HARGA_TRUK_RUTE_ID, RUTE_ID, TRUK_ID, HARGA, HARGA_SUPIR) values(@1,@2,@3,@4,@5)";

        private readonly string updateQuery = "UPDATE harga_truk_rute " +
            "set HARGA=@1, RUTE_ID=@2, TRUK_ID=@3, HARGA_SUPIR=@5 " + "where HARGA_TRUK_RUTE_ID=@4";

        private readonly string deleteQuery = "DELETE from harga_truk_rute " +
            "where HARGA_TRUK_RUTE_ID=@1";

        private readonly string deleteByTrukIdQuery = "DELETE from harga_truk_rute " +
            "where TRUK_ID=@1";

        private readonly string findByIdQuery = "SELECT HARGA_TRUK_RUTE_ID, RUTE_ID, TRUK_ID, HARGA, HARGA_SUPIR " +
            "from harga_truk_rute " +
            "where HARGA_TRUK_RUTE_ID= @1";

        private readonly string generateIdQuery = "SELECT HARGA_TRUK_RUTE_ID " +
            "from harga_truk_rute " +
            "ORDER BY HARGA_TRUK_RUTE_ID DESC";

        private readonly string findAllDataQuery = "SELECT HARGA_TRUK_RUTE_ID, RUTE_ID, TRUK_ID, HARGA, HARGA_SUPIR " +
            "from harga_truk_rute " +
            "where NOMOR_POLISI LIKE @1 OR SUPIR_ID =@2 OR JENIS_TRUK_ID =@3 OR STATUS =@4";

        private readonly string findAllDataByTrukIdQuery = "SELECT HARGA_TRUK_RUTE_ID, RUTE_ID, TRUK_ID, HARGA, HARGA_SUPIR " +
            "from harga_truk_rute " +
            "where TRUK_ID = @1";

        private readonly string findAllDataByRuteIdQuery = "SELECT HARGA_TRUK_RUTE_ID, RUTE_ID, TRUK_ID, HARGA, HARGA_SUPIR " +
            "from harga_truk_rute " +
            "where RUTE_ID = @1";

        #endregion

        #region Query Yang Ga Kepake

        private readonly string countAllDataByTrukIdQuery =
            "SELECT count(HARGA_TRUK_RUTE_ID)" +
            "from harga_truk_rute where TRUK_ID=@1";

        //private readonly string countAllDataSearchQuery = "SELECT count(HARGA_TRUK_RUTE_ID)" +
        //            "from harga_truk_rute " +
        //            "where TRUK_ID like @1";

        #endregion

        #region

        public String nomorOtomatis()
        {
            using (MySqlCommand cmd = new MySqlCommand(generateIdQuery, connection))
            {
                using (MySqlDataReader mdr = cmd.ExecuteReader())
                {
                    HargaRuteTruk h = new HargaRuteTruk();
                    if (mdr.Read())
                    {
                        String id = UtilsLeftRightMid.Mid(mdr.GetString("HARGA_TRUK_RUTE_ID"), 1, 4);
                        Int32 nilai = Convert.ToInt32(id) + 1;

                        String AN = UtilsLeftRightMid.Right("0000", 4 - nilai.ToString().Length) + nilai;
                        return "H" + AN.ToString();
                    }
                    else
                    {
                        h.Id = "H0001";
                        return h.Id;
                    }
                }
            }
        }

        public HargaRuteTruk save(HargaRuteTruk h)
        {
            Console.WriteLine(insertQuery);
            using (MySqlCommand cmd = new MySqlCommand(insertQuery, connection))
            {
                cmd.Parameters.AddWithValue("@1", nomorOtomatis());
                cmd.Parameters.AddWithValue("@2", h.Rute.Id);
                cmd.Parameters.AddWithValue("@3", h.Truk.Id);
                cmd.Parameters.AddWithValue("@4", h.Harga);
                cmd.Parameters.AddWithValue("@5", h.Harga_supir);


                cmd.ExecuteNonQuery();

                return h;
            }
        }

        public HargaRuteTruk update(HargaRuteTruk h)
        {
            Console.WriteLine(updateQuery);
            using (MySqlCommand cmd = new MySqlCommand(updateQuery, connection))
            {
                cmd.Parameters.AddWithValue("@1", h.Harga);
                cmd.Parameters.AddWithValue("@2", h.Rute.Id);
                cmd.Parameters.AddWithValue("@3", h.Truk.Id);
                cmd.Parameters.AddWithValue("@4", h.Id);
                cmd.Parameters.AddWithValue("@5", h.Harga_supir);


                int x = cmd.ExecuteNonQuery();
                return h;
            }
        }

        public HargaRuteTruk delete(HargaRuteTruk h)
        {
            Console.WriteLine(deleteQuery);
            using (MySqlCommand cmd = new MySqlCommand(deleteQuery, connection))
            {
                cmd.Parameters.AddWithValue("@1", h.Id);

                int x = cmd.ExecuteNonQuery();
                return h;
            }
        }

        public void deleteByTrukId(String trukId)
        {
            Console.WriteLine(deleteByTrukIdQuery);
            using (MySqlCommand cmd = new MySqlCommand(deleteByTrukIdQuery, connection))
            {
                cmd.Parameters.AddWithValue("@1", trukId);

                int x = cmd.ExecuteNonQuery();
            }
        }

        public long countAllData(Truk truk)
        {
            int jumlahbaris = 0;

            using (MySqlCommand cmd = new MySqlCommand(countAllDataByTrukIdQuery, connection))
            {
                cmd.Parameters.AddWithValue("@1", truk.Id);
                using (MySqlDataReader mdr = cmd.ExecuteReader())
                {
                    if (mdr.Read())
                    {
                        jumlahbaris = mdr.GetInt32("count(HARGA_TRUK_RUTE_ID)");
                    }
                }
            }
            return jumlahbaris;
        }

        public IList<HargaRuteTruk> findAllDataByTrukId(String trukId)
        {
            List<HargaRuteTruk> daftarHargaRuteTruk = new List<HargaRuteTruk>();
            
            using (MySqlCommand cmd = new MySqlCommand(findAllDataByTrukIdQuery, connection))
            {
                cmd.Parameters.AddWithValue("@1", trukId);
                using (MySqlDataReader mdr = cmd.ExecuteReader())
                {
                    while (mdr.Read())
                    {
                        daftarHargaRuteTruk.Add(mappingKeObject(mdr));
                    }
                }
            }
            return daftarHargaRuteTruk;
        }

        public IList<HargaRuteTruk> findAllDataByRuteId(String ruteId)
        {
            List<HargaRuteTruk> daftarHargaRuteTruk = new List<HargaRuteTruk>();

            using (MySqlCommand cmd = new MySqlCommand(findAllDataByRuteIdQuery, connection))
            {
                cmd.Parameters.AddWithValue("@1", ruteId);
                using (MySqlDataReader mdr = cmd.ExecuteReader())
                {
                    while (mdr.Read())
                    {
                        daftarHargaRuteTruk.Add(mappingKeObject(mdr));
                    }
                }
            }
            return daftarHargaRuteTruk;
        }


        public void doMultipleJob(IList<HargaRuteTruk> list)
        {
            foreach (HargaRuteTruk h in list)
            {
                //if (h.Id == null)
                //{
                    switch (h.Status)
                    {
                        case Command.New:
                            save(h);
                            break;
                        case Command.Update:
                            update(h);
                            break;
                        case Command.Delete:
                            delete(h);
                            break;
                        default:
                            Console.WriteLine("Not Execute");
                            break;
                    }
                //}
            }
        }

        #endregion

        private HargaRuteTruk mappingKeObject(MySqlDataReader mdr)
        {
            HargaRuteTruk h = new HargaRuteTruk();
            h.Id = mdr.GetString("HARGA_TRUK_RUTE_ID");
            h.Truk = new Truk((mdr.GetString("TRUK_ID")));
            h.Rute = new Rute((mdr.GetString("RUTE_ID")));
            h.Harga = mdr.GetDecimal("HARGA");
            h.Harga_supir = mdr.GetDecimal("HARGA_SUPIR");
            h.Status = Command.None;

            return h;
        }

        public HargaRuteTruk findById(String id)
        {
            using (MySqlCommand cmd = new MySqlCommand(findByIdQuery, connection))
            {
                cmd.Parameters.AddWithValue("@1", id);
                using (MySqlDataReader mdr = cmd.ExecuteReader())
                {
                    if (mdr.Read())
                    {
                        HargaRuteTruk h = mappingKeObject(mdr);
                        return h;
                    }
                }
            }
            return null;
        }

    }
}
