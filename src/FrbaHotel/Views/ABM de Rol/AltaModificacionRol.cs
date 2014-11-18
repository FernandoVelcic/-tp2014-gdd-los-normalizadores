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

namespace FrbaHotel.Views.ABM_de_Rol
{
    public partial class AltaModificacionRol : Form
    {
        private Boolean esAlta = false;
        private ABMRol formAnterior;

        private Rol rol;

        public AltaModificacionRol(ABMRol formAnterior) : this(new Rol())
        {
            esAlta = true;
            this.formAnterior = formAnterior;

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

            BindingSource funcionalidades_binding = new BindingSource();
            funcionalidades_binding.DataSource = EntityManager.getEntityManager().findAll<Funcionalidad>();
            list_Funcionalidades.DataSource = funcionalidades_binding;

            if (!esAlta)
            {
                List<RolFuncionalidad> funcionalidades = rol.getFuncionalidades();

                for (int i = 0; i < list_Funcionalidades.Items.Count; i++)
                {
                    Funcionalidad funcionalidad = list_Funcionalidades.Items[i] as Funcionalidad;
                    list_Funcionalidades.SetSelected(i, funcionalidades.Exists(f => f.funcionalidad.id == funcionalidad.id));
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                rol.save();

                if (!esAlta)
                {
                    List<RolFuncionalidad> funcionalidades = rol.getFuncionalidades();
                    funcionalidades.ForEach(f => f.delete());
                }

                foreach (Funcionalidad funcionalidad in list_Funcionalidades.SelectedItems)
                {
                    RolFuncionalidad rol_funcionalidad = new RolFuncionalidad();
                    rol_funcionalidad.funcionalidad = funcionalidad;
                    rol_funcionalidad.rol = rol;
                    rol_funcionalidad.insert();
                }
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

            if (esAlta)
            {
                formAnterior.Recargar();
                MessageBox.Show("Rol creado correctamente!");
            }
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
