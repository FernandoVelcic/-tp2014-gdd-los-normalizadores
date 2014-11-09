namespace FrbaHotel.Views.Generar_Modificar_Reserva
{
    partial class HabitacionesDisponibles
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
            this.btn_Volver = new System.Windows.Forms.Button();
            this.btn_Confirmar = new System.Windows.Forms.Button();
            this.list_Habitaciones = new System.Windows.Forms.ListBox();
            this.btn_CrearCliente = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_Volver
            // 
            this.btn_Volver.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Volver.Location = new System.Drawing.Point(12, 296);
            this.btn_Volver.Name = "btn_Volver";
            this.btn_Volver.Size = new System.Drawing.Size(115, 46);
            this.btn_Volver.TabIndex = 3;
            this.btn_Volver.Text = "Volver";
            this.btn_Volver.UseVisualStyleBackColor = true;
            this.btn_Volver.Click += new System.EventHandler(this.btn_Volver_Click);
            // 
            // btn_Confirmar
            // 
            this.btn_Confirmar.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Confirmar.Location = new System.Drawing.Point(133, 296);
            this.btn_Confirmar.Name = "btn_Confirmar";
            this.btn_Confirmar.Size = new System.Drawing.Size(139, 46);
            this.btn_Confirmar.TabIndex = 4;
            this.btn_Confirmar.Text = "Seleccionar cliente existente";
            this.btn_Confirmar.UseVisualStyleBackColor = true;
            this.btn_Confirmar.Click += new System.EventHandler(this.btn_Confirmar_Click);
            // 
            // list_Habitaciones
            // 
            this.list_Habitaciones.FormattingEnabled = true;
            this.list_Habitaciones.Location = new System.Drawing.Point(12, 11);
            this.list_Habitaciones.Name = "list_Habitaciones";
            this.list_Habitaciones.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.list_Habitaciones.Size = new System.Drawing.Size(405, 251);
            this.list_Habitaciones.TabIndex = 5;
            this.list_Habitaciones.SelectedIndexChanged += new System.EventHandler(this.list_Habitaciones_SelectedIndexChanged);
            // 
            // btn_CrearCliente
            // 
            this.btn_CrearCliente.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_CrearCliente.Location = new System.Drawing.Point(278, 296);
            this.btn_CrearCliente.Name = "btn_CrearCliente";
            this.btn_CrearCliente.Size = new System.Drawing.Size(139, 46);
            this.btn_CrearCliente.TabIndex = 6;
            this.btn_CrearCliente.Text = "Crear nuevo cliente";
            this.btn_CrearCliente.UseVisualStyleBackColor = true;
            this.btn_CrearCliente.Click += new System.EventHandler(this.btn_CrearCliente_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 265);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Costo total de la reserva:";
            // 
            // HabitacionesDisponibles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 352);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_CrearCliente);
            this.Controls.Add(this.list_Habitaciones);
            this.Controls.Add(this.btn_Confirmar);
            this.Controls.Add(this.btn_Volver);
            this.Name = "HabitacionesDisponibles";
            this.Text = "Habitaciones disponibles";
            this.Load += new System.EventHandler(this.HabitacionesDisponibles_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Volver;
        private System.Windows.Forms.Button btn_Confirmar;
        private System.Windows.Forms.ListBox list_Habitaciones;
        private System.Windows.Forms.Button btn_CrearCliente;
        private System.Windows.Forms.Label label1;
    }
}