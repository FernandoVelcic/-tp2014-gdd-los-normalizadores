﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
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
            Form login = new FrbaHotel.Login.Login();
            login.Show();
        }

        private void recepcionistaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ir_a_login();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form medio = new FrbaHotel.Operaciones();
            medio.Show();
        }
    }
}
