using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;

using FrbaHotel.Homes;
using FrbaHotel.Models;
using FrbaHotel.Database_Helper;

using MyActiveRecord;

namespace FrbaHotel.ABM_de_Usuario
{
    public partial class ABMUsuario : Form
    {
        public ABMUsuario()
        {
            InitializeComponent();
        }

        private void ABMUsuario_Load(object sender, EventArgs e)
        {
            BindingSource documentos_binding = new BindingSource();
            documentos_binding.DataSource = EntityManager.getEntityManager().findAll<TipoDocumento>();
            comboBox1.DataSource = documentos_binding;
            comboBox1.Text = "";
            Listar(new List<FetchCondition>());
        }

        private void Listar(List<FetchCondition> conditions)
        {
            try
            {
                var usuarios_binding = new BindingList<Usuario>(EntityManager.getEntityManager().findList<Usuario>(conditions));
                dataGridView1.DataSource = new BindingSource(usuarios_binding, null);
            }
            catch (SqlException e)
            {
                MessageBox.Show("Error en la query: " + Query.log.Last());
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            Navigator.nextForm(this,new FrbaHotel.ABM_de_Usuario.AltaModificaiconUsuario());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<RolUsuario> roles = (dataGridView1.SelectedRows[0].DataBoundItem as Usuario).getRoles();
            if( !roles.Any(r => r.hotel.id == SesionActual.rol_usuario.hotel.id) ) {
                MessageBox.Show("No se puede eliminar un usuario si no trabaja en el mismo hotel que el Administrador");
                return;
            }
            this.deleteRecord(dataGridView1);
            button4_Click(null, null);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<RolUsuario> roles = (dataGridView1.SelectedRows[0].DataBoundItem as Usuario).getRoles();
            if (!roles.Any(r => r.hotel.id == SesionActual.rol_usuario.hotel.id))
            {
                MessageBox.Show("No se puede modificar un usuario si no trabaja en el mismo hotel que el Administrador");
                return;
            }
            this.editRecord<Usuario, FrbaHotel.ABM_de_Usuario.AltaModificaiconUsuario>(dataGridView1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox8.Text = "";
            comboBox1.SelectedIndex = -1;

            Listar(new List<FetchCondition>());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            List<FetchCondition> condiciones = new List<FetchCondition>();

            FetchCondition condicionUsername = new FetchCondition();
            condicionUsername.setLike("usuarios.username", textBox1.Text);
            condiciones.Add(condicionUsername);

            FetchCondition condicionNombre = new FetchCondition();
            condicionNombre.setLike("usuarios.nombre", textBox2.Text);
            condiciones.Add(condicionNombre);

            FetchCondition condicionApellido = new FetchCondition();
            condicionApellido.setLike("usuarios.apellido", textBox3.Text);
            condiciones.Add(condicionApellido);

            FetchCondition condicionMail = new FetchCondition();
            condicionMail.setLike("usuarios.mail", textBox8.Text);
            condiciones.Add(condicionMail);

            FetchCondition condicionIdentificacion = new FetchCondition();
            condicionIdentificacion.setLike("usuarios.documento_nro", textBox4.Text);
            condiciones.Add(condicionIdentificacion);

            if (comboBox1.Text != "")
            {
                FetchCondition condicionTipoIdentificacion = new FetchCondition();
                condicionTipoIdentificacion.setEquals("usuarios.documento_tipo_id", (comboBox1.SelectedValue as TipoDocumento).id.ToString());
                condiciones.Add(condicionTipoIdentificacion);
            }

            Listar(condiciones);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        
    }
}
