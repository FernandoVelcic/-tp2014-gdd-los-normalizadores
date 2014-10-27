using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MyActiveRecord;

namespace FrbaHotel.Models
{
    public class Pais : ActiveRecord
    {
        public override String table { get { return "paises"; } }

        //public int id { get; set; } //INTEGER IDENTITY PRIMARY KEY
        public String nombre { get; set; }  //[nvarchar](255)
        public String gentilicio { get; set; } //[nvarchar](255)
    }
}
