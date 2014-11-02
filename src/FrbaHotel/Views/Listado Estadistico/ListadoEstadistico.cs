using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel.Listado_Estadistico
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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
            int anio = int.Parse(textBox1.Text);
            string trimestre = comboBox2.SelectedItem.ToString();
            string categoria = comboBox1.SelectedItem.ToString();
            switch (comboBox1.SelectedIndex)
            {
                case 0: //Hotel con mayor cantidad de reservas canceladas
                    break;

                case 1: //Hotel con mayor cantidad de consumibles facturados
                    break;

                case 2: //Hotel con mayor cantidad de días fuera de servicio
                    break;

                case 3: //Habitacion con mayor cantidad de días y veces ocupada
                    break;

                case 4: //Cliente con mayor cantidad de puntos
                    break;
            }
            //seleccionarTop(anio, trimestre, categoria)  //logica que falta
        }
    }
}
