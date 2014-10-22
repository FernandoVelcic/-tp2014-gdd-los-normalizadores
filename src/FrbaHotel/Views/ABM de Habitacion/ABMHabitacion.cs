using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Models;
using FrbaHotel.Database_Helper;
using MyActiveRecord;

namespace FrbaHotel.Views.ABM_de_Habitacion
{
    public partial class ABMHabitacion : Form
    {
        public ABMHabitacion()
        {
            InitializeComponent();
        }

        private void ABMHabitacion_Load(object sender, EventArgs e)
        {
            Listar(new List<FetchCondition>());
            setUpComboBoxes();
        }


        private void Listar(List<FetchCondition> conditions)
        {
            var habitacionesBinding = new BindingList<Habitacion>(EntityManager.getEntityManager().findList<Habitacion>(conditions));
            dataGridView1.DataSource = new BindingSource(habitacionesBinding, null);
        }

        private void setUpComboBoxes()
        {
            BindingSource hoteles_binding = new BindingSource();
            hoteles_binding.DataSource = EntityManager.getEntityManager().findAll<Hotel>();
            cmb_Hoteles.DataSource = hoteles_binding;
            cmb_Hoteles.DisplayMember = "calle";

            BindingSource tipo_habitacion_binding = new BindingSource();
            tipo_habitacion_binding.DataSource = EntityManager.getEntityManager().findAll<TipoHabitacion>();
            cmb_TipoHabitacion.DataSource = tipo_habitacion_binding;
            cmb_TipoHabitacion.DisplayMember = "descripcion";

        }


        private void onBtnModificar(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("¿Esta seguro que desea modificar este registro?", "Modificar registro", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

            if (dr == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
                {
                    Habitacion regimen = row.DataBoundItem as Habitacion;
                    //modificar
                    //dataGridView1.Rows.RemoveAt(row.Index);
                    MessageBox.Show("Registro modificado correctamente");
                }
            } 
        }

        private void onBtnAlta(object sender, EventArgs e)
        {
            new FrbaHotel.ABM_de_Habitacion.Form1(new Habitacion()).Show();
        }

        private void onBtnEliminar(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("¿Esta seguro que desea borrar este registro?", "Borrar registro", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

            if (dr == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
                {
                    Habitacion habitacion = row.DataBoundItem as Habitacion;
                    habitacion.logicalDelete();
                    //dataGridView1.Rows.RemoveAt(row.Index);
                    MessageBox.Show("Registro borrado correctamente");
                }
            }
        }


        private void btn_Filtrar_Click(object sender, EventArgs e)
        {
            List<FetchCondition> condiciones = new List<FetchCondition>();

            FetchCondition condicionHotel = new FetchCondition();
            Hotel hotelSeleccionado = (Hotel)cmb_Hoteles.SelectedItem;
            condicionHotel.setEquals("hoteles.id", hotelSeleccionado.id.ToString());
            condiciones.Add(condicionHotel);

            FetchCondition condicionTipoHabitacion = new FetchCondition();
            TipoHabitacion tipoHabitacionSeleccionada = (TipoHabitacion) cmb_TipoHabitacion.SelectedItem;
            condicionTipoHabitacion.setEquals("habitaciones_tipos.id", tipoHabitacionSeleccionada.id.ToString());
            condiciones.Add(condicionTipoHabitacion);

            Listar(condiciones);
        }


          
    }
}
