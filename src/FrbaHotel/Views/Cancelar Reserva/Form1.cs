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

namespace FrbaHotel.Cancelar_Reserva
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

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            
            Reserva reserva = EntityManager.getEntityManager().findBy<Reserva>("codigo", txt_NroReserva.Text);
            if (reserva == null)
            {
                MessageBox.Show("La reserva no existe");
                return;
            }


        }




    }
}
