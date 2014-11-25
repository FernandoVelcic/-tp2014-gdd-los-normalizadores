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
        List<ConsumibleEstadia> items = new List<ConsumibleEstadia>();

        public int unidades { get; set; }

        public Form1(Estadia estadia)
        {
            this.estadia = estadia;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.cargarConsumibles();

            //Bindeo de todos los consumibles con el combo box
            BindingSource consumibles_binding = new BindingSource();
            consumibles_binding.DataSource = EntityManager.getEntityManager().findAll<Consumible>();
            comboBox1.DataSource = consumibles_binding;

            //Bindeo del nro de reserva y el tipo de regimen con los text box
            Reserva reserva = EntityManager.getEntityManager().findBy<Reserva>("reservas.id", estadia.reserva.id.ToString());
            txt_reserva_id.Text = estadia.reserva.id.ToString();
            txt_TipoRegimen.Text = reserva.regimen.descripcion;

            txt_UnidadesArticulo.DataBindings.Add("Text", this, "unidades");
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
            Consumible consumible_seleccionado = comboBox1.SelectedItem as Consumible;

            if (unidades <= 0)
            {
                MessageBox.Show("Debe ingresar cantidades positivas");
                txt_UnidadesArticulo.Text = "";
                return;
            }

            if (items.Exists(item => item.consumible.id == consumible_seleccionado.id))
            {
                MessageBox.Show("Este consumible ya se encuentra en la lista, modifique la cantidad");
                return;
            }

            //Crea el consumible a persistir
            ConsumibleEstadia consumible_estadia = new ConsumibleEstadia();
            consumible_estadia.estadia = estadia;
            consumible_estadia.consumible = consumible_seleccionado;
            consumible_estadia.unidades = unidades;
            items.Add(consumible_estadia);
            
            cargarConsumibles();
        }

        private void cargarConsumibles()
        {
            //Bindea los items ya ingresado con el datagrid donde se va actualizando
            BindingList<ConsumibleItemsUnidades> consumibleUnidadesBinding = new BindingList<ConsumibleItemsUnidades>();
            items.ForEach(i => consumibleUnidadesBinding.Add(new ConsumibleItemsUnidades(i)));
            dataGridView1.DataSource = new BindingSource(consumibleUnidadesBinding, null);
        }


        private void btn_Facturar_Click(object sender, EventArgs e)
        {
            //Confirmacion de consumibles, para seguir con la facturacion
            DialogResult result1 = MessageBox.Show("¿Está seguro que ya ingreso todo lo consumido y desea facturar?", "Importante", MessageBoxButtons.YesNo);
            if (result1 == DialogResult.Yes)
            {
                Navigator.nextForm(this, new FrbaHotel.Views.Facturar_Estadia.Facturar(estadia));
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Borrado de un item consumible ingresado
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
            cargarConsumibles();
        }

    }
}
