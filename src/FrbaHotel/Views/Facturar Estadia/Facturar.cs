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
            factura = new Factura();
            factura.fecha = (int.Parse(estadia.fecha_inicio) + estadia.cant_noches).ToString();  
            //Insert de factura porque sino de otro modo no podria insertar los items sin el id de la misma
            try
            {
                factura.save();
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

            textBox1.Text = factura.nro.ToString(); //nro de factura
            textBox2.Text = estadia.reserva.fecha_inicio.ToString(); //Fecha de inicio que se reservo
            textBox3.Text = (estadia.reserva.fecha_inicio + estadia.reserva.cant_noches).ToString(); //Fecha de supuesta salida
            textBox4.Text = estadia.fecha_inicio.ToString();//Fecha de inicio real( check in) Las dos de inicio deberian ser iguales porque sino no te dejarian entrar o ya estaria cancelada
            textBox5.Text = (estadia.fecha_inicio + estadia.cant_noches).ToString();//Fecha de salida real ( check out)

            List<ConsumibleEstadia> consumiblesEstadia = EntityManager.getEntityManager().findAllBy<ConsumibleEstadia>("estadia_id", estadia.id.ToString());

            BindingList<ItemFactura> itemsFactura = new BindingList<ItemFactura>();

            foreach (ConsumibleEstadia consumible in consumiblesEstadia)
            {
                ItemFactura item = new ItemFactura();
                item.descripcion = consumible.consumible.descripcion;
                item.factura_cantidad = consumible.unidades;
                item.monto = consumible.consumible.precio * consumible.unidades;
                item.factura_id = factura.id;
                itemsFactura.Add(item);

                try
                {
                    item.save();
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
          


            List<HotelRegimen> hotelesRegimen = EntityManager.getEntityManager().findAllBy<HotelRegimen>("regimen_id", estadia.reserva.regimen.id.ToString());
            List<ReservaHabitacion> reservaHabitaciones = EntityManager.getEntityManager().findAllBy<ReservaHabitacion>("reserva_id", estadia.reserva.id.ToString());

            Habitacion habitacion = (reservaHabitaciones.Take(1) as ReservaHabitacion).habitacion;
            hotel = hotelesRegimen.Find(hotelr => hotelr.hotel.id == habitacion.hotel.id).hotel;

            //tipo_habitacion_seleccionado.porcentual* regimen_seleccionado.precio * tipo_habitacion_seleccionado.cantidad_maxima_personas + hotel_seleccionado.cant_estrella * hotel_seleccionado.recarga_estrella;
            foreach (ReservaHabitacion reservaHabitacion in reservaHabitaciones)
            {
                ItemFactura item = new ItemFactura();
                item.descripcion = reservaHabitacion.habitacion.descripcion + estadia.reserva.regimen.descripcion + "Monto por reserva de habitaciones";//La descripcion te la dejo a vos redactador
                item.factura_cantidad = estadia.cant_noches;
                
                //CALCULO DE PRECIO DE HABITACION
                
                item.monto = (habitacion.tipo.porcentual * estadia.reserva.regimen.precio * habitacion.tipo.cantidad_maxima_personas + hotel.cant_estrella * hotel.recarga_estrella) * estadia.reserva.cant_noches;
                item.factura_id = factura.id;
                item.save();
                itemsFactura.Add(item);

                
            }
            foreach (ReservaHabitacion reservaHabitacion1 in reservaHabitaciones)
            {
                if ( estadia.cant_noches < estadia.reserva.cant_noches)
                {
                    ItemFactura item1 = new ItemFactura();
                    item1.descripcion = "Dias que no se alojo";
                    item1.factura_cantidad = estadia.reserva.cant_noches - estadia.cant_noches;
                    item1.monto = 0;
                    item1.factura_id = factura.id;

                    itemsFactura.Add(item1);
                    try
                    {
                        item1.save();
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
            dataGridView1.DataSource = itemsFactura;
        }



        private void button1_Click(object sender, EventArgs e)
        {
            string forma_de_pago = comboBox1.SelectedItem.ToString();
            factura.forma_pago = forma_de_pago;

            //Update de la factura para guardar la forma de pago
            try
            {
                factura.save();
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string forma_de_pago = comboBox1.SelectedItem.ToString();
            if (forma_de_pago == "Tarjeta de Crédito" || forma_de_pago == "Tarjeta de Débito") activarDatosTarjeta();
            if (forma_de_pago == "Efectivo") desactivarDatosTarjeta();
        }

        public void activarDatosTarjeta()
        {
            label7.Visible = true;
            label8.Visible = true;
            textBox7.Visible = true;
            textBox8.Visible = true;
        }
        public void desactivarDatosTarjeta()
        {
            label7.Visible = false;
            label8.Visible = false;
            textBox7.Visible = false;
            textBox8.Visible = false;
        }
    }
}
