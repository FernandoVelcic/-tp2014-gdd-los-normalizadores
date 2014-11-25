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
        List<ItemFactura> itemsEstadia = new List<ItemFactura>();
        List<ConsumibleEstadia> consumiblesEstadia;
        List<ConsumibleItemsUnidades> itemsVisibles = new List<ConsumibleItemsUnidades>();
        Cliente cliente;

        public Facturar(Estadia estadia)
        {
            this.estadia = estadia;
            consumiblesEstadia = EntityManager.getEntityManager().findAllBy<ConsumibleEstadia>("estadia_id", estadia.id.ToString());
            InitializeComponent();
        }

        public void Facturar_load(object sender, EventArgs e)
        {
            //
            List<FetchCondition> condiciones = new List<FetchCondition>();
            FetchCondition condicionNoSinEspecificar = new FetchCondition();
            condicionNoSinEspecificar.setNotEquals("id", 1); //Sin especificar id = 1
            condiciones.Add(condicionNoSinEspecificar);

            BindingSource formas_pago_binding = new BindingSource();
            formas_pago_binding.DataSource = EntityManager.getEntityManager().findList<FormaDePago>(condiciones);
            cmb_FormaDePago.DataSource = formas_pago_binding;
            //

           
            //ConsumibleItemsUnidades que es la manera de representarlo visiblemente en el datagrid
            consumiblesEstadia.ForEach(i => this.itemsVisibles.Add(new ConsumibleItemsUnidades(i)));

            //Insert de factura porque sino de otro modo no podria insertar los items sin el id de la misma
            factura = new Factura();
            factura.fecha = (DateTime.Parse(estadia.fecha_inicio).AddDays(estadia.cant_noches)).ToString();
            factura.forma_pago_id = 1;
            factura.estadia = estadia;

            Reserva reserva = EntityManager.getEntityManager().findBy<Reserva>("reservas.id", estadia.reserva.id.ToString());
            cliente = reserva.cliente;

            factura.cliente = cliente;

            factura.save();
            setTexts();


            txt_Usuario.Text = cliente.nombre.ToString() + " " + cliente.apellido.ToString();
            Habitacion habitacionPosta = reserva.obtener_una_habitacion();
            hotel = habitacionPosta.hotel;
            //Registro de los dias no hospedados
            setItemHabitacionNoHospedada();
            //Registro de los dias hospedados
            setItemHabitacionHospedada();

            //Si el regimen es All inclusive o All inclusive moderado, registro del descuento de los consumibles
            if (reserva.regimen.id == 3 || reserva.regimen.id == 4)
            {
                setdescuentoAllInclusive();
            }

            dataGridView1.DataSource = new BindingSource(this.itemsVisibles, null);

          
        }



        private void setTexts()
        {
            txt_FacturaNro.Text = factura.id.ToString(); //nro de factura
            txt_Desde.Text = estadia.reserva.fecha_inicio.ToString(); //Fecha de inicio que se reservo
            txt_Hasta.Text = (DateTime.Parse(estadia.reserva.fecha_inicio).AddDays(estadia.reserva.cant_noches)).ToString(); //Fecha de supuesta salida
            txt_CheckIn.Text = estadia.fecha_inicio.ToString();//Fecha de inicio real( check in) Las dos de inicio deberian ser iguales porque sino no te dejarian entrar o ya estaria cancelada
            txt_CheckOut.Text = (DateTime.Parse(estadia.fecha_inicio).AddDays(estadia.cant_noches)).ToString();//Fecha de salida real ( check out)

        }

        private void setItemHabitacionHospedada()
        {
            ItemFactura itemHabitacion = new ItemFactura();
            itemHabitacion.consumible_estadia = null;
            itemHabitacion.factura = factura;
            itemHabitacion.tipo = "H";

            Reserva reserva = EntityManager.getEntityManager().findBy<Reserva>("reservas.id", estadia.reserva.id.ToString());
            Habitacion habitacion = reserva.obtener_una_habitacion();

            int cantidad_habitaciones = EntityManager.getEntityManager().findAllBy<ReservaHabitacion>("reservas_habitaciones.reserva_id", reserva.id.ToString()).Count;

            //CALCULO PRECIO DE HABITACION
            itemHabitacion.monto = ((habitacion.tipo.porcentual * reserva.regimen.precio * habitacion.tipo.cantidad_maxima_personas + hotel.cant_estrella * hotel.recarga_estrella) * reserva.cant_noches) * cantidad_habitaciones;
            itemHabitacion.unidades = estadia.cant_noches;

            itemHabitacion.save();

            ConsumibleItemsUnidades itemVisible = new ConsumibleItemsUnidades();
            itemVisible.codigo = 0;
            itemVisible.descripcion = "Regimen " + reserva.regimen.descripcion + ". Habitacion tipo: " + habitacion.descripcion + "-Dias hospedados";
            itemVisible.precio = (habitacion.tipo.porcentual * reserva.regimen.precio * habitacion.tipo.cantidad_maxima_personas + hotel.cant_estrella * hotel.recarga_estrella);
            itemVisible.unidades = itemHabitacion.unidades;
            itemVisible.monto = itemHabitacion.monto;

            this.itemsVisibles.Add(itemVisible);
            this.itemsEstadia.Add(itemHabitacion);

        }
        private void setItemHabitacionNoHospedada()
        {
            if (estadia.cant_noches < estadia.reserva.cant_noches)
            {

                ItemFactura itemHabitacionNoHospedada = new ItemFactura();
                itemHabitacionNoHospedada.consumible_estadia = null;
                itemHabitacionNoHospedada.factura = factura;
                itemHabitacionNoHospedada.monto = 0;
                itemHabitacionNoHospedada.tipo = "N";
                itemHabitacionNoHospedada.unidades = estadia.reserva.cant_noches - estadia.cant_noches;

                itemHabitacionNoHospedada.save();

                Reserva reserva = EntityManager.getEntityManager().findBy<Reserva>("reservas.id", estadia.reserva.id.ToString());
                Habitacion habitacion = reserva.obtener_una_habitacion();

                ConsumibleItemsUnidades itemVisible = new ConsumibleItemsUnidades();
                itemVisible.codigo = 0;
                string descHab;
                if (habitacion.descripcion == "")
                {
                    descHab = "Sin descripcion ";
                }
                else
                {
                    descHab = habitacion.descripcion;
                }
                string descReg;
                if (reserva.regimen.descripcion == "")
                {
                    descReg = "Sin desc";
                }
                else
                {
                    descReg = reserva.regimen.descripcion;
                }
                itemVisible.descripcion = "Regimen " + descReg + ". Habitacion tipo: " + descHab + "-Dias no usados";
                itemVisible.precio = 0;
                itemVisible.unidades = itemHabitacionNoHospedada.unidades;
                itemVisible.monto = 0;

                this.itemsVisibles.Add(itemVisible);
                this.itemsEstadia.Add(itemHabitacionNoHospedada);
            }
        }

        public void setdescuentoAllInclusive()
        {
            float suma = EntityManager.getEntityManager().findAllBy<ConsumibleEstadia>("estadia_id", estadia.id.ToString()).Select(item => item.unidades * item.consumible.precio).Sum();

            ItemFactura itemDescuento = new ItemFactura();
            itemDescuento.consumible_estadia = null;
            itemDescuento.factura = factura;

            itemDescuento.tipo = "D";
            itemDescuento.unidades = 0;
            itemDescuento.monto = -suma;

            itemDescuento.save();

            Reserva reserva = estadia.reserva;
            ConsumibleItemsUnidades itemVisible = new ConsumibleItemsUnidades();
            itemVisible.codigo = 0;
            itemVisible.descripcion = "Descuento por regimen" + reserva.regimen.descripcion;
            itemVisible.precio = 0;
            itemVisible.unidades = 0;
            itemVisible.monto = itemDescuento.monto;

            itemsVisibles.Add(itemVisible);
            itemsEstadia.Add(itemDescuento);
        }



        private void onBtnFacturar(object sender, EventArgs e)
        {
            facturarConsumibles();
            if (cmb_FormaDePago.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione una forma de pago");
                return;
            }


            FormaDePago forma = cmb_FormaDePago.SelectedItem as FormaDePago;
            factura.forma_pago_id = forma.id;

            //update del numero de tarjeta del usuario
            if (cliente.nro_tarjeta == null && txt_Tarjeta.Text != "" && txt_Pin.Text != "")
            {
                cliente.nro_tarjeta = txt_Tarjeta.Text;
                cliente.pin = txt_Pin.Text;

                cliente.save();
            }
            //Ingreso de una nro de tarjeta distinto del que ya tiene el cliente
            else if (cliente.nro_tarjeta != txt_Tarjeta.Text && txt_Tarjeta.Text != "" && txt_Pin.Text != "")
            {
                DialogResult result1 = MessageBox.Show("El usuario tiene asignado el siguiente numero de tarjeta, desea cambiarlo?" + cliente.nro_tarjeta, "Importante", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (result1 == DialogResult.Yes)
                {
                    cliente.nro_tarjeta = txt_Tarjeta.Text;
                    cliente.pin = txt_Pin.Text;

                    cliente.save();
                }
            }
            //Si no se ingreso el nro de tarjeta
            if ((forma.descripcion != "Efectivo") && (cliente.pin == "") && (cliente.pin != txt_Pin.ToString()))
            {
                MessageBox.Show("El PIN de seguridad de la tarjeta no es el correcto");
                return;
            }

            //factura.cliente_id = cliente;
            //Update de la factura para guardar la forma de pago
            factura.save();
            MessageBox.Show("La factura se genero con exito!");

            Navigator.nextForm(this, new FrbaHotel.Operaciones());
        }
        public void facturarConsumibles()
        {
            //Persistencia de los items de factura una vez elegido el medio de pago
            
            foreach (ConsumibleEstadia consumibleEstadia in consumiblesEstadia)
            {
                ItemFactura itemConsumible = new ItemFactura();
                itemConsumible.consumible_estadia = consumibleEstadia;
                itemConsumible.factura = factura;
                itemConsumible.tipo = "C";
                itemConsumible.monto = consumibleEstadia.unidades * consumibleEstadia.consumible.precio;
                itemConsumible.unidades = consumibleEstadia.unidades;

                itemConsumible.save();
            }
        }

        //TARJETA DE CREDITO
        private void onCambioFormaDePago(object sender, EventArgs e)
        {
            FormaDePago forma = cmb_FormaDePago.SelectedItem as FormaDePago;

            if (forma.descripcion == "Tarjeta de crédito" || forma.descripcion == "Tarjeta de débito") activarDatosTarjeta();
            if (forma.descripcion == "Efectivo") desactivarDatosTarjeta();
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
