using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel;
using FrbaHotel.Database_Helper;

namespace FrbaHotel.Registrar_Estadia
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // this.nextForm(new Registrar_Estadia();   //completar con ingreso
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //validar si existe la reserva, mostrar mensajito y cerrar
        }

      

        
    }
}
