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
            List<TipoHabitacion> tipoHabitaciones = EntityManager.getEntityManager().findAll<TipoHabitacion>();
            tipo_habitacion_binding.DataSource = tipoHabitaciones;
            cmb_TipoHabitacion.DataSource = tipo_habitacion_binding;
            cmb_TipoHabitacion.DisplayMember = "descripcion";
            cmb_TipoHabitacion.SelectedItem = tipoHabitaciones[0];

            BindingSource regimen_binding = new BindingSource();
            List<Regimen> regimenes = EntityManager.getEntityManager().findAll<Regimen>();
            regimen_binding.DataSource = regimenes;
            cmb_Regimen.DataSource = regimen_binding;
            cmb_Regimen.DisplayMember = "descripcion";
            cmb_Regimen.SelectedItem = regimenes[0];

            txt_Cant_Noches.DataBindings.Add("Text", this.reserva, "cant_noches");
            txt_Desde.DataBindings.Add("Text", this.reserva, "fecha_inicio");
        }

        public void update_habitaciones(object sender, EventArgs e)
        {
        }


        private void btn_Generar_Click(object sender, EventArgs e)
        {

            new HabitacionesDisponibles(
                cmb_Regimen.SelectedItem as Regimen, cmb_TipoHabitacion.SelectedItem as TipoHabitacion, DateTime.Parse(txt_Desde.Text), Int32.Parse(txt_Cant_Noches.Text), new Hotel()).Show();


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
