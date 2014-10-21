using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MyActiveRecord;

namespace FrbaHotel.Models
{
    public class Rol : ActiveRecord
    {
        public override String table { get { return "roles"; } }

        //public int id { get; set; } //INTEGER IDENTITY PRIMARY KEY
        public String descripcion { get; set; } //[nvarchar](30)
        public int rol_permisos_id { get; set; } //INTEGER
        public Boolean estado { get; set; } //[bit]
    }
}
