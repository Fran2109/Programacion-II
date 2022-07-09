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

namespace Ejercicio_Alumnos
{
    public partial class Form1 : Form
    {
        List<Alumno> list_alumnos;
        Alumno alumno_primerAlumno;
        Alumno alumno_segundoAlumno;
        Anios intervalo_anios;
        Meses intervalo_meses;
        Dias intervalo_dias;
        Intervalo intervalo_intervalo;
        public Form1()
        {
            InitializeComponent();
            list_alumnos = new List<Alumno>();
            alumno_primerAlumno = new Alumno();
            alumno_segundoAlumno = new Alumno(1, "Francisco", "Filosi", DateTime.Parse("21/09/2001"), DateTime.Parse("10/06/2020"), true, 20);
            list_alumnos.Add(alumno_primerAlumno);
            list_alumnos.Add(alumno_segundoAlumno);
            Mostrar();

            intervalo_anios = new Anios();
            intervalo_meses = new Meses();
            intervalo_dias = new Dias();
            intervalo_intervalo = intervalo_anios;
        }
        private void Mostrar()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = list_alumnos;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.MultiSelect = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if(dataGridView1.SelectedRows.Count > 0)
                {
                    Alumno alumno_seleccionado = dataGridView1.SelectedRows[0].DataBoundItem as Alumno;
                    textBox_antiguedad.Text = alumno_seleccionado.Antiguedad(intervalo_intervalo).ToString();
                    textBox_materiasNoAprobadas.Text = alumno_seleccionado.Materias_No_Aprobadas().ToString();
                    textBox_edadIngreso.Text = alumno_seleccionado.Edad_De_Ingreso(intervalo_anios).ToString();
                }
                
            }
            catch(Exception error) { MessageBox.Show(error.Message); }
        }
        private void radioButton_anios_CheckedChanged(object sender, EventArgs e)
        {
            intervalo_intervalo = intervalo_anios;
            dataGridView1_RowEnter(null, null);
        }
        private void radioButton_meses_CheckedChanged(object sender, EventArgs e)
        {
            intervalo_intervalo = intervalo_meses;
            dataGridView1_RowEnter(null, null);
        }
        private void radioButton_dias_CheckedChanged(object sender, EventArgs e)
        {
            intervalo_intervalo = intervalo_dias;
            dataGridView1_RowEnter(null, null);
        }
        private void button_agregar_Click(object sender, EventArgs e)
        {
            try
            {
                Alumno alumno_agregar = new Alumno(
                    int.Parse(Interaction.InputBox("Legajo: ")),
                    Interaction.InputBox("Nombre: "),
                    Interaction.InputBox("Apellido: "),
                    DateTime.Parse(Interaction.InputBox("Fecha de Nacimiento: ")),
                    DateTime.Parse(Interaction.InputBox("Fecha de Ingreso: ")),
                    MessageBox.Show("¿Activo?", "", MessageBoxButtons.YesNo) == DialogResult.Yes ? true : false,
                    int.Parse(Interaction.InputBox("Cantidad de Materias Aprobadas: "))
                );
                list_alumnos.Add(alumno_agregar);
                Mostrar();
                if( !button_eliminar.Enabled || !button_editar.Enabled )
                {
                    button_eliminar.Enabled = true;
                    button_editar.Enabled = true;
                }
                dataGridView1_RowEnter(null, null);
            } catch(Exception error) { MessageBox.Show(error.Message); }
            
        }
        private void button_eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                Alumno alumno_eliminar = dataGridView1.SelectedRows[0].DataBoundItem as Alumno;
                list_alumnos.Remove(alumno_eliminar);
                Mostrar();
                if( dataGridView1.SelectedRows.Count == 0 )
                {
                    button_editar.Enabled = false;
                    button_eliminar.Enabled = false;
                }
            }catch(Exception error) { MessageBox.Show(error.Message); }
        }
        private void button_editar_Click(object sender, EventArgs e)
        {
            try
            {
                Alumno alumno_editar = dataGridView1.SelectedRows[0].DataBoundItem as Alumno;
                alumno_editar.Legajo = int.Parse(Interaction.InputBox("Legajo: ", "Legajo", alumno_editar.Legajo.ToString()));
                alumno_editar.Nombre = Interaction.InputBox("Nombre: ", "Nombre", alumno_editar.Nombre);
                alumno_editar.Apellido = Interaction.InputBox("Apellido: ", "Apellido", alumno_editar.Apellido);
                alumno_editar.Activo = MessageBox.Show("¿Activo?", "", MessageBoxButtons.YesNo) == DialogResult.Yes ? true : false;
                alumno_editar.Cant_Materias_Aprobadas = int.Parse(Interaction.InputBox("Cantidad de Materias Aprobadas: ", "Materias Aprobadas", "36"));
                Mostrar();
                dataGridView1_RowEnter(null, null);
            } catch( Exception error ) { MessageBox.Show(error.Message); }
        }
    }
}
