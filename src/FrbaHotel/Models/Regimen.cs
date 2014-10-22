using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MyActiveRecord;

namespace FrbaHotel.Models
{
    public class Regimen : ActiveRecord
    {
        public override String table { get { return "regimenes"; } }

        //public int id { get; set; } //INTEGER IDENTITY PRIMARY KEY
        public String codigo { get; set; }//[nvarchar](255)
        public String descripcion { get; set; } //[nvarchar](255)
        public float precio { get; set; } //[numeric](18, 2)
        public Boolean estado { get; set; } //[bit]

        public override string ToString()
        {
            return descripcion;
        }


    }
}
