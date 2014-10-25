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

namespace FrbaHotel.Views.ABM_de_Rol
{
    public partial class ABMRol : Form
    {
        public ABMRol()
        {
            InitializeComponent();
        }

        private void ABMRol_Load(object sender, EventArgs e)
        {
            var rolesBinding = new BindingList<Rol>(EntityManager.getEntityManager().findAll<Rol>());
            dataGridView1.DataSource = new BindingSource(rolesBinding, null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.nextForm(new FrbaHotel.ABM_de_Rol.AltaModificacionRol());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.editRecord<Rol, FrbaHotel.ABM_de_Rol.AltaModificacionRol>(dataGridView1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.deleteRecord(dataGridView1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            var rolesBinding = new BindingList<Rol>(EntityManager.getEntityManager().findAll<Rol>());
            dataGridView1.DataSource = new BindingSource(rolesBinding, null);
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
               
    }
}
