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
    public partial class Operaciones : Form
    {
        public Operaciones()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form cliente = new FrbaHotel.Views.ABM_de_Cliente.Listado();
            cliente.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form habit = new FrbaHotel.Views.ABM_de_Habitacion.ABMHabitacion();
            habit.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form regimen = new FrbaHotel.Views.ABM_de_Regimen.ABMRegimen();
            regimen.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form rol = new FrbaHotel.Views.ABM_de_Rol.ABMRol();
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
            Form login = new FrbaHotel.Login.Login();
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
            new FrbaHotel.ABM_de_Usuario.ABMUsuario().Show();
        }

      
    }
}
