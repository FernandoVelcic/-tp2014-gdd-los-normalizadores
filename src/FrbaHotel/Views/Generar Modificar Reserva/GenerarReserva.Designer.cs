namespace FrbaHotel.Generar_Modificar_Reserva
{
    partial class Form1
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
            this.cmb_Hotel = new System.Windows.Forms.ComboBox();
            this.txt_Hotel = new System.Windows.Forms.Label();
            this.cmb_TipoHabitacion = new System.Windows.Forms.ComboBox();
            this.txt_Cant_Noches = new System.Windows.Forms.TextBox();
            this.txt_Desde = new System.Windows.Forms.TextBox();
            this.cmb_Regimen = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Generar = new System.Windows.Forms.Button();
            this.btn_Volver = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmb_Hotel);
            this.groupBox1.Controls.Add(this.txt_Hotel);
            this.groupBox1.Controls.Add(this.cmb_TipoHabitacion);
            this.groupBox1.Controls.Add(this.txt_Cant_Noches);
            this.groupBox1.Controls.Add(this.txt_Desde);
            this.groupBox1.Controls.Add(this.cmb_Regimen);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(363, 232);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos de la reserva";
            // 
            // cmb_Hotel
            // 
            this.cmb_Hotel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Hotel.FormattingEnabled = true;
            this.cmb_Hotel.Location = new System.Drawing.Point(175, 168);
            this.cmb_Hotel.Name = "cmb_Hotel";
            this.cmb_Hotel.Size = new System.Drawing.Size(121, 24);
            this.cmb_Hotel.TabIndex = 10;
            this.cmb_Hotel.SelectedIndexChanged += new System.EventHandler(this.cmb_Hotel_SelectedIndexChanged);
            // 
            // txt_Hotel
            // 
            this.txt_Hotel.AutoSize = true;
            this.txt_Hotel.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Hotel.Location = new System.Drawing.Point(53, 171);
            this.txt_Hotel.Name = "txt_Hotel";
            this.txt_Hotel.Size = new System.Drawing.Size(39, 16);
            this.txt_Hotel.TabIndex = 9;
            this.txt_Hotel.Text = "Hotel:";
            // 
            // cmb_TipoHabitacion
            // 
            this.cmb_TipoHabitacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_TipoHabitacion.FormattingEnabled = true;
            this.cmb_TipoHabitacion.Location = new System.Drawing.Point(174, 107);
            this.cmb_TipoHabitacion.Name = "cmb_TipoHabitacion";
            this.cmb_TipoHabitacion.Size = new System.Drawing.Size(121, 24);
            this.cmb_TipoHabitacion.TabIndex = 8;
            // 
            // txt_Cant_Noches
            // 
            this.txt_Cant_Noches.Location = new System.Drawing.Point(174, 76);
            this.txt_Cant_Noches.Name = "txt_Cant_Noches";
            this.txt_Cant_Noches.Size = new System.Drawing.Size(121, 22);
            this.txt_Cant_Noches.TabIndex = 7;
            // 
            // txt_Desde
            // 
            this.txt_Desde.Location = new System.Drawing.Point(175, 46);
            this.txt_Desde.Name = "txt_Desde";
            this.txt_Desde.Size = new System.Drawing.Size(121, 22);
            this.txt_Desde.TabIndex = 7;
            // 
            // cmb_Regimen
            // 
            this.cmb_Regimen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Regimen.FormattingEnabled = true;
            this.cmb_Regimen.Location = new System.Drawing.Point(175, 138);
            this.cmb_Regimen.Name = "cmb_Regimen";
            this.cmb_Regimen.Size = new System.Drawing.Size(121, 24);
            this.cmb_Regimen.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(53, 138);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Tipo Regimen:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(53, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Tipo Habitacion:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(52, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Cantidad noches:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(53, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Desde:";
            // 
            // btn_Generar
            // 
            this.btn_Generar.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Generar.Location = new System.Drawing.Point(260, 250);
            this.btn_Generar.Name = "btn_Generar";
            this.btn_Generar.Size = new System.Drawing.Size(115, 46);
            this.btn_Generar.TabIndex = 2;
            this.btn_Generar.Text = "Ver habitaciones disponibles";
            this.btn_Generar.UseVisualStyleBackColor = true;
            this.btn_Generar.Click += new System.EventHandler(this.btn_Generar_Click);
            // 
            // btn_Volver
            // 
            this.btn_Volver.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Volver.Location = new System.Drawing.Point(12, 250);
            this.btn_Volver.Name = "btn_Volver";
            this.btn_Volver.Size = new System.Drawing.Size(115, 46);
            this.btn_Volver.TabIndex = 3;
            this.btn_Volver.Text = "Volver";
            this.btn_Volver.UseVisualStyleBackColor = true;
            this.btn_Volver.Click += new System.EventHandler(this.btn_Volver_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(385, 305);
            this.Controls.Add(this.btn_Volver);
            this.Controls.Add(this.btn_Generar);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Reservas";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_Cant_Noches;
        private System.Windows.Forms.TextBox txt_Desde;
        private System.Windows.Forms.ComboBox cmb_Regimen;
        private System.Windows.Forms.Button btn_Generar;
        private System.Windows.Forms.Button btn_Volver;
        private System.Windows.Forms.ComboBox cmb_TipoHabitacion;
        private System.Windows.Forms.ComboBox cmb_Hotel;
        private System.Windows.Forms.Label txt_Hotel;
    }
}