using FrbaHotel.Database_Helper;
using FrbaHotel.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using FrbaHotel.Homes;
using System.Globalization;
using System.Windows.Forms;

using MyActiveRecord;

namespace FrbaHotel.Registrar_Consumible
{
    public partial class Form1 : Form
    {
        Estadia estadia;
        List<ItemAFacturar> items= new List<ItemAFacturar>();

        public Form1(Estadia e)
        {
            estadia = e;
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.cargarConsumibles();

            comboBox1.Items.Clear();

            BindingSource consumibles_binding = new BindingSource();
            consumibles_binding.DataSource = EntityManager.getEntityManager().findAll<Consumible>();
            comboBox1.DataSource = consumibles_binding;
             
            
            txt_reserva_id.Text = estadia.reserva.id.ToString();
            Reserva resInter=estadia.reserva;
            Reserva reserva = EntityManager.getEntityManager().findBy<Reserva>("reservas.id", resInter.id.ToString());
            Regimen reg = reserva.regimen;
            Regimen regimen = EntityManager.getEntityManager().findBy<Regimen>("regimenes.id", reg.id.ToString());
            txt_TipoRegimen.Text = regimen.descripcion;

        }

        private void btn_Volver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Modificar_Click(object sender, EventArgs e)
        {
            this.editRecord<ConsumibleItemsUnidades, FrbaHotel.Registrar_Consumible.ModificacionConsumible>(dataGridView1);
        }

        private void btn_Agregar_Click(object sender, EventArgs e)
        {
            if (int.Parse(txt_UnidadesArticulo.Text) < 0)
            {
                MessageBox.Show("Debe ingresar cantidades positivas");
                txt_UnidadesArticulo.Text = "";
                return;
            }

            ItemAFacturar consumible_estadia = new ItemAFacturar();

            int unidades = int.Parse(txt_UnidadesArticulo.Text);    //chequear si va, para mi deberia, pero en la tabla no está
            Consumible consumible_seleccionado = comboBox1.SelectedItem as Consumible;

            if (items.Exists(item => item.consumible.id == consumible_seleccionado.id))
            {
                MessageBox.Show("Este consumible ya se encuentra en la lista, modifique la cantidad");
                return;
            }

            consumible_estadia.estadia = estadia;
            consumible_estadia.consumible = consumible_seleccionado;
            consumible_estadia.unidades = unidades;
            consumible_estadia.monto = unidades * consumible_seleccionado.precio;
            items.Add(consumible_estadia);
            this.cargarConsumibles();
         }

        private void cargarConsumibles()
        {
           
            BindingList<ConsumibleItemsUnidades> consumibleUnidadesBinding = new BindingList<ConsumibleItemsUnidades>();
            foreach (ItemAFacturar consumibleEstadia in items)
            {
                ConsumibleItemsUnidades consumibleUnidades = new ConsumibleItemsUnidades();

                consumibleUnidades.codigo = consumibleEstadia.consumible.id;
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
                     Navigator.nextForm(this, new FrbaHotel.Views.Facturar_Estadia.Facturar(estadia, items));
            }

        }

        public bool IsNumeric(object Expression)
        {
            bool esnumero;
            double returnNumero;

            esnumero = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out returnNumero);
            return esnumero;
        }

        private void txt_UnidadesArticulo_TextChanged(object sender, EventArgs e)
        {
            if (!IsNumeric(txt_UnidadesArticulo.Text) && txt_UnidadesArticulo.Text != "") { 
                MessageBox.Show("Debe ingresar numeros unicamente"); txt_UnidadesArticulo.Text = "0"; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("¿Esta seguro que desea borrar este registro?", "Borrar registro", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

            if (dr == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    ConsumibleItemsUnidades record = row.DataBoundItem as ConsumibleItemsUnidades;
                    items.RemoveAll(item => item.consumible.id == record.codigo);
                    MessageBox.Show("Registro borrado correctamente");
                }
            }
            this.cargarConsumibles();
        }



       
    }
}
