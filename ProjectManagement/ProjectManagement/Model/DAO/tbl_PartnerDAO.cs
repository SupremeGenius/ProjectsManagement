using ProjectManagement.DTO;
using ProjectManagement.GUI.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.DAO
{
    class tbl_PartnerDAO
    {
        SqlConnection con = null;
        DataSet ds = new DataSet();

        public List<tbl_PartnerDTO> GetListPartners(int companyId)
        {
            List<tbl_PartnerDTO> listDTO = new List<tbl_PartnerDTO>();
            try
            {
                using (con = DBConnection.MakeConnection(con))
                {
                    con = DBConnection.OpenConnection(con);
                    SqlCommand command = new SqlCommand("Select id, name, position, address,phone, email from tbl_Partner where companyID = @Id and deleteStatus = 'False'", con);
                    command.Parameters.AddWithValue("@Id", companyId);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string name = reader.GetString(1);
                        string position = reader.GetString(2);
                        string address;
                        try
                        {
                            address = reader.GetString(3);
                        }
                        catch (Exception)
                        {
                            address = "";
                        }
                        string phone = reader.GetString(4);
                        string email = reader.GetString(5);

                        tbl_PartnerDTO dto = new tbl_PartnerDTO(id, name, position, address, phone, companyId, email);
                        listDTO.Add(dto);
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return listDTO;
        }

        public List<int> GetListPartnerId(int companyId)
        {
            try
            {

                List<int> listPartnerId = new List<int>();
                using (con = DBConnection.MakeConnection(con))
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("Select id, name, position, address,phone, companyID, email from tbl_Partner where companyID = @Id and deleteStatus = 'False'", con);
                    command.Parameters.AddWithValue("@Id", companyId);
                    SqlDataReader reader = command.ExecuteReader();
                    Console.WriteLine();
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        listPartnerId.Add(id);
                    }
                    return listPartnerId;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public String GetPartnerById(int id)
        {
            try
            {
                using (con = DBConnection.MakeConnection(con))
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("Select name, phone from tbl_Partner where id=@partnerID and deleteStatus = 'False'", con);
                    command.Parameters.AddWithValue("@partnerID", id);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        return reader.GetString(0) + " - " + reader.GetString(1);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return null;
        }

        public int GetCompanyIdById(int partnerID)
        {
            try
            {
                using (con = DBConnection.MakeConnection(con))
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("Select companyID from tbl_Partner where id=@id", con);
                    command.Parameters.AddWithValue("@id", partnerID);
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

        public tbl_PartnerDTO GetByName_Phone_CompanyId(string partnerInfor, int companyId)
        {
            try
            {
                using (con = DBConnection.MakeConnection(con))
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("Select id, position, address, phone, email from tbl_Partner where phone like @phone and companyID = @companyId", con);
                    string[] infor = partnerInfor.Split('-');
                    command.Parameters.AddWithValue("@phone", infor[1].Trim());
                    command.Parameters.AddWithValue("@companyId", companyId);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string position = reader.GetString(1);
                        string address = reader.GetString(2);
                        string phone = reader.GetString(3);
                        string email = reader.GetString(4);
                        tbl_PartnerDTO dto = new tbl_PartnerDTO(id, infor[0].Trim(), position, address, phone, companyId, email);
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

        public bool Update(tbl_PartnerDTO dto)
        {
            try
            {
                using (con = DBConnection.MakeConnection(con))
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("Update tbl_Partner set name=@name, position=@positon, address=@add, phone=@phone, email=@email where id=@id", con);
                    command.Parameters.AddWithValue("@name", dto.Name);
                    command.Parameters.AddWithValue("@positon", dto.Position);
                    command.Parameters.AddWithValue("@add", dto.Address);
                    command.Parameters.AddWithValue("@phone", dto.Phone);
                    command.Parameters.AddWithValue("@email", dto.Email);
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

        public int GetIdByPhone(string phone)
        {
            try
            {
                using (con = DBConnection.MakeConnection(con))
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("Select id from tbl_Partner where phone like @phone", con);
                    command.Parameters.AddWithValue("@phone", phone);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        return id;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return -1;
        }

        public bool Insert(tbl_PartnerDTO dto)
        {
            try
            {
                using (con = DBConnection.MakeConnection(con))
                {
                    con.Open();
                    SqlCommand command;
                    if (dto.Address != null)
                    {
                        command = new SqlCommand("Insert into tbl_Partner(name, position, address, phone, companyID, email) values(@name, @position, @address, @phone, @companyID, @email)", con);
                        command.Parameters.AddWithValue("@name", dto.Name);
                        command.Parameters.AddWithValue("@position", dto.Position);
                        command.Parameters.AddWithValue("@address", dto.Address);
                        command.Parameters.AddWithValue("@phone", dto.Phone);
                        command.Parameters.AddWithValue("@companyID", dto.CompanyId);
                        command.Parameters.AddWithValue("@email", dto.Email);
                    } else
                    {
                        command = new SqlCommand("Insert into tbl_Partner(name, position, phone, companyID, email) values(@name, @position, @phone, @companyID, @email)", con);
                        command.Parameters.AddWithValue("@name", dto.Name);
                        command.Parameters.AddWithValue("@position", dto.Position);
                        command.Parameters.AddWithValue("@phone", dto.Phone);
                        command.Parameters.AddWithValue("@companyID", dto.CompanyId);
                        command.Parameters.AddWithValue("@email", dto.Email);
                    }

                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                using(con = DBConnection.MakeConnection(con))
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("Delete from tbl_Partner where id = @id", con);
                    command.Parameters.AddWithValue("@id", id);
                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        // get partner current insert
        public string GetEndPartner()
        {
            try
            {
                using (con = DBConnection.MakeConnection(con))
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("Select top 1 id, name from tbl_Partner order by id DESC", con);
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

    }
}
