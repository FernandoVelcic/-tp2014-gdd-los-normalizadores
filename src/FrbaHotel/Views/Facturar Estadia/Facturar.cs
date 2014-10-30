using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel.Views.Facturar_Estadia
{
    public partial class Facturar : Form
    {
        public Facturar()
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(Facturar_FormClosing);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string forma_de_pago = comboBox1.SelectedItem.ToString();
            //armar el registro de la factura
            //cerrar y volver a operaciones
        }

        void Facturar_FormClosing(object sender, FormClosingEventArgs e)
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string forma_de_pago = comboBox1.SelectedItem.ToString();
            if (forma_de_pago == "Tarjeta de Crédito" || forma_de_pago == "Tarjeta de Débito") activarDatosTarjeta();
            if (forma_de_pago == "Efectivo") desactivarDatosTarjeta();
        }

      public void activarDatosTarjeta(){
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
