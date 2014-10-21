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

namespace FrbaHotel.Views.ABM_de_Cliente
{
    public partial class Form1 : Form
    {

        Cliente cliente;

        public Form1(Cliente cliente)
        {
            InitializeComponent();
            this.cliente = cliente;
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                bindFromForm();
                cliente.save();
                MessageBox.Show("El cliente se guardo correctamente");
                this.Close();
            }
            catch (ValidationException exception)
            {
                MessageBox.Show(exception.Message);
            }
            catch (SqlException exception)
            {
                MessageBox.Show(exception.Message);
            }
            

        }

        private void bindFromForm()
        {

            cliente.nombre = txt_Nombre.Text;
            cliente.apellido = txt_Apellido.Text;
            //tipo y nro doc

            cliente.mail = txt_Mail.Text;
            //cliente.t = txt_Telefono.Text;
            cliente.dom_calle = txt_Calle.Text;
            //cliente. = txt_Localidad.Text;
            cliente.nacionalidad = txt_Pais.Text;
            //nacionalidad se autocompleta? hace falta ponerlo?
            cliente.fecha_nac = dateTimePicker1.Value.ToString();

        }


        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            txt_FechaNac.Text = dateTimePicker1.Value.ToString("MM/dd/yyyy");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

    }
}
