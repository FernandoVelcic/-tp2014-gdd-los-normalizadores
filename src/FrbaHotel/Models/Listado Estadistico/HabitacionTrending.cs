using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaHotel.Database_Helper;

namespace FrbaHotel.Models.Listado_Estadistico
{
    class HabitacionTrending
    {

        public Habitacion habitacion
        {
            get { return EntityManager.getEntityManager().findById<Habitacion>(habitacion_id); }
        }

        [System.ComponentModel.Browsable(false)] 
        public int habitacion_id {get; set;}
        public int cantidad_veces { get; set; }
        public int cantidad_noches { get; set; }

        [System.ComponentModel.Browsable(false)] 
        public long hotel_id { get; set; }
        public Hotel Hotel {
            get { return EntityManager.getEntityManager().findById<Hotel>(habitacion.hotel.id); }
        }

    }
}
