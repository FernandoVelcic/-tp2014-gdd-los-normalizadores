using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form cliente = new FrbaHotel.ABM_de_Cliente.Form1();
            cliente.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form habit = new FrbaHotel.ABM_de_Habitacion.Form1();
            habit.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form regimen = new FrbaHotel.ABM_de_Regimen.Form1();
            regimen.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form rol = new FrbaHotel.ABM_de_Rol.Form1();
            rol.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form cancreser = new FrbaHotel.Cancelar_Reserva.Form1();
            cancreser.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form reser = new FrbaHotel.Generar_Modificar_Reserva.Form1();
            reser.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form listado = new FrbaHotel.Listado_Estadistico.Form1();
            listado.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form login = new FrbaHotel.Login.Form1();
            login.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form consumible = new FrbaHotel.Registrar_Consumible.Form1();
            consumible.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form estadia = new FrbaHotel.Registrar_Estadia.Form1();
            estadia.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Form user = new FrbaHotel.ABM_de_Usuario.Form1();
            user.Show();
        }

      
    }
}
