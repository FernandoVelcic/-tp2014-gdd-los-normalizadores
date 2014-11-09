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

        public ModificarReserva(FrbaHotel.Generar_Modificar_Reserva.FormGenerarReserva formRetorno)
        {
            InitializeComponent();
            this.formRetorno = formRetorno;
        }


        private void btn_Modificar_Click(object sender, EventArgs e)
        {

            try
            {
                long codigo = Convert.ToInt64(txt_Codigo.Text);
                Reserva reserva = EntityManager.getEntityManager().findById<Reserva>(codigo);
                if (reserva == null)
                {
                    MessageBox.Show("La reserva no existe");
                    return;
                }

                this.Close();
                formRetorno.onReservaSeleccionada(reserva);
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Escriba un numero de reserva valido");
                return;
            }

        }

        private void btn_Volver_Click(object sender, EventArgs e)
        {
            this.Close();
        }



    }
}
