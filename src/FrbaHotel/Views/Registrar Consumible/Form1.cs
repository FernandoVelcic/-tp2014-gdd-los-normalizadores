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

namespace FrbaHotel.Registrar_Consumible
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           var consumiblesBinding = new BindingList<Consumible>(EntityManager.getEntityManager().findAll<Consumible>());
            dataGridView1.DataSource = new BindingSource(consumiblesBinding, null);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btn_Volver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //modificar el que esta seleccionado en el datagrid
        }

        private void btn_Agregar_Click(object sender, EventArgs e)
        {
           //cargar los datos en la reserva que tiene que venir como parametro desde el checkout
            string descripcion = textBox2.Text;
            double precio = Double.Parse(textBox3.Text);
            int unidades = int.Parse(textBox4.Text);    //chequear si va, para mi deberia, pero en la tabla no está
         }

       

       


    }
}
