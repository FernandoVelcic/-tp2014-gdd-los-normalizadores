using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MyActiveRecord;

using FrbaHotel.Database_Helper;
using FrbaHotel.Models;


namespace FrbaHotel.Models
{
    public class ReservaHotel : ActiveRecord
    {
        public override String table { get { return "v_reservas_hoteles"; } }

        //public int id { get; set; } //INTEGER IDENTITY PRIMARY KEY
        public Reserva reserva { get; set; }
        public Hotel hotel { get; set; }
    }
}
