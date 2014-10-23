using FrbaHotel.Models;
using FrbaHotel.Models.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using FrbaHotel.Database_Helper;

namespace FrbaHotel.Views.ABM_de_Cliente
{
    public partial class AltaModificacionCliente : Form
    {
        private bool esAlta = false;
        private Cliente cliente;

        public AltaModificacionCliente() : this(new Cliente())
        {
            esAlta = true;
            cliente.fecha_nac = DateTime.Today.ToString();
        }

        public AltaModificacionCliente(Cliente cliente)
        {
            InitializeComponent();
            this.cliente = cliente;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            BindingSource documentos_binding = new BindingSource();
            documentos_binding.DataSource = EntityManager.getEntityManager().findAll<TipoDocumento>();
            comboBox3.DataSource = documentos_binding;
            if(!esAlta)
                comboBox3.Text = cliente.documento_tipo.descripcion;

            txt_Nombre.DataBindings.Add("Text", cliente, "nombre");
            txt_Apellido.DataBindings.Add("Text", cliente, "apellido");
            txt_Mail.DataBindings.Add("Text", cliente, "mail");
            dateTimePicker1.DataBindings.Add("Text", cliente, "fecha_nac", true);
            txt_Telefono.DataBindings.Add("Text", cliente, "telefono");

            txt_Calle.DataBindings.Add("Text", cliente, "dom_calle");
            textBox1.DataBindings.Add("Text", cliente, "nro_calle");
            textBox2.DataBindings.Add("Text", cliente, "piso");
            textBox3.DataBindings.Add("Text", cliente, "depto");

            txt_Localidad.DataBindings.Add("Text", cliente, "localidad");
            txt_Pais.DataBindings.Add("Text", cliente, "nacionalidad");

            textBox8.DataBindings.Add("Text", cliente, "documento_nro");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cliente.documento_tipo = comboBox3.SelectedValue as TipoDocumento;

            try
            {
                cliente.save();
                MessageBox.Show("El cliente se guardo correctamente");
                this.Close();
            }
            catch (ValidationException exception)
            {
                MessageBox.Show(exception.Message);
            }
            catch (SqlException exception)
            {
                MessageBox.Show(exception.Message);
            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
