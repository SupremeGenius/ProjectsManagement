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
    class tbl_CompanyDAO
    {
        SqlConnection con = null;
        SqlDataAdapter adapter;

        public void GetAllCompany(ref DataGridView gv)
        {
            List<tbl_CompanyDTO> listCompany = new List<tbl_CompanyDTO>();
            try
            {
                using (con = DBConnection.OpenConnection(con))
                {


                    adapter = new SqlDataAdapter("Select id, name, address, email from tbl_Company where deleteStatus = 'False'", con);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "Company");
                    gv.DataSource = ds.Tables["Company"];
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<tbl_CompanyDTO> GetAllCompany()
        {
            List<tbl_CompanyDTO> listCompany = new List<tbl_CompanyDTO>();
            try
            {
                using (con = DBConnection.MakeConnection(con))
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("Select id, name, address, email from tbl_Company where deleteStatus = 'False'", con);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        tbl_CompanyDTO dto = new tbl_CompanyDTO()
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Address = reader.GetString(2),
                            Email = reader.GetString(3)
                        };
                        listCompany.Add(dto);
                    }
                    return listCompany;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void SearchCompanyByName(ref DataGridView gv, string searchValue)
        {
            try
            {
                using (con = DBConnection.OpenConnection(con))
                {
                    SqlCommand command = new SqlCommand("Select id, name, address, email from tbl_Company where name like @searchValue and deleteStatus = 'False'", con);
                    command.Parameters.AddWithValue("@searchValue", "%" + searchValue + "%");
                    adapter = new SqlDataAdapter(command);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "Company");
                    gv.DataSource = ds.Tables["Company"];
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string GetNameById(int id)
        {
            try
            {
                using(con = DBConnection.MakeConnection(con))
                {
                    con.Open();
                    SqlCommand commmand = new SqlCommand("Select name from tbl_Company where id=@id", con);
                    commmand.Parameters.AddWithValue("@id", id);
                    SqlDataReader reader = commmand.ExecuteReader();
                    if (reader.Read())
                    {
                        return reader.GetString(0);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return null;
        }

        public tbl_CompanyDTO GetById(int id)
        {
            try
            {
                using (con = DBConnection.MakeConnection(con))
                {
                    con.Open();
                    SqlCommand commmand = new SqlCommand("Select name, address, email, bankNumber from tbl_Company where id=@id", con);
                    commmand.Parameters.AddWithValue("@id", id);
                    SqlDataReader reader = commmand.ExecuteReader();
                    if (reader.Read())
                    {
                        string name = reader.GetString(0);
                        string address = reader.GetString(1);
                        string email = reader.GetString(2);
                        string bankNumber = reader.GetString(3);
                        tbl_CompanyDTO dto = new tbl_CompanyDTO(id, name, address, email, bankNumber, false);
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

        public bool Update(tbl_CompanyDTO dto)
        {
            try
            {
                using (con = DBConnection.MakeConnection(con))
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("Update tbl_Company set name= @name, address= @add, email= @email, bankNumber= @bank where id = @id", con);
                    command.Parameters.AddWithValue("@name", dto.Name);
                    command.Parameters.AddWithValue("@add", dto.Address);
                    command.Parameters.AddWithValue("@email", dto.Email);
                    command.Parameters.AddWithValue("@bank", dto.BankNumber);
                    command.Parameters.AddWithValue("@id", dto.Id);
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

        public bool Insert(tbl_CompanyDTO dto)
        {
            try
            {
                using(con = DBConnection.MakeConnection(con))
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("Insert into tbl_Company(name, address, email, bankNumber) values(@name, @address, @email, @bank)", con);
                    command.Parameters.AddWithValue("@name", dto.Name);
                    command.Parameters.AddWithValue("@address", dto.Address);
                    command.Parameters.AddWithValue("@email", dto.Email);
                    command.Parameters.AddWithValue("@bank", dto.BankNumber);
                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string GetEndCom()
        {
            try
            {
                using(con = DBConnection.MakeConnection(con))
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("Select top 1 id, name from tbl_Company order by id DESC", con);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        return reader.GetString(1) + " - Id:" + reader.GetInt32(0);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return null;
        }

        public bool Delete(int id)
        {
            try
            {
                using (con = DBConnection.MakeConnection(con))
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("Delete from tbl_Company where id = @id", con);
                    command.Parameters.AddWithValue("@id", id);
                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
