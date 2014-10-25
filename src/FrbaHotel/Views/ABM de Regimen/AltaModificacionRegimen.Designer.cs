namespace FrbaHotel.ABM_de_Regimen
{
    partial class AltaModificacionRegimen
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radio_Inactivo = new System.Windows.Forms.RadioButton();
            this.radio_Activo = new System.Windows.Forms.RadioButton();
            this.txt_PrecioBase = new System.Windows.Forms.TextBox();
            this.txt_Descripcion = new System.Windows.Forms.TextBox();
            this.txt_Codigo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bnt_Confirmar = new System.Windows.Forms.Button();
            this.btn_Volver = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.txt_PrecioBase);
            this.groupBox1.Controls.Add(this.txt_Descripcion);
            this.groupBox1.Controls.Add(this.txt_Codigo);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(424, 300);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Regimen";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radio_Inactivo);
            this.groupBox2.Controls.Add(this.radio_Activo);
            this.groupBox2.Location = new System.Drawing.Point(84, 188);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(323, 66);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Estado:";
            // 
            // radio_Inactivo
            // 
            this.radio_Inactivo.AutoSize = true;
            this.radio_Inactivo.Location = new System.Drawing.Point(191, 33);
            this.radio_Inactivo.Name = "radio_Inactivo";
            this.radio_Inactivo.Size = new System.Drawing.Size(72, 17);
            this.radio_Inactivo.TabIndex = 8;
            this.radio_Inactivo.TabStop = true;
            this.radio_Inactivo.Text = "No Activo";
            this.radio_Inactivo.UseVisualStyleBackColor = true;
            // 
            // radio_Activo
            // 
            this.radio_Activo.AutoSize = true;
            this.radio_Activo.Location = new System.Drawing.Point(66, 33);
            this.radio_Activo.Name = "radio_Activo";
            this.radio_Activo.Size = new System.Drawing.Size(55, 17);
            this.radio_Activo.TabIndex = 7;
            this.radio_Activo.TabStop = true;
            this.radio_Activo.Text = "Activo";
            this.radio_Activo.UseVisualStyleBackColor = true;
            // 
            // txt_PrecioBase
            // 
            this.txt_PrecioBase.Location = new System.Drawing.Point(226, 144);
            this.txt_PrecioBase.Name = "txt_PrecioBase";
            this.txt_PrecioBase.Size = new System.Drawing.Size(100, 20);
            this.txt_PrecioBase.TabIndex = 6;
            // 
            // txt_Descripcion
            // 
            this.txt_Descripcion.Location = new System.Drawing.Point(226, 90);
            this.txt_Descripcion.Name = "txt_Descripcion";
            this.txt_Descripcion.Size = new System.Drawing.Size(100, 20);
            this.txt_Descripcion.TabIndex = 5;
            // 
            // txt_Codigo
            // 
            this.txt_Codigo.Location = new System.Drawing.Point(226, 43);
            this.txt_Codigo.Name = "txt_Codigo";
            this.txt_Codigo.Size = new System.Drawing.Size(100, 20);
            this.txt_Codigo.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(83, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Precio base (U$S):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(83, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Descripción:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(83, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Codigo:";
            // 
            // bnt_Confirmar
            // 
            this.bnt_Confirmar.Location = new System.Drawing.Point(271, 339);
            this.bnt_Confirmar.Name = "bnt_Confirmar";
            this.bnt_Confirmar.Size = new System.Drawing.Size(165, 48);
            this.bnt_Confirmar.TabIndex = 1;
            this.bnt_Confirmar.Text = "Confirmar";
            this.bnt_Confirmar.UseVisualStyleBackColor = true;
            this.bnt_Confirmar.Click += new System.EventHandler(this.bnt_Confirmar_Click);
            // 
            // btn_Volver
            // 
            this.btn_Volver.Location = new System.Drawing.Point(12, 339);
            this.btn_Volver.Name = "btn_Volver";
            this.btn_Volver.Size = new System.Drawing.Size(165, 48);
            this.btn_Volver.TabIndex = 2;
            this.btn_Volver.Text = "Volver";
            this.btn_Volver.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Volver.UseVisualStyleBackColor = true;
            this.btn_Volver.Click += new System.EventHandler(this.btn_Volver_Click);
            // 
            // AltaModificacionRegimen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(454, 404);
            this.Controls.Add(this.btn_Volver);
            this.Controls.Add(this.bnt_Confirmar);
            this.Controls.Add(this.groupBox1);
            this.Name = "AltaModificacionRegimen";
            this.Text = "ABM de Regimen";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radio_Inactivo;
        private System.Windows.Forms.RadioButton radio_Activo;
        private System.Windows.Forms.TextBox txt_PrecioBase;
        private System.Windows.Forms.TextBox txt_Descripcion;
        private System.Windows.Forms.Button bnt_Confirmar;
        private System.Windows.Forms.Button btn_Volver;
        private System.Windows.Forms.TextBox txt_Codigo;
        private System.Windows.Forms.Label label1;
    }
}