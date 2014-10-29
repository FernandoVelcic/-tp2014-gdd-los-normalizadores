using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MyActiveRecord;
using FrbaHotel.Models.Exceptions;
using FrbaHotel.Tools;

namespace FrbaHotel.Models
{
    public class Hotel : ActiveRecord
    {
        public override String table { get { return "hoteles"; } }

        //public int id { get; set; } //INTEGER IDENTITY PRIMARY KEY
        public String nombre { get; set; } //[nvarchar](255)
        public String mail { get; set; } //[nvarchar](255)
        public String telefono { get; set; } //[nvarchar](255)
        public String fecha_creacion { get; set; } //[datetime]
        public Pais pais { get; set; }
        public String ciudad { get; set; } //[nvarchar](255)
        public String calle { get; set; } //[nvarchar](255)
        public int nro_Calle { get; set; } //[numeric](18, 0)
	    public int cant_estrella { get; set; } //[numeric](18, 0)
	    public int recarga_estrella { get; set; } //[numeric](18, 0)
        public Boolean estado { get; set; } //[bit]

        public override string ToString()
        {
            return (nombre == "") ? calle + " " + nro_Calle : nombre;
        }

        public override void preSave()
        {
            if (mail.isValidEmail() != true)
                throw new ValidationException("Formato de email invalido");
        }
    }
}
