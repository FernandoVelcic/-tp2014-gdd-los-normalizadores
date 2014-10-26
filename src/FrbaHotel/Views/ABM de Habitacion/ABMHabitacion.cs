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
            BindingSource hoteles_binding = new BindingSource();
            hoteles_binding.DataSource = EntityManager.getEntityManager().findAll<Hotel>();
            cmb_Hoteles.DataSource = hoteles_binding;
            cmb_Hoteles.DisplayMember = "calle";
            cmb_Hoteles.Text = "";

            BindingSource tipo_habitacion_binding = new BindingSource();
            tipo_habitacion_binding.DataSource = EntityManager.getEntityManager().findAll<TipoHabitacion>();
            cmb_TipoHabitacion.DataSource = tipo_habitacion_binding;
            cmb_TipoHabitacion.DisplayMember = "descripcion";
            cmb_TipoHabitacion.Text = "";

            Listar(new List<FetchCondition>());
        }


        private void Listar(List<FetchCondition> conditions)
        {
            var habitacionesBinding = new BindingList<Habitacion>(EntityManager.getEntityManager().findList<Habitacion>(conditions));
            dataGridView1.DataSource = new BindingSource(habitacionesBinding, null);
        }

        private void onBtnModificar(object sender, EventArgs e)
        {
            this.editRecord<Habitacion, FrbaHotel.ABM_de_Habitacion.AltaModificacionHabitacion>(dataGridView1);
        }

        private void onBtnAlta(object sender, EventArgs e)
        {
            this.nextForm(new FrbaHotel.ABM_de_Habitacion.AltaModificacionHabitacion());
        }

        private void onBtnEliminar(object sender, EventArgs e)
        {
            this.deleteRecord(dataGridView1);
        }


        private void btn_Filtrar_Click(object sender, EventArgs e)
        {
            List<FetchCondition> condiciones = new List<FetchCondition>();

            FetchCondition condicionNumero = new FetchCondition();
            condicionNumero.setLike("numero", textBox1.Text);
            condiciones.Add(condicionNumero);

            if (cmb_Hoteles.Text != "")
            {
                FetchCondition condicionHotel = new FetchCondition();
                Hotel hotelSeleccionado = cmb_Hoteles.SelectedItem as Hotel;
                condicionHotel.setEquals("hoteles.id", hotelSeleccionado.id.ToString());
                condiciones.Add(condicionHotel);
            }

            if (cmb_TipoHabitacion.Text != "")
            {
                FetchCondition condicionTipoHabitacion = new FetchCondition();
                TipoHabitacion tipoHabitacionSeleccionada = cmb_TipoHabitacion.SelectedItem as TipoHabitacion;
                condicionTipoHabitacion.setEquals("habitaciones_tipos.id", tipoHabitacionSeleccionada.id.ToString());
                condiciones.Add(condicionTipoHabitacion);
            }

            Listar(condiciones);
        }


          
    }
}
