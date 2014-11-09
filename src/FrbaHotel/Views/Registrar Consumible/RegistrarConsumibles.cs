﻿using FrbaHotel.Database_Helper;
using FrbaHotel.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel.Registrar_Consumible
{
    public partial class Form1 : Form
    {
        Estadia estadia;

        public Form1(Estadia e)
        {
            estadia = e;
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            this.cargarConsumibles();
            
            BindingSource consumibles_binding = new BindingSource();
            consumibles_binding.DataSource = EntityManager.getEntityManager().findAll<Consumible>();
            cmb_DescripcionArticulo.DataSource = consumibles_binding;
            cmb_DescripcionArticulo.Text = "";

            txt_reserva_id.Text = estadia.reserva.id.ToString();
            txt_TipoRegimen.Text = estadia.reserva.regimen.descripcion;

        }

        private void btn_Volver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Modificar_Click(object sender, EventArgs e)
        {
            this.editRecord<ConsumibleItemsUnidades, FrbaHotel.Registrar_Consumible.ModificacionConsumible>(dataGridView1);
            
            //modificar el que esta seleccionado en el datagrid
        }

        private void btn_Agregar_Click(object sender, EventArgs e)
        {
            ItemFactura consumible_estadia = new ItemFactura();

            int unidades = int.Parse(txt_UnidadesArticulo.Text);    //chequear si va, para mi deberia, pero en la tabla no está
            Consumible consumible_seleccionado = cmb_DescripcionArticulo.SelectedItem as Consumible;

            consumible_estadia.estadia.id = estadia.id;
            consumible_estadia.consumible.codigo = consumible_seleccionado.codigo;
            consumible_estadia.unidades = unidades;
            consumible_estadia.monto = unidades * consumible_seleccionado.precio;

            consumible_estadia.save();
            this.cargarConsumibles();
         }

        private void cargarConsumibles()
        {
            List<ItemFactura> consumiblesEstadia = EntityManager.getEntityManager().findAllBy<ItemFactura>("estadia_id", estadia.id.ToString());

            BindingList<ConsumibleItemsUnidades> consumibleUnidadesBinding = new BindingList<ConsumibleItemsUnidades>();
            foreach (ItemFactura consumibleEstadia in consumiblesEstadia)
            {
                ConsumibleItemsUnidades consumibleUnidades = new ConsumibleItemsUnidades();

                consumibleUnidades.codigo = consumibleEstadia.consumible.codigo;
                consumibleUnidades.descripcion = consumibleEstadia.consumible.descripcion;
                consumibleUnidades.precio = consumibleEstadia.consumible.precio;
                consumibleUnidades.unidades = consumibleEstadia.unidades;
                consumibleUnidades.monto = consumibleEstadia.monto;

                consumibleUnidadesBinding.Add(consumibleUnidades);
            }
            dataGridView1.DataSource = new BindingSource(consumibleUnidadesBinding, null);
        }


        private void btn_Facturar_Click(object sender, EventArgs e)
        {

            DialogResult result1 = MessageBox.Show("¿Está seguro que ya ingreso todo lo consumido y desea facturar?","Importante",MessageBoxButtons.YesNo);
            if(result1==DialogResult.Yes)
            {
                     Navigator.nextForm(this, new FrbaHotel.Views.Facturar_Estadia.Facturar(estadia));
            }

        }

       
    }
}
