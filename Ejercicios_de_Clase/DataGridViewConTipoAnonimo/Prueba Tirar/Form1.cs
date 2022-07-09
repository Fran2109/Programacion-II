using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prueba_Tirar
{
    public partial class Form1 : Form
    {
        List<Mascota> _lm;
        OrdenarEspecieAsc _ea;
        OrdenarEspecieDesc _ed;
        Ordenar[] _o;
        public Form1()
        {
            InitializeComponent();
            _ea = new OrdenarEspecieAsc() { Leyenda="Especie ASC"};
            _ed = new OrdenarEspecieDesc() { Leyenda="Especie DESC"};
            _o = new Ordenar[] { _ea,_ed};
            _lm = new List<Mascota>();
        }
        private void Polimorfico(Ordenar pO)
        {
            _lm.Sort(pO.RetornaObjOrden());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _lm.AddRange(new Mascota[] { new Mascota() { Especie = "Perro" }, new Mascota() { Especie = "Gato" } });
            foreach(Ordenar o in _o)
            {
                listBox1.Items.Add(o.Leyenda);
            }
            
            
            List<persona> L = new List<persona>() { new persona("Ana", "Perez"), new persona("Sol", "Garcia") };

            //var i = from x in L
             //       select new { Nom = (string)x.Apellido +", " + (string)x.Nombre };
            //dg1.Columns.AddRange(new DataGridViewColumn[] {new DataGridViewTextBoxColumn(), new DataGridViewTextBoxColumn() });
            
            //foreach (var z in i) { dg1.Rows.Add(new object[]{z.Nom}) ; }
           //dg1.DataSource = null;
           //dg1.DataSource = i.ToList();
            dg1.DataSource = (from x in L  select new { Datos = $"{x.Apellido}, {x.Nombre}"}).ToList();


        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Polimorfico(_o[listBox1.SelectedIndex]);
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = _lm;
            //MessageBox.Show($"Seleccionó {listBox1.SelectedItem} y esta en el índice {listBox1.SelectedIndex}");
        }
    }
    public class persona
    {
        public persona(string pn,string pa) { Nombre = pn;Apellido = pa; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
    }

    public abstract class Ordenar
    {
        public string Leyenda { get; set; }
        public abstract IComparer<Mascota> RetornaObjOrden();
    }
    public class OrdenarEspecieAsc : Ordenar
    {
        public override IComparer<Mascota> RetornaObjOrden()
        {
            return new Mascota.EspecieASC();
        }
    }
    public class OrdenarEspecieDesc : Ordenar
    {
        public override IComparer<Mascota> RetornaObjOrden()
        {
            return new Mascota.EspecieDESC();
        }
    }

    public class Mascota
    {
        public string Especie { get; set; }
       
        public class EspecieASC : IComparer<Mascota>
        {
            public int Compare(Mascota x, Mascota y)
            {
                return string.Compare(x.Especie,y.Especie);
            }
        }
        public class EspecieDESC : IComparer<Mascota>
        {
            public int Compare(Mascota x, Mascota y)
            {
                return string.Compare(x.Especie, y.Especie) * -1;
            }
        }
    }
}
