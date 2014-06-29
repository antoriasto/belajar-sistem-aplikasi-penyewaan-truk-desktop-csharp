using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using domain.model;
using domain.service;
using core.dao;
using MySql.Data.MySqlClient;
using core.utilities;

namespace core.implementasi
{
    public class CustomerServiceImpl : ICustomerService
    {
        private CustomerDao customerDao;
        private MySqlConnection connection = null;

        // Constructor
        public CustomerServiceImpl()
        {
            // Initialize new Implementation.
            customerDao = new CustomerDao();
            // Setting koneksi string mysql (liat static class di Utilities > Database Connection).
            connection = new MySqlConnection(DataBaseConnection.stringMySqlConnection);
            Console.WriteLine("Customer Dao Initialize");
        }

        #region Method Untuk Akses Dao

        /// <summary>
        /// Ini method Akses Dao, bisa dibilang controllernya ada disini.
        /// Kalo Ada Kesalahan di Class DAO, class ini ngebalikin nilai null atau default ke View.
        /// </summary>

        public Customer save(Customer customer)
        {
            try
            {
                // Setting koneksi dan buka koneksi.
                customerDao.setConnection = connection;
                connection.Open();
                return customerDao.save(customer);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                connection.Close();
            }
            return null;
        }

        public Customer ubah(Customer customer)
        {
            try
            {
                // Setting koneksi dan buka koneksi di class Dao dari sini.
                customerDao.setConnection = connection;
                connection.Open();
                return customerDao.update(customer);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                // Tutup Koneksi.
                connection.Close();
            }
            return null;
        }

        public Customer hapus(Customer customer)
        {
            try
            {
                // Setting koneksi dan buka koneksi di class Dao dari sini.
                customerDao.setConnection = connection;
                connection.Open();
                return customerDao.delete(customer);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                // Tutup Koneksi.
                connection.Close();
            }
            return null;
        }

        public string nomorOtomatis()
        {
            try
            {
                // Setting koneksi dan buka koneksi di class Dao dari sini.
                customerDao.setConnection = connection;
                connection.Open();
                return customerDao.nomorOtomatis();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                // Tutup Koneksi.
                connection.Close();
            }
            return null;
        }

        public Customer cari(String id)
        {
            try
            {
                // Setting koneksi dan buka koneksi di class Dao dari sini.
                customerDao.setConnection = connection;
                connection.Open();
                return customerDao.findById(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                connection.Close();
            }
            finally
            {
                // Tutup Koneksi.
                connection.Close();
            }
            return null;
        }

        public long countAllData(String search)
        {
            try
            {
                // Setting koneksi dan buka koneksi di class Dao dari sini.
                customerDao.setConnection = connection;
                connection.Open();
                return customerDao.countAllData(search);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                // Tutup Koneksi.
                connection.Close();
            }
            return 0;
        }

        public IList<Customer> cariDaftarCustomer(String search)
        {
            try
            {
                // Setting koneksi dan buka koneksi di class Dao dari sini.
                customerDao.setConnection = connection;
                connection.Open();
                return customerDao.findAllData(search);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                // Tutup Koneksi.
                connection.Close();
            }
            return null;
        }

        #endregion





        public Customer update(Customer domain)
        {
            try
            {
                // Setting koneksi dan buka koneksi di class Dao dari sini.
                customerDao.setConnection = connection;
                connection.Open();
                return customerDao.update(domain);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                connection.Close();
            }
            finally
            {
                // Tutup Koneksi.
                connection.Close();
            }
            return null;
        }
    }
}
