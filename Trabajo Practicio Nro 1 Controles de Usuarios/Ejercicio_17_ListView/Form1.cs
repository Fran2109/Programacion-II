using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio_17_ListView
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            listView1.Items.Add("Osvaldo");
            listView1.Items.Add("Nicolas");
            listView1.Items.Add("Pedro");
            listView1.Items.Add("Leandro");
            listView1.Items.Add("Monica");
            listView1.Sorting = SortOrder.Ascending;
            listView1.View = View.List;
        }

        private void Agregar_Click(object sender, EventArgs e)
        {
            listView1.Items.Add(textBox1.Text);
        }
    }
}
