using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using FrbaHotel.Models;

namespace FrbaHotel.Homes
{
    class SesionActual
    {
        public static RolUsuario rol_usuario { get; set; }

        private static SesionActual instance;

        public static SesionActual getSesionActual()
        {
            if (instance == null)
            {
                instance = new SesionActual();
            }

            return instance;
        }
    }
}
