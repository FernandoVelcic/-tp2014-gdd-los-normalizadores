using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MyActiveRecord;

using FrbaHotel.Database_Helper;
using FrbaHotel.Models;
using FrbaHotel.Models.Exceptions;
using FrbaHotel.Tools;

namespace FrbaHotel.Models
{
    public class Hotel : ActiveRecord
    {
        public override String table { get { return "hoteles"; } }

        //public int id { get; set; } //INTEGER IDENTITY PRIMARY KEY
        public String nombre { get; set; } //[nvarchar](255)
        public String ciudad { get; set; } //[nvarchar](255)
        public String calle { get; set; } //[nvarchar](255)
        public int nro_Calle { get; set; } //[numeric](18, 0)
	    public int cant_estrella { get; set; } //[numeric](18, 0)
	    public int recarga_estrella { get; set; } //[numeric](18, 0)

        public String mail { get; set; } //[nvarchar](255)
        public String telefono { get; set; } //[nvarchar](255)
        public String fecha_creacion { get; set; } //[datetime]
        public Pais pais { get; set; }

        public override string ToString()
        {
            return nombre;
        }

        public override void preSave()
        {
            if (mail.isValidEmail() != true && !String.IsNullOrEmpty(mail))
            {
                throw new ValidationException("Formato de email invalido");
            }
            
            if (String.IsNullOrEmpty(nombre))
            {
                throw new ValidationException("El nombre es obligatorio");
            }

            if (String.IsNullOrEmpty(ciudad))
            {
                throw new ValidationException("La ciudad es obligatoria");
            }
            if (String.IsNullOrEmpty(calle))
            {
                throw new ValidationException("La calle es obligatoria");
            }
        }

        public bool estaLibre(String fecha1, String fecha2)
        {
            FetchCondition condicion_hotel = new FetchCondition();
            condicion_hotel.setEquals("hotel_id", id);

            {
                List<FetchCondition> condiciones = new List<FetchCondition>();
                FetchCondition condicion_fecha = new FetchCondition();
                condicion_fecha.setBetween("'" + fecha1 + "'", "fecha_desde", "fecha_hasta");
                condiciones.Add(condicion_fecha);
                condiciones.Add(condicion_hotel);

                List<HotelBaja> hoteles_bajas = EntityManager.getEntityManager().findList<HotelBaja>(condiciones);

                if (hoteles_bajas.Count != 0)
                    return false;
            }

            {
                List<FetchCondition> condiciones = new List<FetchCondition>();
                FetchCondition condicion_fecha = new FetchCondition();
                condicion_fecha.setBetween("'" + fecha2 + "'", "fecha_desde", "fecha_hasta");
                condiciones.Add(condicion_fecha);
                condiciones.Add(condicion_hotel);

                List<HotelBaja> hoteles_bajas = EntityManager.getEntityManager().findList<HotelBaja>(condiciones);

                if (hoteles_bajas.Count != 0)
                    return false;
            }

            {
                List<FetchCondition> condiciones = new List<FetchCondition>();
                FetchCondition condicion_fecha = new FetchCondition();
                condicion_fecha.setBetween("fecha_desde", "'" + fecha1 + "'", "'" + fecha2 + "'");
                condiciones.Add(condicion_fecha);
                condiciones.Add(condicion_hotel);

                List<HotelBaja> hoteles_bajas = EntityManager.getEntityManager().findList<HotelBaja>(condiciones);

                if (hoteles_bajas.Count != 0)
                    return false;
            }
            return true;
        }
    }
}
