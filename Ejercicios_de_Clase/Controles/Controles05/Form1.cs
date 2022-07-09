using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace Controles05
{
    public partial class Form1 : Form
    {
        List<string> _lista;
        public Form1()
        {
            InitializeComponent();
            _lista = new List<string>();
            comboBox1.Font = new Font("Arial", 16);
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            _lista.Add(Interaction.InputBox("Nombre: "));
            listBox1.Items.Clear();
            listBox1.Items.AddRange(_lista.ToArray());

            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(_lista.ToArray());
            comboBox1.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox2.Items.Add(Interaction.InputBox("Nombre: "));
        }

        private void Form1_Click(object sender, EventArgs e)
        {

        }
    }
}
