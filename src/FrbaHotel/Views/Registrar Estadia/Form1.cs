using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel;
using FrbaHotel.Database_Helper;

namespace FrbaHotel.Registrar_Estadia
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);

        }

      private void button1_Click(object sender, EventArgs e)
        {
            recopilarDatos();  
          // this.nextForm(new Registrar_Estadia();   //completar con ingreso
        }

        private void button2_Click(object sender, EventArgs e)
        {
            recopilarDatos();
            //validar si existe la reserva, e ir a registrar consumible para luego facturar
        }

        public void recopilarDatos()
        {
            int nroReserva = int.Parse(textBox2.Text);
            DateTime fecha = dateTimePicker1.Value;
            string usuario = textBox1.Text;
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
