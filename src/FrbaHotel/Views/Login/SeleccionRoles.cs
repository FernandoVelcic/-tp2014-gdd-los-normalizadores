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
        private Usuario user;

        public SeleccionRoles(Usuario user)
        {
            this.user = user;
            InitializeComponent();
        }

        private void SeleccionRoles_Load(object sender, EventArgs e)
        {
            List<RolUsuario> roles = EntityManager.getEntityManager().findAllBy<RolUsuario>("user_id", user.id.ToString());

            if (roles.Count == 0)
            {
                MessageBox.Show("Este usuario no posee roles", "Salir", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //TODO: Ir a home y cerrar
                return;
            }
            
            if (roles.Count == 1)
            {
                this.Hide();
                new FrbaHotel.Operaciones().Show();
            }

            BindingSource roles_binding = new BindingSource();
            roles_binding.DataSource = EntityManager.getEntityManager().findAll<RolUsuario>();
            comboBox1.DataSource = roles_binding;
            //comboBox1.DisplayMember = "descripcion";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Home().Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un rol para poder ingresar.");
                return;
            }
            new Operaciones().Show();
        }
    }
}
