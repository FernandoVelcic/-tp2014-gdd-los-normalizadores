using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel.ABM_de_Cliente
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
            Cliente cliente= New Cliente();
            cliente.nombre=textBox3.Text;
            cliente.apellido=textBox4.Text;
            //tipo y nro doc
            cliente.mail=textBox5.Text;
            cliente.telefono=textBox6.Text;
            cliente.direccion=textBox7.Text;
            cliente.localidad=textBox1.Text;
            cliente.pais=textBox2.Text;
            //nacionalidad se autocompleta? hace falta ponerlo?
            cliente.fechaNacimiento=textBox8.Text;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            textBox8.Text = dateTimePicker1.Value.ToString("MM/dd/yyyy");
        }
    }
}
