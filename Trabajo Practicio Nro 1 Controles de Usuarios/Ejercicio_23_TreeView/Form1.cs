using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio_23_TreeView
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            treeView1.BeginUpdate();
            treeView1.Nodes.Add("Raiz");
            treeView1.Nodes[0].Nodes.Add("Padre");
            treeView1.Nodes[0].Nodes[0].Nodes.Add("Hijo");
            treeView1.Nodes[0].Nodes.Add("Padre");
            treeView1.Nodes[0].Nodes[0].Nodes[0].Nodes.Add("Ñieto");
            treeView1.Nodes[0].Nodes[1].Nodes.Add("Hijo");
            treeView1.Nodes[0].Nodes[1].Nodes[0].Nodes.Add("Ñieto");
            treeView1.EndUpdate();
        }
    }
}
