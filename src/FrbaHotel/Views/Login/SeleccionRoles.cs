using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using FrbaHotel;
using FrbaHotel.Homes;
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
        }

        private void SeleccionRoles_Shown(object sender, EventArgs e)
        {
            roles = EntityManager.getEntityManager().findAllBy<RolUsuario>("usuario_id", user.id.ToString());

            if (roles.Count == 0)
            {
                MessageBox.Show("Este usuario no posee roles", "Salir", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Navigator.nextForm(this,new Home());
            }

            if (roles.Count == 1)
            {
                if (roles[0].rol.estado != true)
                {
                    MessageBox.Show("El rol asociado a este usuario se encuentra inhabilitado");
                    return;
                }

                SesionActual.rol_usuario = roles[0];
                Navigator.nextForm(this,new Operaciones());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Navigator.nextForm(this,new Home());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un rol para poder ingresar.");
                return;
            }

            if ((comboBox1.SelectedValue as RolUsuario).rol.estado != true)
            {
                MessageBox.Show("El rol seleccionado se encuentra inhabilitado");
                return;
            }

            SesionActual.rol_usuario = comboBox1.SelectedValue as RolUsuario;
            Navigator.nextForm(this,new Operaciones());
        }
    }
}
