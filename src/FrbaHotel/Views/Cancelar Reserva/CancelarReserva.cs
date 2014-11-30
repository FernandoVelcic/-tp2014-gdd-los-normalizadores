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

using System.Data.SqlClient;
using FrbaHotel.Homes;
using FrbaHotel.Models.Exceptions;
using FrbaHotel.Models.Reservas;

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
            dateTimePicker1.Text = Config.getInstance().getCurrentDate().ToShortDateString();
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            
            Reserva reserva = EntityManager.getEntityManager().findBy<Reserva>("reservas.id", txt_NroReserva.Text);
            if (reserva == null)
            {
                MessageBox.Show("La reserva no existe");
                return;
            }

            if (reserva.reserva_estado == 6)
            {
                MessageBox.Show("No se puede cancelar una reserva ingresada");
                return;
            }
           
            DateTime fecha = DateTime.Parse(dateTimePicker1.Text);   

            if (DateTime.Compare(DateTime.Parse(reserva.fecha_inicio), fecha) < 0)
            {
                MessageBox.Show("No se puede cancelar una reserva una vez comenzada");   
                return;
            }

            List<FetchCondition> condiciones = new List<FetchCondition>();
            FetchCondition fetchCondition = new FetchCondition();
            fetchCondition.setEquals("reserva_id", reserva.id);
            condiciones.Add(fetchCondition);
            List<ReservaCancelada> viajasCancelaciones = EntityManager.getEntityManager().findList<ReservaCancelada>(condiciones);
            if (viajasCancelaciones.Count != 0)
            {
                MessageBox.Show("La reserva ya había sido cancelada anteriormente");
                return;
            }

            ReservaCancelada reservaCancelada = new ReservaCancelada();
            reservaCancelada.fecha = fecha.ToString();
            reservaCancelada.reserva = reserva;
            reservaCancelada.motivo = txt_Motivo.Text;
            reservaCancelada.usuario = txt_Usuario.Text;

            if (SesionActual.rol_usuario.rol.id == 2) //Recepcionista
                reserva.reserva_estado = 3;
            if (SesionActual.rol_usuario.rol.id == 3) //Guest
                reserva.reserva_estado = 4;
           
            try
            {
                reserva.save();
                reservaCancelada.save();
            }
            catch (ValidationException exception)
            {
                MessageBox.Show(exception.Message);
                return;
            }
            catch (SqlException exception)
            {
                MessageBox.Show(exception.Message);
                return;
            }

            MessageBox.Show("La reserva " + txt_NroReserva.Text + " fue cancelada");
            
            Close();
        }

        private void btn_Vovler_Click(object sender, EventArgs e)
        {
            Close();
        }




    }
}
