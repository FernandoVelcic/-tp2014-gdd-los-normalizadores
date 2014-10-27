using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;

using FrbaHotel.Tools;
using FrbaHotel.Models;
using FrbaHotel.Database_Helper;
using FrbaHotel.Models.Exceptions;

namespace FrbaHotel.ABM_de_Usuario
{
    public partial class AltaModificaiconUsuario : Form
    {
        private bool esAlta = false;
        private Usuario usuario;

        public AltaModificaiconUsuario() : this(new Usuario())
        {
            esAlta = true;
            usuario.intentos_fallidos = 0;
            usuario.estado = true;
            usuario.fecha_nac = DateTime.Today.ToString();
        }

        public AltaModificaiconUsuario(Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BindingSource roles_binding = new BindingSource();
            roles_binding.DataSource = EntityManager.getEntityManager().findAll<Rol>();
            this.Rol.DataSource = roles_binding;
            this.Rol.DisplayMember = "descripcion";

            BindingSource hoteles_binding = new BindingSource();
            hoteles_binding.DataSource = EntityManager.getEntityManager().findAll<Hotel>();
            this.Hotel.DataSource = hoteles_binding;
            this.Hotel.DisplayMember = "calle";
            
            BindingSource documentos_binding = new BindingSource();
            documentos_binding.DataSource = EntityManager.getEntityManager().findAll<TipoDocumento>();
            comboBox3.DataSource = documentos_binding;
            comboBox3.DisplayMember = "descripcion";

            textBox1.DataBindings.Add("Text", usuario, "username");
            textBox3.DataBindings.Add("Text", usuario, "nombre");
            textBox8.DataBindings.Add("Text", usuario, "documento_nro");
            textBox4.DataBindings.Add("Text", usuario, "apellido");
            textBox5.DataBindings.Add("Text", usuario, "mail");
            textBox6.DataBindings.Add("Text", usuario, "telefono");
            textBox7.DataBindings.Add("Text", usuario, "direccion");
            dateTimePicker1.DataBindings.Add("Text", usuario, "fecha_nac", true);
            comboBox2.DataBindings.Add("SelectedIndex", usuario, "estado");
        }

      
        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 1)
            {
                MessageBox.Show("Debe seleccionar al menos un rol para algun hotel");
                return;
            }
            
            //Bindings especiales
            usuario.password = new SHA256(textBox2.Text).ToString();
            usuario.documento_tipo = comboBox3.SelectedValue as TipoDocumento;

            try
            {
                usuario.save();
                
                /*foreach(Rol rol in checkedListBox1.CheckedItems)
                {
                    RolUsuario rolUsuario = new RolUsuario();
                    rolUsuario.rol = rol;
                    rolUsuario.usuario = usuario;
                    rolUsuario.insert();
                }*/
            }
            catch (ValidationException exception)
            {
                MessageBox.Show(exception.Message);
                return;
            }
            catch (SqlException exception)
            {
                MessageBox.Show(exception.Message);
                return;
            }

            if(esAlta)
                MessageBox.Show("Usuario creado correctamente!");
            else
                MessageBox.Show("Usuario modificado correctamente!");

            this.nextForm(new ABMUsuario());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.nextForm(new ABMUsuario());
        }
    }
}
