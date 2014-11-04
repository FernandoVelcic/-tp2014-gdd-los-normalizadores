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
using FrbaHotel.Models.Exceptions;
using FrbaHotel.Database_Helper;

using FrbaHotel.Homes;

namespace FrbaHotel.Views.ABM_de_Hotel
{
    public partial class AltaModificacionHotel : Form
    {
        private Boolean esAlta = false;
        private Hotel hotel;

        public AltaModificacionHotel() : this(new Hotel())
        {
            esAlta = true;
            hotel.fecha_creacion = DateTime.Today.ToString();
        }

        public AltaModificacionHotel(Hotel hotel)
        {
            InitializeComponent();
            this.hotel = hotel;
        }

        private void AltaModificacionHotel_Load(object sender, EventArgs e)
        {
            //Binding nacionalidad
            BindingSource nacionalidad_binding = new BindingSource();
            nacionalidad_binding.DataSource = EntityManager.getEntityManager().findAll<Pais>();
            comboBox4.DataSource = nacionalidad_binding;
            comboBox4.DisplayMember = "nombre";
            if (!esAlta)
                comboBox4.Text = hotel.pais.nombre;

            //Binding lista de regimenes
            BindingSource regimenes_binding = new BindingSource();
            regimenes_binding.DataSource = EntityManager.getEntityManager().findAll<Regimen>();
            comboBox3.DataSource = regimenes_binding;

            //Binding lista de regimenes que ofrece
            if (!esAlta)
            {
                //Lista de regimenes que ya poseia
                List<HotelRegimen> regimenes_hotel = EntityManager.getEntityManager().findAllBy<HotelRegimen>("hotel_id", hotel.id.ToString());
                regimenes_hotel.ForEach(r => listBox1.Items.Add(r));
            }

            //Binding varios
            textBox1.DataBindings.Add("Text", hotel, "nombre");
            textBox2.DataBindings.Add("Text", hotel, "mail");
            textBox3.DataBindings.Add("Text", hotel, "telefono");
            textBox4.DataBindings.Add("Text", hotel, "calle");
            textBox8.DataBindings.Add("Text", hotel, "nro_Calle");
            textBox5.DataBindings.Add("Text", hotel, "cant_estrella");
            textBox6.DataBindings.Add("Text", hotel, "ciudad");
            dateTimePicker1.DataBindings.Add("Text", hotel, "fecha_creacion", true);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            hotel.pais = comboBox4.SelectedItem as Pais;

            if (listBox1.Items.Count == 0)
            {
                MessageBox.Show("Debe agregar al menos un regimen para el hotel");
                return;
            }

            try
            {
                hotel.save();

                if (esAlta) //Si se da de alta hay que agregarle al administrador este hotel
                {
                    RolUsuario rol_nuevo = new RolUsuario();
                    rol_nuevo.rol = SesionActual.rol_usuario.rol;
                    rol_nuevo.usuario = SesionActual.rol_usuario.usuario;
                    rol_nuevo.hotel = hotel;
                    rol_nuevo.insert();
                }

                foreach (HotelRegimen hotelRegimen in listBox1.Items)
                {
                    hotelRegimen.save();
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

            if (esAlta)
                MessageBox.Show("Hotel creado correctamente!");
            else
                MessageBox.Show("Hotel modificado correctamente!");

            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            HotelRegimen hotel_regimen = new HotelRegimen();
            hotel_regimen.regimen = comboBox3.SelectedItem as Regimen;
            hotel_regimen.hotel = hotel;

            foreach (HotelRegimen hotelRegimen in listBox1.Items)
            {
                if (hotelRegimen.regimen == hotel_regimen.regimen)
                {
                    MessageBox.Show("Este hotel ya posee este régimen");
                    return;
                }
            }

            listBox1.Items.Add(hotel_regimen);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            HotelRegimen regimen = listBox1.SelectedItem as HotelRegimen;
            if (!esAlta)
            {
                List<ReservaHabitacion> reservas_habitaciones = EntityManager.getEntityManager().findAllBy<ReservaHabitacion>("habitaciones.hotel_id", hotel.id.ToString());
                List<Reserva> reservas = new List<Reserva>();

                //HACK porque el ORM no llega a mappear a ese nivel de profundidad
                reservas_habitaciones.ForEach(r => reservas.Add(EntityManager.getEntityManager().findById<Reserva>(r.reserva.id)));
                //Reservas no canceladas, no tener en cuenta las que ya pasaron y ver que sean del regimen que se quiere borrar
                reservas = reservas.FindAll(r => !r.estaCancelada() && DateTime.Parse(r.fecha_inicio).AddDays(r.cant_noches) >= Config.getInstance().getCurrentDate() && r.regimen.id == regimen.regimen.id);

                if(reservas.Count != 0)
                {
                    MessageBox.Show("No se puede eliminar este regimen dado que hay reservas tomadas");
                    return;
                }
                
                regimen.delete();
            }
                
            listBox1.Items.Remove(listBox1.SelectedItem);
        }
    }
}
