using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MyActiveRecord;

namespace FrbaHotel.Models
{
    public class TipoHabitacion : ActiveRecord
    {

        public override String table { get { return "habitaciones_tipos"; } }

        public float porcentual { get; set; }
        public String codigo { get; set; }
        public String descripcion { get; set; }

        public override string ToString()
        {
            return descripcion;
        }

    }
}
