using MyActiveRecord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaHotel.Models
{
    public class ReservaCliente : ActiveRecord
    {

        public override String table { get { return "reserva_cliente"; } }

        //public int id { get; set; } //INTEGER IDENTITY PRIMARY KEY

        public Reserva reserva { get; set; }
        public Cliente cliente { get; set; }
    }
}
