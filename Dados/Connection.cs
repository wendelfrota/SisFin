using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados
{
    public class Connection
    {
        public static String conString = ConfigurationManager.ConnectionStrings["cnStrSqlServer"].ConnectionString;
        public static SqlConnection Con = new SqlConnection();

        public static void getConnection()
        {
            try
            {
                if (Connection.Con.State == System.Data.ConnectionState.Closed)
                {
                   Connection.Con.ConnectionString=conString;
                   Connection.Con.Open();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
