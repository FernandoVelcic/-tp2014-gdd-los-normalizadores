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

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            textBox1.Text = "";
            textBox2.Text = "";
            comboBox1.SelectedIndex = -1;
            dataGridView1.Rows.Clear();

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            int anio = int.Parse(textBox1.Text);
            int trimestre = int.Parse(textBox2.Text);
            string categoria = comboBox1.SelectedItem.ToString();
            //seleccionarTop(anio, trimestre, categoria)  //logica que falta
        }

       
    }
}
