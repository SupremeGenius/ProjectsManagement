using ProjectManagement.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Model.BLL
{
    class tbl_ProjectBLL
    {
        public bool Check_Save(tbl_ProjectDTO current, tbl_ProjectDTO now)
        {
            if (!current.Name.ToLower().Equals(now.Name.ToLower()))
            {
                return false;
            }
            if (!current.Description.ToLower().Equals(now.Description.ToLower()))
            {
                return false;
            }
            if (!current.Status.ToLower().Equals(now.Status.ToLower()))
            {
                return false;
            }
            if (current.AdvancePayment != now.AdvancePayment)
            {
                return false;
            }
            if (current.Cost != now.Cost)
            {
                return false;
            }
            if (current.BeginTime != now.BeginTime)
            {
                return false;
            }
            if (current.Deadline != now.Deadline)
            {
                return false;
            }
            if (current.EndTime != now.EndTime)
            {
                return false;
            }
            return true;
        }

    }
}
