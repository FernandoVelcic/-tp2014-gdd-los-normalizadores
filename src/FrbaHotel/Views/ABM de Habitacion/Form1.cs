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


namespace FrbaHotel.ABM_de_Habitacion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //TODO matchear bien esto
            Habitacion habitacionNew = new Habitacion();
            habitacionNew.numero = Convert.ToInt32(textBox1.Text);
            habitacionNew.piso = Convert.ToInt32(comboBox2.Text);
            habitacionNew.hotel_id = Convert.ToInt32(comboBox1.Text);
            /*
            habitacionNew.ubicacionEnElHotel = textBox2.Text;
            habitacionNew.tipoDeHabitacion = comboBox3.Text;*/
            habitacionNew.descripcion = textBox3.Text;
            try
            {
                habitacionNew.insert();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Faltan llenar campos!\r\n" + ex.Message);
                return;
            }

            MessageBox.Show("Habitacion creada correctamente!");
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
    }
}
