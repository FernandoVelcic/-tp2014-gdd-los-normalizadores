using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MyActiveRecord;

namespace FrbaHotel.Models
{
    class TipoDocumento : ActiveRecord
    {
        public override String table { get { return "documento_tipos"; } }

        //public int id { get; set; } //INTEGER IDENTITY PRIMARY KEY
        public String descripcion { get; set; } //[nvarchar](255)
    }
}
