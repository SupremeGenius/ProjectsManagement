using ProjectManagement.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProjectManagement.Utils
{
    class FormatData
    {
        public static bool FormatEmail(string email)
        {
            Regex emailFormat = new Regex(@"^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,6}$", RegexOptions.IgnoreCase);
            return emailFormat.IsMatch(email);
        }

        public static bool FormatNumber(string number)
        {
            try
            {
                int.Parse(number.Trim());
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool FormatFloat(string number)
        {
            try
            {
                float.Parse(number.Trim());
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool FormatPhone(string number)
        {
            Regex format = new Regex(@"^\d{9,}$", RegexOptions.IgnoreCase);
            return format.IsMatch(number);
        }

        // check save data

        public bool Check_Save(tbl_EmployeeDTO current, tbl_EmployeeDTO now)
        {
            if (!current.Name.ToLower().Equals(now.Name.ToLower()))
            {
                return false;
            }
            if (!current.Address.ToLower().Equals(now.Address.ToLower()))
            {
                return false;
            }
            if (current.Birthday != now.Birthday)
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
            if (!current.Role.ToLower().Equals(now.Role.ToLower()))
            {
                return false;
            }
            if (current.Salary != now.Salary)
            {
                return false;
            }
            return true;
        }

    }
}
