﻿using System;
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
using FrbaHotel.Views.Registrar_Estadia;
using FrbaHotel.Homes;
using MyActiveRecord;

namespace FrbaHotel.Registrar_Estadia
{
    public partial class Form1 : Form
    {
        public int reserva_numero { get; set; }
        public String fecha { get; set; }
        public String usuario { get; set; }

        Reserva reserva;

        public Form1()
        {
            InitializeComponent();
            fecha = Config.getInstance().getCurrentDate().ToShortDateString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Bindeo del nro de reserva, fecha, y usuario
            txt_NroReserva.DataBindings.Add("Text", this, "reserva_numero");
            dateTimePicker1.DataBindings.Add("Text", this, "fecha", true);
            txt_Usuario.DataBindings.Add("Text", this, "usuario");
        }

        //CHECK-IN
        private void onCheckIn(object sender, EventArgs e)
        {   //Validacion de que exista la reserva
            if (!obtenerReserva())
                return;

            Estadia es = EntityManager.getEntityManager().findBy<Estadia>("reserva_id", reserva.id.ToString());
            //Validacion de que no se haya hecho el ingreso antes
            if (es != null)
            {
                MessageBox.Show("La estadia ya ha sido validada con anteriodad");
                return;
            }

            //Comparacion de fechas, unicamente se puede ingresar el dia en que se reservo
            if (DateTime.Compare(DateTime.Parse(fecha).Date, DateTime.Parse(reserva.fecha_inicio).Date) == 0)
            {
                reserva.reserva_estado = 6;
                //reserva.fecha_cancelacion = "";

                Estadia estadia = new Estadia();
                estadia.fecha_inicio = fecha;
                estadia.reserva = reserva;

                try
                {
                    reserva.save();
                    estadia.save();
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
                Navigator.nextForm(this, new FrbaHotel.Views.Registrar_Estadia.Ingreso(estadia));
            }
            else if (DateTime.Compare(DateTime.Parse(fecha).Date, DateTime.Parse(reserva.fecha_inicio).Date) != 0)
            {
                MessageBox.Show("La fecha ingresada no es igual a la reservada");
            }
        }

        //CHECK-OUT
        private void onCheckout(object sender, EventArgs e)
        {
            if (!obtenerReserva())
                return;

            Estadia estadiaout = EntityManager.getEntityManager().findBy<Estadia>("estadias.reserva_id", reserva_numero.ToString());

            if (estadiaout == null)
            {
                MessageBox.Show("Primero debe hacer el check-in");
                return;
            }

            //Validacion de que la salida no se haya hecho antes
            if (estadiaout.cant_noches != 0)
            {
                MessageBox.Show("La estadia ya ha sido efectivizada con anterioridad");
                return;
            }

            //Calculo de la cantidad de noches que se hospedo
            int dias_desde_ingreso = DateTime.Compare(DateTime.Parse(fecha).Date, DateTime.Parse(reserva.fecha_inicio).Date);
            int cant_noches = int.Parse(DateTime.Parse(fecha).Subtract(DateTime.Parse(estadiaout.fecha_inicio)).TotalDays.ToString());
            if (dias_desde_ingreso >= 0 && reserva.cant_noches >= cant_noches)
            {
                estadiaout.cant_noches = cant_noches;

                try
                {
                    estadiaout.save();
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

                Navigator.nextForm(this, new FrbaHotel.Registrar_Consumible.Form1(estadiaout));
            }
            else
            {
                MessageBox.Show("Debe seleccionar una fecha posterior a la fecha de ingreso para hacer el checkout");
            }
        }
        public bool obtenerReserva()
        {

            reserva = EntityManager.getEntityManager().findBy<Reserva>("reservas.id", reserva_numero.ToString());

            if (reserva == null)
            {
                MessageBox.Show("Por favor, ingrese un número de reserva correcto.");
                return false;
            }

            List<ReservaHabitacion> habitaciones_reservadas = EntityManager.getEntityManager().findAllBy<ReservaHabitacion>("reservas_habitaciones.reserva_id", reserva.id.ToString());
            Habitacion habitacion = EntityManager.getEntityManager().findBy<Habitacion>("habitaciones.id", habitaciones_reservadas[0].habitacion.id.ToString());
            //Validacion de que el usuario que realiza el check-in o check.out se encuentre en el mismo hotel
            if (SesionActual.rol_usuario.rol.id == 3) //Si es guest
            {
                return true;
            }
            
            if (SesionActual.rol_usuario == null || SesionActual.rol_usuario.hotel == null || habitacion.hotel.id != SesionActual.rol_usuario.hotel.id)
            {
                MessageBox.Show("La reserva no corresponde al hotel en el cual se esta trabajando");
                return false;
            }
            return true;

        }
    }
}
