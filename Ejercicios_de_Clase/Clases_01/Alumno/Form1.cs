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

namespace Alumno
{
    public partial class Form1 : Form
    {
        List<Alumno> _l;
        Intervalo _i;
        IntervaloAxos _ia;
        IntervaloMeses _im;
        IntervaloDias _id;

        public Form1()
        {
            InitializeComponent();
            _l = new List<Alumno>();
            _ia = new IntervaloAxos();
            _im = new IntervaloMeses();
            _id = new IntervaloDias();
            _i = _ia;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.MultiSelect = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                _l.Add(new Alumno(int.Parse(Interaction.InputBox("Legajo: ")),
                                  Interaction.InputBox("Nombre: "),
                                  Interaction.InputBox("Apellido: "),
                                  DateTime.Parse(Interaction.InputBox("Fecha Nacimiento: ")),
                                  DateTime.Parse(Interaction.InputBox("Fecha Ingreso: ")),
                                  MessageBox.Show("¿Activo?", "", MessageBoxButtons.YesNo) == DialogResult.Yes ? true : false,
                                  int.Parse(Interaction.InputBox("Cantidad de materias aprobadas"))));
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = _l;
                dataGridView1_RowEnter(null,null);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            _i = _ia; dataGridView1_RowEnter(null, null);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            _i = _im; dataGridView1_RowEnter(null, null);
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            _i = _id; dataGridView1_RowEnter(null, null);
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                Alumno _a = dataGridView1.SelectedRows[0].DataBoundItem as Alumno;
                textBox1.Text = _a.Antiguedad(_i).ToString();
                textBox2.Text = _a.CantidadNoAprobadas().ToString();
                textBox3.Text = _a.EdadIngreso().ToString();
            }
            catch (Exception ) {  }

        }
    }
    public class Alumno
    {

        public Alumno() { }
        public Alumno(int pLegajo,string pNombre,string pApellido,DateTime pFecNac,DateTime pFecIng,bool pActivo,int pCantidadAprobadas )
        {
            Legajo = pLegajo;Nombre = pNombre;Apellido = pApellido;
            FechaNac = pFecNac;FechaIng = pFecIng;Activo = pActivo;
            MateriasAprobadas = pCantidadAprobadas;
        }
        
        public int Legajo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        private DateTime _fechaNac;
        public DateTime FechaNac
        {
            set { _fechaNac = value; }
        }
        private DateTime _fechaIng;
        public DateTime FechaIng
        {
           
            set { _fechaIng = value; }

        }
        
        public int Edad
        {
            get            
            {
                int _axos = DateTime.Today.Year - _fechaNac.Year;
                _axos += DateTime.Today.DayOfYear < _fechaNac.DayOfYear ? -1 : 0;
                return _axos; 
            }
           
        }

        public bool Activo { get; set; }
        private int _materiasAprobadas;
        public int MateriasAprobadas
        {
            set { _materiasAprobadas = value; }
        }

        public int Antiguedad(Intervalo pIntervalo)
        {
         
            return pIntervalo.Calcular(_fechaIng);
        }
        public int CantidadNoAprobadas()
        {
            return 36 - _materiasAprobadas;
        }
        public int EdadIngreso()
        {
            int _axos = _fechaIng.Year - _fechaNac.Year;
            _axos += _fechaIng.DayOfYear < _fechaNac.DayOfYear ? -1 : 0;
            return _axos;
        }



    }

    public abstract class Intervalo
    {
        public abstract int Calcular(DateTime pFechaIng);

    }
    public class IntervaloAxos : Intervalo
    {
        public override int Calcular(DateTime pFechaIng)
        {

            return (int)DateAndTime.DateDiff(DateInterval.Year, pFechaIng, DateTime.Today);
        }
    }
    public class IntervaloMeses : Intervalo
    {
        public override int Calcular(DateTime pFechaIng)
        {
            return (int)DateAndTime.DateDiff(DateInterval.Month, pFechaIng, DateTime.Today);
        }
    }
    public class IntervaloDias : Intervalo
    {
        public override int Calcular(DateTime pFechaIng)
        {
            return (int)DateAndTime.DateDiff(DateInterval.Day, pFechaIng, DateTime.Today);
        }
    }

}
