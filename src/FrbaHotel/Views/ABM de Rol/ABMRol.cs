using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;

using FrbaHotel.Models;
using FrbaHotel.Database_Helper;

using MyActiveRecord;

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
            Listar(new List<FetchCondition>());
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
            Listar(new List<FetchCondition>());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            List<FetchCondition> condiciones = new List<FetchCondition>();

            FetchCondition condicionNombre = new FetchCondition();
            condicionNombre.setLike("roles.descripcion", textBox1.Text);
            condiciones.Add(condicionNombre);

            Listar(condiciones);
        }

        private void Listar(List<FetchCondition> conditions)
        {
            try
            {
                var rolesBinding = new BindingList<Rol>(EntityManager.getEntityManager().findList<Rol>(conditions));
                dataGridView1.DataSource = new BindingSource(rolesBinding, null);
            }
            catch (SqlException e)
            {
                MessageBox.Show("Error en la query: " + Query.log.Last());
            }

        }
               
    }
}
