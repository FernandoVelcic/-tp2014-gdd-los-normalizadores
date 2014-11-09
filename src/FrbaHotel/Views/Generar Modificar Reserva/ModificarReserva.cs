using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Database_Helper;
using FrbaHotel.Models;

namespace FrbaHotel.Views.Generar_Modificar_Reserva
{
    public partial class ModificarReserva : Form
    {
        private FrbaHotel.Generar_Modificar_Reserva.FormGenerarReserva formRetorno;

        public int codigo { get; set; }

        public ModificarReserva(FrbaHotel.Generar_Modificar_Reserva.FormGenerarReserva formRetorno)
        {
            InitializeComponent();
            this.formRetorno = formRetorno;
        }

        private void ModificarReserva_Load(object sender, EventArgs e)
        {
            txt_Codigo.DataBindings.Add("Text", this, "codigo");
        }


        private void btn_Modificar_Click(object sender, EventArgs e)
        {
            Reserva reserva = EntityManager.getEntityManager().findById<Reserva>(codigo);
            if (reserva == null)
            {
                MessageBox.Show("La reserva no existe");
                return;
            }

            this.Close();
            formRetorno.onReservaSeleccionada(reserva);

        }

        private void btn_Volver_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
