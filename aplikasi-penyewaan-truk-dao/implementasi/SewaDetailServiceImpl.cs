using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using domain.service;
using domain.model;
using core.dao;
using MySql.Data.MySqlClient;
using core.utilities;

namespace core.implementasi
{
    public class SewaDetailServiceImpl : ISewaDetailService
    {
        private SewaDetailDao sewaDetailDao = new SewaDetailDao();
        private MySqlConnection connection;

        public SewaDetailServiceImpl() {
            connection = new MySqlConnection(DataBaseConnection.stringMySqlConnection);
        }

        public IList<SewaDetail> findAllData(String id)
        {
            try
            {
                // Setting koneksi dan buka koneksi.
                sewaDetailDao.setConnection = connection;
                connection.Open();
                return sewaDetailDao.findAllData(id);
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




    }
}
