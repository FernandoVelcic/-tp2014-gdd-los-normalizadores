using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MyActiveRecord;

namespace FrbaHotel.Models
{
    public class HotelRegimen : ActiveRecord
    {
        public override String table { get { return "hoteles_regimenes"; } }

        //public int id { get; set; } //INTEGER IDENTITY PRIMARY KEY
        public Hotel hotel { get; set; }
        public Regimen regimen { get; set; }

        public override string ToString()
        {
            return regimen.descripcion;
        }
    }
}
