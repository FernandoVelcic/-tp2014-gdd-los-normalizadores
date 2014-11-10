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
        public ConsumibleItemsUnidades consumibleU { get; set; }

        public ModificacionConsumible(ConsumibleItemsUnidades item)
        {
            consumibleU = item;
            InitializeComponent();
        }

        private void ModificacionConsumible_Load(object sender, EventArgs e)
        {
            label2.DataBindings.Add("Text", consumibleU, "descripcion");
            txt_Unidades.DataBindings.Add("Text", consumibleU, "unidades");
        }
            

        private void button2_Click(object sender, EventArgs e)
        {

           /* 
            ItemFactura consumibleEstadia = EntityManager.getEntityManager().findBy<ItemFactura>("codigo", consumibleU.codigo.ToString());
           
            if(textBox1.Text != null)
            {
                consumibleEstadia.unidades = int.Parse(textBox1.Text);
                consumibleEstadia.monto = consumibleEstadia.consumible.precio * consumibleEstadia.unidades;
                
                Close();
            }*/
            MessageBox.Show("Se ha modificado la cantidad de unidades correctamente");
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

       


    }
}
