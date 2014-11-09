using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using FrbaHotel.Database_Helper;
using FrbaHotel.Models;
using FrbaHotel.Models.Exceptions;
using FrbaHotel.Views.ABM_de_Cliente;

using MyActiveRecord;

namespace FrbaHotel.Views.Generar_Modificar_Reserva
{
    public partial class HabitacionesDisponibles : Form, SeleccionCliente
    {
        private Hotel hotel;
        private TipoHabitacion tipoHabitacion;
        private Form previousForm;
        private Reserva reserva;

        private bool esModificacion;

        public HabitacionesDisponibles(Reserva reserva, TipoHabitacion tipoHabitacion, Hotel hotel, bool esModificacion, Form previous)
        {
            this.reserva = reserva;
            this.tipoHabitacion = tipoHabitacion;
            this.hotel = hotel;
            
            this.previousForm = previous;
            this.esModificacion = esModificacion;

            InitializeComponent();

            if (esModificacion)
            {
                btn_Confirmar.Visible = false;
                btn_CrearCliente.Text = "Modificar reserva";
            }
        }

        /* TODO 
         * pasar a una vista con las habitaciones disponibles o algo parecido 
         */
        private void HabitacionesDisponibles_Load(object sender, EventArgs e)
        {
            //Cancelar reservas por no show
            String execUspCancelarReservas = "EXECUTE [LOS_NORMALIZADORES].[uspCancelarReservasPorNoShow] @fecha_sistema = '" + Config.getInstance().getCurrentDate().ToShortDateString() + "'";
            new SqlCommand(execUspCancelarReservas, ConnectionManager.getInstance().getConnection()).ExecuteNonQuery();

            //Obtener habitaciones
            SelectQuery<Habitacion> query = new SelectQuery<Habitacion>(typeof(Habitacion));

            query.addSelect("habitaciones.id");
            query.addSelect("habitaciones.numero");
            query.addSelect("habitaciones.piso");

            query.addInnerJoin("hoteles", "habitaciones.hotel_id = hoteles.id");
            query.addInnerJoin("habitaciones_tipos", "habitaciones.tipo_id = habitaciones_tipos.id");
            query.addInnerJoin("hoteles_regimenes", "hoteles.id = hoteles_regimenes.hotel_id");
            query.addInnerJoin("regimenes", "hoteles_regimenes.regimen_id = regimenes.id");

            query.addWhere("regimenes.id", reserva.regimen);
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
            List<ReservaHabitacion> habitaciones_reservadas = new List<ReservaHabitacion>();
            if (esModificacion)
                habitaciones_reservadas = reserva.obtener_habitaciones();

            habitaciones = habitaciones.FindAll(h => h.estaDisponible(DateTime.Parse(reserva.fecha_inicio), reserva.cant_noches) || habitaciones_reservadas.Exists(hr => hr.habitacion.id == h.id));

            BindingSource habitaciones_binding = new BindingSource();
            habitaciones_binding.DataSource = habitaciones;
            list_Habitaciones.DataSource = habitaciones_binding;

            for (int i = 0; i < list_Habitaciones.Items.Count; i++)
            {
                Habitacion habitacion = list_Habitaciones.Items[i] as Habitacion;
                list_Habitaciones.SetSelected(i, habitaciones_reservadas.Exists(hr => hr.habitacion.id == habitacion.id));
            }
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
            if (esModificacion)
            {
                guardarReserva();
                return;
            }

            AltaModificacionCliente form = new ABM_de_Cliente.AltaModificacionCliente();
            form.setModoSeleccion(this);
            form.Show();
        }

        void guardarReserva()
        {
            try
            {
                reserva.save();

                if (esModificacion)
                    reserva.obtener_habitaciones().ForEach(h => h.delete());

                foreach (Habitacion habitacion in list_Habitaciones.SelectedItems)
                {
                    ReservaHabitacion reserva_habitacion = new ReservaHabitacion();
                    reserva_habitacion.habitacion = habitacion;
                    reserva_habitacion.reserva = reserva;
                    reserva_habitacion.insert();
                }
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

        /* Cuando se selecciona un cliente */
        void SeleccionCliente.clienteSeleccionado(Cliente cliente)
        {
            if (cliente.estado == false)
            {
                MessageBox.Show("Este cliente no tiene permitido realizar reservas");
                return;
            }

            
            reserva.cliente = cliente;
            guardarReserva();
        }

        private void list_Habitaciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            //FORMULA
            label1.Text = "Costo total de la reserva: $" + list_Habitaciones.SelectedItems.Count * (tipoHabitacion.porcentual * reserva.regimen.precio * tipoHabitacion.cantidad_maxima_personas + hotel.cant_estrella * hotel.recarga_estrella);
        }


    }
}
