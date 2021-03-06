﻿using System;
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

        public void Recargar()
        {
            textBox1.Text = "";
            textBox3.Text = "";
            cmb_Hoteles.SelectedIndex = -1;
            comboBox1.SelectedIndex = -1;
            cmb_TipoHabitacion.SelectedIndex = -1;
            Listar(new List<FetchCondition>());
        }


        private void Listar(List<FetchCondition> conditions)
        {
            var habitacionesBinding = new BindingList<Habitacion>(EntityManager.getEntityManager().findList<Habitacion>(conditions));
            dataGridView1.DataSource = new BindingSource(habitacionesBinding, null);
        }

        private void onBtnModificar(object sender, EventArgs e)
        {
            this.editRecord<Habitacion, FrbaHotel.Views.ABM_de_Habitacion.AltaModificacionHabitacion>(dataGridView1);
        }

        private void onBtnAlta(object sender, EventArgs e)
        {
            Navigator.nextForm(this,new FrbaHotel.Views.ABM_de_Habitacion.AltaModificacionHabitacion(this));
        }

        private void onBtnEliminar(object sender, EventArgs e)
        {
            this.deleteRecord(dataGridView1);
            btn_Filtrar_Click(null, null);
        }


        private void btn_Filtrar_Click(object sender, EventArgs e)
        {
            List<FetchCondition> condiciones = new List<FetchCondition>();

            FetchCondition condicionNumero = new FetchCondition();
            condicionNumero.setLike("numero", textBox1.Text);
            condiciones.Add(condicionNumero);

            FetchCondition condicionPiso = new FetchCondition();
            condicionPiso.setLike("piso", textBox3.Text);
            condiciones.Add(condicionPiso);

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

            if (comboBox1.Text != "")
            {
                FetchCondition condicionVistaExterior = new FetchCondition();
                condicionVistaExterior.setEquals("frente", comboBox1.Text);
                condiciones.Add(condicionVistaExterior);
            }

            Listar(condiciones);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Recargar();
        }


          
    }
}
