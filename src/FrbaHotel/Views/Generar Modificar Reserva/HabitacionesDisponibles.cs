using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using FrbaHotel.Models;
using FrbaHotel.Models.Exceptions;
using FrbaHotel.Views.ABM_de_Cliente;
using MyActiveRecord;

namespace FrbaHotel.Views.Generar_Modificar_Reserva
{
    public partial class HabitacionesDisponibles : Form, SeleccionCliente
    {

        private DateTime desde;
        private int cantidadNoches;
        private Regimen regimen;
        private Hotel hotel;
        private TipoHabitacion tipoHabitacion;
        private Form previousForm;
        private Habitacion habitacion; 

        public HabitacionesDisponibles(Regimen regimen, TipoHabitacion tipoHabitacion, DateTime desde, int cantidadNoches, Hotel hotel, Form previous)
        {
            this.desde = desde;
            this.cantidadNoches = cantidadNoches;
            this.hotel = hotel;
            this.regimen = regimen;
            this.tipoHabitacion = tipoHabitacion;
            this.previousForm = previous;

            InitializeComponent();
            load_Habitaciones(regimen, tipoHabitacion);
        }

        /* TODO 
         * pasar a una vista con las habitaciones disponibles o algo parecido 
         */
        private void load_Habitaciones(Regimen regimen, TipoHabitacion tipoHabitacion)
        {

            SelectQuery<Habitacion> query = new SelectQuery<Habitacion>(typeof(Habitacion));

            query.addSelect("habitaciones.id");
            query.addSelect("habitaciones.numero");
            query.addSelect("habitaciones.piso");

            query.addInnerJoin("hoteles", "habitaciones.hotel_id = hoteles.id");
            query.addInnerJoin("habitaciones_tipos", "habitaciones.tipo_id = habitaciones_tipos.id");
            query.addInnerJoin("hoteles_regimenes", "hoteles.id = hoteles_regimenes.hotel_id");
            query.addInnerJoin("regimenes", "hoteles_regimenes.regimen_id = regimenes.id");

            query.addWhere("regimenes.id", regimen);
            query.addWhere("habitaciones.tipo_id", tipoHabitacion);
            query.addWhere("habitaciones.hotel_id", hotel);
            query.addWhere("habitaciones.estado = 1"); //La habitacion dada de baja no se puede tener en cuenta

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

                    habitacion.hotel = hotel;

                    habitaciones.Add(habitacion);
                }
            }

            //Mostrar solo habitaciones no ocupadas
            habitaciones = habitaciones.FindAll(h => h.estaDisponible(desde, cantidadNoches));

            BindingSource habitaciones_binding = new BindingSource();
            habitaciones_binding.DataSource = habitaciones;
            list_Habitaciones.DataSource = habitaciones_binding;
            

        }

        private void btn_Confirmar_Click(object sender, EventArgs e)
        {
            ABMCliente form = new ABM_de_Cliente.ABMCliente();
            form.Show();
            form.setModoSeleccionCliente(this);
            
        }

        private void btn_Volver_Click(object sender, EventArgs e)
        {
            this.Close();
            this.previousForm.Show();
        }

        private void btn_CrearCliente_Click(object sender, EventArgs e)
        {
            AltaModificacionCliente form = new ABM_de_Cliente.AltaModificacionCliente();
            form.setModoSeleccion(this);
            form.Show();
        }


        /* Cuando se selecciona un cliente */
        void SeleccionCliente.clienteSeleccionado(Cliente cliente)
        {
            Reserva reserva = new Reserva();
            reserva.regimen = regimen;
            reserva.habitacion = list_Habitaciones.SelectedItem as Habitacion;
            reserva.fecha_inicio = desde;
            reserva.cant_noches = cantidadNoches;
            reserva.cliente = cliente;
            reserva.reserva_estado = 1; //Reserva correcta

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
                MessageBox.Show(exception.Message);
                return;
            }

            MessageBox.Show("La reserva se guardo con exito! El numero de reserva es: " + reserva.id);
            Close();
            new Operaciones().Show();

        }


    }
}
