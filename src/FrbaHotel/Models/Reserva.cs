using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MyActiveRecord;
using System.Windows.Forms;

namespace FrbaHotel.Models
{
    public class Reserva : ActiveRecord
    {
        public override String table { get { return "reservas"; } }

        //public int id { get; set; } //INTEGER IDENTITY PRIMARY KEY
        public DateTime fecha_carga { get; set; } //[datetime]
        public DateTime fecha_inicio { get; set; } //[datetime]
        public Regimen regimen { get; set; } //[numeric](18, 0)
        public TipoHabitacion tipo_habitacion { get; set; } //Integer
        public int cant_noches { get; set; } //[numeric](18, 0)
        public int cantidad_personas { get; set; } //INTEGER


        public override void preInsert()
        {
            fecha_carga = Config.getInstance().getCurrentDate();
        }


    }
}
