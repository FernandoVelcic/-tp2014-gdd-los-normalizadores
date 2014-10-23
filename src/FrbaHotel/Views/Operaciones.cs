using FrbaHotel.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using FrbaHotel.Database_Helper;

namespace FrbaHotel
{
    public partial class Operaciones : Form
    {
        public Operaciones(RolUsuario rolUsuario) : this()
        {
            Rol permisos = rolUsuario.rol;
            button1.Visible = permisos.ABM_Cliente;
            button2.Visible = permisos.ABM_Habitación;
            button3.Visible = permisos.ABM_Regimen;
            button4.Visible = permisos.ABM_Rol;
            button5.Visible = permisos.Cancelar_Reserva;
            button6.Visible = permisos.Generar_Reserva;
            button7.Visible = permisos.Listado_Estadístico;
            //button8.Visible = permisos.Login;
            button9.Visible = permisos.Registrar_Consumible;
            button10.Visible = permisos.Registrar_Estadía;
            button11.Visible = permisos.ABM_Usuario;
        }

        public Operaciones()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.nextForm(new FrbaHotel.Views.ABM_de_Cliente.ABMCliente());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.nextForm(new FrbaHotel.Views.ABM_de_Habitacion.ABMHabitacion());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.nextForm(new FrbaHotel.Views.ABM_de_Regimen.ABMRegimen());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.nextForm(new FrbaHotel.Views.ABM_de_Rol.ABMRol());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.nextForm(new FrbaHotel.Cancelar_Reserva.Form1());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.nextForm(new FrbaHotel.Generar_Modificar_Reserva.Form1());
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.nextForm(new FrbaHotel.Listado_Estadistico.Form1());
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.nextForm(new FrbaHotel.Login.Login());
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.nextForm(new FrbaHotel.Registrar_Consumible.Form1());
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.nextForm(new FrbaHotel.Registrar_Estadia.Form1());
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.nextForm(new FrbaHotel.ABM_de_Usuario.ABMUsuario());
        }
    }
}
