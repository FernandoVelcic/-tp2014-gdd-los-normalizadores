using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;

using FrbaHotel.Models;
using FrbaHotel.Models.Exceptions;
using FrbaHotel.Database_Helper;

namespace FrbaHotel.Views.ABM_de_Hotel
{
    public partial class AltaModificacionHotel : Form
    {
        private Boolean esAlta = false;
        private Hotel hotel;

        public AltaModificacionHotel() : this(new Hotel())
        {
            esAlta = true;
            hotel.estado = true;
            hotel.fecha_creacion = DateTime.Today.ToString();
        }

        public AltaModificacionHotel(Hotel hotel)
        {
            InitializeComponent();
            this.hotel = hotel;
        }

        private void AltaModificacionHotel_Load(object sender, EventArgs e)
        {
            BindingSource nacionalidad_binding = new BindingSource();
            nacionalidad_binding.DataSource = EntityManager.getEntityManager().findAll<Pais>();
            comboBox4.DataSource = nacionalidad_binding;
            comboBox4.DisplayMember = "nombre";
            //if (!esAlta)
            //    comboBox4.Text = hotel.pais.nombre;

            textBox1.DataBindings.Add("Text", hotel, "nombre");
            textBox2.DataBindings.Add("Text", hotel, "mail");
            textBox3.DataBindings.Add("Text", hotel, "telefono");
            textBox4.DataBindings.Add("Text", hotel, "calle");
            textBox8.DataBindings.Add("Text", hotel, "nro_Calle");
            textBox5.DataBindings.Add("Text", hotel, "cant_estrella");
            textBox6.DataBindings.Add("Text", hotel, "ciudad");
            dateTimePicker1.DataBindings.Add("Text", hotel, "fecha_creacion", true);
            comboBox1.DataBindings.Add("SelectedIndex", hotel, "estado");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                hotel.save();
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

            if (esAlta)
                MessageBox.Show("Hotel creado correctamente!");
            else
                MessageBox.Show("Hotel modificado correctamente!");

            this.nextForm(new FrbaHotel.Views.ABM_de_Hotel.ABMHotel());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.nextForm(new FrbaHotel.Views.ABM_de_Hotel.ABMHotel());
        }
    }
}
