using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel.ABM_de_Usuario
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

      
        private void button1_Click(object sender, EventArgs e)
        {
            Usuarios user = new Usuarios();
            user.username = textBox1.Text;
            user.password = textBox2.Text;
            user.nombre = textBox3.Text;
            user.apellido = textBox4.Text;
            user.mail = textBox5.Text;

            user.fecha_nac = textBox8.Text;

            user.intentos_fallidos = 0;
            user.estado = true;

            try
            {
                user.insert();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Faltan llenar campos!\r\n" + ex.Message);
                return;
            }

            MessageBox.Show("Usuario creado correctamente!");
            this.Close();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            textBox8.Text = dateTimePicker1.Value.ToString("MM/dd/yyyy");
        }

   
       
    }
}
