using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyActiveRecord;
using FrbaHotel.Database_Helper;
using FrbaHotel.Models;
using FrbaHotel.Models.Exceptions;

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

        public override void preSave()
        {
            if (String.IsNullOrEmpty(motivo))
            {
                throw new ValidationException("El motivo es obligatorio");
            }

            if (String.IsNullOrEmpty(fecha))
            {
                throw new ValidationException("La fecha es obligatoria");
            }

            if (String.IsNullOrEmpty(usuario))
            {
                throw new ValidationException("El usuario es obligatorio");
            }

        }
    }
}
