using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace ProjectManagement.GUI.Utils
{
    class DBConnection
    {
        public static SqlConnection MakeConnection(SqlConnection con)
        {
            string strConnection = ConfigurationManager.ConnectionStrings["assignment"].ConnectionString;
            con = new SqlConnection(strConnection);
            return con;
        }

        public static SqlConnection OpenConnection(SqlConnection con)
        {
            if (con == null)
            {
                con = MakeConnection(con);
            }
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            return con;
        }

        public static SqlConnection CloseConnection(SqlConnection con)
        {
            if (con != null && con.State == ConnectionState.Open)
            {
                con.Close();
            }
            return con;
        }

    }
}
