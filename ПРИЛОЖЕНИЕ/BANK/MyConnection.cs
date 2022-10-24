using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BANK
{
    public static class MyConnection
    {
        static public SqlConnection Connection = new SqlConnection(@"Data Source=DESKTOP-9N46EPK\DANIIL_BANK1230;Initial Catalog=data_bank;Integrated Security=True");

        static public void OpenConnection()
        {
            if (Connection.State == System.Data.ConnectionState.Closed)
                Connection.Open();
        }

        static public void CloseConnection()
        {
            if (Connection.State == System.Data.ConnectionState.Open)
                Connection.Close();
        }

        static public System.Data.SqlClient.SqlConnection GetConnection()
        {
            return Connection;
        }
    }
}
