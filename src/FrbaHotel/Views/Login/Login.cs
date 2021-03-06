﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using MyActiveRecord;
using System.Data.SqlClient;
using FrbaHotel.Tools;
using FrbaHotel.Models;
using FrbaHotel.Database_Helper;
using FrbaHotel.Views.Login;

namespace FrbaHotel.Login
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)textBox2.PasswordChar = '\0';
            if (!checkBox1.Checked) textBox2.PasswordChar = '*';

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String query;
            query = "DECLARE @Retintentos_fallidos int;";
            query += "EXECUTE " + Config.getInstance().schema + " .[uspLogin] @username = '" + textBox1.Text + "', @password = '" + new SHA256(textBox2.Text).ToString() + "', @intentos_fallidos = @Retintentos_fallidos OUTPUT;";
            query += "SELECT @Retintentos_fallidos;";
            SqlCommand command = new SqlCommand(query, ConnectionManager.getInstance().getConnection());
            int intentos_fallidos = System.Convert.ToInt32(command.ExecuteScalar());

            switch (intentos_fallidos)
            {
                case -3: //Usuario inhabilitado (estado = 0)
                    MessageBox.Show("Usuario inhabilitado");
                    break;
                case -2: //Usuario bloqueado (supero los intentos fallidos)
                    MessageBox.Show("Usuario bloqueado (Supero los tres intentos fallidos)");
                    break;
                case -1: //Usuario y contraseña invalida
                    MessageBox.Show("Usuario y contraseña invalida");
                    break;
                case 0: //Login correcto
                    MessageBox.Show("Usuario y contraseña valido");
                    Usuario user = EntityManager.getEntityManager().findBy<Usuario>("username", textBox1.Text);
                    Navigator.nextForm(this,new SeleccionRoles(user));
                    break;
                default: //Contraseña incorrecta (sumando intentos fallidos)
                    MessageBox.Show("Contraseña incorrecta. Intentos fallidos: " + intentos_fallidos);
                    break;
            }
        }
    }
}
