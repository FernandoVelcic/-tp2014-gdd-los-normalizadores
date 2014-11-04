using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyActiveRecord;
using FrbaHotel.Models;
using FrbaHotel.Database_Helper;
using FrbaHotel.Views.ABM_de_Cliente;
using FrbaHotel.Models.Exceptions;
using System.Data.SqlClient;


namespace FrbaHotel.Views.Registrar_Estadia
{
    public partial class Ingreso : Form, SeleccionCliente
    {
        public List<Cliente> clientes = new List<Cliente>();
        public Reserva reserva;
        
        public Ingreso(Reserva res)
        {
            reserva = res;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ABMCliente form = new ABM_de_Cliente.ABMCliente();
            form.Show();
            form.setModoSeleccionCliente(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AltaModificacionCliente form = new ABM_de_Cliente.AltaModificacionCliente();
            form.setModoSeleccion(this);
            form.Show();      
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                ReservaCliente reservaCliente = new ReservaCliente();

                Cliente cliente = row.DataBoundItem as Cliente;
                reservaCliente.cliente = cliente;
                reservaCliente.reserva = this.reserva;

                try
                {
                    reservaCliente.save();
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
            }
            MessageBox.Show("Reserva confirmada con exito");
        }
      
    
        /* Cuando se selecciona un cliente */
        void SeleccionCliente.clienteSeleccionado(Cliente cliente)
        {
            if (cliente.estado == false)
            {
                MessageBox.Show("Este cliente no tiene permitido hacer el check-in");
                return;
            }

            if( clientes.Any(elemento => elemento.id == cliente.id) )
            {
                MessageBox.Show("Este cliente ya se encuentra en la grilla");
                return;
            }
           clientes.Add(cliente);
           listar();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                Cliente cliente = row.DataBoundItem as Cliente;
                Cliente borrado = clientes.Find(elemento => elemento.id ==cliente.id);
                clientes.Remove(borrado);
            }
            listar();
        }

        private void listar()
        {
            var clientesBinding = new BindingList<Cliente>(clientes);
            dataGridView1.DataSource = new BindingSource(clientesBinding, null);
        }
    }
}
