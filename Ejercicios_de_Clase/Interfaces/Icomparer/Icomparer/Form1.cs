using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Icomparer
{
    public partial class Form1 : Form
    {
        List<Persona> _p;
        public Form1()
        {
            InitializeComponent();
            _p = new List<Persona>();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _p.Add(new Persona() { Nombre = "Juan", Apellido = "Perez", Edad = 44 });
            _p.Add(new Persona() { Nombre = "Ana", Apellido = "Suarez", Edad = 27 });
            _p.Add(new Persona() { Nombre = "Cecilia", Apellido = "Martinez", Edad = 33 });
            /*
            _p.AddRange(new Persona[] {new Persona() { Nombre = "Juan", Apellido = "Perez", Edad = 44 },
                                       new Persona() { Nombre = "Ana", Apellido = "Suarez", Edad = 27 },
                                       new Persona() { Nombre = "Cecilia", Apellido = "Martinez", Edad = 33 }});
            */

            dataGridView1.DataSource = _p.ToArray();

            _p.Sort(new Persona.NombreASC()); dataGridView2.DataSource = _p.ToArray();
            _p.Sort(new Persona.NombreDESC()); dataGridView3.DataSource = _p.ToArray();
            _p.Sort(new Persona.ApellidoASC()); dataGridView4.DataSource = _p.ToArray();
            _p.Sort(new Persona.ApellidoDESC()); dataGridView5.DataSource = _p.ToArray();
            _p.Sort(new Persona.EdadASC()); dataGridView6.DataSource = _p.ToArray();
            _p.Sort(new Persona.EdadDESC()); dataGridView7.DataSource = _p.ToArray();
        }
    }
    public class Persona
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }

        public class NombreASC : IComparer<Persona>
        {
            public int Compare(Persona x, Persona y)
            {
               return  string.Compare(x.Nombre,y.Nombre);
            }
        }
        public class NombreDESC : IComparer<Persona>
        {
            public int Compare(Persona x, Persona y)
            {
                return string.Compare(x.Nombre, y.Nombre) * -1;
            }
        }
        public class ApellidoASC : IComparer<Persona>
        {
            public int Compare(Persona x, Persona y)
            {
                return string.Compare(x.Apellido, y.Apellido);
            }
        }
        public class ApellidoDESC : IComparer<Persona>
        {
            public int Compare(Persona x, Persona y)
            {
                return string.Compare(x.Apellido, y.Apellido) * -1;
            }
        }
        public class EdadASC : IComparer<Persona>
        {
            public int Compare(Persona x, Persona y)
            {
                int _rdo = 0;
                if (x.Edad < y.Edad) _rdo = -1;
                if (x.Edad > y.Edad) _rdo = 1;
                return _rdo;
            }
        }
        public class EdadDESC : IComparer<Persona>
        {
            public int Compare(Persona x, Persona y)
            {
                int _rdo = 0;
                if (x.Edad < y.Edad) _rdo = 1;
                if (x.Edad > y.Edad) _rdo = -1;
                return _rdo;
            }
        }
    }
}
