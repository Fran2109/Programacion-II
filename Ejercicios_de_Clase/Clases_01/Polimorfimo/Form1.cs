using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Polimorfimo
{
    public partial class Form1 : Form
    {
        Suma _s;
        Resta _r;
        Producto _p;
            
        public Form1()
        {
            InitializeComponent();
            _s = new Suma(); _r = new Resta(); _p = new Producto();
        }
        private void UsaPolimorfismo(Operacion pO)
        {
          textBox3.Text=pO.Calcular(decimal.Parse(textBox1.Text), decimal.Parse(textBox2.Text)).ToString();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
             
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UsaPolimorfismo(_s);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UsaPolimorfismo(_r);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UsaPolimorfismo(_p);
        }
    }

    public abstract class Operacion
    {
        public abstract decimal Calcular(decimal pN1, decimal pN2);

    }
    public class Suma : Operacion
    {
        public override decimal Calcular(decimal pN1, decimal pN2)
        {
            return pN1 + pN2;
        }
    }
    public class Resta : Operacion
    {
        public override decimal Calcular(decimal pN1, decimal pN2)
        {
            return pN1 - pN2; 
        }
    }
    public class Producto : Operacion
    {
        public override decimal Calcular(decimal pN1, decimal pN2)
        {
            return pN1 * pN2; 
        }
    }
}
