using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using FrbaHotel.Tools;
using FrbaHotel.Models;
using FrbaHotel.Database_Helper;

namespace FrbaHotel.ABM_de_Usuario
{
    public partial class AltaUsuario : Form
    {
        public AltaUsuario()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BindingSource roles_binding = new BindingSource();
            roles_binding.DataSource = EntityManager.getEntityManager().findAll<Rol>();
            checkedListBox1.DataSource = roles_binding;
            checkedListBox1.DisplayMember = "descripcion";

            BindingSource hoteles_binding = new BindingSource();
            hoteles_binding.DataSource = EntityManager.getEntityManager().findAll<Hotel>();
            comboBox1.DataSource = hoteles_binding;
            comboBox1.DisplayMember = "id"; //TODO mostrar un nombre de hotel mas lindo

            BindingSource documentos_binding = new BindingSource();
            documentos_binding.DataSource = EntityManager.getEntityManager().findAll<TipoDocumento>();
            comboBox3.DataSource = documentos_binding;
            comboBox3.DisplayMember = "descripcion";
        }

      
        private void button1_Click(object sender, EventArgs e)
        {
            if (checkedListBox1.CheckedItems.Count == 0)
            {
                MessageBox.Show("Debe seleccionar al menos un rol");
                return;
            }
            Usuario user = new Usuario();
            user.username = textBox1.Text;
            user.password = new SHA256(textBox2.Text).ToString();
            user.nombre = textBox3.Text;
            user.apellido = textBox4.Text;
            user.mail = textBox5.Text;
            user.telefono = textBox6.Text;
            user.direccion = textBox7.Text;

            user.hotel = comboBox1.SelectedValue as Hotel;

            user.documento_tipo = comboBox3.SelectedValue as TipoDocumento;
            user.documento_nro = long.Parse(textBox8.Text);

            user.fecha_nac = dateTimePicker1.Text;

            user.intentos_fallidos = 0;
            user.estado = true;

            try
            {
                user.insert();
                
                foreach(Rol rol in checkedListBox1.CheckedItems)
                {
                    RolUsuario rolUsuario = new RolUsuario();
                    rolUsuario.rol = rol;
                    rolUsuario.usuario = user;
                    rolUsuario.insert();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Faltan llenar campos!\r\n" + ex.Message);
                return;
            }

            MessageBox.Show("Usuario creado correctamente!");
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }


       
    }
}
