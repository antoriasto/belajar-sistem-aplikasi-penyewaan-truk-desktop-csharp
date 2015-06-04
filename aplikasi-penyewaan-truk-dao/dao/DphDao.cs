using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using domain.model;
using aplikasi_penyewaan_truk_domain.model;
using core.utilities;

namespace core.dao
{
    public class DphDao
    {
        private MySqlConnection connection;

        // Variabel mysql koneksi, koneksi privatenya yang dipake di semua method.
        public MySqlConnection setConnection
        {
            set { this.connection = value; }
        }

        private readonly string insertQuery = "INSERT INTO dph (DPH_ID, CUSTOMER_ID, TANGGAL_DPH) values(@1,@2,@3)";
        private readonly string generateIdQuery = "SELECT DPH_ID " +
            "from Dph " +
            "ORDER BY DPH_ID DESC";

        public Dph save(Dph Dph)
        {
            Console.WriteLine(insertQuery);
            using (MySqlCommand cmd = new MySqlCommand(insertQuery, connection))
            {
                cmd.Parameters.AddWithValue("@1", Dph.Id);
                cmd.Parameters.AddWithValue("@2", Dph.Customer.Id);
                cmd.Parameters.AddWithValue("@3", Dph.Tanggal);

                int x = cmd.ExecuteNonQuery();
                return Dph;
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
                        String id = UtilsLeftRightMid.Mid(mdr.GetString("DPH_ID"), 2, 13);
                        Int32 nilai = Convert.ToInt32(id) + 1;

                        String AN = UtilsLeftRightMid.Right("PH0000000000000", 13 - nilai.ToString().Length) + nilai;
                        return "PH" + AN.ToString();
                    }
                    else
                    {
                        truk.Id = "PH0000000000001";
                        return truk.Id;
                    }
                }
            }
        }


    }
}
