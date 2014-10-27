using MyActiveRecord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using FrbaHotel.Database_Helper;
using FrbaHotel.Models.Exceptions;
using FrbaHotel.Tools;

namespace FrbaHotel.Models
{
    public class Cliente : ActiveRecord
    {
        public override String table { get { return "clientes"; } }

        //public int id { get; set; } //INTEGER IDENTITY PRIMARY KEY
        public String apellido { get; set; } //[nvarchar](255)
        public String nombre { get; set; }  //[nvarchar](255)
        public String fecha_nac { get; set; } //[datetime]
        public String mail { get; set; } //[nvarchar](255)
        public String telefono { get; set; } //[nvarchar](255)

        public String dom_calle { get; set; } //[nvarchar](255)
        public int nro_calle { get; set; } //[numeric](18, 0)
        public int piso { get; set; } //[numeric](18, 0)
        public String depto { get; set; } //[nvarchar](50)

        public String localidad { get; set; } //[nvarchar](255)
        [System.ComponentModel.Browsable(false)]
        public Pais nacionalidad { get; set; } //INTEGER
        //[System.ComponentModel.Browsable(false)]
        //public Pais pais { get; set; } //INTEGER

        public Boolean estado { get; set; } //[bit]

        public TipoDocumento documento_tipo { get; set; }
        public long documento_nro { get; set; } //[numeric](18, 0)

        public override void preInsert()
        {
            if (mail.isValidEmail() != true)
                throw new ValidationException("Formato de email invalido");

            List<Cliente> clientes = EntityManager.getEntityManager().findAllBy<Cliente>("mail", mail);
            if (clientes.Count != 0)
            {
                throw new ValidationException("Email duplicado");
            }
        }
    }
}
