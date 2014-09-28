using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ir_a_login();
        }

       
        private void salirToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void administradorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ir_a_login();
        }

        private void ir_a_login()
        {
            //this.Hide();
            Form login = new FrbaHotel.Login.Form1();
            login.Show();
        }

        private void recepcionistaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ir_a_login();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form medio = new FrbaHotel.Form2();
            medio.Show();
        }
    }
}
