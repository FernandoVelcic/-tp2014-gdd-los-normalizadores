using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaHotel
{
    class Habitacion : ActiveRecord
    {
        public int numero { get; set; } //id?
        public String hotel { get; set; } //lo usamos string?
        public String pisoHotel { get; set; } //idem arriba
        public String ubicacionEnElHotel { get; set; } //[nvarchar](255)
        public String tipoDeHabitacion { get; set; } //[nvarchar](255)
        public String descripcion { get; set; } //[nvarchar](255)
    }
}
