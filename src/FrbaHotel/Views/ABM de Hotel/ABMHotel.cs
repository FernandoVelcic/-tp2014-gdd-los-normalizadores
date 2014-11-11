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

namespace FrbaHotel.Views.ABM_de_Hotel
{
    public partial class ABMHotel : Form
    {
        public ABMHotel()
        {
            InitializeComponent();
        }

        private void ABMHotel_Load(object sender, EventArgs e)
        {
            Listar(new List<FetchCondition>());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Recargar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Navigator.nextForm(this, new AltaModificacionHotel(this));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Navigator.nextForm(this, new BajaHotel(dataGridView1.SelectedRows[0].DataBoundItem as Hotel));
            button4_Click(null, null);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.editRecord<Hotel, AltaModificacionHotel>(dataGridView1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            List<FetchCondition> condiciones = new List<FetchCondition>();

            if (textBox1.Text != "")
            {
                FetchCondition condicionNombre = new FetchCondition();
                condicionNombre.setLike("hoteles.nombre", textBox1.Text);
                condiciones.Add(condicionNombre);
             }

            if (textBox3.Text != "")
            {
                FetchCondition condicionCiudad = new FetchCondition();
                condicionCiudad.setLike("hoteles.ciudad", textBox3.Text);
                condiciones.Add(condicionCiudad);
            }

            if (textBox4.Text != "")
            {
                FetchCondition condicionPais = new FetchCondition();
                condicionPais.setLike("hoteles.pais", textBox4.Text);
                condiciones.Add(condicionPais);
            }

            if (textBox2.Text != "")
            {
                FetchCondition condicionEstrellas = new FetchCondition();
                condicionEstrellas.setLike("hoteles.cant_estrella", textBox2.Text);
                condiciones.Add(condicionEstrellas);
            }
            Listar(condiciones);
        }

        private void Listar(List<FetchCondition> conditions)
        {
            try
            {
                var hotelesBinding = new BindingList<Hotel>(EntityManager.getEntityManager().findList<Hotel>(conditions));
                dataGridView1.DataSource = new BindingSource(hotelesBinding, null);
            }
            catch (SqlException e)
            {
                MessageBox.Show("Error en la query: " + Query.log.Last());
            }

        }

        public void Recargar()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";

            Listar(new List<FetchCondition>());
        }
       
    }
}
