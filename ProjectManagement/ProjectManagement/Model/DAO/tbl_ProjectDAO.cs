using ProjectManagement.DTO;
using ProjectManagement.GUI.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectManagement.DAO
{
    class tbl_ProjectDAO
    {
        SqlConnection con = null;
        SqlDataAdapter adapter;
        DataSet ds = new DataSet();

        public void GetAllProject(ref DataGridView gv)
        {
            try
            {
                using (con = DBConnection.MakeConnection(con))
                {
                    adapter = new SqlDataAdapter("SELECT id, name,description,partnerId,status,advancePayment,cost,beginTime,deadline,endTime FROM tbl_Project where deleteStatus = 'False' order by beginTime DESC", con);
                    adapter.Fill(ds, "Projects");
                    gv.DataSource = ds.Tables["Projects"];
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<string> GetAllProject()
        {
            try
            {

                using (con = DBConnection.MakeConnection(con))
                {
                    con.Open();
                    List<string> list = new List<string>();
                    SqlCommand command = new SqlCommand("SELECT id, name FROM tbl_Project where deleteStatus = 'False' order by beginTime DESC", con);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        list.Add(reader["name"] + " - ID :" + reader["id"]);
                    }
                    return list;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void GetProjectsOfCompany(List<int> listPartnerId, ref DataGridView gv)
        {
            try
            {
                List<DTO.tbl_ProjectDTO> listProjects = new List<DTO.tbl_ProjectDTO>();
                DataTable project = new DataTable();
                ds.Tables.Add(project);
                using (con = DBConnection.MakeConnection(con))
                {
                    foreach (int parnerId in listPartnerId)
                    {
                        SqlCommand command = new SqlCommand("Select id, name, description, status, advancePayment, cost, beginTime, deadline, endTime from tbl_Project where partnerId=@id and deleteStatus = 'False'", con);
                        command.Parameters.AddWithValue("@id", parnerId);
                        adapter = new SqlDataAdapter(command);
                        adapter.Fill(ds, "ProjectByPartnerID" + parnerId);
                        project.Merge(ds.Tables["ProjectByPartnerID" + parnerId]);
                    }
                    gv.DataSource = project;
                }
            }
            catch (Exception e)
            {
                string a = e.ToString();
                throw;
            }
        }

        public int GetNumberProjectsOfCompany(List<int> listPartnerId)
        {
            try
            {
                List<DTO.tbl_ProjectDTO> listProjects = new List<DTO.tbl_ProjectDTO>();
                DataTable project = new DataTable();
                ds.Tables.Add(project);
                using (con = DBConnection.MakeConnection(con))
                {
                    foreach (int parnerId in listPartnerId)
                    {
                        SqlCommand command = new SqlCommand("Select id, name, description, status, advancePayment, cost, beginTime, deadline, endTime from tbl_Project where partnerId=@id and deleteStatus = 'False'", con);
                        command.Parameters.AddWithValue("@id", parnerId);
                        adapter = new SqlDataAdapter(command);
                        adapter.Fill(ds, "ProjectByPartnerID" + parnerId);
                        project.Merge(ds.Tables["ProjectByPartnerID" + parnerId]);
                    }
                    return project.Rows.Count;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int GetPartnerId(int projectID)
        {
            try
            {
                using (con = DBConnection.MakeConnection(con))
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("Select partnerId from tbl_Project where id=@projectId and deleteStatus = 'False'", con);
                    command.Parameters.AddWithValue("@projectId", projectID);
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

        public void SearchByName(string searchValue, ref DataGridView gv)
        {
            try
            {
                using (con = DBConnection.MakeConnection(con))
                {
                    SqlCommand command = new SqlCommand("SELECT id, name,description,partnerId,status,advancePayment,cost,beginTime,deadline,endTime,deleteStatus FROM tbl_Project where name like @name order by beginTime DESC", con);
                    command.Parameters.AddWithValue("@name", "%" + searchValue + "%");
                    adapter = new SqlDataAdapter(command);
                    adapter.Fill(ds, "ListSearchResult");
                    gv.DataSource = ds.Tables["ListSearchResult"];
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void GetByPartnerId(int partnerId, ref DataGridView gv)
        {
            try
            {
                using (con = DBConnection.MakeConnection(con))
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("Select id, name,description,partnerId,status,advancePayment,cost,beginTime,deadline,endTime from tbl_Project where partnerId = @partnerId and deleteStatus = 'False' ", con);
                    command.Parameters.AddWithValue("@partnerId", partnerId);
                    adapter = new SqlDataAdapter(command);
                    adapter.Fill(ds, "ProjectsByPartnerId");
                    gv.DataSource = ds.Tables["ProjectsByPartnerId"];
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public tbl_ProjectDTO GetById(int id)
        {
            try
            {
                using (con = DBConnection.MakeConnection(con))
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("Select name, description, partnerId, status, advancePayment, cost, beginTime, deadline, endTime from tbl_Project where id = @id", con);
                    command.Parameters.AddWithValue("@id", id);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        string name = reader["name"].ToString();
                        string description = reader["description"].ToString();
                        int partnerId = int.Parse(reader["partnerId"].ToString());
                        string status = "Doing...";
                        if (bool.Parse(reader["status"].ToString()))
                        {
                            status = "Done";
                        }
                        float advancePayment = float.Parse(reader["advancePayment"].ToString());
                        float cost = float.Parse(reader["cost"].ToString());
                        DateTime beginTime = reader.GetDateTime(6);
                        DateTime deadline;
                        DateTime endTime;
                        tbl_ProjectDTO dto = new tbl_ProjectDTO()
                        {
                            Id = id,
                            Name = name,
                            Description = description,
                            PartnerId = partnerId,
                            Status = status,
                            AdvancePayment = advancePayment,
                            Cost = cost,
                            BeginTime = beginTime,
                        };
                        try
                        {
                            deadline = reader.GetDateTime(7);
                            dto.Deadline = deadline;
                        }
                        catch (Exception)
                        {
                        }
                        try
                        {
                            endTime = reader.GetDateTime(8);
                            dto.EndTime = endTime;
                        }
                        catch (Exception)
                        {
                        }
                        return dto;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return null;
        }

        public bool Update(tbl_ProjectDTO dto)
        {
            try
            {
                using (con = DBConnection.MakeConnection(con))
                {
                    con.Open();
                    SqlCommand command;
                    if (dto.Status.Equals("Done"))
                    {
                        command = new SqlCommand("Update tbl_Project set name = @name, description = @description, status = @status, advancePayment = @adPayment, cost = @cost, beginTime = @beginTime, deadline = @deadline, endTime = @endTime where id = @id", con);
                        command.Parameters.AddWithValue("@name", dto.Name);
                        command.Parameters.AddWithValue("@description", dto.Description);
                        command.Parameters.AddWithValue("@status", true);
                        command.Parameters.AddWithValue("@endTime", dto.EndTime);
                        command.Parameters.AddWithValue("@adPayment", dto.AdvancePayment);
                        command.Parameters.AddWithValue("@cost", dto.Cost);
                        command.Parameters.AddWithValue("@beginTime", dto.BeginTime);
                        command.Parameters.AddWithValue("@deadline", dto.Deadline);
                        command.Parameters.AddWithValue("@id", dto.Id);
                    }
                    else
                    {
                        command = new SqlCommand("Update tbl_Project set name = @name, description = @description, status = @status, advancePayment = @adPayment, cost = @cost, beginTime = @beginTime, deadline = @deadline, endTime = null where id = @id", con);
                        command.Parameters.AddWithValue("@name", dto.Name);
                        command.Parameters.AddWithValue("@description", dto.Description);
                        command.Parameters.AddWithValue("@status", false);
                        command.Parameters.AddWithValue("@adPayment", dto.AdvancePayment);
                        command.Parameters.AddWithValue("@cost", dto.Cost);
                        command.Parameters.AddWithValue("@beginTime", dto.BeginTime);
                        command.Parameters.AddWithValue("@deadline", dto.Deadline);
                        command.Parameters.AddWithValue("@id", dto.Id);
                    }

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

        public bool Delete(int id)
        {
            try
            {
                using (con = DBConnection.MakeConnection(con))
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("Update tbl_Project set deleteStatus = 'true' where id = @id", con);
                    command.Parameters.AddWithValue("@id", id);
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

        public bool Insert(tbl_ProjectDTO dto)
        {
            try
            {
                using(con= DBConnection.MakeConnection(con))
                {
                    con.Open();
                    SqlCommand command;
                    if (dto.Status.Equals("Doing..."))
                    {
                        if (dto.Description == null)
                        {
                            command = new SqlCommand("Insert into tbl_Project(name, partnerId, status, advancePayment, cost, beginTime) values(@name, @partnerId, @status, @advancePayment, @cost, @beginTime)", con);
                            command.Parameters.AddWithValue("@status", false);
                        }
                        else
                        {
                            command = new SqlCommand("Insert into tbl_Project(name, description, partnerId, status, advancePayment, cost, beginTime) values(@name, @description, @partnerId, @status, @advancePayment, @cost, @beginTime)", con);
                            command.Parameters.AddWithValue("@description", dto.Description);
                            command.Parameters.AddWithValue("@status", false);
                        }

                    }
                    else
                    {
                        if (dto.Description == null)
                        {
                            command = new SqlCommand("Insert into tbl_Project(name, partnerId, status, advancePayment, cost, beginTime, deadline, endTime) values(@name, @partnerId, @status, @advancePayment, @cost, @beginTime, @deadline, @endTime)", con);
                            command.Parameters.AddWithValue("@status", true);
                            command.Parameters.AddWithValue("@deadline", dto.Deadline);
                            command.Parameters.AddWithValue("@endTime", dto.EndTime);
                        }
                        else
                        {
                            command = new SqlCommand("Insert into tbl_Project(name, description, partnerId, status, advancePayment, cost, beginTime, deadline, endTime) values(@name, @description, @partnerId, @status, @advancePayment, @cost, @beginTime, @deadline, @endTime)", con);
                            command.Parameters.AddWithValue("@description", dto.Description);
                            command.Parameters.AddWithValue("@status", true);
                            command.Parameters.AddWithValue("@deadline", dto.Deadline);
                            command.Parameters.AddWithValue("@endTime", dto.EndTime);
                        }
                        
                    }
                    command.Parameters.AddWithValue("@name", dto.Name);
                    command.Parameters.AddWithValue("@partnerId", dto.PartnerId);
                    command.Parameters.AddWithValue("@advancePayment", dto.AdvancePayment);
                    command.Parameters.AddWithValue("@cost", dto.Cost);
                    command.Parameters.AddWithValue("@beginTime", dto.BeginTime);
                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int GetEndId()
        {
            try
            {
                using(con = DBConnection.MakeConnection(con))
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("Select top 1 id from tbl_Project order by id DESC", con);
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
