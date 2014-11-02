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
        public Habitacion habitacion { get; set; }
        public Cliente cliente { get; set; }
        public int cant_noches { get; set; } //[numeric](18, 0)
        public int cantidad_personas { get; set; } //INTEGER
        public int reserva_estado { get; set; } //INTEGER NOT NULL

        public String motivo_cancelacion { get; set; } //[nvarchar](255)
        //public DateTime fecha_cancelacion { get; set; } //[datetime]
        public String usuario_cancelacion { get; set; } //[nvarchar](30)


        public override void preInsert()
        {
            fecha_carga = Config.getInstance().getCurrentDate();
        }


    }
}
