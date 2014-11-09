using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel.Views.Generar_Modificar_Reserva
{
    public partial class GenerarModificarReserva : Form
    {
        public GenerarModificarReserva()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.nextForm(new FormGenerarReserva());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.nextForm(new ModificarReserva());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
