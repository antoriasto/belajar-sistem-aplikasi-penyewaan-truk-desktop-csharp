using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace core.utilities
{
    public static class DataBaseConnection
    {

        // Script alamat koneksi database mysql.
        public static readonly string stringMySqlConnection = "Database=truck_db;" +
                                    "Server=localhost;" +
                                    "port=3306;" +
                                    "Uid=root;" +
                                    "password=admin;";

    }
}
