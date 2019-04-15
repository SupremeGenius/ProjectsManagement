using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ProjectManagement.GUI.Utils;
using ProjectManagement.DTO;

namespace ProjectManagement.DAO
{
    
    class tbl_JoiningDAO
    {
        SqlConnection con = null;


        public List<int> GetListEmIDByProjectId(int projectId)
        {
            try
            {
                using(con = DBConnection.MakeConnection(con))
                {
                    List<int> listEmId = new List<int>();
                    con.Open();
                    SqlCommand command = new SqlCommand("Select emId from tbl_Joining where projectId=@projectId", con);
                    command.Parameters.AddWithValue("@projectId", projectId);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        listEmId.Add(reader.GetInt32(0));
                    }
                    return listEmId;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<int> GetListProjectByEmId(int emID)
        {
            try
            {
                using (con = DBConnection.MakeConnection(con))
                {
                    List<int> listProId = new List<int>();
                    con.Open();
                    SqlCommand command = new SqlCommand("Select projectId from tbl_Joining where emId = @emId", con);
                    command.Parameters.AddWithValue("@emId", emID);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        listProId.Add(reader.GetInt32(0));
                    }
                    return listProId;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteByProID_EmID(int proID, int emID)
        {
            try
            {
                using(con = DBConnection.MakeConnection(con))
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("Delete from tbl_Joining where projectId = @proID and emId = @emId", con);
                    command.Parameters.AddWithValue("@proID", proID);
                    command.Parameters.AddWithValue("@emId", emID);
                    int row = command.ExecuteNonQuery();
                    if (row > 0)
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

        public bool Insert(int proID, int emID)
        {
            try
            {
                using (con = DBConnection.MakeConnection(con))
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("Insert into tbl_Joining(projectId, emId) values(@proID,@emId)", con);
                    command.Parameters.AddWithValue("@proID", proID);
                    command.Parameters.AddWithValue("@emId", emID);
                    int row = command.ExecuteNonQuery();
                    if (row > 0)
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
