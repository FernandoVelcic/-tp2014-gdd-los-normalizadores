using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
            Habitaciones habitacionNew = new Habitaciones();
            habitacionNew.numero = Convert.ToInt32(textBox1.Text);
            /*habitacionNew.hotel= comboBox1.Text;
            habitacionNew.pisoHotel = comboBox2.Text ;
            habitacionNew.ubicacionEnElHotel = textBox2.Text;
            habitacionNew.tipoDeHabitacion = comboBox3.Text;*/
            habitacionNew.descripcion = textBox3.Text;
        }

      
    }
}
