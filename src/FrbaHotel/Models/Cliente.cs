using MyActiveRecord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaHotel.Models
{
    public class Cliente : ActiveRecord
    {
        public override String table { get { return "clientes"; } }

        //public int id { get; set; } //INTEGER IDENTITY PRIMARY KEY
        public int pasaporte_nro { get; set; }  //[numeric](18, 0)
        public String apellido { get; set; } //[nvarchar](255)
        public String nombre { get; set; }  //[nvarchar](255)
        public String fecha_nac { get; set; } //[datetime]
        public String mail { get; set; } //[nvarchar](255)

        /* ¿Normalizar? */
        public String dom_calle { get; set; } //[nvarchar](255)
        public String nro_calle { get; set; } //[numeric](18, 0)
        public String piso { get; set; } //[numeric](18, 0)
        public String depto { get; set; } //[nvarchar](50)

        public String nacionalidad { get; set; } //[nvarchar](255)
    }
}
