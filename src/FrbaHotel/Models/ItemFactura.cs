﻿using MyActiveRecord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaHotel.Models
{
    class ItemFactura : ActiveRecord
    {

        public override String table { get { return "items"; } }

        
        public long factura_id { get; set; }
        public String descripcion { get; set; }
        public int factura_cantidad { get; set; }
        public float monto { get; set; } 

        
    }
}
