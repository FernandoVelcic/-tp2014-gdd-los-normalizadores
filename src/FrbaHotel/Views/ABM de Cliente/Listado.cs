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
    public partial class Listado : Form
    {
        public Listado()
        {
            InitializeComponent();
            setUpList();
        }


        public void setUpList()
        {
            var clientesBinding = new BindingList<Cliente>(EntityManager.findAll<Cliente>());
            dataGridView2.DataSource = new BindingSource(clientesBinding, null);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form cliente = new FrbaHotel.Views.ABM_de_Cliente.Form1();
            cliente.Show();
        }

        private List<Cliente> getClientesList()
        {
            return new List<Cliente>();
        }


    }
}
