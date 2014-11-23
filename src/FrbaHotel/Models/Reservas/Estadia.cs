﻿using MyActiveRecord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaHotel.Models.Exceptions;

namespace FrbaHotel.Models
{
    public class Estadia : ActiveRecord
    {

        public override String table { get { return "estadias"; } }
        public Reserva reserva { get; set; }
        public String fecha_inicio { get; set; }
        public int cant_noches { get; set; }

        public int cantidad_maxima_personas()
        {
            return reserva.cantidad_maxima_personas();
        }

        public override void preSave()
        {
            if (String.IsNullOrEmpty(fecha_inicio))
            {
                throw new ValidationException("La fecha de inicio es obligatoria");
            }

        }
    }
}