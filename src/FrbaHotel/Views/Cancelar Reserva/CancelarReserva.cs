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
using FrbaHotel.Models.Exceptions;


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
           
            DateTime fecha= DateTime.Parse(dateTimePicker1.Text);   

            if (DateTime.Compare(reserva.fecha_inicio, fecha) < 0)
            {
                MessageBox.Show("No se puede cancelar una reserva una vez comenzada");   
                return;
            }
            reserva.fecha_cancelacion = fecha;
            reserva.motivo_cancelacion = txt_Motivo.Text;
            reserva.usuario_cancelacion = txt_Usuario.Text;
            //if (rol_usuario == "Recepcionista") reserva.reserva_estado = 3;//fer completa
            //if (rol_usuario == "Guest") reserva.reserva_estado = 4;       //fer completa            
            try
            {
                reserva.save();

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

            
            MessageBox.Show("La reserva fue cancelada");
            
            Close();
        }

        private void btn_Vovler_Click(object sender, EventArgs e)
        {
            Close();
        }




    }
}
