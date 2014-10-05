using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using FrbaHotel.Database_Helper;

namespace FrbaHotel.ABM_de_Usuario
{
    public partial class ABMUsuario : Form
    {
        public ABMUsuario()
        {
            InitializeComponent();
        }

        private void ABMUsuario_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = EntityManager.findAll<Usuarios>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new FrbaHotel.ABM_de_Usuario.AltaUsuario().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.RemoveAt(item.Index);
                //dataGridView1.Rows[item.Index];
            }
        }
    }
}
