using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using FrbaHotel.Tools;
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
            roles_binding.DataSource = EntityManager.findAll<Roles>();
            comboBox2.DataSource = roles_binding;
            comboBox2.DisplayMember = "Descripcion";
            comboBox2.ValueMember = "id";

            BindingSource hoteles_binding = new BindingSource();
            hoteles_binding.DataSource = EntityManager.findAll<Hoteles>();
            comboBox1.DataSource = hoteles_binding;
            comboBox1.DisplayMember = "id"; //TODO mostrar un nombre de hotel mas lindo
            comboBox1.ValueMember = "id";
        }

      
        private void button1_Click(object sender, EventArgs e)
        {
            Usuarios user = new Usuarios();
            user.username = textBox1.Text;
            user.password = new SHA256(textBox2.Text).ToString();
            user.nombre = textBox3.Text;
            user.apellido = textBox4.Text;
            user.mail = textBox5.Text;

            user.fecha_nac = dateTimePicker1.Text;

            user.intentos_fallidos = 0;
            user.estado = true;

            try
            {
                user.insert();
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
