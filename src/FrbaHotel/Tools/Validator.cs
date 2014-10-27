using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaHotel.Tools
{
    public static class Validator
    {
        public static bool isValidEmail(this String email)
        {
            try
            {
                new System.Net.Mail.MailAddress(email);
            }
            catch
            {
                return false;
            }

            return true;
        }
            
    }
}
