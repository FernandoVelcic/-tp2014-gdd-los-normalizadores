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
using FrbaHotel.Models.Exceptions;
using FrbaHotel.Models;

namespace FrbaHotel.Registrar_Estadia
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
        }


        private void onCheckIn(object sender, EventArgs e)
        {
            try
            {
                recopilarDatos();
            }
            catch (ValidationException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void onCheckout(object sender, EventArgs e)
        {
            try
            {
                recopilarDatos();
            }
            catch (ValidationException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        public void recopilarDatos()
        {

            try
            {
                int nroReserva = int.Parse(txt_NroReserva.Text); 
                Reserva reserva = EntityManager.getEntityManager().findBy<Reserva>("reservas.codigo", nroReserva.ToString());
            }
            catch (FormatException e)
            {
                throw new ValidationException("Por favor, seleccione un numero de reserva valida.");
            }
            catch (NullReferenceException ex)
            {
                throw new ValidationException("La reserva seleccionada no existe");
            }
           
            DateTime fecha = datepicker.Value;

            /* Porque se usa el usuario? */
            string usuario = txt_Usuario.Text;
        }



        void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            switch (e.CloseReason)  //la opcion de cierre que suceda, aunque podria ser default
            {
                case CloseReason.ApplicationExitCall:
                    break;
                case CloseReason.FormOwnerClosing:
                    break;
                case CloseReason.MdiFormClosing:
                    break;
                case CloseReason.None:
                    break;
                case CloseReason.TaskManagerClosing:
                    break;
                case CloseReason.UserClosing:
                    //this.nextform….               
                    break;
                case CloseReason.WindowsShutDown:
                    break;
                default:
                    break;
            }


        }
        
    }
}
