using FrbaHotel.Database_Helper;
using FrbaHotel.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

            var clientesBinding = new BindingList<Cliente>(EntityManager.getEntityManager().findAll<Cliente>());
            dataGridView2.DataSource = new BindingSource(clientesBinding, null);
        }

        private void button1_Click_1(object sender, EventArgs e)
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

        private void button2_Click_1(object sender, EventArgs e)
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

        private void button4_Click(object sender, EventArgs e)
        {

        }



    }
}
