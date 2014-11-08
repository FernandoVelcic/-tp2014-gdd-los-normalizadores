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
using FrbaHotel.Models.Exceptions;
using System.Data.SqlClient;

namespace FrbaHotel.Views.Facturar_Estadia
{
    public partial class Facturar : Form
    {
        Estadia estadia;
        Factura factura;
        Hotel hotel;
        public Facturar(Estadia e)
        {
            estadia = e;
            InitializeComponent();
        }

        public void Facturar_load(object sender, EventArgs e)
        {

            try
            {

                //Insert de factura porque sino de otro modo no podria insertar los items sin el id de la misma
                factura = new Factura();
                factura.fecha = (int.Parse(estadia.fecha_inicio) + estadia.cant_noches).ToString();  
                factura.save();
                setTexts();
                /* ??? */
                List<ConsumibleEstadia> consumiblesEstadia = EntityManager.getEntityManager().findAllBy<ConsumibleEstadia>("estadia_id", estadia.id.ToString());
                List<HotelRegimen> hotelesRegimen = EntityManager.getEntityManager().findAllBy<HotelRegimen>("regimen_id", estadia.reserva.regimen.id.ToString());
                List<ReservaHabitacion> reservaHabitaciones = EntityManager.getEntityManager().findAllBy<ReservaHabitacion>("reserva_id", estadia.reserva.id.ToString());
                Habitacion habitacion = (reservaHabitaciones.Take(1) as ReservaHabitacion).habitacion;
                hotel = hotelesRegimen.Find(hotelr => hotelr.hotel.id == habitacion.hotel.id).hotel;
                setConsumibleHabitacion(reservaHabitaciones);
                setconsumibleHabiNoHospedada(reservaHabitaciones);
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


            BindingSource consEstadia_binding = new BindingSource();
            consEstadia_binding.DataSource = EntityManager.getEntityManager().findAllBy<ConsumibleEstadia>("estadia_id", estadia.id.ToString());
            dataGridView1.DataSource = consEstadia_binding;

        }



        private void setTexts()
        {
            txt_FacturaNro.Text = factura.nro.ToString(); //nro de factura
            txt_Desde.Text = estadia.reserva.fecha_inicio.ToString(); //Fecha de inicio que se reservo
            txt_Hasta.Text = (estadia.reserva.fecha_inicio + estadia.reserva.cant_noches).ToString(); //Fecha de supuesta salida
            txt_CheckIn.Text = estadia.fecha_inicio.ToString();//Fecha de inicio real( check in) Las dos de inicio deberian ser iguales porque sino no te dejarian entrar o ya estaria cancelada
            txt_CheckOut.Text = (estadia.fecha_inicio + estadia.cant_noches).ToString();//Fecha de salida real ( check out)
        }

        private void setConsumibleHabitacion(List<ReservaHabitacion> reservaHabitaciones)
        {
            //tipo_habitacion_seleccionado.porcentual* regimen_seleccionado.precio * tipo_habitacion_seleccionado.cantidad_maxima_personas + hotel_seleccionado.cant_estrella * hotel_seleccionado.recarga_estrella;
            foreach (ReservaHabitacion reservaHabitacion in reservaHabitaciones)
            {
                Consumible consumibleHabitacion = new Consumible();
                consumibleHabitacion.descripcion = "Regimen" + reservaHabitacion.reserva.regimen.descripcion + ". Habitacion tipo" + reservaHabitacion.habitacion.descripcion + "-Dias que realmente se hospedo";
                consumibleHabitacion.precio = 0;

                try
                {
                    consumibleHabitacion.save();
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

                ConsumibleEstadia consumibleEstadiaHab = new ConsumibleEstadia();
                consumibleEstadiaHab.estadia = estadia;
                consumibleEstadiaHab.consumible = consumibleHabitacion;

                //CALCULO PRECIO DE HABITACION
                consumibleEstadiaHab.monto = (reservaHabitacion.habitacion.tipo.porcentual * estadia.reserva.regimen.precio * reservaHabitacion.habitacion.tipo.cantidad_maxima_personas + hotel.cant_estrella * hotel.recarga_estrella) * estadia.reserva.cant_noches;
                consumibleEstadiaHab.unidades = estadia.cant_noches;

                try
                {
                    consumibleEstadiaHab.save();
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
            }
        }

        private void setconsumibleHabiNoHospedada(List<ReservaHabitacion> reservaHabitaciones)
        {
            foreach (ReservaHabitacion reservaHabitacion1 in reservaHabitaciones)
            {
                if (estadia.cant_noches < estadia.reserva.cant_noches)
                {
                    Consumible consumibleHabiNoHospedada = new Consumible();
                    consumibleHabiNoHospedada.descripcion = "Regimen" + reservaHabitacion1.reserva.regimen.descripcion + ". Habitacion tipo" + reservaHabitacion1.habitacion.descripcion + "-Dias que no se hospedo";
                    consumibleHabiNoHospedada.precio = 0;
                    consumibleHabiNoHospedada.save();


                    ConsumibleEstadia consumibleEstadiaNoHospedada = new ConsumibleEstadia();
                    consumibleEstadiaNoHospedada.estadia = estadia;
                    consumibleEstadiaNoHospedada.consumible = consumibleHabiNoHospedada;
                    consumibleEstadiaNoHospedada.monto = 0;
                    consumibleEstadiaNoHospedada.unidades = estadia.reserva.cant_noches - estadia.cant_noches;
                    consumibleEstadiaNoHospedada.save();

                }
            }
        }

        private void onBtnFacturar(object sender, EventArgs e)
        {
            
            string forma_de_pago = cmb_FormaDePago.SelectedItem.ToString();
            
            /* Se agrego harcodeado en el script de migracion que 1: sin especificar, 2: efectivo, 3: credito 4:debito*/
            switch(forma_de_pago)
            {
                case "Efectivo":
                    factura.forma_pago_id =2;
                break;
                case "Tarjeta de Crédito":
                    factura.forma_pago_id =3;
                break;
                case "Tarjeta de Débito":
                    factura.forma_pago_id =4;
                break;
                default:
                    factura.forma_pago_id =1;
                break;
            }
            //update del numero de tarjeta del usuario
            Cliente cliente = EntityManager.getEntityManager().findBy<Cliente>("cliente.id", estadia.reserva.cliente.ToString());
            if(cliente.nro_tarjeta==null)
            {
                cliente.nro_tarjeta=txt_Tarjeta.Text;
                try
                {
                    cliente.save();
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
            }else if(cliente.nro_tarjeta!=txt_Tarjeta.Text) 
            {
                DialogResult result1 = MessageBox.Show("El usuario tiene asignado el siguiente numero de tarjeta, desea cambiarlo?" + cliente.nro_tarjeta, "Importante", MessageBoxButtons.YesNo);
                if (result1 == DialogResult.Yes)
                {
                    cliente.nro_tarjeta = txt_Tarjeta.Text;
                    try
                    {
                        cliente.save();
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
                }
            }
            //Update de la factura para guardar la forma de pago
            try
            {
                factura.save();
                MessageBox.Show("La factura se genero con exito!");
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

            Close();
        }

        private void onCambioFormaDePago(object sender, EventArgs e)
        {
            string forma_de_pago = cmb_FormaDePago.SelectedItem.ToString();
            if (forma_de_pago == "Tarjeta de Crédito" || forma_de_pago == "Tarjeta de Débito") activarDatosTarjeta();
            if (forma_de_pago == "Efectivo") desactivarDatosTarjeta();
        }

        public void activarDatosTarjeta()
        {
            label7.Visible = true;
            label8.Visible = true;
            txt_Tarjeta.Visible = true;
            txt_Pin.Visible = true;
        }

        public void desactivarDatosTarjeta()
        {
            label7.Visible = false;
            label8.Visible = false;
            txt_Tarjeta.Visible = false;
            txt_Pin.Visible = false;
        }

    }
}
