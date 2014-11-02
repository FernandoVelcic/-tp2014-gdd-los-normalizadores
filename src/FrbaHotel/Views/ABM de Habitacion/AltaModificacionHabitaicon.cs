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
    public partial class AltaModificacionHabitacion : Form
    {
        private bool esAlta = false;
        private Habitacion habitacion;

        public AltaModificacionHabitacion() : this(new Habitacion())
        {
            esAlta = true;
            habitacion.estado = true;
        }

        public AltaModificacionHabitacion(Habitacion habitacion)
        {
            InitializeComponent();
            this.habitacion = habitacion;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            BindingSource hoteles_binding = new BindingSource();
            hoteles_binding.DataSource = EntityManager.getEntityManager().findAll<Hotel>();
            cmb_Hotel.DataSource = hoteles_binding;

            BindingSource habitacionesTipo_binding = new BindingSource();
            habitacionesTipo_binding.DataSource = EntityManager.getEntityManager().findAll<TipoHabitacion>();
            cmb_TipoHabitacion.DataSource = habitacionesTipo_binding;

            txt_NroHabitacion.DataBindings.Add("Text", habitacion, "numero");
            txt_Piso.DataBindings.Add("Text", habitacion, "piso");
            cmb_Frente.DataBindings.Add("Text", habitacion, "frente");
            comboBox1.DataBindings.Add("SelectedIndex", habitacion, "estado");
            textBox1.DataBindings.Add("Text", habitacion, "descripcion");

            if (!esAlta)
            {
                cmb_Hotel.Text = habitacion.hotel.ToString();
                cmb_TipoHabitacion.Text = habitacion.tipo.ToString();
                cmb_TipoHabitacion.Enabled = false;
            }
        }
        

        private void onGuardar(object sender, EventArgs e)
        {
            habitacion.hotel = cmb_Hotel.SelectedValue as Hotel;
            habitacion.tipo = cmb_TipoHabitacion.SelectedValue as TipoHabitacion;

            try
            {
                habitacion.save();
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

            if(esAlta)
                MessageBox.Show("Habitacion creada correctamente!");
            else
                MessageBox.Show("Habitacion modificada correctamente!");

            Close();
        }

        private void onVolver(object sender, EventArgs e)
        {
            Close();
        }
      
    }
}
