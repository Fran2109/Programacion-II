using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio_06_GrupBox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int CRojo, CAzul, CVerde;
        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            CRojo = Rojo.Checked ? 255 : 0;
            CAzul = Azul.Checked ? 255 : 0;
            CVerde = Verde.Checked ? 255 : 0;
            this.BackColor = Color.FromArgb(CRojo, CVerde, CAzul);
        }
    }
}
