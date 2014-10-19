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
using FrbaHotel.Database_Helper;

namespace FrbaHotel.Views.Login
{
    public partial class SeleccionRoles : Form
    {
        //private Usuario user { get; set; }

        public SeleccionRoles()
        {
            InitializeComponent();
        }

        private void SeleccionRoles_Load(object sender, EventArgs e)
        {
            /*List<RolUsuario> roles = EntityManager.getEntityManager().findAllBy<RolUsuario>("user_id", user.id.ToString());
            if (roles.Count == 1)
            {
                this.Hide();
                new FrbaHotel.Form2().Show();
            }*/
        }
    }
}
