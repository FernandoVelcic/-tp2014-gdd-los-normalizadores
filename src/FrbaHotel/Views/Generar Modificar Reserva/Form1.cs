using FrbaHotel.Database_Helper;
using FrbaHotel.Models;
using FrbaHotel.Models.Exceptions;
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

    }
}
