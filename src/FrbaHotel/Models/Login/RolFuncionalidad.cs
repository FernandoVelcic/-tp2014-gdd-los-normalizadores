using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MyActiveRecord;

namespace FrbaHotel.Models
{
    public class RolFuncionalidad : ActiveRecord
    {
        public override String table { get { return "roles_funcionalidades"; } }

        //public int id { get; set; } //INTEGER IDENTITY PRIMARY KEY
        public Rol rol { get; set; }
        public Funcionalidad funcionalidad { get; set; }
    }
}
