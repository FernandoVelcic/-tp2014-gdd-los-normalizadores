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

            public string descripcion { get; set; }

            public override string ToString()
            {
                return descripcion;
            }

        }
    }

