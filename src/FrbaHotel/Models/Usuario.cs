using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MyActiveRecord;
using FrbaHotel.Models.Exceptions;
using FrbaHotel.Tools;

namespace FrbaHotel.Models
{
    public class Usuario : ActiveRecord
    {
        public override String table { get { return "usuarios"; } }

        //public int id { get; set; } //INTEGER IDENTITY PRIMARY KEY
        public String username { get; set; } //[nvarchar](30)
        [System.ComponentModel.Browsable(false)]
        public String password { get; set; } //[char](256)
        public String nombre { get; set; } //[nvarchar](255)
        public String apellido { get; set; } //[nvarchar](255)

        public TipoDocumento documento_tipo { get; set; }
        public long documento_nro { get; set; } //[numeric](18, 0)

        public String mail { get; set; } //[nvarchar](255)
        public String telefono { get; set; } //[nvarchar](255)
        public String direccion { get; set; } //[nvarchar](255)
        public String fecha_nac { get; set; } //datetime

        public int intentos_fallidos { get; set; } //[tinyint]
        public Boolean estado { get; set; } //[bit]


        public override void preSave()
        {
            if (mail.isValidEmail() != true)
                throw new ValidationException("Formato de email invalido");
        }
    }
}
