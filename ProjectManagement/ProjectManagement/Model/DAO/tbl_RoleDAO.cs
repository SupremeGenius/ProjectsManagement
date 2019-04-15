using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ProjectManagement.GUI.Utils;
using System.Windows.Forms;

namespace ProjectManagement.DAO
{
    class tbl_RoleDAO
    {
        SqlConnection con;
        public string GetByID(int id)
        {
            try
            {
                using(con = DBConnection.MakeConnection(con))
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("Select roleName from tbl_Role where id=@id", con);
                    command.Parameters.AddWithValue("@id", id);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        return id + " - " + reader.GetString(0);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return null;
        }

        public void GetAll(ref ComboBox cb)
        {
            try
            {
                using(con = DBConnection.MakeConnection(con))
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("Select roleName from tbl_Role", con);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        cb.Items.Add(reader["roleName"]);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int GetIdByName(string roleName)
        {
            try
            {
                using(con = DBConnection.MakeConnection(con))
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("Select id from tbl_Role where roleName = @name", con);
                    command.Parameters.AddWithValue("@name", roleName);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        return reader.GetInt32(0);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return -1;
        }
    }
}
