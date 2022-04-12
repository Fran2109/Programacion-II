using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio_22_ToolTip
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            toolTip1.SetToolTip(this.textBox1, "Ingrese un Nombre");
            toolTip1.SetToolTip(this.textBox2, "Ingrese un Apellido");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text!="" && textBox2.Text!="")
            {
                MessageBox.Show("Datos enviados Correctamente");
                textBox1.Text = textBox2.Text = "";
            }
            else
            {
                MessageBox.Show("Hay datos Vacios");
            }
        }
    }
}
