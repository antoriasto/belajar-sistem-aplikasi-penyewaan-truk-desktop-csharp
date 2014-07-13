using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using domain.service;
using MySql.Data.MySqlClient;
using core.utilities;
using core.dao;
using domain.model;
using domain.model.enumerasi;

namespace core.implementasi
{
    public class InvoiceServiceImpl : IInvoiceService
    {
        private InvoiceDao invoiceDao = new InvoiceDao();
        private TrukDao trukDao = new TrukDao();
        private MySqlConnection connection;

        public InvoiceServiceImpl() {
            connection = new MySqlConnection(DataBaseConnection.stringMySqlConnection);
        }


        public Invoice save(Invoice invoice)
        {
            try
            {
                // Setting koneksi dan buka koneksi.
                invoiceDao.setConnection = connection;
                connection.Open();
                return invoice;
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

        public String autoNumber()
        {
            try
            {
                // Setting koneksi dan buka koneksi.
                invoiceDao.setConnection = connection;
                connection.Open();
                return invoiceDao.nomorOtomatis();
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

        public Invoice save(Invoice invoice, IList<Truk> listTruk)
        {
            try
            {
                // Setting koneksi dan buka koneksi.
                invoiceDao.setConnection = connection;
                trukDao.setConnection = connection;
                connection.Open();

                invoiceDao.save(invoice);
                foreach(Truk t in listTruk) {
                    t.Status = StatusTruk.Tersedia.ToString();
                    trukDao.updateStatusTruk(t);
                }
                return invoice;
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
