using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using FrbaHotel;
using FrbaHotel.Models;
using FrbaHotel.Homes;
using FrbaHotel.Database_Helper;

namespace FrbaHotel
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Navigator.nextForm(this,new FrbaHotel.Login.Login());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Rol GuestRol = EntityManager.getEntityManager().findById<Rol>(3); //Buscar rol guest
            RolUsuario GuestRolUsuario = new RolUsuario();
            GuestRolUsuario.rol = GuestRol;
            SesionActual.rol_usuario = GuestRolUsuario;

            Navigator.nextForm(this,new FrbaHotel.Operaciones());
        }
    }
}
