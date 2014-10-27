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
        private Boolean esAlta = false;
        private Rol rol;

        public AltaModificacionRol() : this(new Rol())
        {
            esAlta = true;
            rol.estado = true;
        }

        public AltaModificacionRol(Rol rol)
        {
            InitializeComponent();
            this.rol = rol;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.DataBindings.Add("Text", rol, "descripcion");
            comboBox1.DataBindings.Add("SelectedIndex", rol, "estado");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Falta saber como quieren que se guarde el listado de cada rol
            CheckedListBox.CheckedItemCollection listaSeleccionados = checkedListBox1.CheckedItems;
            
            try
            {
                rol.save();
            }
            catch (ValidationException exception)
            {
                MessageBox.Show(exception.Message);
                return;
            }
            catch (SqlException exception)
            {
                MessageBox.Show(exception.Message);
                return;
            }

            if(esAlta)
                MessageBox.Show("Rol creado correctamente!");
            else
                MessageBox.Show("Rol modificado correctamente!");
            this.nextForm(new ABMRol());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.nextForm(new ABMRol());
        }
    }
}
