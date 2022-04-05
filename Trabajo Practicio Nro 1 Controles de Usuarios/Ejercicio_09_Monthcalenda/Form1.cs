using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio_09_Monthcalenda
{
    public partial class Form1 : Form
    {
        string[] Meses = new string[12] { "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre" };
        public Form1()
        {
            InitializeComponent();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            textBox1.Text = "Fecha seleccionada = " + monthCalendar1.SelectionStart.Day.ToString() + " de " + Meses[monthCalendar1.SelectionStart.Month-1] + " del " + monthCalendar1.SelectionStart.Year.ToString();
        }
    }
}
