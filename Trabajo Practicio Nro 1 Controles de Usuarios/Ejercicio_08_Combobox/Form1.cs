using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio_08_Combobox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = $"Ha elegido la Opcion {comboBox1.SelectedItem.ToString()}";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Hombre");
            comboBox1.Items.Add("Mujer");
            comboBox1.Items.Add("Niño");
            comboBox1.Items.Add("Niña");
        }
    }
}
