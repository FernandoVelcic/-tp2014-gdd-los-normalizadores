using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaHotel.Models.Listado_Estadistico
{
    class HabitacionTrending
    {

        public int habitacion_id {get; set;}
        public int cantidad_veces { get; set; }
        public int cantidad_noches { get; set; }
        public String Hotel { get; set; }

    }
}
