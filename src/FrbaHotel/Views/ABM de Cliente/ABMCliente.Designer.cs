﻿namespace FrbaHotel.Views.ABM_de_Cliente
{
    partial class ABMCliente
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.btn_ModificarCliente = new System.Windows.Forms.Button();
            this.btn_EliminarCliente = new System.Windows.Forms.Button();
            this.btn_AltaDeCliente = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_Limpiar = new System.Windows.Forms.Button();
            this.btn_Filtrar = new System.Windows.Forms.Button();
            this.txt_Filter_Documento = new System.Windows.Forms.TextBox();
            this.txt_Filter_Apellido = new System.Windows.Forms.TextBox();
            this.txt_Filter_Mail = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.txt_Filtro_Nombre = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Seleccionar = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.dataGridView2);
            this.groupBox1.Location = new System.Drawing.Point(12, 111);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(659, 488);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Listado de clientes";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(458, 444);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(129, 28);
            this.button2.TabIndex = 2;
            this.button2.Text = "> Clientes";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(254, 444);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(129, 28);
            this.button1.TabIndex = 1;
            this.button1.Text = "< Clientes";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(6, 19);
            this.dataGridView2.MultiSelect = false;
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(647, 416);
            this.dataGridView2.TabIndex = 0;
            // 
            // btn_ModificarCliente
            // 
            this.btn_ModificarCliente.Location = new System.Drawing.Point(543, 47);
            this.btn_ModificarCliente.Name = "btn_ModificarCliente";
            this.btn_ModificarCliente.Size = new System.Drawing.Size(128, 29);
            this.btn_ModificarCliente.TabIndex = 6;
            this.btn_ModificarCliente.Text = "Modificar clientes";
            this.btn_ModificarCliente.UseVisualStyleBackColor = true;
            this.btn_ModificarCliente.Click += new System.EventHandler(this.button3_Click);
            // 
            // btn_EliminarCliente
            // 
            this.btn_EliminarCliente.Location = new System.Drawing.Point(543, 82);
            this.btn_EliminarCliente.Name = "btn_EliminarCliente";
            this.btn_EliminarCliente.Size = new System.Drawing.Size(128, 29);
            this.btn_EliminarCliente.TabIndex = 5;
            this.btn_EliminarCliente.Text = "Eliminar cliente";
            this.btn_EliminarCliente.UseVisualStyleBackColor = true;
            this.btn_EliminarCliente.Click += new System.EventHandler(this.onBtnEliminar);
            // 
            // btn_AltaDeCliente
            // 
            this.btn_AltaDeCliente.Location = new System.Drawing.Point(543, 12);
            this.btn_AltaDeCliente.Name = "btn_AltaDeCliente";
            this.btn_AltaDeCliente.Size = new System.Drawing.Size(128, 29);
            this.btn_AltaDeCliente.TabIndex = 4;
            this.btn_AltaDeCliente.Text = "Alta de clientes";
            this.btn_AltaDeCliente.UseVisualStyleBackColor = true;
            this.btn_AltaDeCliente.Click += new System.EventHandler(this.onBtnAlta);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_Limpiar);
            this.groupBox2.Controls.Add(this.btn_Filtrar);
            this.groupBox2.Controls.Add(this.txt_Filter_Documento);
            this.groupBox2.Controls.Add(this.txt_Filter_Apellido);
            this.groupBox2.Controls.Add(this.txt_Filter_Mail);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.comboBox2);
            this.groupBox2.Controls.Add(this.txt_Filtro_Nombre);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(525, 99);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Opciones de filtrado";
            // 
            // btn_Limpiar
            // 
            this.btn_Limpiar.AccessibleDescription = "";
            this.btn_Limpiar.AccessibleName = "";
            this.btn_Limpiar.Location = new System.Drawing.Point(254, 70);
            this.btn_Limpiar.Name = "btn_Limpiar";
            this.btn_Limpiar.Size = new System.Drawing.Size(127, 23);
            this.btn_Limpiar.TabIndex = 22;
            this.btn_Limpiar.Tag = "0";
            this.btn_Limpiar.Text = "Limpiar";
            this.btn_Limpiar.UseVisualStyleBackColor = true;
            this.btn_Limpiar.Click += new System.EventHandler(this.button4_Click);
            // 
            // btn_Filtrar
            // 
            this.btn_Filtrar.AccessibleDescription = "";
            this.btn_Filtrar.AccessibleName = "";
            this.btn_Filtrar.Location = new System.Drawing.Point(393, 70);
            this.btn_Filtrar.Name = "btn_Filtrar";
            this.btn_Filtrar.Size = new System.Drawing.Size(120, 23);
            this.btn_Filtrar.TabIndex = 21;
            this.btn_Filtrar.Tag = "0";
            this.btn_Filtrar.Text = "Filtrar";
            this.btn_Filtrar.UseVisualStyleBackColor = true;
            this.btn_Filtrar.Click += new System.EventHandler(this.onBtnFiltrar);
            // 
            // txt_Filter_Documento
            // 
            this.txt_Filter_Documento.Location = new System.Drawing.Point(368, 48);
            this.txt_Filter_Documento.Name = "txt_Filter_Documento";
            this.txt_Filter_Documento.Size = new System.Drawing.Size(145, 20);
            this.txt_Filter_Documento.TabIndex = 20;
            // 
            // txt_Filter_Apellido
            // 
            this.txt_Filter_Apellido.Location = new System.Drawing.Point(110, 44);
            this.txt_Filter_Apellido.MaxLength = 255;
            this.txt_Filter_Apellido.Name = "txt_Filter_Apellido";
            this.txt_Filter_Apellido.Size = new System.Drawing.Size(121, 20);
            this.txt_Filter_Apellido.TabIndex = 19;
            // 
            // txt_Filter_Mail
            // 
            this.txt_Filter_Mail.Location = new System.Drawing.Point(110, 67);
            this.txt_Filter_Mail.MaxLength = 255;
            this.txt_Filter_Mail.Name = "txt_Filter_Mail";
            this.txt_Filter_Mail.Size = new System.Drawing.Size(121, 20);
            this.txt_Filter_Mail.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(251, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Nro de identificacion:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(251, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Tipo de identificacion:";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(368, 22);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(145, 21);
            this.comboBox2.TabIndex = 14;
            // 
            // txt_Filtro_Nombre
            // 
            this.txt_Filtro_Nombre.Location = new System.Drawing.Point(110, 22);
            this.txt_Filtro_Nombre.MaxLength = 255;
            this.txt_Filtro_Nombre.Name = "txt_Filtro_Nombre";
            this.txt_Filtro_Nombre.Size = new System.Drawing.Size(121, 20);
            this.txt_Filtro_Nombre.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Apellido:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Mail:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Nombre:";
            // 
            // btn_Seleccionar
            // 
            this.btn_Seleccionar.Location = new System.Drawing.Point(543, 12);
            this.btn_Seleccionar.Name = "btn_Seleccionar";
            this.btn_Seleccionar.Size = new System.Drawing.Size(128, 29);
            this.btn_Seleccionar.TabIndex = 8;
            this.btn_Seleccionar.Text = "Seleccionar cliente";
            this.btn_Seleccionar.UseVisualStyleBackColor = true;
            this.btn_Seleccionar.Click += new System.EventHandler(this.btn_Seleccionar_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(47, 444);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(129, 28);
            this.button3.TabIndex = 3;
            this.button3.Text = "Inicio";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // ABMCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 607);
            this.Controls.Add(this.btn_Seleccionar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btn_ModificarCliente);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_EliminarCliente);
            this.Controls.Add(this.btn_AltaDeCliente);
            this.Name = "ABMCliente";
            this.Text = "ABM de Clientes";
            this.Load += new System.EventHandler(this.ABMCliente_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ABMCliente_FormClosed);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button btn_ModificarCliente;
        private System.Windows.Forms.Button btn_EliminarCliente;
        private System.Windows.Forms.Button btn_AltaDeCliente;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txt_Filter_Mail;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.TextBox txt_Filtro_Nombre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_Filter_Documento;
        private System.Windows.Forms.TextBox txt_Filter_Apellido;
        private System.Windows.Forms.Button btn_Filtrar;
        private System.Windows.Forms.Button btn_Limpiar;
        private System.Windows.Forms.Button btn_Seleccionar;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
    }
}