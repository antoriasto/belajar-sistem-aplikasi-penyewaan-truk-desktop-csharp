using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using domain.model;
using MySql.Data.MySqlClient;
using core.utilities;

namespace core.dao
{
    public class CustomerDao
    {
        private MySqlConnection connection;

        // Variabel mysql koneksi, koneksi privatenya yang dipake di semua method.
        public MySqlConnection setConnection {
            set { this.connection = value; }
        }

        #region Query

        // Script semua Query yang diapake.
        // Create, Find, Update, Delete.
        // ----------------------------
        private readonly string insertQuery = "INSERT INTO customer (CUSTOMER_ID, NAMA_CUSTOMER, ALAMAT_CUSTOMER, TELEPON_CUSTOMER) values(@1,@2,@3,@4)";

        private readonly string updateQuery = "UPDATE customer " +
            "set NAMA_CUSTOMER=@1, ALAMAT_CUSTOMER=@2, TELEPON_CUSTOMER=@3 " + "where CUSTOMER_ID=@4";

        private readonly string deleteQuery = "DELETE from customer " +
            "where CUSTOMER_ID=@1";

        private readonly string generateIdQuery = "SELECT CUSTOMER_ID " +
            "from customer " +
            "ORDER BY CUSTOMER_ID DESC";

        private readonly string findByIdQuery = "SELECT CUSTOMER_ID, NAMA_CUSTOMER, ALAMAT_CUSTOMER, TELEPON_CUSTOMER " +
            "from customer " +
            "where CUSTOMER_ID= @1";

        private readonly string countAllDataQuery =
                    "SELECT count(CUSTOMER_ID)" +
                    "from customer";

        private readonly string countAllDataSearchQuery = "SELECT count(CUSTOMER_ID)" +
                    "from customer " +
                    "where NAMA_CUSTOMER like @1";

        private readonly string findAllDataQuery = "SELECT CUSTOMER_ID, NAMA_CUSTOMER, ALAMAT_CUSTOMER, TELEPON_CUSTOMER " +
            "from customer";

        private readonly string findAllDataPagingAndSearchQuery = "SELECT CUSTOMER_ID, NAMA_CUSTOMER, ALAMAT_CUSTOMER, TELEPON_CUSTOMER " +
            "from customer where NAMA_CUSTOMER like @1 limit @2, @3";

        #endregion

        #region Dao Data Acces Object

        /// <summary>
        /// Poin engine ada disini save ke database.
        /// Gunain koneksi (MySql) privatenya yang diatas.
        /// </summary>

        public Customer save(Customer customer) {
            Console.WriteLine(insertQuery);
            using (MySqlCommand cmd = new MySqlCommand(insertQuery, connection)) {
                cmd.Parameters.AddWithValue("@1", customer.Id);
                cmd.Parameters.AddWithValue("@2", customer.Nama);
                cmd.Parameters.AddWithValue("@3", customer.Alamat);
                cmd.Parameters.AddWithValue("@4", customer.Telefon);

                int x = cmd.ExecuteNonQuery();
                return customer;
            }
        }

        public Customer update(Customer customer) {
            using (MySqlCommand cmd = new MySqlCommand(updateQuery, connection)) {
                cmd.Parameters.AddWithValue("@1", customer.Nama);
                cmd.Parameters.AddWithValue("@2", customer.Alamat);
                cmd.Parameters.AddWithValue("@3", customer.Telefon);
                cmd.Parameters.AddWithValue("@4", customer.Id);

                int x = cmd.ExecuteNonQuery();
                return customer;
            }
        }

        public Customer delete(Customer customer) {
            using (MySqlCommand cmd = new MySqlCommand(deleteQuery, connection)) {
                cmd.Parameters.AddWithValue("@1", customer.Id);

                int x = cmd.ExecuteNonQuery();
                return customer;
            }
        }

        public String nomorOtomatis() {
            using (MySqlCommand cmd = new MySqlCommand(generateIdQuery, connection)) {
                using (MySqlDataReader mdr = cmd.ExecuteReader()) {
                    Truk truk = new Truk();
                    if (mdr.Read()) {
                        String id = UtilsLeftRightMid.Mid(mdr.GetString("CUSTOMER_ID"), 1, 4);
                        Int32 nilai = Convert.ToInt32(id) + 1;

                        String AN = UtilsLeftRightMid.Right("0000", 4 - nilai.ToString().Length) + nilai;
                        return "C" + AN.ToString();
                    }
                    else {
                        truk.Id = "C0001";
                        return truk.Id;
                    }
                }
            }
        }

        public Customer findById(String customerId) {
            using (MySqlCommand cmd = new MySqlCommand(findByIdQuery, connection)) {
                cmd.Parameters.AddWithValue("@1", customerId);
                using (MySqlDataReader mdr = cmd.ExecuteReader()) {
                    if (mdr.Read()) {
                        Customer customer = mappingKeObject(mdr);
                        return customer;
                    }
                }
            }
            return null;
        }

        public long countAllData() {
            int jumlahbaris = 0;

            using (MySqlCommand cmd = new MySqlCommand(countAllDataQuery, connection)) {
                using (MySqlDataReader mdr = cmd.ExecuteReader()) {
                    if (mdr.Read()) {
                        jumlahbaris = mdr.GetInt32("count(ID)");
                    }
                }
            }
            return jumlahbaris;
        }

        public long countAllData(String search) {
            int jumlahbaris = 0;

            using (MySqlCommand cmd = new MySqlCommand(countAllDataSearchQuery, connection)) {
                cmd.Parameters.AddWithValue("@1", "%" + search + "%");
                using (MySqlDataReader mdr = cmd.ExecuteReader()) {
                    if (mdr.Read()) {
                        jumlahbaris = mdr.GetInt32("count(ID)");
                    }
                }
            }
            return jumlahbaris;
        }

        public List<Customer> findAllData() {

            List<Customer> daftarCustomer = new List<Customer>();

            using (MySqlCommand cmd = new MySqlCommand(findAllDataQuery, connection)) {
                using (MySqlDataReader mdr = cmd.ExecuteReader()) {
                    while (mdr.Read()) {
                        Customer customer = mappingKeObject(mdr);
                        daftarCustomer.Add(customer);
                    }
                }
            }
            return daftarCustomer;
        }

        public List<Customer> findAllData(String search) {
            List<Customer> daftarCustomer = new List<Customer>();

            using (MySqlCommand cmd = new MySqlCommand(findAllDataPagingAndSearchQuery, connection)) {
                cmd.Parameters.AddWithValue("@1", "%" + search + "%");
                cmd.Parameters.AddWithValue("@2", 0);
                cmd.Parameters.AddWithValue("@3", 200);

                using (MySqlDataReader mdr = cmd.ExecuteReader()) {
                    while (mdr.Read()) {
                        Customer customer = mappingKeObject(mdr);
                        daftarCustomer.Add(customer);
                    }
                }
            }
            return daftarCustomer;
        }

        private Customer mappingKeObject(MySqlDataReader mdr) {
            Customer cst = new Customer();
            cst.Id = mdr.GetString("CUSTOMER_ID");
            cst.Nama = mdr.GetString("NAMA_CUSTOMER");
            cst.Alamat = mdr.GetString("ALAMAT_CUSTOMER");
            cst.Telefon = mdr.GetString("TELEPON_CUSTOMER");

            return cst;
        }

        #endregion

    }
}
