using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio_10_ProgressBar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            timer1.Start();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Value = progressBar1.Value != 100? progressBar1.Value + 1 : progressBar1.Value;
            label1.Text = "Cargando Mensaje " + progressBar1.Value.ToString() + "%";
            if(progressBar1.Value == 100)
            {
                timer1.Stop();
                MessageBox.Show("EL mensaje a terminado de cargarse");
            }

        }
    }
}
