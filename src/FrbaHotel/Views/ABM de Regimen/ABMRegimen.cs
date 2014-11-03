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
            Navigator.nextForm(this,new FrbaHotel.ABM_de_Regimen.AltaModificacionRegimen());
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.editRecord<Regimen, FrbaHotel.ABM_de_Regimen.AltaModificacionRegimen>(dataGridView1);
        }
        
        private void button3_Click_1(object sender, EventArgs e)
        {
            this.deleteRecord(dataGridView1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text= "";
            textBox3.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            dataGridView1.Rows.Clear();
            //Data binding (cargar en el data todos los registros)
        }

    }
}
