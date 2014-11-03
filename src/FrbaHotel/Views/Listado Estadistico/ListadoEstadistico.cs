using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using FrbaHotel.Models.Listado_Estadistico;
using FrbaHotel.Database_Helper;

namespace FrbaHotel.Listado_Estadistico
{
    public partial class Form1 : Form
    {
        private int anio;

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
            DateTime fecha1, fecha2;
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
                    List<HotelesReservasCanceladas> hoteles = EntityManager.getEntityManager().findAll<HotelesReservasCanceladas>();
                    hoteles = hoteles.OrderByDescending(h => h.cantidad).Take(5).ToList();

                    dataGridView1.DataSource = hoteles;
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
    }
}
