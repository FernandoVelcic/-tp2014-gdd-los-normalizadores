using MyActiveRecord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaHotel.Models
{
    class Estadia : ActiveRecord
    {

        public override String table { get { return "estadias"; } }


        /* Sincronizar la db con esto */
        public Reserva reserva { get; set; }
        public DateTime fecha_llegada { get; set; }
        public DateTime fecha_salida { get; set; }



    }
}
