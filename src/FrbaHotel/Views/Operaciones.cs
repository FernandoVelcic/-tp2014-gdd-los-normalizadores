using FrbaHotel.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using FrbaHotel.Homes;
using FrbaHotel.Database_Helper;

namespace FrbaHotel
{
    public partial class Operaciones : Form
    {
        private Rol permisos;

        public Operaciones(RolUsuario rolUsuario)
        {
            SesionActual.rol_usuario = rolUsuario;
            permisos = rolUsuario.rol;

            InitializeComponent();
            determinarPermisos();
            button8.Text = "Cerrar Sesion";
            label1.Text = "Usted se encuentra logeado como " + rolUsuario.ToString();
        }

        public Operaciones()
        {
            Rol GuestRol = EntityManager.getEntityManager().findById<Rol>(3); //Buscar rol guest
            RolUsuario GuestRolUsuario = new RolUsuario();
            GuestRolUsuario.rol = GuestRol;
            SesionActual.rol_usuario = GuestRolUsuario;
            permisos = GuestRol;

            InitializeComponent();
            //determinarPermisos();
        }


        private void Operaciones_Shown(object sender, EventArgs e)
        {
            if (permisos.id == 3 && permisos.estado == false) //Guests deshabilitados
            {
                this.nextForm(new Home());
                MessageBox.Show("En este momento los guests no pueden acceder al sistema. Por favor intente mas tarde.");
            }
        }

        public void determinarPermisos()
        {
            button1.Visible = permisos.ABM_Cliente;
            button2.Visible = permisos.ABM_Habitación;
            button3.Visible = permisos.ABM_Regimen;
            button4.Visible = permisos.ABM_Rol;
            button5.Visible = permisos.Cancelar_Reserva;
            button6.Visible = permisos.Generar_Reserva;
            button7.Visible = permisos.Listado_Estadístico;
            //button8.Visible Volver a pantalla principal
            button9.Visible = permisos.Registrar_Consumible;
            button10.Visible = permisos.Registrar_Estadía;
            button11.Visible = permisos.ABM_Usuario;
            button12.Visible = permisos.ABM_Hotel;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Navigator.nextForm(this, new FrbaHotel.Views.ABM_de_Cliente.ABMCliente());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Navigator.nextForm(this, new FrbaHotel.Views.ABM_de_Habitacion.ABMHabitacion());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Navigator.nextForm(this, new FrbaHotel.Views.ABM_de_Regimen.ABMRegimen());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Navigator.nextForm(this, new FrbaHotel.Views.ABM_de_Rol.ABMRol());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Navigator.nextForm(this, new FrbaHotel.Cancelar_Reserva.Form1());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Navigator.nextForm(this, new FrbaHotel.Generar_Modificar_Reserva.Form1());
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Navigator.nextForm(this, new FrbaHotel.Listado_Estadistico.Form1());
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Navigator.nextForm(this, new FrbaHotel.Home());
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Navigator.nextForm(this, new FrbaHotel.Registrar_Consumible.Form1());
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Navigator.nextForm(this, new FrbaHotel.Registrar_Estadia.Form1());
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Navigator.nextForm(this, new FrbaHotel.ABM_de_Usuario.ABMUsuario());
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Navigator.nextForm(this, new FrbaHotel.Views.ABM_de_Hotel.ABMHotel());
        }
    }
}
