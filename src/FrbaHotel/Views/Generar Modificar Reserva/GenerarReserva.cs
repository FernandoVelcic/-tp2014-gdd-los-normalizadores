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

namespace FrbaHotel.Generar_Modificar_Reserva
{
    public partial class Form1 : Form
    {
        Reserva reserva;

        public Form1()
        {
            InitializeComponent();
            this.reserva = new Reserva();
            reserva.cant_noches = 7;
            reserva.fecha_inicio = DateTime.Today.ToString();
            reserva.reserva_estado = 1;
        }


        public Form1(Reserva reserva)
        {
            InitializeComponent();
            this.reserva = reserva;
            reserva.cant_noches = 7;
            reserva.fecha_inicio = DateTime.Today.ToString();
            reserva.reserva_estado = 1;
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
            cmb_TipoHabitacion.DisplayMember = "descripcion";

            update_regimenes();

            txt_Cant_Noches.DataBindings.Add("Text", this.reserva, "cant_noches");
            txt_Desde.DataBindings.Add("Text", this.reserva, "fecha_inicio");
        }

        private void btn_Generar_Click(object sender, EventArgs e)
        {

            try
            {
                validate();
                new HabitacionesDisponibles(
               (cmb_Regimen.SelectedItem as HotelRegimen).regimen, cmb_TipoHabitacion.SelectedItem as TipoHabitacion, DateTime.Parse(txt_Desde.Text), Int32.Parse(txt_Cant_Noches.Text), cmb_Hotel.SelectedItem as Hotel, this).Show();
                this.Hide();
                
            }
            catch (ValidationException exception)
            {
                MessageBox.Show(exception.Message);
            }
           
        }

        private void validate()
        {

            if (DateTime.Parse(txt_Desde.Text).Year < 1900)
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

        private void cmb_Hotel_SelectedIndexChanged(object sender, EventArgs e)
        {
            update_regimenes();
        }


    }
}
