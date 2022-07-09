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

namespace EjemploClaseVista
{
    public partial class Form1 : Form
    {
        List<Persona> _l;
        PersonaVista _pv;
        public Form1()
        {
            InitializeComponent();
            _l = new List<Persona>();
            _pv = new PersonaVista();
            button1.Click += button2_Click;
        }
       
        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.MultiSelect = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.MultiSelect = false;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = null; dataGridView2.DataSource = _pv.RetornaListaPersonaVista(_l);
            string[] datos = {"D o c u m e n t o","E d a d"};
            int _c = 0;
            foreach(DataGridViewColumn c in dataGridView2.Columns)
            {
                c.HeaderText = datos[_c];
                c.Width += 30;
                if(_c==1) c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                _c++;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

           try
                {
                    _l.Add(new Persona(Interaction.InputBox("Tipo de Documento:"),
                                       Interaction.InputBox("Número de Documento: "),
                                       DateTime.Parse(Interaction.InputBox("Fecha de Nacimiento"))));
                    dataGridView1.DataSource = null;dataGridView1.DataSource = _l;
                    //button2_Click(null, null);
                    //button2_Click(null, new EventArgs());
                    //button2_Click(sender, e);
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }

          

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Persona _p = (dataGridView2.SelectedRows[0].DataBoundItem as PersonaVista).RetornaOriginal();
        }
    }

    public class PersonaVista
    {

        public string Documento { get; set; }
        public int Edad { get; }
        Persona _retornaOriginal=null;
        public Persona RetornaOriginal()
        {
            return _retornaOriginal;
        }
        public PersonaVista(){}
        public PersonaVista(string pDoc, int pEdad, Persona pPersona)
        {
            Documento = pDoc;Edad = pEdad; _retornaOriginal = pPersona;
        }
        public List<PersonaVista> RetornaListaPersonaVista(List<Persona> plistaPersona)
        {
            List<PersonaVista> _laux = new List<PersonaVista>();

            try
            {
                foreach (Persona p in plistaPersona)
                {
                    var axos = DateTime.Now.Year - p.RetornaFechaNacimiento().Year;
                    axos = axos - (DateTime.Now.DayOfYear < p.RetornaFechaNacimiento().DayOfYear ? 1 : 0);
                    _laux.Add(new PersonaVista($"{p.TipoDoc} {p.NumeroDoc}",axos,p));

                }
            }
            catch (Exception ex) { throw ex; }
            return _laux;
        }

    }

    public class Persona
    {
        public Persona(string pTD,string pND,DateTime pFN)
        { TipoDoc = pTD;NumeroDoc = pND;FechaNac = pFN; }
        public string TipoDoc { get; set; }
        public string NumeroDoc { get; set; }
        DateTime _fechaNac;
        public DateTime FechaNac 
        { 
            set
            { _fechaNac = value; }
        }

        public DateTime RetornaFechaNacimiento() { return _fechaNac; }

    }
}
