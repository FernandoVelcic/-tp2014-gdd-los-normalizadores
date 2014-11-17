﻿using MyActiveRecord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaHotel.Models
{
    public class Factura : ActiveRecord
    {

        public override String table { get { return "facturas"; } }

        public Estadia estadia { get; set; }
        public int nro { get; set; }
        public String fecha { get; set; }
        public int forma_pago_id { get; set; }
        //public int cliente_id { get; set; }
    }
}