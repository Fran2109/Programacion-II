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

namespace Controles09
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

        private void button1_Click(object sender, EventArgs e)
        {
            Persona _p1 = new Persona("Ana","Garcia");
            MessageBox.Show(_p1.NombreCompleto(Interaction.InputBox("Título: ")));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GC.Collect();
        }
    }

    public class Persona
    {

        public Persona()
        { MessageBox.Show("Estamos instanciando una nueva persona !!!"); }
        public Persona(string pNombre="") : this()
        { Nombre = pNombre;  }
        public Persona(string pNombre, string pApellido="") : this(pNombre)
        { Apellido = pApellido; }
       
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public string NombreCompleto(string pTitulo="")
        {
            return $"{pTitulo} {Nombre} {Apellido}";
        }
        ~Persona()
        {
            MessageBox.Show("Se ejecutó la función destructora !!!");
        }
    }
}
