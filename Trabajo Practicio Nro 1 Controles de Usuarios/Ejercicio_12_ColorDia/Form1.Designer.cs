﻿namespace Ejercicio_12_ColorDia
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
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.ButtonColorDialog = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // colorDialog1
            // 
            this.colorDialog1.FullOpen = true;
            this.colorDialog1.HelpRequest += new System.EventHandler(this.colorDialog1_HelpRequest);
            // 
            // ButtonColorDialog
            // 
            this.ButtonColorDialog.Location = new System.Drawing.Point(329, 130);
            this.ButtonColorDialog.Name = "ButtonColorDialog";
            this.ButtonColorDialog.Size = new System.Drawing.Size(75, 23);
            this.ButtonColorDialog.TabIndex = 0;
            this.ButtonColorDialog.Text = "Boton Color";
            this.ButtonColorDialog.UseVisualStyleBackColor = true;
            this.ButtonColorDialog.Click += new System.EventHandler(this.ButtonColorDialog_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ButtonColorDialog);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button ButtonColorDialog;
    }
}

