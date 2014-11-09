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

namespace FrbaHotel.Registrar_Consumible
{
    public partial class ModificacionConsumible : Form
    {
        ConsumibleItemsUnidades consumibleU;

        public ModificacionConsumible( ConsumibleItemsUnidades consu)
        {
            consumibleU = consu;
            InitializeComponent();
        }

        private void ModificacionConsumible_Load(object sender, EventArgs e)
        {
            label1.Text = consumibleU.descripcion;
        }
            

        private void button2_Click(object sender, EventArgs e)
        {
            
            ItemFactura consumibleEstadia = EntityManager.getEntityManager().findBy<ItemFactura>("codigo", consumibleU.codigo.ToString());
           
            if(textBox1.Text != null)
            {
                consumibleEstadia.unidades = int.Parse(textBox1.Text);
                consumibleEstadia.monto = consumibleEstadia.consumible.precio * consumibleEstadia.unidades;
                consumibleEstadia.save();
                Close();
            }
            MessageBox.Show("No ha ingresado las unidades a modificar");
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }


    }
}
