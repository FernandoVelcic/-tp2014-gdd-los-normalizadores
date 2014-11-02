using FrbaHotel.Database_Helper;
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
        Regimen regimen;

        public Form1(Regimen r)
        {
            regimen = r;
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
           //var consumiblesBinding = new BindingList<Consumible>(EntityManager.getEntityManager().findAll<Consumible>());
            //dataGridView1.DataSource = new BindingSource(consumiblesBinding, null);
            
            BindingSource consumibles_binding = new BindingSource();
            consumibles_binding.DataSource = EntityManager.getEntityManager().findAll<Consumible>();
            comboBox1.DataSource = consumibles_binding;
            comboBox1.Text = "";

            textBox5.Text = regimen.descripcion;

        }

        private void btn_Volver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //modificar el que esta seleccionado en el datagrid
        }

        private void btn_Agregar_Click(object sender, EventArgs e)
        {
            ConsumibleEstadia consumible_estadia = new ConsumibleEstadia();

            int unidades = int.Parse(textBox4.Text);    //chequear si va, para mi deberia, pero en la tabla no está
            Consumible consumible_seleccionado = comboBox1.SelectedItem as Consumible;

            consumible_estadia.estadia_codigo = regimen.codigo;
            consumible_estadia.consumible_codigo = consumible_seleccionado.codigo;
            consumible_estadia.unidades = unidades;

            consumible_estadia.save();
         }

       

       


    }
}
