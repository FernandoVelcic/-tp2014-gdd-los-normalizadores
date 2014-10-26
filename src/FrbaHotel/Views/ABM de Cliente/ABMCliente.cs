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
        public ABMCliente()
        {
            InitializeComponent();
        }

        private void ABMCliente_Load(object sender, EventArgs e)
        {
            BindingSource documentos_binding = new BindingSource();
            documentos_binding.DataSource = EntityManager.getEntityManager().findAll<TipoDocumento>();
            comboBox2.DataSource = documentos_binding;
            comboBox2.Text = "";
            Listar(new List<FetchCondition>());
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

        private void onBtnAlta(object sender, EventArgs e)
        {
            this.nextForm(new FrbaHotel.Views.ABM_de_Cliente.AltaModificacionCliente());
        }


        private void button3_Click(object sender, EventArgs e)
        {
            this.editRecord<Cliente, AltaModificacionCliente>(dataGridView2);
        }


        private void onBtnEliminar(object sender, EventArgs e)
        {
            this.deleteRecord(dataGridView2);
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

        }

        private void button4_Click(object sender, EventArgs e)
        {
            txt_Filtro_Nombre.Text = "";
            txt_Filter_Mail.Text = "";
            txt_Filter_Documento.Text = "";
            txt_Filter_Apellido.Text = "";
            comboBox2.SelectedIndex = -1;
            dataGridView2.Rows.Clear();
            //Data binding (cargar en el data todos los registros)
        }



    }
}
