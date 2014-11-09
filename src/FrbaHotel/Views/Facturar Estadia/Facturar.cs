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
        List<ItemFactura> itemsEstadia;
        List<ItemAFacturar> itemsParaFacturar;
        List<ConsumibleItemsUnidades> itemsVisibles;

        public Facturar(Estadia e, List<ItemAFacturar> items)
        {
            estadia = e;
            itemsParaFacturar = items;
            InitializeComponent();
        }

        public void Facturar_load(object sender, EventArgs e)
        {
            itemsVisibles = new List<ConsumibleItemsUnidades>();

            try
            {
                //Insert de factura porque sino de otro modo no podria insertar los items sin el id de la misma
                factura = new Factura();
                factura.fecha = (int.Parse(estadia.fecha_inicio) + estadia.cant_noches).ToString();  
                factura.save();
                setTexts();
                /* ??? */

                foreach( ItemAFacturar item in itemsParaFacturar)
                {
                    ConsumibleItemsUnidades itemVisible = new ConsumibleItemsUnidades();

                    itemVisible.codigo = item.consumible.codigo;
                    itemVisible.descripcion = item.consumible.descripcion;
                    itemVisible.precio = item.consumible.precio;
                    itemVisible.unidades = item.unidades;
                    itemVisible.monto = item.monto;

                    itemsVisibles.Add(itemVisible);

                }
                
                List<HotelRegimen> hotelesRegimen = EntityManager.getEntityManager().findAllBy<HotelRegimen>("regimen_id", estadia.reserva.regimen.id.ToString());
                List<ReservaHabitacion> reservaHabitaciones = EntityManager.getEntityManager().findAllBy<ReservaHabitacion>("reserva_id", estadia.reserva.id.ToString());
                Habitacion habitacion = (reservaHabitaciones.Take(1) as ReservaHabitacion).habitacion;
                hotel = hotelesRegimen.Find(hotelr => hotelr.hotel.id == habitacion.hotel.id).hotel;
                setItemHabitacion(reservaHabitaciones);
                setItemHabiNoHospedada(reservaHabitaciones);

                //Si el regimen es All inclusive o All inclusive moderado
                if (estadia.reserva.regimen.id == 3 || estadia.reserva.regimen.id == 4)
                {
                    setdescuentoAllInclusive();
                }
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

            BindingSource itemsVisiblesBinding = new BindingSource();
            itemsVisiblesBinding.DataSource = itemsVisibles;
            dataGridView1.DataSource = itemsVisibles;
        }



        private void setTexts()
        {
            txt_FacturaNro.Text = factura.nro.ToString(); //nro de factura
            txt_Desde.Text = estadia.reserva.fecha_inicio.ToString(); //Fecha de inicio que se reservo
            txt_Hasta.Text = (estadia.reserva.fecha_inicio + estadia.reserva.cant_noches).ToString(); //Fecha de supuesta salida
            txt_CheckIn.Text = estadia.fecha_inicio.ToString();//Fecha de inicio real( check in) Las dos de inicio deberian ser iguales porque sino no te dejarian entrar o ya estaria cancelada
            txt_CheckOut.Text = (estadia.fecha_inicio + estadia.cant_noches).ToString();//Fecha de salida real ( check out)
        }

        private void setItemHabitacion(List<ReservaHabitacion> reservaHabitaciones)
        {
            //tipo_habitacion_seleccionado.porcentual* regimen_seleccionado.precio * tipo_habitacion_seleccionado.cantidad_maxima_personas + hotel_seleccionado.cant_estrella * hotel_seleccionado.recarga_estrella;
            foreach (ReservaHabitacion reservaHabitacion in reservaHabitaciones)
            {
                ItemFactura itemHabitacion = new ItemFactura();
                itemHabitacion.estadia = estadia;
                itemHabitacion.consumible = null;
                itemHabitacion.factura = factura;
                itemHabitacion.tipo = "H";

                //CALCULO PRECIO DE HABITACION
                itemHabitacion.monto = (reservaHabitacion.habitacion.tipo.porcentual * estadia.reserva.regimen.precio * reservaHabitacion.habitacion.tipo.cantidad_maxima_personas + hotel.cant_estrella * hotel.recarga_estrella) * estadia.reserva.cant_noches;
                itemHabitacion.unidades = estadia.cant_noches;

                try
                {
                    itemHabitacion.save();
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

                ConsumibleItemsUnidades itemVisible = new ConsumibleItemsUnidades();
                itemVisible.codigo = 0;
                itemVisible.descripcion = "Regimen" + reservaHabitacion.reserva.regimen.descripcion + ". Habitacion tipo" + reservaHabitacion.habitacion.descripcion + "-Dias que realmente se hospedo";
                itemVisible.precio = (reservaHabitacion.habitacion.tipo.porcentual * estadia.reserva.regimen.precio * reservaHabitacion.habitacion.tipo.cantidad_maxima_personas + hotel.cant_estrella * hotel.recarga_estrella);
                itemVisible.unidades = itemHabitacion.unidades;
                itemVisible.monto = itemHabitacion.monto;

                itemsVisibles.Add(itemVisible);
                itemsEstadia.Add(itemHabitacion);  
            }
        }

        private void setItemHabiNoHospedada(List<ReservaHabitacion> reservaHabitaciones)
        {
            foreach (ReservaHabitacion reservaHabitacion in reservaHabitaciones)
            {

                if (estadia.cant_noches < estadia.reserva.cant_noches)
                {
                    ItemFactura itemHabitacionNoHospedada = new ItemFactura();
                    itemHabitacionNoHospedada.estadia = estadia;
                    itemHabitacionNoHospedada.consumible = null;
                    itemHabitacionNoHospedada.factura = factura;
                    itemHabitacionNoHospedada.monto = 0;
                    itemHabitacionNoHospedada.tipo = "N";
                    itemHabitacionNoHospedada.unidades = estadia.reserva.cant_noches - estadia.cant_noches;
              
                    try
                    {
                        itemHabitacionNoHospedada.save();
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

                    ConsumibleItemsUnidades itemVisible = new ConsumibleItemsUnidades();
                    itemVisible.codigo = 0;
                    itemVisible.descripcion = "Regimen" + reservaHabitacion.reserva.regimen.descripcion + ". Habitacion tipo" + reservaHabitacion.habitacion.descripcion + "-Dias que no se hospedo";
                    itemVisible.precio = 0;
                    itemVisible.unidades = itemHabitacionNoHospedada.unidades;
                    itemVisible.monto = 0;

                    itemsVisibles.Add(itemVisible);
                    itemsEstadia.Add(itemHabitacionNoHospedada);    

                }
            }
        }

        public void setdescuentoAllInclusive()
        {
            float suma =  itemsEstadia.Select<ItemFactura, float>(item => item.unidades * item.consumible.precio).Sum();

            ItemFactura itemDescuento = new ItemFactura();
            itemDescuento.estadia = estadia;
            itemDescuento.consumible = null;
            itemDescuento.factura = factura;

            itemDescuento.tipo = "D";
            itemDescuento.unidades = 0;
            itemDescuento.monto = suma * (-1);

            try
            {
                itemDescuento.save();
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

            ConsumibleItemsUnidades itemVisible = new ConsumibleItemsUnidades();
            itemVisible.codigo = 0;
            itemVisible.descripcion = "Descuento por regimen" + estadia.reserva.regimen.descripcion;
            itemVisible.precio = 0;
            itemVisible.unidades = 0;
            itemVisible.monto = itemDescuento.monto;

            itemsVisibles.Add(itemVisible);
            itemsEstadia.Add(itemDescuento);
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
