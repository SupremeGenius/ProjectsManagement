using ProjectManagement.GUI.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement
{
    class tbl_AccountDAO
    {

        SqlConnection con = null;
        /// <summary>
        /// check login
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool CheckLogin(string username, string password)
        {
            try
            {
                using (con = DBConnection.OpenConnection(con))
                {

                    SqlCommand command = new SqlCommand();
                    command.CommandType = CommandType.Text;
                    command.CommandText = "Select roleId from tbl_Account where username =@Username and password =@Password";
                    command.Connection = con;
                    command.Parameters.Add("@Username", SqlDbType.NVarChar).Value = username;
                    command.Parameters.Add("@Password", SqlDbType.NVarChar).Value = password;
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        return true;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return false;
        }

    }
}
