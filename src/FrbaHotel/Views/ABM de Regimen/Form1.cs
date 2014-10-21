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

namespace FrbaHotel.ABM_de_Regimen
{
    public partial class Form1 : Form
    {

        Regimen regimen;

        public Form1(Regimen regimen)
        {
            InitializeComponent();
            this.regimen = regimen;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void bnt_Confirmar_Click(object sender, EventArgs e)
        {
            try
            {
                bindFromForm();
                regimen.save();
                MessageBox.Show("El regimen se guardo correctamente");
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


        private void bindFromForm()
        {
            regimen.codigo = txt_Codigo.Text;
            regimen.descripcion = txt_Descripcion.Text;
            regimen.precio = Single.Parse(txt_PrecioBase.Text);
            regimen.estado = radio_Activo.Checked;
        }

        private void bindFromObject()
        {
            txt_Codigo.Text = regimen.codigo;
            txt_Descripcion.Text = regimen.descripcion;
            txt_PrecioBase.Text = regimen.precio.ToString();
            radio_Activo.Checked = regimen.estado;
        }




    }
}
