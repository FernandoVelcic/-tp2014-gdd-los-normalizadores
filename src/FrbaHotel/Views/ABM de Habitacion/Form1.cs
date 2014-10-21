using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using MyActiveRecord;
using FrbaHotel.Models;
using FrbaHotel.Database_Helper;
using FrbaHotel.Models.Exceptions;
using System.Data.SqlClient;


namespace FrbaHotel.ABM_de_Habitacion
{
    public partial class Form1 : Form
    {

        private List<Hotel> hoteles;
        private List<TipoHabitacion> tipoHabitaciones;
        private Habitacion habitacion;

        public Form1(Habitacion habitacion)
        {
            InitializeComponent();
            cmb_Frente.Items.Add("Si");
            cmb_Frente.Items.Add("No");
            this.habitacion = habitacion;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            hoteles = EntityManager.getEntityManager().findAll<Hotel>();
            foreach (Hotel hotel in hoteles)
            {
                cmb_Hotel.Items.Add(hotel.calle);
            }

            tipoHabitaciones = EntityManager.getEntityManager().findAll<TipoHabitacion>();
            foreach (TipoHabitacion tipo in tipoHabitaciones)
            {
                cmb_TipoHabitacion.Items.Add(tipo.descripcion);
            }

        }
        

        private void onGuardar(object sender, EventArgs e)
        {

            try
            {
                bindFromForm();
                habitacion.insert();
            }
            catch (ValidationException ex)
            {
                MessageBox.Show("Faltan llenar campos!\r\n" + ex.Message);
                return;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message + "\r\n"  + Query.log.Last());
                return;
            }

            MessageBox.Show("Habitacion creada correctamente!");
            this.Close();

        }


        private void bindFromForm()
        {

            //TODO matchear bien esto
            habitacion.numero = Convert.ToInt32(txt_NroHabitacion.Text);
            habitacion.piso = Convert.ToInt32(txt_Piso.Text);

            foreach (Hotel hotel in hoteles)
            {
                if (cmb_Hotel.Text == hotel.calle)
                {
                    habitacion.hotel = hotel;
                }
            }

            foreach (TipoHabitacion tipo in tipoHabitaciones)
            {
                if (cmb_TipoHabitacion.Text == tipo.descripcion)
                {
                    habitacion.tipo = tipo;
                }
            }


            if (habitacion.tipo == null)
            {
                throw new ValidationException("Complete el campo tipo");
            }

            habitacion.frente = cmb_Frente.Text == "Si" ? "S" : "N";

        }



        private void onVolver(object sender, EventArgs e)
        {
            this.Close();
        }


        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

      
    }
}
