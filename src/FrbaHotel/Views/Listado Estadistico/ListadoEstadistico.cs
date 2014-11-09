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
            this.anio = 2013;
            txt_Anio.DataBindings.Add("Text", this, "anio");
            cmb_Tipo.SelectedIndex = 3;
            cmb_Trimestre.SelectedIndex = 0;

            fecha1 = new DateTime(anio, 1, 1);
            fecha2 = new DateTime(anio, 3, 31);
            HabitacionConMayorCantidadDeDiasYVecesOcupada();
        }

        private void btnLimpiar(object sender, EventArgs e)
        {
            txt_Anio.Text = "";
            cmb_Trimestre.SelectedIndex = -1;
            cmb_Tipo.SelectedIndex = -1;
            dataGridView1.Rows.Clear();

        }
        
        private void btnFiltrar(object sender, EventArgs e)
        {
            if (anio < 1900 || anio > 2020)
            {
                MessageBox.Show("Por favor, seleccione un año valido");
                return;
            }

            switch (cmb_Trimestre.SelectedIndex)
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

            switch (cmb_Tipo.SelectedIndex)
            {
                case 0: //Hotel con mayor cantidad de reservas canceladas
                    HotelMayorCantidadReservasCanceladas();
                    break;

                case 1: //Hotel con mayor cantidad de consumibles facturados
                    HotelConMasConsumibles();
                    break;

                case 2: //Hotel con mayor cantidad de días fuera de servicio
                    HotelMayorCantidadDiasFueraServicio();
                    break;

                case 3: //Habitacion con mayor cantidad de días y veces ocupada
                    HabitacionConMayorCantidadDeDiasYVecesOcupada();
                    break;

                case 4: //Cliente con mayor cantidad de puntos
                    ClienteConMasPuntos();
                    break;

                default:
                    MessageBox.Show("Debe seleccionar el top que desea");
                    break;
            }
        }



        private void HotelMayorCantidadReservasCanceladas()
        {
            
            List<HotelesReservasCanceladas> hoteles = new List<HotelesReservasCanceladas>();
            
            var query = "SELECT TOP 5 hotel_id, COUNT(*) AS cantidad ";
            
            query += "FROM [LOS_NORMALIZADORES].[reservas] ";

            query += "INNER JOIN [LOS_NORMALIZADORES].[reservas_habitaciones] ON [reservas].id = reservas_habitaciones.reserva_id ";
            query += "INNER JOIN [LOS_NORMALIZADORES].[habitaciones] ON [reservas_habitaciones].habitacion_id = habitaciones.id ";
	        query += "INNER JOIN [LOS_NORMALIZADORES].[hoteles] ON [hoteles].id = [habitaciones].hotel_id ";

            query += "WHERE (reserva_estado = 3 OR reserva_estado = 4 OR reserva_estado = 5) ";
            query += "AND [fecha_cancelacion] BETWEEN '" + fecha1.ToShortDateString() + "' AND '" + fecha2.ToShortDateString() + "' "; 
            query += "GROUP BY hotel_id ORDER BY COUNT(*) DESC";


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


        /* TODO aca se vuelve complicado, los consumibles se facturan por estadias,*/
        /* pero las estadias segun el modelo de datos podria tener mas de una habitacion/hotel */
        /* Si bien desde la app no permitimos eso, es muy dificil de calcular */
        /* Hay que joinear consuibles_estadias, estadias, habitacion y hotel ?? */
        private void HotelConMasConsumibles()
        {
            var query = "SELECT hotel_id, SUM(consumibles_estadias.monto * consumibles_estadias.unidades) as total ";

            query += " FROM [" + Config.getInstance().schema + "].[consumibles_estadias] ";

            query += " INNER JOIN [" + Config.getInstance().schema + "].[estadias] ON consumibles_estadias.estadia_id = estadias.id";
            query += " INNER JOIN [" + Config.getInstance().schema + "].[reservas] ON estadias.reserva_id = reservas.id";
            query += " INNER JOIN [" + Config.getInstance().schema + "].[reservas_habitaciones] ON reservas_habitaciones.reserva_id = reservas.id";
            query += " INNER JOIN [" + Config.getInstance().schema + "].[habitaciones] ON reservas_habitaciones.habitacion_id = habitaciones.id";
            query += " INNER JOIN [" + Config.getInstance().schema + "].[hoteles] ON habitaciones.hotel_id = hoteles.id";

            query += " WHERE reservas.fecha_inicio BETWEEN '" + fecha1.ToShortDateString() + "' AND '" + fecha2.ToShortDateString() + "' ";
            query += " GROUP BY hotel_id ";

            List<HotelCaro> hoteles = new List<HotelCaro>();

            SqlCommand command = new SqlCommand(query, ConnectionManager.getInstance().getConnection());
            using (SqlDataReader result = command.ExecuteReader())
            {
                while (result.Read())
                {
                    HotelCaro hotel = new HotelCaro();
                    hotel.hotel_id = Convert.ToInt32(result["hotel_id"]);
                    hotel.total = Convert.ToInt32(result["total"]);
                    hoteles.Add(hotel);
                }
            }

            dataGridView1.DataSource = hoteles;

        }

        /* TODO revisar, en vez de usar top, usar numrow */
        private void HotelMayorCantidadDiasFueraServicio()
        {

            List<HotelesReservasCanceladas> hoteles = new List<HotelesReservasCanceladas>();

            var query = " SELECT TOP 5 hotel_id, SUM(DATEDIFF(d, hoteles_bajas.fecha_desde, hoteles_bajas.fecha_hasta)+1) AS cantidad_dias ";
            query += " FROM [LOS_NORMALIZADORES].[hoteles] ";
            query += " RIGHT JOIN [LOS_NORMALIZADORES].[hoteles_bajas] ON hoteles.id = hoteles_bajas.hotel_id ";
            query += " WHERE fecha_desde BETWEEN '" + fecha1 + "' AND '" + fecha2 + "' ";
            query += " GROUP BY hotel_id ORDER BY 2 DESC";


            SqlCommand command = new SqlCommand(query, ConnectionManager.getInstance().getConnection());
            using (SqlDataReader result = command.ExecuteReader())
            {
                while (result.Read())
                {
                    HotelesReservasCanceladas reserva_cancelada = new HotelesReservasCanceladas();
                    Hotel hotel_temporal = new Hotel();
                    hotel_temporal.id = Convert.ToInt32(result["hotel_id"].ToString());
                    reserva_cancelada.hotel = hotel_temporal;
                    reserva_cancelada.cantidad = Convert.ToInt32(result["cantidad_dias"]);

                    hoteles.Add(reserva_cancelada);
                }
            }

            hoteles.ForEach(h => h.hotel = EntityManager.getEntityManager().findById<Hotel>(h.hotel.id));

            //List<HotelesReservasCanceladas> hoteles = EntityManager.getEntityManager().findAll<HotelesReservasCanceladas>();
            dataGridView1.DataSource = hoteles;
        }


        /* TODO faltan las fechas */
        private void HabitacionConMayorCantidadDeDiasYVecesOcupada()
        {

            var query = "SELECT habitaciones.id, hoteles.calle, hoteles.ciudad, ";

            query += " (SELECT COUNT(*) FROM [" + Config.getInstance().schema + "].[estadias] ";
            query += " INNER JOIN [" + Config.getInstance().schema + "].[reservas] ON estadias.reserva_id = reservas.id";
            query += " INNER JOIN [" + Config.getInstance().schema + "].[reservas_habitaciones] ON reservas_habitaciones.reserva_id = reservas.id";
            query += " WHERE reservas_habitaciones.habitacion_id = habitaciones.id";
            query += " AND estadias.fecha_inicio > '" + fecha1 + "'";     
            query += " ) veces, ";

            query += " (SELECT ISNULL(SUM(estadias.cant_noches), 0) FROM [" + Config.getInstance().schema + "].[estadias] ";
            query += " INNER JOIN [" + Config.getInstance().schema + "].[reservas] ON estadias.reserva_id = reservas.id";
            query += " INNER JOIN [" + Config.getInstance().schema + "].[reservas_habitaciones] ON reservas_habitaciones.reserva_id = reservas.id";
            query += " WHERE reservas_habitaciones.habitacion_id = habitaciones.id";
            query += " AND estadias.fecha_inicio > '" + fecha1 + "'";
            query += " ) cantidad_noches ";
            
            query += " FROM [LOS_NORMALIZADORES].[habitaciones] ";
            query += " INNER JOIN [" + Config.getInstance().schema + "].[hoteles] ON habitaciones.hotel_id = hoteles.id";

            List<HabitacionTrending> habitaciones = new List<HabitacionTrending>();

            SqlCommand command = new SqlCommand(query, ConnectionManager.getInstance().getConnection());
            using (SqlDataReader result = command.ExecuteReader())
            {
                while (result.Read())
                {
                    HabitacionTrending habitacion = new HabitacionTrending();
                    habitacion.habitacion_id = Convert.ToInt32(result["id"]);
                    habitacion.cantidad_veces = Convert.ToInt32(result["veces"]);
                    habitacion.cantidad_noches = Convert.ToInt32(result["cantidad_noches"]);
                    habitacion.Hotel = result["ciudad"].ToString() + " - " + result["calle"].ToString();
                    habitaciones.Add(habitacion);
                }
            }


            dataGridView1.DataSource = habitaciones;

        }



        /* TODO ver esto */
        /* Cliente con mayor cantidad de puntos, donde cada $10 en estadías vale 1 puntos */
        /* y cada $5 de consumibles es 1 punto, de la sumatoria de todas las facturaciones que haya tenido */
        /* dentro de un periodo independientemente del Hotel. */
        /* Tener en cuenta que la facturación siempre es a quien haya realizado la reserva. */
        private void ClienteConMasPuntos()
        {


            var query = "SELECT SUM((consumidos/5) + (habitaciones/10)) as puntos, clientes.id as cliente_id ";
            query += " FROM [LOS_NORMALIZADORES].[gastos_estadia] ";
            query += " INNER JOIN [" + Config.getInstance().schema + "].[clientes] ON clientes.id = gastos_estadia.cliente_id";
            query += " WHERE fecha > '" + fecha1 + "'";
            query += " AND fecha < '" + fecha2 + "'";
            query += " GROUP BY clientes.id ";

            List<ClienteTrending> clientes = new List<ClienteTrending>();

            SqlCommand command = new SqlCommand(query, ConnectionManager.getInstance().getConnection());
            using (SqlDataReader result = command.ExecuteReader())
            {
                while (result.Read())
                {
                    ClienteTrending cliente = new ClienteTrending();
                    cliente.cliente_id = result["cliente_id"].ToString();
                    cliente.puntos = Convert.ToInt32(result["puntos"]);
                    clientes.Add(cliente);
                }
            }

            dataGridView1.DataSource = clientes;


        }



    }
}
