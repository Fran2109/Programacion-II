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

namespace Controles10
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Termostato _t = new Termostato();
        private void Form1_Load(object sender, EventArgs e)
        {
            _t.Peligro += FuncionPeligro;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                _t.Temperatura = int.Parse(Interaction.InputBox("Temperatura: "));

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }
        private void FuncionPeligro(object sender, EventArgs e)
        {
            MessageBox.Show("Se cargó una temperatura peligrosa !!!");
        }
    }
    public class Termostato
    {
        public event EventHandler Peligro;

        int _temperatura;
        public int Temperatura 
        {
            get { return _temperatura; }
            set {
                if (value > 100)
                { Peligro?.Invoke(this, null); }
                else { _temperatura = value; }
                    
                } 
        }

    }
}
