namespace Ejercicio_Alumnos
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label_materiasNoAprobadas = new System.Windows.Forms.Label();
            this.textBox_materiasNoAprobadas = new System.Windows.Forms.TextBox();
            this.textBox_antiguedad = new System.Windows.Forms.TextBox();
            this.label_antiguedad = new System.Windows.Forms.Label();
            this.textBox_edadIngreso = new System.Windows.Forms.TextBox();
            this.label_edadIngreso = new System.Windows.Forms.Label();
            this.button_agregar = new System.Windows.Forms.Button();
            this.button_editar = new System.Windows.Forms.Button();
            this.button_eliminar = new System.Windows.Forms.Button();
            this.radioButton_anios = new System.Windows.Forms.RadioButton();
            this.radioButton_meses = new System.Windows.Forms.RadioButton();
            this.radioButton_dias = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(776, 160);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_RowEnter);
            // 
            // label_materiasNoAprobadas
            // 
            this.label_materiasNoAprobadas.AutoSize = true;
            this.label_materiasNoAprobadas.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_materiasNoAprobadas.Location = new System.Drawing.Point(165, 283);
            this.label_materiasNoAprobadas.Name = "label_materiasNoAprobadas";
            this.label_materiasNoAprobadas.Size = new System.Drawing.Size(292, 25);
            this.label_materiasNoAprobadas.TabIndex = 1;
            this.label_materiasNoAprobadas.Text = "Cant. Materias no Aprobadas";
            // 
            // textBox_materiasNoAprobadas
            // 
            this.textBox_materiasNoAprobadas.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_materiasNoAprobadas.Location = new System.Drawing.Point(499, 283);
            this.textBox_materiasNoAprobadas.Name = "textBox_materiasNoAprobadas";
            this.textBox_materiasNoAprobadas.Size = new System.Drawing.Size(114, 31);
            this.textBox_materiasNoAprobadas.TabIndex = 2;
            // 
            // textBox_antiguedad
            // 
            this.textBox_antiguedad.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_antiguedad.Location = new System.Drawing.Point(499, 227);
            this.textBox_antiguedad.Name = "textBox_antiguedad";
            this.textBox_antiguedad.Size = new System.Drawing.Size(114, 31);
            this.textBox_antiguedad.TabIndex = 4;
            // 
            // label_antiguedad
            // 
            this.label_antiguedad.AutoSize = true;
            this.label_antiguedad.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_antiguedad.Location = new System.Drawing.Point(165, 227);
            this.label_antiguedad.Name = "label_antiguedad";
            this.label_antiguedad.Size = new System.Drawing.Size(121, 25);
            this.label_antiguedad.TabIndex = 3;
            this.label_antiguedad.Text = "Antiguedad";
            // 
            // textBox_edadIngreso
            // 
            this.textBox_edadIngreso.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_edadIngreso.Location = new System.Drawing.Point(499, 339);
            this.textBox_edadIngreso.Name = "textBox_edadIngreso";
            this.textBox_edadIngreso.Size = new System.Drawing.Size(114, 31);
            this.textBox_edadIngreso.TabIndex = 6;
            // 
            // label_edadIngreso
            // 
            this.label_edadIngreso.AutoSize = true;
            this.label_edadIngreso.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_edadIngreso.Location = new System.Drawing.Point(165, 339);
            this.label_edadIngreso.Name = "label_edadIngreso";
            this.label_edadIngreso.Size = new System.Drawing.Size(169, 25);
            this.label_edadIngreso.TabIndex = 5;
            this.label_edadIngreso.Text = "Edad de Ingreso";
            // 
            // button_agregar
            // 
            this.button_agregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_agregar.Location = new System.Drawing.Point(12, 212);
            this.button_agregar.Name = "button_agregar";
            this.button_agregar.Size = new System.Drawing.Size(112, 48);
            this.button_agregar.TabIndex = 7;
            this.button_agregar.Text = "Agregar";
            this.button_agregar.UseVisualStyleBackColor = true;
            this.button_agregar.Click += new System.EventHandler(this.button_agregar_Click);
            // 
            // button_editar
            // 
            this.button_editar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_editar.Location = new System.Drawing.Point(12, 266);
            this.button_editar.Name = "button_editar";
            this.button_editar.Size = new System.Drawing.Size(112, 48);
            this.button_editar.TabIndex = 8;
            this.button_editar.Text = "Editar";
            this.button_editar.UseVisualStyleBackColor = true;
            this.button_editar.Click += new System.EventHandler(this.button_editar_Click);
            // 
            // button_eliminar
            // 
            this.button_eliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_eliminar.Location = new System.Drawing.Point(12, 320);
            this.button_eliminar.Name = "button_eliminar";
            this.button_eliminar.Size = new System.Drawing.Size(112, 48);
            this.button_eliminar.TabIndex = 9;
            this.button_eliminar.Text = "Eliminar";
            this.button_eliminar.UseVisualStyleBackColor = true;
            this.button_eliminar.Click += new System.EventHandler(this.button_eliminar_Click);
            // 
            // radioButton_anios
            // 
            this.radioButton_anios.AutoSize = true;
            this.radioButton_anios.Checked = true;
            this.radioButton_anios.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton_anios.Location = new System.Drawing.Point(670, 231);
            this.radioButton_anios.Name = "radioButton_anios";
            this.radioButton_anios.Size = new System.Drawing.Size(79, 29);
            this.radioButton_anios.TabIndex = 13;
            this.radioButton_anios.TabStop = true;
            this.radioButton_anios.Text = "Años";
            this.radioButton_anios.UseVisualStyleBackColor = true;
            this.radioButton_anios.CheckedChanged += new System.EventHandler(this.radioButton_anios_CheckedChanged);
            // 
            // radioButton_meses
            // 
            this.radioButton_meses.AutoSize = true;
            this.radioButton_meses.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton_meses.Location = new System.Drawing.Point(670, 284);
            this.radioButton_meses.Name = "radioButton_meses";
            this.radioButton_meses.Size = new System.Drawing.Size(94, 29);
            this.radioButton_meses.TabIndex = 14;
            this.radioButton_meses.TabStop = true;
            this.radioButton_meses.Text = "Meses";
            this.radioButton_meses.UseVisualStyleBackColor = true;
            this.radioButton_meses.CheckedChanged += new System.EventHandler(this.radioButton_meses_CheckedChanged);
            // 
            // radioButton_dias
            // 
            this.radioButton_dias.AutoSize = true;
            this.radioButton_dias.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton_dias.Location = new System.Drawing.Point(670, 333);
            this.radioButton_dias.Name = "radioButton_dias";
            this.radioButton_dias.Size = new System.Drawing.Size(73, 29);
            this.radioButton_dias.TabIndex = 15;
            this.radioButton_dias.TabStop = true;
            this.radioButton_dias.Text = "Dias";
            this.radioButton_dias.UseVisualStyleBackColor = true;
            this.radioButton_dias.CheckedChanged += new System.EventHandler(this.radioButton_dias_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.radioButton_dias);
            this.Controls.Add(this.radioButton_meses);
            this.Controls.Add(this.radioButton_anios);
            this.Controls.Add(this.button_eliminar);
            this.Controls.Add(this.button_editar);
            this.Controls.Add(this.button_agregar);
            this.Controls.Add(this.textBox_edadIngreso);
            this.Controls.Add(this.label_edadIngreso);
            this.Controls.Add(this.textBox_antiguedad);
            this.Controls.Add(this.label_antiguedad);
            this.Controls.Add(this.textBox_materiasNoAprobadas);
            this.Controls.Add(this.label_materiasNoAprobadas);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label_materiasNoAprobadas;
        private System.Windows.Forms.TextBox textBox_materiasNoAprobadas;
        private System.Windows.Forms.TextBox textBox_antiguedad;
        private System.Windows.Forms.Label label_antiguedad;
        private System.Windows.Forms.TextBox textBox_edadIngreso;
        private System.Windows.Forms.Label label_edadIngreso;
        private System.Windows.Forms.Button button_agregar;
        private System.Windows.Forms.Button button_editar;
        private System.Windows.Forms.Button button_eliminar;
        private System.Windows.Forms.RadioButton radioButton_anios;
        private System.Windows.Forms.RadioButton radioButton_meses;
        private System.Windows.Forms.RadioButton radioButton_dias;
    }
}

