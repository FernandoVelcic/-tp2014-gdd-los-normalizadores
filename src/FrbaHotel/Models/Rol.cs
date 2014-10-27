using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MyActiveRecord;

namespace FrbaHotel.Models
{
    public class Rol : ActiveRecord
    {
        public override String table { get { return "roles"; } }

        //public int id { get; set; } //INTEGER IDENTITY PRIMARY KEY
        public String descripcion { get; set; } //[nvarchar](30)
        public Boolean estado { get; set; } //[bit]
        public Boolean ABM_Rol { get; set; } //[bit]
        public Boolean ABM_Habitación { get; set; } //[bit]
        public Boolean ABM_Cliente { get; set; } //[bit]
        public Boolean ABM_Usuario { get; set; } //[bit]
        public Boolean ABM_Regimen { get; set; } //[bit]
        public Boolean ABM_Hotel { get; set; } //[bit]
        public Boolean Generar_Reserva { get; set; } //[bit]
        public Boolean Cancelar_Reserva { get; set; } //[bit]
        public Boolean Registrar_Consumible { get; set; } //[bit]
        public Boolean Registrar_Estadía { get; set; } //[bit]
        public Boolean Facturar_Estadía { get; set; } //[bit]
        public Boolean Listado_Estadístico { get; set; } //[bit]

        public override string ToString()
        {
            return descripcion;
        }
        
    }
}
