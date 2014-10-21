using FrbaHotel.Models;
using FrbaHotel.Models.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel.Generar_Modificar_Reserva
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

        private void btn_Volver_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private Reserva bindFromForm()
        {
            Reserva  reserva = new Reserva();
            return reserva;
        }

        private void btn_Generar_Click(object sender, EventArgs e)
        {

            Reserva reserva = bindFromForm();
            try
            {
                reserva.save();
                MessageBox.Show("La reserva se genero corractamente");
                this.Close();
            }
            catch (ValidationException exception)
            {
                MessageBox.Show(exception.Message);
            }
            catch (SqlException exception)
            {
                MessageBox.Show(exception.Message);
            }

        }



    }
}
