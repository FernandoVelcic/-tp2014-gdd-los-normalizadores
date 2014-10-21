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
        private Cliente cliente;

        public AltaModificacionCliente() : this(new Cliente())
        {
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
            comboBox3.DisplayMember = "descripcion";

            txt_Nombre.DataBindings.Add("Text", cliente, "nombre");
            txt_Apellido.DataBindings.Add("Text", cliente, "apellido");
            txt_Mail.DataBindings.Add("Text", cliente, "mail");
            txt_Calle.DataBindings.Add("Text", cliente, "dom_calle");
            dateTimePicker1.DataBindings.Add("Text", cliente, "fecha_nac", true);

            //tipo y nro doc

            //cliente.t = txt_Telefono.Text;
            //cliente. = txt_Localidad.Text;
            cliente.nacionalidad = txt_Pais.Text;
            //nacionalidad se autocompleta? hace falta ponerlo?
        }

        private void button1_Click(object sender, EventArgs e)
        {

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
