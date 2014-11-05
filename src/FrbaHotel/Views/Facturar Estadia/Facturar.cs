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

namespace FrbaHotel.Views.Facturar_Estadia
{
    public partial class Facturar : Form
    {
        Reserva reserva;

        public Facturar(Reserva res)
        {
            reserva = res;
            InitializeComponent();
        }

        public void Facturar_load(object sender, EventArgs e)
        {
            textBox1.Text = reserva.id.ToString();
            textBox2.Text = reserva.fecha_inicio.ToString();
            textBox3.Text = (reserva.fecha_inicio + reserva.cant_noches).ToString();
            //textBox4.Text = reserva.fecha_checkin.ToString();
            //textBox5.Text = reserva.fecha_checkout.ToString();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            string forma_de_pago = comboBox1.SelectedItem.ToString();
            //armar el registro de la factura
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
