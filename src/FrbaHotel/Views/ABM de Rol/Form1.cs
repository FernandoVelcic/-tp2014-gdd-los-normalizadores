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



namespace FrbaHotel.ABM_de_Rol
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Rol rol = new Rol();
            
            rol.descripcion=textBox1.Text;
            if (radioButton1.Checked) rol.estado = true;
            if (radioButton2.Checked) rol.estado = false;
            //Falta saber como quieren que se guarde el listado de cada rol
            CheckedListBox.CheckedItemCollection listaSeleccionados = checkedListBox1.CheckedItems;
            try
            {
                rol.insert();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Faltan llenar campos!\r\n" + ex.Message);
                return;
            }

            MessageBox.Show("Rol creado correctamente!");
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

             

       
    }
}
