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
        public long forma_pago_id { get; set; }
        public Cliente cliente { get; set; }
    }
}