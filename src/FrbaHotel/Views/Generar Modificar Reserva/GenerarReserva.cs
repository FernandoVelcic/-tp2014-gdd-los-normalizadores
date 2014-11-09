using FrbaHotel.Database_Helper;
using FrbaHotel.Models;
using FrbaHotel.Models.Exceptions;
using FrbaHotel.Views.Generar_Modificar_Reserva;
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

using FrbaHotel.Homes;
using System.Globalization;

namespace FrbaHotel.Views.Generar_Modificar_Reserva
{
    public partial class FormGenerarReserva : Form
    {
        private Reserva reserva;
        private bool esModificacion;

        public FormGenerarReserva()
        {
            esModificacion = false;

            reserva = new Reserva();
            reserva.cant_noches = 7;
            reserva.fecha_inicio = Config.getInstance().getCurrentDate().ToShortDateString();
            reserva.reserva_estado = 1; //Reserva correcta
            InitializeComponent();
        }

        public FormGenerarReserva(Reserva reserva)
        {
            esModificacion = true;

            this.reserva = reserva;
            reserva.reserva_estado = 2; //Reserva modificada

            InitializeComponent();
            btn_Generar.Text = "Siguiente (puede cambiar habitaciones)";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BindingSource hoteles_binding = new BindingSource();
            hoteles_binding.DataSource = EntityManager.getEntityManager().findAll<Hotel>();
            cmb_Hotel.DataSource = hoteles_binding;

            if (SesionActual.rol_usuario.rol.id != 3) //Si no es Guest
            {
                txt_Hotel.Visible = false;
                cmb_Hotel.Visible = false;
                cmb_Hotel.SelectedItem = SesionActual.rol_usuario.hotel;
            }


            BindingSource tipo_habitacion_binding = new BindingSource();
            List<TipoHabitacion> tipoHabitaciones = EntityManager.getEntityManager().findAll<TipoHabitacion>();
            tipo_habitacion_binding.DataSource = tipoHabitaciones;
            cmb_TipoHabitacion.DataSource = tipo_habitacion_binding;

            if (esModificacion)
            {
                Habitacion habitacion = reserva.obtener_una_habitacion();
                cmb_Hotel.Text = habitacion.hotel.ToString();
                cmb_Regimen.Text = reserva.regimen.descripcion;
                cmb_TipoHabitacion.Text = habitacion.tipo.ToString();
            }

            update_regimenes();

            txt_Cant_Noches.DataBindings.Add("Text", this.reserva, "cant_noches");
            dateTimePicker1.DataBindings.Add("Text", this.reserva, "fecha_inicio", true);

            update_precio_habitacion();
        }

        private void btn_Generar_Click(object sender, EventArgs e)
        {
            Hotel hotel_seleccionado = cmb_Hotel.SelectedItem as Hotel;
            reserva.regimen = (cmb_Regimen.SelectedItem as HotelRegimen).regimen;
            TipoHabitacion tipo_habitacion_seleccionado = cmb_TipoHabitacion.SelectedItem as TipoHabitacion;

            if ( !hotel_seleccionado.estaLibre(reserva.fecha_inicio, DateTime.Parse(reserva.fecha_inicio).AddDays(reserva.cant_noches).ToShortDateString()) )
            {
                MessageBox.Show("El hotel no esta disponible para ese periodo");
                return;
            }

            try
            {
                validate();
                new HabitacionesDisponibles(reserva, tipo_habitacion_seleccionado, hotel_seleccionado, esModificacion, this).Show();
                this.Hide();

            }
            catch (ValidationException exception)
            {
                MessageBox.Show(exception.Message);
            }

        }

        private void validate()
        {
            if (DateTime.Parse(reserva.fecha_inicio) < Config.getInstance().getCurrentDate().Date)
            {
                throw new ValidationException("No puede pedir reservas en fechas anteriores a la actual");
            }

            if (DateTime.Parse(reserva.fecha_inicio).Year < 1900)
            {
                throw new ValidationException("Por favor, seleccione una fecha valida");
            }

            if (Int32.Parse(txt_Cant_Noches.Text) < 0)
            {
                throw new ValidationException("Por favor, seleccione una cantidad de días valida");
            }

        }

        private void btn_Volver_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void update_regimenes()
        {
            BindingSource regimen_binding = new BindingSource();
            List<HotelRegimen> regimenes = EntityManager.getEntityManager().findAllBy<HotelRegimen>("hotel_id", (cmb_Hotel.SelectedItem as Hotel).id.ToString());
            regimen_binding.DataSource = regimenes;
            cmb_Regimen.DataSource = regimen_binding;
        }

        private void update_precio_habitacion()
        {
            Hotel hotel_seleccionado = cmb_Hotel.SelectedItem as Hotel;
            Regimen regimen_seleccionado = (cmb_Regimen.SelectedItem as HotelRegimen).regimen;
            TipoHabitacion tipo_habitacion_seleccionado = cmb_TipoHabitacion.SelectedItem as TipoHabitacion;

            //FORMULA
            if (regimen_seleccionado != null && tipo_habitacion_seleccionado != null && hotel_seleccionado != null)
                label1.Text = "Costo por dia por habitacion: $" + (tipo_habitacion_seleccionado.porcentual* regimen_seleccionado.precio * tipo_habitacion_seleccionado.cantidad_maxima_personas + hotel_seleccionado.cant_estrella * hotel_seleccionado.recarga_estrella);
            else
                label1.Text = "Costo por dia por habitacion:";
        }

        private void cmb_Hotel_SelectedIndexChanged(object sender, EventArgs e)
        {
            update_regimenes();
            update_precio_habitacion();
        }

        private void cmb_TipoHabitacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            update_precio_habitacion();
        }
    }
}
