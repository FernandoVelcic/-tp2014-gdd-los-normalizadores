using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MyActiveRecord;
using FrbaHotel.Database_Helper;
using FrbaHotel.Models.Exceptions;
using System.Data.SqlClient;

namespace FrbaHotel.Models
{
    public class Habitacion : ActiveRecord
    {
        public override String table { get { return "habitaciones"; } }

        //public int id { get; set; } //INTEGER IDENTITY PRIMARY KEY
        
        public Hotel hotel { get; set; } //hotel_id
        public int numero { get; set; } //[numeric](18, 0)
        public int piso { get; set; } //[numeric](18, 0)
        public String frente { get; set; } //[nvarchar](50)
        public TipoHabitacion tipo { get; set; }
        public Boolean estado { get; set; } //[bit]
        public String descripcion { get; set; } //[nvarchar](255)

        public override string ToString()
        {
            return hotel.ToString() + " - " + numero.ToString() ;
        }

        public override void preSave()
        {
            List<FetchCondition> condiciones = new List<FetchCondition>();
            FetchCondition condicionId = new FetchCondition();
            condicionId.setNotEquals("habitaciones.id", id);
            condiciones.Add(condicionId);
            FetchCondition condicionHotel = new FetchCondition();
            condicionHotel.setEquals("habitaciones.hotel_id", hotel.id);
            condiciones.Add(condicionHotel);
            FetchCondition condicionHabitacion = new FetchCondition();
            condicionHabitacion.setEquals("habitaciones.numero", numero);
            condiciones.Add(condicionHabitacion);

            List<Habitacion> habitaciones = EntityManager.getEntityManager().findList<Habitacion>(condiciones);
            if (habitaciones.Count != 0)
            {
                throw new ValidationException("Numero de habitacion duplicado");
            }
        }


        public Boolean estaDisponible(DateTime desde, int cantidadNoches)
        {
            /*List<FetchCondition> condiciones = new List<FetchCondition>();
            FetchCondition condicionId = new FetchCondition();
            condicionId.setEquals("habitacion_id", id);
            condiciones.Add(condicionId);

            FetchCondition condicionFecha = new FetchCondition();
            condicionFecha.setNotBetween("fecha_inicio", "DATEADD(day,cant_noches,CAST('" + desde.ToShortDateString() + "' AS DATE))", "'" + desde.AddDays(cantidadNoches).ToShortDateString() + "'");
            condiciones.Add(condicionFecha);

            List<Reserva> reservas = EntityManager.getEntityManager().findList<Reserva>(condiciones);

            return reservas.Count == 0;*/
            
            SelectQuery<Reserva> query = new SelectQuery<Reserva>(typeof(Reserva));

            query.addCount();

            query.addLeftJoin("reservas_habitaciones", "reservas.id = reservas_habitaciones.reserva_id");
            query.addWhere("reservas_habitaciones.habitacion_id", id.ToString());
            query.addWhere("fecha_inicio", "'" + desde.AddDays(cantidadNoches).ToShortDateString() + "'", "<=");
            query.addWhere("(DATEADD(day,cant_noches,fecha_inicio))", "'" + desde.ToShortDateString() + "'", ">=");
            

            SqlCommand cmd = new SqlCommand(query.build(), ConnectionManager.getInstance().getConnection());
            Int32 count = (Int32)cmd.ExecuteScalar();

            return count == 0;
        }


    }
}
