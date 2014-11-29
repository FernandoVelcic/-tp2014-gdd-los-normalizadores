using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaHotel.Database_Helper;

namespace FrbaHotel.Models.Listado_Estadistico
{
    class HotelCaro
    {

        public Hotel Hotel
        {
            get { return EntityManager.getEntityManager().findById<Hotel>(Convert.ToInt64(hotel_id)); }
        }

        [System.ComponentModel.Browsable(false)]
        public int hotel_id { get; set; }
        public int total { get; set; }


    }
}
