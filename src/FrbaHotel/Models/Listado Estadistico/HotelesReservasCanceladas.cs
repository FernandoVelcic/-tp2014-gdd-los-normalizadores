using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MyActiveRecord;

namespace FrbaHotel.Models.Listado_Estadistico
{
    class HotelesReservasCanceladas : ActiveRecord
    {
        public override String table { get { return "v_HotelesReservasCanceladas"; } }

        //public int id { get; set; } //INTEGER IDENTITY PRIMARY KEY
        public Hotel hotel { get; set; }
        public int cantidad { get; set; }
    }
}
