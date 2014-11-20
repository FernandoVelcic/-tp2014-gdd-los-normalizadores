using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyActiveRecord;
using FrbaHotel.Database_Helper;
using FrbaHotel.Models;

namespace FrbaHotel.Models.Reservas
{
    public class ReservaCancelada : ActiveRecord
    {
        public override String table { get { return "reservas_canceladas"; } }
        //public int id { get; set; } //INTEGER IDENTITY PRIMARY KEY
        public String motivo { get; set; } //[nvarchar](255)
        public String fecha { get; set; } //[datetime]
        public String usuario { get; set; } //[nvarchar](30)
        public Reserva reserva { get; set; }

    }
}
