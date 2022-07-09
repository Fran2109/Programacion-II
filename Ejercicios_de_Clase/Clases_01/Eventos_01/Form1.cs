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

namespace Eventos_01
{
    public partial class Form1 : Form
    {
        Persona _p;
        public Form1()
        {
            InitializeComponent();
            _p = new Persona();
            _p.EdadIncorrecta += FedadIncorrecta;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        private void FedadIncorrecta(object sender, EventArgs e)
        {
            MessageBox.Show("La edad es incorrecta !!!");
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                _p.Nombre = Interaction.InputBox("Nombre: ");
                _p.Apellido = Interaction.InputBox("Apellido: ");
                _p.Edad = int.Parse(Interaction.InputBox("Edad: "));
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                _p.EdadIncorrecta += FedadIncorrecta;
                label1.Text = int.Parse(label1.Text)==0 ? "0" : (int.Parse(label1.Text) + 1).ToString();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                _p.EdadIncorrecta -= FedadIncorrecta;
                label1.Text = (int.Parse(label1.Text) - 1).ToString();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }
    }

    public class Persona
    {
        // Declaración del Evento
        public event EventHandler EdadIncorrecta;
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        int _edad;
        public int Edad 
        {
            get { return _edad; }
            set { 
                    
                if (value < 1 || value > 150) {  EdadIncorrecta?.Invoke(this, null);  }
                else
                { _edad = value; }
                }
        }
    }
}
