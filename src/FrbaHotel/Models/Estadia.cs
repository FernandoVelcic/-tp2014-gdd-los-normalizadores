﻿using MyActiveRecord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaHotel.Models
{
    class Estadia : ActiveRecord
    {

        public override String table { get { return "estadias"; } }

        public Reserva reserva { get; set; }
        public String fecha_inicio { get; set; }
        public int cant_noches { get; set; }

    }
}