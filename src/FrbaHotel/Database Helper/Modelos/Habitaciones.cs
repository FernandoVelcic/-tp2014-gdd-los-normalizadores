using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MyActiveRecord;

namespace FrbaHotel
{
    class Habitaciones : ActiveRecord
    {
        public override String table { get { return "habitaciones"; } }

        //public int id { get; set; } //INTEGER IDENTITY PRIMARY KEY
        public int hotel_id { get; set; } //INTEGER
        public int numero { get; set; } //[numeric](18, 0)
        public int piso { get; set; } //[numeric](18, 0)
        public String frente { get; set; } //[nvarchar](50)
        public int tipo_codigo { get; set; } //[numeric](18, 0)
        public String tipo_descripcion { get; set; } //[nvarchar](255)
        public String descripcion { get; set; } //[nvarchar](255)
        public int tipo_porcentual { get; set; } //[numeric](18, 2)
    }
}
