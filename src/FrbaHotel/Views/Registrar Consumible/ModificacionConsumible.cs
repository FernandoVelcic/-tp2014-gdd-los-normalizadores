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
            
        //Modificacion de la cantidad de unidades del item seleccionado
        private void button2_Click(object sender, EventArgs e)
        {
            if (consumibleU.unidades <= 0)
            {
                MessageBox.Show("Debe ingresar cantidades positivas (Si desea borrarlo solo necesita clickear en el boton de borrado)");
                return;
            }
            consumibleU.monto = consumibleU.precio * consumibleU.unidades;
            consumibleU.consumible_estadia.unidades = consumibleU.unidades;

            MessageBox.Show("Se ha modificado la cantidad de unidades correctamente");
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

       


    }
}
