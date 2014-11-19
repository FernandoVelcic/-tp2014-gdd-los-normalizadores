using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;

using FrbaHotel.Database_Helper;
using FrbaHotel.Models;
using FrbaHotel.Models.Exceptions;

namespace FrbaHotel.Views.ABM_de_Hotel
{
    public partial class BajaHotel : Form
    {
        private Hotel hotel;
        private HotelBaja hotel_baja;

        public BajaHotel(Hotel hotel)
        {
            InitializeComponent();
            this.hotel = hotel;
            hotel_baja = new HotelBaja();
            hotel_baja.hotel = hotel;

            hotel_baja.fecha_desde = Config.getInstance().getCurrentDate().ToShortDateString();
            hotel_baja.fecha_hasta = Config.getInstance().getCurrentDate().ToShortDateString();
        }

        private void BajaHotel_Load(object sender, EventArgs e)
        {
            var hoteles_bajas_binding = new BindingList<HotelBaja>(EntityManager.getEntityManager().findAllBy<HotelBaja>("hoteles_bajas.hotel_id", hotel.id.ToString()));
            dataGridView1.DataSource = new BindingSource(hoteles_bajas_binding, null);
            dateTimePicker1.DataBindings.Add("Text", hotel_baja, "fecha_desde", true);
            dateTimePicker2.DataBindings.Add("Text", hotel_baja, "fecha_hasta", true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                hotel_baja.save();
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

            MessageBox.Show("Hotel dado de baja correctamente! No se podran realizar reservas durante el periodo establecido");

            Close();
        }
    }
}
