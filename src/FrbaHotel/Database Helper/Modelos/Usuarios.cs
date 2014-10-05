using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MyActiveRecord;

namespace FrbaHotel
{
    class Usuarios : ActiveRecord
    {

        public override String table { get { return "usuarios"; } }

        //public int id { get; set; } //INTEGER IDENTITY PRIMARY KEY
        public String username { get; set; } //[nvarchar](30)
        [System.ComponentModel.Browsable(false)] //Para no mostrar la contraseña
        public String password { get; set; } //[char](256)
        public String nombre { get; set; } //[nvarchar](255)
        public String apellido { get; set; } //[nvarchar](255)
        //tipo y numero de documento
        public String mail { get; set; } //[nvarchar](255)
        //telefono
        //direccion
        public String fecha_nac { get; set; } //datetime
        //hotel donde se desempeña

        public int intentos_fallidos { get; set; } //[tinyint]
        public Boolean estado { get; set; } //[bit]

    }
}
