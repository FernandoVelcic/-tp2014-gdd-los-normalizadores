using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
﻿using MyActiveRecord;

namespace FrbaHotel.Models
    {
        public class FormaDePago : ActiveRecord
        {

            public override String table { get { return "formas_de_pago"; } }

            public int cliente_id { get; set;}//INTEGER NOT NULL,				
	        public string tipo { get; set;}//[nvarchar](30) NOT NULL,
	        public int nro_tarjeta { get; set;}//INTEGER,
	        public int nro_pin { get; set;}//INTEGER,
        }
    }

