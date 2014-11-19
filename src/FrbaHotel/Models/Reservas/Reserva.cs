using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MyActiveRecord;

using FrbaHotel.Database_Helper;
using FrbaHotel.Models;


namespace FrbaHotel.Models
{
    public class Reserva : ActiveRecord
    {
        public override String table { get { return "reservas"; } }

        //public int id { get; set; } //INTEGER IDENTITY PRIMARY KEY
        public String fecha_carga { get; set; } //[datetime]
        public String fecha_inicio { get; set; } //[datetime]
        public Regimen regimen { get; set; } //[numeric](18, 0)
        public Cliente cliente { get; set; }
        public int cant_noches { get; set; } //[numeric](18, 0)
        public int reserva_estado { get; set; } //INTEGER NOT NULL

        public override void preInsert()
        {
            fecha_carga = Config.getInstance().getCurrentDate().ToString();
        }

        public bool estaCancelada()
        {
            return reserva_estado == 3 || reserva_estado == 4 || reserva_estado == 5;
        }

        public List<ReservaHabitacion> obtener_habitaciones()
        {
            return EntityManager.getEntityManager().findAllBy<ReservaHabitacion>("reservas_habitaciones.reserva_id", id.ToString());
        }

        public Habitacion obtener_una_habitacion() //HACK
        {
            List<ReservaHabitacion> habitaciones_reservadas = obtener_habitaciones();
            return EntityManager.getEntityManager().findById<Habitacion>(habitaciones_reservadas[0].habitacion.id);
        }

        public int cantidad_maxima_personas()
        {
            return obtener_habitaciones().Count() * obtener_una_habitacion().tipo.cantidad_maxima_personas;
        }
    }
}
