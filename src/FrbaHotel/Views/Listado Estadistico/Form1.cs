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
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);

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
            //seleccionarTop(anio, trimestre, categoria)  //logica que falta
        }

        void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            switch (e.CloseReason)  //la opcion de cierre que suceda, aunque podria ser default
            {
                case CloseReason.ApplicationExitCall:
                    break;
                case CloseReason.FormOwnerClosing:
                    break;
                case CloseReason.MdiFormClosing:
                    break;
                case CloseReason.None:
                    break;
                case CloseReason.TaskManagerClosing:
                    break;
                case CloseReason.UserClosing:
                    //this.nextform….               
                    break;
                case CloseReason.WindowsShutDown:
                    break;
                default:
                    break;
            }


        }

       
    }
}
