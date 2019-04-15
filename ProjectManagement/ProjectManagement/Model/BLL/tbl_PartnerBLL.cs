using ProjectManagement.DAO;
using ProjectManagement.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectManagement.BLL
{
    class tbl_PartnerBLL
    {
        public bool Check_Save(tbl_PartnerDTO current, tbl_PartnerDTO now)
        {
            if (!current.Name.ToLower().Equals(now.Name.ToLower()))
            {
                return false;
            }
            if (!current.Position.ToLower().Equals(now.Position.ToLower()))
            {
                return false;
            }
            if (!current.Address.ToLower().Equals(now.Address.ToLower()))
            {
                return false;
            }
            if (!current.Phone.ToLower().Equals(now.Phone.ToLower()))
            {
                return false;
            }
            if (!current.Email.ToLower().Equals(now.Email.ToLower()))
            {
                return false;
            }
            return true;
        }

    }
}
