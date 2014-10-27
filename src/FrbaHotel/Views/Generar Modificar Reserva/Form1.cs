using FrbaHotel.Database_Helper;
using FrbaHotel.Models;
using FrbaHotel.Models.Exceptions;
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

namespace FrbaHotel.Generar_Modificar_Reserva
{
    public partial class Form1 : Form
    {
        Reserva reserva;

        public Form1() : this(new Reserva())
        {

        }


        public Form1(Reserva reserva)
        {
            InitializeComponent();
            this.reserva = reserva;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BindingSource tipo_habitacion_binding = new BindingSource();
            tipo_habitacion_binding.DataSource = EntityManager.getEntityManager().findAll<TipoHabitacion>();
            cmb_TipoHabitacion.DataSource = tipo_habitacion_binding;
            cmb_TipoHabitacion.DisplayMember = "descripcion";

            BindingSource regimen_binding = new BindingSource();
            regimen_binding.DataSource = EntityManager.getEntityManager().findAll<Regimen>();
            cmb_Regimen.DataSource = regimen_binding;
            cmb_Regimen.DisplayMember = "descripcion";

            txt_Cant_Noches.DataBindings.Add("Text", this.reserva, "cant_noches");
            txt_Desde.DataBindings.Add("Text", this.reserva, "fecha_inicio");
            load_Habitaciones();
        }

        public void update_habitaciones(object sender, EventArgs e)
        {
            load_Habitaciones();
        }

        private void load_Habitaciones()
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

            query.addWhere("regimenes.id", ((Regimen)cmb_Regimen.SelectedItem).id.ToString());
            query.addWhere("habitaciones.tipo_id", ((TipoHabitacion)cmb_TipoHabitacion.SelectedItem).id.ToString());

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

            BindingSource habitacion_binding = new BindingSource();
            habitacion_binding.DataSource = habitaciones;
            cmb_Habitacion.DataSource = habitacion_binding;

        }

        private void btn_Generar_Click(object sender, EventArgs e)
        {
            reserva.regimen = cmb_Regimen.SelectedItem as Regimen;
            reserva.tipo_habitacion = cmb_TipoHabitacion.SelectedItem as TipoHabitacion;

            try
            {
                reserva.save();
            }
            catch (ValidationException exception)
            {
                MessageBox.Show(exception.Message);
                return;
            }
            catch (SqlException exception)
            {
                MessageBox.Show(exception.StackTrace);
                return;
            }
            MessageBox.Show("La reserva se genero corractamente");
            //TODO: Volver a formulario anterior
        }

        private void btn_Volver_Click(object sender, EventArgs e)
        {
            //TODO: Volver a formulario anterior
        }

        private void update_habitaciones()
        {

        }


    }
}
