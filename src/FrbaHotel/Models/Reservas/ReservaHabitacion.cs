using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using MyActiveRecord;
using System.Windows.Forms;

namespace FrbaHotel.Models
{
    public class ReservaHabitacion : ActiveRecord
    {
        public override String table { get { return "reservas_habitaciones"; } }

        //public int id { get; set; } //INTEGER IDENTITY PRIMARY KEY
        public Reserva reserva { get; set; }
        public Habitacion habitacion { get; set; }
    }
}
