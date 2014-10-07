using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MyActiveRecord;

namespace FrbaHotel
{
    class Regimenes : ActiveRecord
    {
        public override String table { get { return "regimenes"; } }

        //public int id { get; set; } //INTEGER IDENTITY PRIMARY KEY
        public String descripcion { get; set; } //[nvarchar](255)
        public int precio { get; set; } //[numeric](18, 2)
        public Boolean estado { get; set; } //[bit]
    }
}
