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

namespace Ejercicio_11_DataGrid
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            lista = new List<Alumno>();
        }
        List<Alumno> lista;
        private void Form1_Load(object sender, EventArgs e)
        {
            Alumno a1 = new Alumno() { Legajo = 1, Nombre = "Ana", Apellido = "Perex" };
            Alumno a2 = new Alumno() { Legajo = 2, Nombre = "Sol", Apellido = "Gutierrez" };
            Alumno a3 = new Alumno() { Legajo = 3, Nombre = "Juana", Apellido = "Martinez" };
            lista.AddRange(new Alumno[] { a1, a2, a3 });
            Mostrar();
            dataGridView1.MultiSelect = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void Mostrar()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = lista;
        }

        private void Agregar_Click(object sender, EventArgs e)
        {
            Alumno alumnoAgregar = new Alumno();
            try
            {
                alumnoAgregar.Legajo = lista.Last().Legajo + 1;
            }
            catch
            {
                alumnoAgregar.Legajo = 1; 
            }
            alumnoAgregar.Nombre = Interaction.InputBox("Nombre: ");
            alumnoAgregar.Apellido = Interaction.InputBox("Apellido: ");
            lista.AddRange(new Alumno[] { alumnoAgregar });
            Mostrar();
            if(!Eliminar.Enabled)
            {
                Eliminar.Enabled = true;
                Editar.Enabled = true;
            }    
        }
        private void Eliminar_Click(object sender, EventArgs e)
        {
            lista.Remove(dataGridView1.SelectedRows[0].DataBoundItem as Alumno);
            Mostrar();
            if (lista.Count() == 0)
            {
                Eliminar.Enabled = false;
                Editar.Enabled = false;
            }
        }
        int indice;
        private void Editar_Click(object sender, EventArgs e)
        {
            Alumno alumnoEditar = new Alumno();
            indice = lista.IndexOf(dataGridView1.SelectedRows[0].DataBoundItem as Alumno);
            lista[indice].Nombre = Interaction.InputBox("Nombre: ");
            lista[indice].Apellido = Interaction.InputBox("Apellido: ");
            Mostrar();
        }
    }


    public class Alumno
    {
        public int Legajo { get; set; }
        public string Nombre { get; set; }
        string apellido;
        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }
    }
}
