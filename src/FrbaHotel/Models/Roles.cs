﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MyActiveRecord;

namespace FrbaHotel
{
    class Roles : ActiveRecord
    {
        public override String table { get { return "roles"; } }

        //public int id { get; set; } //INTEGER IDENTITY PRIMARY KEY
        public String descripcion { get; set; } //[nvarchar](30)
        public int rol_permisos_id { get; set; } //INTEGER
        public Boolean habilitado { get; set; } //[bit]
    }
}