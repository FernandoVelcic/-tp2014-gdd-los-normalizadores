using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel.Login
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
      
       private void activar_cuadro_login()
        {
            groupBox2.Visible = true; 
            label1.Visible = true;
            textBox1.Visible = true;
            label2.Visible = true;
            textBox2.Visible = true;
        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            this.activar_cuadro_login();
        }

        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
        {
            this.activar_cuadro_login();
        }

        private void radioButton3_CheckedChanged_1(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
            label1.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            label2.Visible = false;
        }
      


    }
}
