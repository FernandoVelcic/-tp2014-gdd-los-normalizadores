using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;

using MyActiveRecord;
using FrbaHotel.Database_Helper;
using FrbaHotel.Models.Exceptions;

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
            SelectQuery<Reserva> query = new SelectQuery<Reserva>(typeof(Reserva));

            query.addCount();

            query.addLeftJoin("reservas_habitaciones", "reservas.id = reservas_habitaciones.reserva_id");
            query.addWhere("reservas_habitaciones.habitacion_id", id.ToString());
            query.addWhere("fecha_inicio", "'" + desde.AddDays(cantidadNoches).ToShortDateString() + "'", "<=");
            query.addWhere("(DATEADD(day,cant_noches,fecha_inicio))", "'" + desde.ToShortDateString() + "'", ">=");
            //Si esta cancelada no tiene que ser tenida en cuenta
            query.addWhere("(reservas.reserva_estado = 1 OR reservas.reserva_estado = 2 OR reservas.reserva_estado = 6)");

            SqlCommand cmd = new SqlCommand(query.build(), ConnectionManager.getInstance().getConnection());
            Int32 count = (Int32)cmd.ExecuteScalar();

            return count == 0;
        }


    }
}
