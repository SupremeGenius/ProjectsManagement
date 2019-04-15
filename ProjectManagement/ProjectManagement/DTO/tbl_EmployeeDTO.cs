using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.DTO
{
    class tbl_EmployeeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime Birthday { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public float Salary { get; set; }

        public tbl_EmployeeDTO()
        {
        }

        public tbl_EmployeeDTO(int id, string name, string address, DateTime birthday, string phone, string email, string role, float salary)
        {
            this.Id = id;
            this.Name = name;
            this.Address = address;
            this.Birthday = birthday;
            this.Phone = phone;
            this.Email = email;
            this.Role = role;
            this.Salary = salary;
        }
    }
}
