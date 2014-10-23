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
        private List<RolUsuario> roles;

        public SeleccionRoles(Usuario user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void SeleccionRoles_Load(object sender, EventArgs e)
        {
            BindingSource roles_binding = new BindingSource();
            roles_binding.DataSource = EntityManager.getEntityManager().findAll<RolUsuario>();
            comboBox1.DataSource = roles_binding;
            comboBox1.ValueMember = "";
            comboBox1.DisplayMember = "rol.descripcion";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.nextForm(new Home());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un rol para poder ingresar.");
                return;
            }

            this.nextForm(new Operaciones(comboBox1.SelectedValue as RolUsuario));
        }

        private void SeleccionRoles_Shown(object sender, EventArgs e)
        {
            roles = EntityManager.getEntityManager().findAllBy<RolUsuario>("usuario_id", user.id.ToString());

            if (roles.Count == 0)
            {
                MessageBox.Show("Este usuario no posee roles", "Salir", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.nextForm(new Home());
            }

            if (roles.Count == 1)
            {
                this.nextForm(new Operaciones(roles[0]));
            }
        }
    }
}
