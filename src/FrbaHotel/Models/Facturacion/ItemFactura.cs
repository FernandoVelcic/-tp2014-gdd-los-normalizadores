using MyActiveRecord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaHotel.Models
{
    public class ItemFactura : ActiveRecord
    {

        public override String table { get { return "items_facturas"; } }

        //public int id { get; set; } //INTEGER IDENTITY PRIMARY KEY

        public Factura factura { get; set; }
        public ConsumibleEstadia consumible_estadia { get; set; }
        public float monto { get; set; } //int
        public int unidades { get; set; }  //INTEGER
        
        /* C: por un consumible 
           H: por una habitacion
           N: por una habitacion no ocupada
           D: descuento
         */
        public String tipo { get; set; }


    }
}
