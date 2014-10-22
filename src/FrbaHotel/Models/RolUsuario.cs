﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MyActiveRecord;

namespace FrbaHotel.Models
{
    public class RolUsuario : ActiveRecord
    {
        public override String table { get { return "rol_usuario"; } }

        //public int id { get; set; } //INTEGER IDENTITY PRIMARY KEY
        public Usuario usuario { get; set; }
        public Rol rol { get; set; }
    }
}