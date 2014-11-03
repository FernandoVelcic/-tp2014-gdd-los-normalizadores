using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

using FrbaHotel.Models;
using FrbaHotel.Models.Listado_Estadistico;
using FrbaHotel.Database_Helper;

using MyActiveRecord;


namespace FrbaHotel.Listado_Estadistico
{
    public partial class Form1 : Form
    {
        private DateTime fecha1, fecha2;
        public int anio { get; set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.DataBindings.Add("Text", this, "anio");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            comboBox2.SelectedIndex = -1;
            comboBox1.SelectedIndex = -1;
            dataGridView1.Rows.Clear();

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (anio < 1900)
            {
                MessageBox.Show("Por favor, seleccione un año valido");
            }

            switch (comboBox2.SelectedIndex)
            {
                case 0: //Primer trimestre
                    fecha1 = new DateTime(anio, 1, 1);
                    fecha2 = new DateTime(anio, 3, 31);
                    break;
                case 1: //Segundo trimestre
                    fecha1 = new DateTime(anio, 4, 1);
                    fecha2 = new DateTime(anio, 6, 30);
                    break;
                case 2: //Tercer trimestre
                    fecha1 = new DateTime(anio, 7, 1);
                    fecha2 = new DateTime(anio, 9, 30);
                    break;
                case 3: //Cuarto trimestre
                    fecha1 = new DateTime(anio, 10, 1);
                    fecha2 = new DateTime(anio, 12, 31);
                    break;

                default:
                    MessageBox.Show("Debe seleccionar el trimestre que desea");
                    return;
            }

            switch (comboBox1.SelectedIndex)
            {
                case 0: //Hotel con mayor cantidad de reservas canceladas
                    HotelMayorCantidadReservasCanceladas();
                    break;

                case 1: //Hotel con mayor cantidad de consumibles facturados
                    break;

                case 2: //Hotel con mayor cantidad de días fuera de servicio
                    break;

                case 3: //Habitacion con mayor cantidad de días y veces ocupada
                    break;

                case 4: //Cliente con mayor cantidad de puntos
                    break;

                default:
                    MessageBox.Show("Debe seleccionar el top que desea");
                    break;
            }
        }

        private void HotelMayorCantidadReservasCanceladas()
        {
            List<HotelesReservasCanceladas> hoteles = new List<HotelesReservasCanceladas>();
            string query = "SELECT TOP 5 hotel_id, COUNT(*) AS cantidad FROM [LOS_NORMALIZADORES].[reservas] LEFT JOIN [LOS_NORMALIZADORES].[habitaciones] ON reservas.habitacion_id = habitaciones.id WHERE (reserva_estado = 3 OR reserva_estado = 4 OR reserva_estado = 5) AND [fecha_cancelacion] BETWEEN '" + fecha1.ToShortDateString() + "' AND '" + fecha2.ToShortDateString() + "' GROUP BY hotel_id ORDER BY COUNT(*) DESC";

            SqlCommand command = new SqlCommand(query, ConnectionManager.getInstance().getConnection());
            using (SqlDataReader result = command.ExecuteReader())
            {
                while (result.Read())
                {
                    HotelesReservasCanceladas reserva_cancelada = new HotelesReservasCanceladas();
                    Hotel hotel_temporal = new Hotel();
                    hotel_temporal.id = Convert.ToInt32(result["hotel_id"].ToString());
                    reserva_cancelada.hotel = hotel_temporal;
                    reserva_cancelada.cantidad = Convert.ToInt32(result["cantidad"]);

                    hoteles.Add(reserva_cancelada);
                }
            }

            hoteles.ForEach(h => h.hotel = EntityManager.getEntityManager().findById<Hotel>(h.hotel.id));
            
            //List<HotelesReservasCanceladas> hoteles = EntityManager.getEntityManager().findAll<HotelesReservasCanceladas>();
            dataGridView1.DataSource = hoteles;
        }
    }
}
