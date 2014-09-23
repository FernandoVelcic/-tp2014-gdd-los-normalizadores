using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MyActiveRecord;

namespace FrbaHotel
{
    class Hoteles : ActiveRecord
    {
        //public int id { get; set; } //INTEGER IDENTITY PRIMARY KEY
        public String ciudad { get; set; } //[varchar](255)
        public String calle { get; set; } //[varchar](255)
        public int nro_Calle { get; set; } //[numeric](18, 0)
	    public int cant_estrella { get; set; } //[numeric](18, 0)
	    public int recarga_estrella { get; set; } //[numeric](18, 0)

        /*public Hoteles(long id, String ciudad, String calle, int nro_Calle, int cant_estrella, int recarga_estrella)
        {
            this.id = id;
            this.ciudad = ciudad;
            this.calle = calle;
            this.nro_Calle = nro_Calle;
            this.nro_Calle = cant_estrella;
            this.recarga_estrella = recarga_estrella;
        }*/
    }
}
