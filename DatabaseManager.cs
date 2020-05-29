using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//Connection
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Data_Driven_6518_Survey_App
{
    public class DatabaseManager
    {
        private string connectionString;
        private SqlConnection conn;
        public DatabaseManager()
        {
            connectionString = ConfigurationManager.ConnectionStrings["TestConnection"].ConnectionString;
        }
        public SqlConnection openConnection()
        {
            conn = new SqlConnection(connectionString);
            conn.Open();
            return conn;
        }
    }
}