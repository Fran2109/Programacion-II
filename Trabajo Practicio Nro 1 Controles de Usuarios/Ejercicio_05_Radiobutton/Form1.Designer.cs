
namespace Ejercicio_05_Radiobutton
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
            this.Rojo = new System.Windows.Forms.RadioButton();
            this.Verde = new System.Windows.Forms.RadioButton();
            this.Azul = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // Rojo
            // 
            this.Rojo.AutoSize = true;
            this.Rojo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rojo.Location = new System.Drawing.Point(357, 167);
            this.Rojo.Name = "Rojo";
            this.Rojo.Size = new System.Drawing.Size(74, 29);
            this.Rojo.TabIndex = 0;
            this.Rojo.Text = "Rojo";
            this.Rojo.UseVisualStyleBackColor = true;
            this.Rojo.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // Verde
            // 
            this.Verde.AutoSize = true;
            this.Verde.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Verde.Location = new System.Drawing.Point(357, 211);
            this.Verde.Name = "Verde";
            this.Verde.Size = new System.Drawing.Size(87, 29);
            this.Verde.TabIndex = 1;
            this.Verde.Text = "Verde";
            this.Verde.UseVisualStyleBackColor = true;
            this.Verde.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // Azul
            // 
            this.Azul.AutoSize = true;
            this.Azul.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Azul.Location = new System.Drawing.Point(357, 255);
            this.Azul.Name = "Azul";
            this.Azul.Size = new System.Drawing.Size(72, 29);
            this.Azul.TabIndex = 2;
            this.Azul.Text = "Azul";
            this.Azul.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Azul.UseVisualStyleBackColor = true;
            this.Azul.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Azul);
            this.Controls.Add(this.Verde);
            this.Controls.Add(this.Rojo);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton Rojo;
        private System.Windows.Forms.RadioButton Verde;
        private System.Windows.Forms.RadioButton Azul;
    }
}

