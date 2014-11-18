using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MyActiveRecord;
using FrbaHotel.Database_Helper;

namespace FrbaHotel.Models
{
    public class Rol : ActiveRecord
    {
        public override String table { get { return "roles"; } }

        //public int id { get; set; } //INTEGER IDENTITY PRIMARY KEY
        public String descripcion { get; set; } //[nvarchar](30)
        public Boolean estado { get; set; } //[bit]

        public override string ToString()
        {
            return descripcion;
        }
        
        public List<RolFuncionalidad> getFuncionalidades()
        {
            return EntityManager.getEntityManager().findAllBy<RolFuncionalidad>("rol_id", id.ToString());
        }
    }
}
