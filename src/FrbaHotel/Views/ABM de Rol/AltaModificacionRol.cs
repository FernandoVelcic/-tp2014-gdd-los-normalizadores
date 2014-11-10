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

            if (!esAlta)
            {
                checkedListBox1.SetItemChecked(0, rol.ABM_Rol);
                checkedListBox1.SetItemChecked(1, rol.ABM_Habitación);
                checkedListBox1.SetItemChecked(2, rol.ABM_Cliente);
                checkedListBox1.SetItemChecked(3, rol.ABM_Usuario);
                checkedListBox1.SetItemChecked(4, rol.ABM_Regimen);
                checkedListBox1.SetItemChecked(5, rol.ABM_Hotel);
                checkedListBox1.SetItemChecked(6, rol.Generar_Reserva);
                checkedListBox1.SetItemChecked(7, rol.Cancelar_Reserva);
                checkedListBox1.SetItemChecked(9, rol.Registrar_Estadía);
                checkedListBox1.SetItemChecked(11, rol.Listado_Estadístico);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            rol.ABM_Rol = checkedListBox1.GetItemChecked(0);
            rol.ABM_Habitación = checkedListBox1.GetItemChecked(1);
            rol.ABM_Cliente = checkedListBox1.GetItemChecked(2);
            rol.ABM_Usuario = checkedListBox1.GetItemChecked(3);
            rol.ABM_Regimen = checkedListBox1.GetItemChecked(4);
            rol.ABM_Hotel = checkedListBox1.GetItemChecked(5);
            rol.Generar_Reserva = checkedListBox1.GetItemChecked(6);
            rol.Cancelar_Reserva = checkedListBox1.GetItemChecked(7);
            rol.Registrar_Estadía = checkedListBox1.GetItemChecked(9);
            rol.Listado_Estadístico = checkedListBox1.GetItemChecked(11);

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
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
