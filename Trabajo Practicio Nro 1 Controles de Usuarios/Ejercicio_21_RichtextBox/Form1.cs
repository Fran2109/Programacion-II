using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio_21_RichtextBox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            richTextBox1.Dock = DockStyle.Fill;
            richTextBox1.LoadFile("Richtext.rtf");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.SaveFile("Richtext.rtf", RichTextBoxStreamType.RichText);
        }

    }
}
