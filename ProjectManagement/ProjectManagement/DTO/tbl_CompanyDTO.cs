using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.DTO
{
    class tbl_CompanyDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string BankNumber { get; set; }
        public bool DeleteStatus { get; set; }

        public tbl_CompanyDTO()
        {
        }

        public tbl_CompanyDTO(int id, string name, string address, string email, string bankNumber, bool deleteStatus)
        {
            this.Id = id;
            this.Name = name;
            this.Address = address;
            this.Email = email;
            this.BankNumber = bankNumber;
            this.DeleteStatus = deleteStatus;
        }
    }
}
