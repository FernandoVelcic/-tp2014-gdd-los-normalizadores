using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaHotel.Models.Exceptions
{
    class ValidationException : Exception
    {

        public ValidationException(String e)
            : base(e)
        {

        }

    }
}
