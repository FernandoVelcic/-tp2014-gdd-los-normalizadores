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
using System.Data.SqlClient;

namespace FrbaHotel.Registrar_Estadia
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
        }


        private void onCheckIn(object sender, EventArgs e)
        {
            try
            {
                recopilarDatos("checkIn");

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
                recopilarDatos("checkOut");
            }
            catch (ValidationException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }



        public void recopilarDatos(String operacion)
        {

            try
            {
                int nroReserva = int.Parse(txt_NroReserva.Text); 
                Reserva reserva = EntityManager.getEntityManager().findBy<Reserva>("reservas.id", nroReserva.ToString());
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

            if(operacion=="checkIn"){
                int nroReserva1 = int.Parse(txt_NroReserva.Text);
                Reserva reservain = EntityManager.getEntityManager().findBy<Reserva>("reservas.id", nroReserva1.ToString());
                reservain.reserva_estado = 6;
                try
                {
                    reservain.save();
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
               MessageBox.Show("La estadía ha sido validada");
               // Navigator.nextForm(this, new FrbaHotel.Registrar_Estadia.Ingreso(reservain)); //no se como ponerlo
            }
            else if(operacion=="checkOut") {
                int nroReserva1 = int.Parse(txt_NroReserva.Text);
                Reserva reservaout = EntityManager.getEntityManager().findBy<Reserva>("reservas.id", nroReserva1.ToString());
                Navigator.nextForm(this, new FrbaHotel.Registrar_Consumible.Form1(reservaout.regimen));
            }
            
        }
    }
}
