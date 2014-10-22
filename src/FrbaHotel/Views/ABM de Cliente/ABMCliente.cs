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
            comboBox2.DisplayMember = "descripcion";
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
            new FrbaHotel.Views.ABM_de_Cliente.AltaModificacionCliente().Show();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.dataGridView2.SelectedRows)
            {
                Cliente cliente = row.DataBoundItem as Cliente;
                new FrbaHotel.Views.ABM_de_Cliente.AltaModificacionCliente(cliente).Show();
            }
        }


        private void onBtnEliminar(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("¿Esta seguro que desea borrar este registro?", "Borrar registro", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

            if (dr == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in this.dataGridView2.SelectedRows)
                {
                    Cliente cliente = row.DataBoundItem as Cliente;
                    cliente.logicalDelete();
                    //dataGridView1.Rows.RemoveAt(row.Index);
                    MessageBox.Show("Registro borrado correctamente");
                }
            }
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

            Listar(condiciones);

        }



    }
}
