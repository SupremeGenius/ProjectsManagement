using ProjectManagement.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.BLL
{
    class tbl_CompanyBLL
    {
        public bool Check_Save(tbl_CompanyDTO current, tbl_CompanyDTO now)
        {
            if (!current.Name.ToLower().Equals(now.Name.ToLower()))
            {
                return false;
            }
            if (!current.Address.ToLower().Equals(now.Address.ToLower()))
            {
                return false;
            }
            if (!current.Email.ToLower().Equals(now.Email.ToLower()))
            {
                return false;
            }
            if (!current.BankNumber.ToLower().Equals(now.BankNumber.ToLower()))
            {
                return false;
            }
            return true;
        }
    }
}
