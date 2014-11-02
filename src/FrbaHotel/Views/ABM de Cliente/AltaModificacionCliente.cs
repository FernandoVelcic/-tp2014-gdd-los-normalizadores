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
            cliente.estado = true;
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

            BindingSource nacionalidad_binding = new BindingSource();
            nacionalidad_binding.DataSource = EntityManager.getEntityManager().findAll<Pais>();
            comboBox2.DataSource = nacionalidad_binding;
            comboBox2.DisplayMember = "gentilicio";
            if (!esAlta)
                comboBox2.SelectedIndex = cliente.nacionalidad_id - 1;
                //comboBox2.Text = cliente.nacionalidad.gentilicio;

            BindingSource paises_binding = new BindingSource();
            paises_binding.DataSource = EntityManager.getEntityManager().findAll<Pais>();
            comboBox4.DataSource = paises_binding;
            comboBox4.DisplayMember = "nombre";
            if (!esAlta)
                comboBox4.SelectedIndex = cliente.pais_id - 1;
                //comboBox4.Text = cliente.pais.nombre;

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

            textBox8.DataBindings.Add("Text", cliente, "documento_nro");
            comboBox1.DataBindings.Add("SelectedIndex", cliente, "estado");

            if (modoSeleccion)
            {
                comboBox1.Visible = false;
                label15.Visible = false;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {

            cliente.documento_tipo = comboBox3.SelectedValue as TipoDocumento;
            cliente.nacionalidad_id = comboBox2.SelectedIndex + 1;
            cliente.pais_id = comboBox4.SelectedIndex + 1;

            try
            {
                cliente.save();
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

            if(esAlta){
                MessageBox.Show("Cliente creado correctamente!");
            }else{
                MessageBox.Show("Cliente modificado correctamente!");
            }

            Close();

            if (modoSeleccion)
            {
                previousForm.clienteSeleccionado(cliente);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Close();
        }



        private Boolean modoSeleccion = false;
        private SeleccionCliente previousForm;
        public void setModoSeleccion(SeleccionCliente form)
        {
            modoSeleccion = true;
            previousForm = form;
        }


    }
}
