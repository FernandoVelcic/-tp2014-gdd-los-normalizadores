using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Models;
using FrbaHotel.Database_Helper;

namespace FrbaHotel.Views.ABM_de_Regimen
{
    public partial class ABMRegimen : Form
    {
        public ABMRegimen()
        {
            InitializeComponent();
        }

        private void ABMRegimen_Load(object sender, EventArgs e)
        {
            var regimennesBinding = new BindingList<Regimen>(EntityManager.getEntityManager().findAll<Regimen>());
            dataGridView1.DataSource = new BindingSource(regimennesBinding, null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new FrbaHotel.ABM_de_Regimen.AltaModificacionRegimen().Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                Regimen regimen = row.DataBoundItem as Regimen;
                new FrbaHotel.ABM_de_Regimen.AltaModificacionRegimen(regimen).Show();
            }
        }
        
        private void button3_Click_1(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("¿Esta seguro que desea borrar este registro?", "Borrar registro", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            
            if (dr == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
                {
                    Regimen regimen = row.DataBoundItem as Regimen;
                    regimen.logicalDelete();
                    //dataGridView1.Rows.RemoveAt(row.Index);
                    MessageBox.Show("Registro borrado correctamente");
                }
            }
        }

    }
}
