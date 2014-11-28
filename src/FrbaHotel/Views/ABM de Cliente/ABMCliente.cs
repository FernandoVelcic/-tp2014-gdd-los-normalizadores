using FrbaHotel.Database_Helper;
using FrbaHotel.Models;
using MyActiveRecord;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel.Views.ABM_de_Cliente
{
    public partial class ABMCliente : Form
    {
        int offset = 1000;
        int inicio=0;
        int final=0;
        public ABMCliente()
        {
            InitializeComponent();
        }

        private void ABMCliente_Load(object sender, EventArgs e)
        {
            final = offset;
            BindingSource documentos_binding = new BindingSource();
            documentos_binding.DataSource = EntityManager.getEntityManager().findAll<TipoDocumento>();
            comboBox2.DataSource = documentos_binding;
            comboBox2.Text = "";
            Paginar();
            btn_Seleccionar.Hide();
        }

        private void Paginar()
        {
            List<FetchCondition> condiciones = new List<FetchCondition>();
            FetchCondition condicionPaginacion = new FetchCondition();
            condicionPaginacion.setBetween("clientes.id", inicio.ToString(), final.ToString());
            condiciones.Add(condicionPaginacion);
            Listar(new List<FetchCondition>(condiciones));
        }

        private void Listar(List<FetchCondition> conditions)
        {
            try
            {
                var clientesBinding = new BindingList<Cliente>(EntityManager.getEntityManager().findList<Cliente>(conditions));
                dataGridView2.DataSource = new BindingSource(clientesBinding, null);
            }
            catch (SqlException e)
            {
                MessageBox.Show("Error en la query: " + Query.log.Last());
            }
            
        }

        public void Recargar()
        {
            txt_Filtro_Nombre.Text = "";
            txt_Filter_Mail.Text = "";
            txt_Filter_Documento.Text = "";
            txt_Filter_Apellido.Text = "";
            button1.Show();
            button2.Show();
            comboBox2.SelectedIndex = 0;
            inicio = 0;
            final = offset;
            Paginar();
        }

        private void onBtnAlta(object sender, EventArgs e)
        {
            Navigator.nextForm(this,new FrbaHotel.Views.ABM_de_Cliente.AltaModificacionCliente(this));
        }


        private void button3_Click(object sender, EventArgs e)
        {
            this.editRecord<Cliente, AltaModificacionCliente>(dataGridView2);
        }


        private void onBtnEliminar(object sender, EventArgs e)
        {
            this.deleteRecord(dataGridView2);
            onBtnFiltrar(null, null);
        }

        private void onBtnFiltrar(object sender, EventArgs e)
        {

            List<FetchCondition> condiciones = new List<FetchCondition>();

            FetchCondition condicionNombre = new FetchCondition();
            condicionNombre.setLike("clientes.nombre", txt_Filtro_Nombre.Text);
            condiciones.Add(condicionNombre);

            FetchCondition condicionApellido = new FetchCondition();
            condicionApellido.setLike("clientes.apellido", txt_Filter_Apellido.Text);
            condiciones.Add(condicionApellido);

            FetchCondition condicionMail = new FetchCondition();
            condicionMail.setLike("clientes.mail", txt_Filter_Mail.Text);
            condiciones.Add(condicionMail);

            FetchCondition condicionIdentificacion = new FetchCondition();
            condicionIdentificacion.setLike("clientes.documento_nro", txt_Filter_Documento.Text);
            condiciones.Add(condicionIdentificacion);

            if (comboBox2.Text != "")
            {
                FetchCondition condicionTipoIdentificacion = new FetchCondition();
                condicionTipoIdentificacion.setEquals("clientes.documento_tipo_id", (comboBox2.SelectedValue as TipoDocumento).id.ToString());
                condiciones.Add(condicionTipoIdentificacion);
            }

            Listar(condiciones);
            button1.Hide();
            button2.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Recargar();
        }



        /* Usado para la seleccion de cliente en la reserva */
        private SeleccionCliente previousForm;
        public void setModoSeleccionCliente(SeleccionCliente form) 
        {
            btn_AltaDeCliente.Hide();
            btn_EliminarCliente.Hide();
            btn_ModificarCliente.Hide();
            previousForm = form;
            btn_Seleccionar.Show();
        }

        private void btn_Seleccionar_Click(object sender, EventArgs e)
        {
            Cliente cliente = dataGridView2.SelectedRows[0].DataBoundItem as Cliente;
            previousForm.clienteSeleccionado(cliente);
            this.Close();
        }


        private void ABMCliente_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(inicio!=0)
            {
                inicio = inicio - offset;
                final = final - offset;
                Paginar();
            }
            else
            {
                MessageBox.Show("Se encuentra al inicio de la lista de clientes");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            inicio = inicio + offset;
            final = final + offset;
            Paginar();
        }


    }
}
