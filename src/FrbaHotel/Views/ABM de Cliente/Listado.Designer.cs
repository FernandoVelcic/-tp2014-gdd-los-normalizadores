namespace FrbaHotel.Views.ABM_de_Cliente
{
    partial class Listado
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
            this.btn_EliminarCliente = new System.Windows.Forms.Button();
            this.btn_AltaCliente = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_EliminarCliente
            // 
            this.btn_EliminarCliente.Location = new System.Drawing.Point(399, 12);
            this.btn_EliminarCliente.Name = "btn_EliminarCliente";
            this.btn_EliminarCliente.Size = new System.Drawing.Size(128, 48);
            this.btn_EliminarCliente.TabIndex = 4;
            this.btn_EliminarCliente.Text = "Eliminar cliente";
            this.btn_EliminarCliente.UseVisualStyleBackColor = true;
            this.btn_EliminarCliente.Click += new System.EventHandler(this.button2_Click);
            // 
            // btn_AltaCliente
            // 
            this.btn_AltaCliente.Location = new System.Drawing.Point(533, 12);
            this.btn_AltaCliente.Name = "btn_AltaCliente";
            this.btn_AltaCliente.Size = new System.Drawing.Size(124, 48);
            this.btn_AltaCliente.TabIndex = 3;
            this.btn_AltaCliente.Text = "Alta de cliente";
            this.btn_AltaCliente.UseVisualStyleBackColor = true;
            this.btn_AltaCliente.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView2);
            this.groupBox1.Location = new System.Drawing.Point(12, 66);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(648, 547);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Listado de clientes";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(18, 19);
            this.dataGridView2.MultiSelect = false;
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(624, 522);
            this.dataGridView2.TabIndex = 0;
            // 
            // Listado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 625);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_EliminarCliente);
            this.Controls.Add(this.btn_AltaCliente);
            this.Name = "Listado";
            this.Text = "Listado";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_EliminarCliente;
        private System.Windows.Forms.Button btn_AltaCliente;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView2;
    }
}