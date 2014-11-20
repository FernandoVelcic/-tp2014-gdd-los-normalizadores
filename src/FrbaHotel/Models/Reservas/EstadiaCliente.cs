using MyActiveRecord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaHotel.Models
{
    public class EstadiaCliente : ActiveRecord
    {

        public override String table { get { return "estadia_cliente"; } }

        //public int id { get; set; } //INTEGER IDENTITY PRIMARY KEY

        public Estadia estadia { get; set; }
        public Cliente cliente { get; set; }
    }
}
