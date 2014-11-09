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
        public int codigo { get; set; }

        public ModificarReserva()
        {
            InitializeComponent();
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

            if (DateTime.Parse(reserva.fecha_inicio) < Config.getInstance().getCurrentDate().Date)
            {
                MessageBox.Show("No se puede modificar reservas en fechas anteriores a la actual");
                return;
            }

            if (reserva.estaCancelada())
            {
                MessageBox.Show("No se puede modificar una reserva ya cancelada");
                return;
            }

            if (reserva.reserva_estado == 6)
            {
                MessageBox.Show("No se puede modificar una reserva despues de haber hecho el check-in");
                return;
            }

            this.nextForm(new Generar_Modificar_Reserva.FormGenerarReserva(reserva));
        }

        private void btn_Volver_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
