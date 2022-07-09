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

namespace Controles07
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            _l = new List<Alumno>();
        }
        List<Alumno> _l;
        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.MultiSelect = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            
            
            Alumno _a1 = new Alumno() { Legajo = 1, Nombre = "Ana", Apellido = "Perez" };

            Alumno _a2 = new Alumno();
            _a2.Legajo = 2;
            _a2.Nombre = "Sol";
            _a2.Apellido = "Martinez";

            Alumno _a3;
            _a3 = new Alumno() { Legajo = 3, Nombre = "Pedro", Apellido = "Garcia" };

            _l.AddRange(new Alumno[] { _a1, _a2, _a3 });
            //_l.Add(_a1);
            //_l.Add(_a2);
            //_l.Add(_a3);

            Mostrar();
        }

        private void Mostrar()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = _l;
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            BackColor = colorDialog1.Color;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Alumno _x = new Alumno();
            _x.Legajo = _l.Count==0 ? 1 : _l.Last().Legajo + 1;
            _x.Nombre = Interaction.InputBox("Nombre: ");
            _x.Apellido = Interaction.InputBox("Apellido: ");
            _l.Add(_x);
            Mostrar();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                 _l.Remove((dataGridView1.SelectedRows[0].DataBoundItem as Alumno));
                 Mostrar();
            }
            catch (Exception ex) { MessageBox.Show("No hay Alumno seleccionado para borarr !!!"); }

          
        }

        private void button3_Click(object sender, EventArgs e)  
        {

            try
            {
                Alumno _alumnoAux = dataGridView1.SelectedRows[0].DataBoundItem as Alumno;
                string _legajoAux = Interaction.InputBox("Nuevo Legajo: ","Modificando...",_alumnoAux.Legajo.ToString());
                if (!Information.IsNumeric(_legajoAux)) throw new Exception("El legajo Ingresado no es numérico !!!");
                if(int.Parse(_legajoAux)!=_alumnoAux.Legajo)
                    if(_l.Exists(X=>X.Legajo== int.Parse(_legajoAux))) throw new Exception("El legajo Ingresado existe !!!");
                _alumnoAux.Legajo = int.Parse(_legajoAux);
                _alumnoAux.Nombre = Interaction.InputBox("Nuevo nombre", "Modificando...", _alumnoAux.Nombre);
                _alumnoAux.Apellido = Interaction.InputBox("Nuevo apellido", "Modificando...", _alumnoAux.Apellido);
                Mostrar();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }
    }
    public class Alumno
    {
        public int Legajo { get; set; }
        public string Nombre { get; set; }

        string  _apellido;
        public string Apellido
        {
            get { return _apellido; }
            set { _apellido = value; }
        }
    }

}
