using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Controles03
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
         
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if(e.KeyChar==13)
                {
                    string[] _s = textBox1.Text.Split(',');
                    foreach(string valores in _s)
                    {
                        if(!(int.Parse(valores)>=0 && int.Parse(valores)<256) )
                        {
                            throw new Exception("Número Inválido !!!");
                        }
                    }
                    this.BackColor = Color.FromArgb(int.Parse(_s[0]), int.Parse(_s[1]), int.Parse(_s[2]));
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message); ;
            }
           
        }
    }
}
