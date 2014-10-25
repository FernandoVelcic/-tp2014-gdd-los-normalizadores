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
using FrbaHotel.Database_Helper;
using FrbaHotel.Views.ABM_de_Rol;
using FrbaHotel.Models.Exceptions;

namespace FrbaHotel.ABM_de_Rol
{
    public partial class AltaModificacionRol : Form
    {
        private Rol rol;

        public AltaModificacionRol() : this(new Rol())
        {
            
        }

        public AltaModificacionRol(Rol rol)
        {
            this.rol = rol;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            rol.descripcion=textBox1.Text;
            if (radioButton1.Checked) rol.estado = true;
            if (radioButton2.Checked) rol.estado = false;
            //Falta saber como quieren que se guarde el listado de cada rol
            CheckedListBox.CheckedItemCollection listaSeleccionados = checkedListBox1.CheckedItems;
            try
            {
                rol.save();
            }
            catch (ValidationException exception)
            {
                MessageBox.Show(exception.Message);
            }
            catch (SqlException exception)
            {
                MessageBox.Show(exception.Message);
            }

            MessageBox.Show("Rol creado correctamente!");
            this.nextForm(new ABMRol());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.nextForm(new ABMRol());
        }
    }
}
