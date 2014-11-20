using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MyActiveRecord;

using FrbaHotel.Database_Helper;
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
        public String calle { get; set; } //[nvarchar](255)
        public int nro_Calle { get; set; } //[numeric](18, 0)
        public String fecha_nac { get; set; } //datetime

        public int intentos_fallidos { get; set; } //[tinyint]
        public Boolean estado { get; set; } //[bit]


        public override void preSave()
        {

            if (String.IsNullOrEmpty(username))
            {
                throw new ValidationException("El username es obligatorio");
            }

            if (String.IsNullOrEmpty(password))
            {
                throw new ValidationException("La password es obligatoria");
            }

            if (String.IsNullOrEmpty(nombre))
            {
                throw new ValidationException("El nombre es obligatorio");
            }

            if (String.IsNullOrEmpty(apellido))
            {
                throw new ValidationException("La password es obligatoria");
            }

            if (String.IsNullOrEmpty(fecha_nac))
            {
                throw new ValidationException("La fecha de nacimiento es obligatoria");
            }


            List<FetchCondition> condiciones = new List<FetchCondition>();
            FetchCondition condicionId = new FetchCondition();
            condicionId.setNotEquals("usuarios.id", id);
            condiciones.Add(condicionId);
            FetchCondition condicionUsername = new FetchCondition();
            condicionUsername.setEquals("usuarios.username", username);
            condiciones.Add(condicionUsername);

            List<Usuario> usuarios = EntityManager.getEntityManager().findList<Usuario>(condiciones);
            if (usuarios.Count != 0)
            {
                throw new ValidationException("Nombre de usuario duplicado");
            }

            if (mail.isValidEmail() != true)
                throw new ValidationException("Formato de email invalido");
        }

        public List<RolUsuario> getRoles()
        {
            return EntityManager.getEntityManager().findAllBy<RolUsuario>("usuario_id", id.ToString());
        }

    }
}
