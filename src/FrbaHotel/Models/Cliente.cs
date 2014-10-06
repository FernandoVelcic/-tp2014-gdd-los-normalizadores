using MyActiveRecord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaHotel.Models
{
    class Cliente : ActiveRecord
    {

        public override String table { get { return "clientes"; } }

        public int pasaporte_nro { get; set; } 
        public String apellido { get; set; }
        public String nombre { get; set; } 
        public DateTime fecha_nac { get; set; } 
        public String mail { get; set; } 

        /* ¿Normalizar? */
        public String dom_calle { get; set; } 
        public String nro_calle { get; set; } 
        public String piso { get; set; }
        public String depto { get; set; }

        public String nacionalidad { get; set; } 



    }
}
