using MyActiveRecord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaHotel.Models
{
    class Consumible : ActiveRecord 
    {

        public override String table { get { return "consumibles"; } }

        public int codigo { get; set; }  //[numeric](18, 0)
        public String descripcion { get; set; } //[nvarchar](255)
        public float precio { get; set; }  // [numeric](18, 2)



    }
}
