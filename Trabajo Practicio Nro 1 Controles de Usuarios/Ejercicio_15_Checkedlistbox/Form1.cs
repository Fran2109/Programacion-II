using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio_15_Checkedlistbox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            checkedListBox1.Items.Add("Rojo");
            checkedListBox1.Items.Add("Verde");
            checkedListBox1.Items.Add("Azul");
        }
        private void Aplicar_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(
                checkedListBox1.CheckedItems.Contains("Rojo") ? 255 : 0,
                checkedListBox1.CheckedItems.Contains("Verde") ? 255 : 0,
                checkedListBox1.CheckedItems.Contains("Azul") ? 255 : 0);
        }
    }
}
