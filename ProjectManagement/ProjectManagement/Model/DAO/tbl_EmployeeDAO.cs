using ProjectManagement.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ProjectManagement.GUI.Utils;
using System.Windows.Forms;
using System.Data;

namespace ProjectManagement.DAO
{
    class tbl_EmployeeDAO
    {
        SqlConnection con;
        DataSet ds = new DataSet();
        public tbl_EmployeeDTO GetById(int id)
        {
            try
            {
                using(con = DBConnection.MakeConnection(con))
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("Select name, address, birthday, phone, email, roleId, salary from tbl_Employee where id=@id and deleteStatus = 'False'", con);
                    command.Parameters.AddWithValue("@id", id);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        string name = reader.GetString(0);
                        string address = reader.GetString(1);
                        DateTime birthday = reader.GetDateTime(2);
                        string phone = reader.GetString(3);
                        string email = reader.GetString(4);
                        int roleId = reader.GetInt32(5);
                        double salary = reader.GetDouble(6);
                        tbl_RoleDAO roleDAO = new tbl_RoleDAO();
                        tbl_EmployeeDTO dto = new tbl_EmployeeDTO(id, name, address, birthday, phone, email, roleDAO.GetByID(roleId), float.Parse(salary+""));
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

        public List<tbl_EmployeeDTO> GetAllEmployee()
        {
            try
            {
                using(con = DBConnection.MakeConnection(con))
                {
                    tbl_RoleDAO roleDao = new tbl_RoleDAO();
                    con.Open();
                    SqlCommand command = new SqlCommand("Select id, name, address, birthday, phone, email, roleId, salary from tbl_Employee where deleteStatus = 'False' order by name ASC", con);
                    SqlDataReader reader = command.ExecuteReader();
                    List<tbl_EmployeeDTO> list = new List<tbl_EmployeeDTO>();
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string name = reader.GetString(1);
                        string address = reader.GetString(2);
                        DateTime birthday = reader.GetDateTime(3);
                        string phone = reader.GetString(4);
                        string email = reader.GetString(5);
                        string[] role = roleDao.GetByID(reader.GetInt32(6)).Split('-');
                        float salary = float.Parse(reader["salary"].ToString());
                        tbl_EmployeeDTO dto = new tbl_EmployeeDTO(id, name, address, birthday, phone, email, role[1].Trim(), salary);
                        list.Add(dto);
                    }
                    return list;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Update(tbl_EmployeeDTO dto)
        {
            try
            {
                using(con = DBConnection.MakeConnection(con))
                {
                    tbl_RoleDAO roleDAO = new tbl_RoleDAO();
                    con.Open();
                    SqlCommand command = new SqlCommand("Update tbl_Employee set name = @name, address = @address, birthday = @birthday, phone = @phone, email = @email, roleId = @role, salary = @salary where id = @id", con);
                    command.Parameters.AddWithValue("@name", dto.Name);
                    command.Parameters.AddWithValue("@address", dto.Address);
                    command.Parameters.AddWithValue("@birthday", dto.Birthday);
                    command.Parameters.AddWithValue("@phone",dto.Phone);
                    command.Parameters.AddWithValue("@email", dto.Email);
                    command.Parameters.AddWithValue("@role", roleDAO.GetIdByName(dto.Role));
                    command.Parameters.AddWithValue("@salary", dto.Salary);
                    command.Parameters.AddWithValue("@id", dto.Id);

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
