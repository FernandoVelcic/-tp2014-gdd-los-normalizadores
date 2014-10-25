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
    public partial class AltaModificacionRegimen : Form
    {
        private Regimen regimen;

        public AltaModificacionRegimen() : this(new Regimen())
        {

        }

        public AltaModificacionRegimen(Regimen regimen)
        {
            InitializeComponent();
            this.regimen = regimen;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txt_Codigo.DataBindings.Add("Text", regimen, "codigo");
            txt_Descripcion.DataBindings.Add("Text", regimen, "descripcion");
            txt_PrecioBase.DataBindings.Add("Text", regimen, "precio");
            radio_Activo.DataBindings.Add("Checked", regimen, "estado");
        }

        private void bnt_Confirmar_Click(object sender, EventArgs e)
        {
            try
            {
                regimen.save();
            }
            catch (ValidationException exception)
            {
                MessageBox.Show(exception.Message);
            }
            catch (SqlException exception)
            {
                MessageBox.Show(exception.Message);
            }
            MessageBox.Show("El regimen se guardo correctamente");
            this.nextForm(new FrbaHotel.Views.ABM_de_Rol.ABMRol());
        }

        private void btn_Volver_Click(object sender, EventArgs e)
        {
            this.nextForm(new FrbaHotel.Views.ABM_de_Rol.ABMRol());
        }
    }
}
