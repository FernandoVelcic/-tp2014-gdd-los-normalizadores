using FrbaHotel.Models;
using MyActiveRecord;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel.Views.Generar_Modificar_Reserva
{
    public partial class HabitacionesDisponibles : Form
    {

        public HabitacionesDisponibles(Regimen regimen, TipoHabitacion tipoHabitacion, DateTime desde, int canitadNoches, Hotel hotel)
        {
            InitializeComponent();
            load_Habitaciones(regimen, tipoHabitacion);
        }

        /* TODO pasar a una vista con las habitaciones disponibles o algo parecido */
        private void load_Habitaciones(Regimen regimen, TipoHabitacion tipoHabitacion)
        {

            SelectQuery<Habitacion> query = new SelectQuery<Habitacion>(typeof(Habitacion));
            query.addSelect("habitaciones.id");
            query.addSelect("habitaciones.numero");
            query.addSelect("habitaciones.piso");
            query.addSelect("hoteles.calle");
            query.addSelect("hoteles.nombre");
            query.addInnerJoin("hoteles", "habitaciones.hotel_id = hoteles.id");
            query.addInnerJoin("habitaciones_tipos", "habitaciones.tipo_id = habitaciones_tipos.id");
            query.addInnerJoin("hoteles_regimenes", "hoteles.id = hoteles_regimenes.hotel_id");
            query.addInnerJoin("regimenes", "hoteles_regimenes.regimen_id = regimenes.id");

            query.addWhere("regimenes.id", regimen);
            query.addWhere("habitaciones.tipo_id", tipoHabitacion);

            var sql = query.build();
            SqlCommand command = new SqlCommand(sql, ConnectionManager.getInstance().getConnection());
            List<Habitacion> habitaciones = new List<Habitacion>();
            using (SqlDataReader result = command.ExecuteReader())
            {
                while (result.Read())
                {
                    Habitacion habitacion = new Habitacion();
                    habitacion.id = Convert.ToInt64(result["id"]);
                    habitacion.numero = Int32.Parse(result["numero"].ToString(), null);
                    habitacion.piso = Int32.Parse(result["piso"].ToString(), null);

                    Hotel hotel = new Hotel();
                    hotel.calle = result["calle"].ToString();
                    hotel.nombre = result["nombre"].ToString();

                    habitacion.hotel = hotel;

                    habitaciones.Add(habitacion);
                }
            }

            BindingSource habitaciones_binding = new BindingSource();
            habitaciones_binding.DataSource = habitaciones;
            list_Habitaciones.DataSource = habitaciones_binding;
            

        }


    }
}
