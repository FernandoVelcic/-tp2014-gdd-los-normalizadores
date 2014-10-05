using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MyActiveRecord;

namespace FrbaHotel
{
    class Reservas : ActiveRecord
    {
        public override String table { get { return "reservas"; } }

        //public int id { get; set; } //INTEGER IDENTITY PRIMARY KEY
        public int habitacion_id { get; set; } //INTEGER
        public int fecha_inicio { get; set; } //[datetime]
        public int codigo { get; set; } //[numeric](18, 0)
        public int cant_noches { get; set; } //[numeric](18, 0)
    }
}
