using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaHotel.Database_Helper;

namespace FrbaHotel.Models.Listado_Estadistico
{
    public class ClienteTrending
    {

        public Cliente cliente {
            get { return EntityManager.getEntityManager().findById<Cliente>(Convert.ToInt64(cliente_id)); }
        }

        [System.ComponentModel.Browsable(false)]
        public String cliente_id { get; set; }
        public int puntos { get; set; }


    }
}
