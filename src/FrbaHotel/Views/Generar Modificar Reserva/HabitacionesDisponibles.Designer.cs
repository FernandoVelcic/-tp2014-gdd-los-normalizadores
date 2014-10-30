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
            // 
            // btn_Confirmar
            // 
            this.btn_Confirmar.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Confirmar.Location = new System.Drawing.Point(170, 296);
            this.btn_Confirmar.Name = "btn_Confirmar";
            this.btn_Confirmar.Size = new System.Drawing.Size(139, 46);
            this.btn_Confirmar.TabIndex = 4;
            this.btn_Confirmar.Text = "Confirmar";
            this.btn_Confirmar.UseVisualStyleBackColor = true;
            // 
            // list_Habitaciones
            // 
            this.list_Habitaciones.FormattingEnabled = true;
            this.list_Habitaciones.Location = new System.Drawing.Point(12, 11);
            this.list_Habitaciones.Name = "list_Habitaciones";
            this.list_Habitaciones.Size = new System.Drawing.Size(297, 264);
            this.list_Habitaciones.TabIndex = 5;
            // 
            // HabitacionesDisponibles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 352);
            this.Controls.Add(this.list_Habitaciones);
            this.Controls.Add(this.btn_Confirmar);
            this.Controls.Add(this.btn_Volver);
            this.Name = "HabitacionesDisponibles";
            this.Text = "Habitaciones disponibles";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Volver;
        private System.Windows.Forms.Button btn_Confirmar;
        private System.Windows.Forms.ListBox list_Habitaciones;
    }
}