using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio_07_Listbox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Colores.Items.Add("Rojo");
            Colores.Items.Add("Verde");
            Colores.Items.Add("Azul");
        }
        int Rojo, Verde, Azul;
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Rojo = Colores.GetSelected(0) ? 255 : 0;
            Verde = Colores.GetSelected(1) ? 255 : 0;
            Azul = Colores.GetSelected(2) ? 255 : 0;
            this.BackColor = Color.FromArgb(Rojo, Verde, Azul);
        }
    }
}