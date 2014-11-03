﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MyActiveRecord;
using FrbaHotel.Models.Exceptions;
using FrbaHotel.Tools;

namespace FrbaHotel.Models
{
    public class HotelBaja : ActiveRecord
    {
        public override String table { get { return "hoteles_bajas"; } }

        //public int id { get; set; } //INTEGER IDENTITY PRIMARY KEY
        public Hotel hotel { get; set; }
        public String fecha_desde { get; set; } //[datetime]
        public String fecha_hasta { get; set; } //[datetime]

        public override void preSave()
        {
            if (Config.getInstance().getCurrentDate() > DateTime.Parse(fecha_desde))
                throw new ValidationException("No se pueden hacer bajas al pasado, la fecha_desde debe ser mayor que la fecha de sistema.");

            if( DateTime.Parse(fecha_desde) > DateTime.Parse(fecha_hasta) )
                throw new ValidationException("Rango de fecha invalido");
        }
    }
}
