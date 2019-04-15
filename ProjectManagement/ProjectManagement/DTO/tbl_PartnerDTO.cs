using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.DTO
{
   public class tbl_PartnerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int  CompanyId { get; set; }
        public string Email { get; set; }

        public tbl_PartnerDTO()
        {
        }

        public tbl_PartnerDTO(int id, string name, string position, string address, string phone, int companyId, string email)
        {
            this.Id = id;
            this.Name = name;
            this.Position = position;
            this.Address = address;
            this.Phone = phone;
            this.CompanyId = companyId;
            this.Email = email;
        }
    }
}
