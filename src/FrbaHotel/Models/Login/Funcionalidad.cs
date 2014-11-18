using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MyActiveRecord;

namespace FrbaHotel.Models
{
    public class Funcionalidad : ActiveRecord
    {
        public override String table { get { return "funcionalidades"; } }

        //public int id { get; set; } //INTEGER IDENTITY PRIMARY KEY
        public String descripcion { get; set; } //[nvarchar](30)

        public override string ToString()
        {
            return descripcion;
        }
    }
}
