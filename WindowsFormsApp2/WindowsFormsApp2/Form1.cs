using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        SqlConnection connection;
        SqlCommand command;
        SqlDataReader reader;
        List<Paciente> pacientes;
        public Form1()
        {
            InitializeComponent();
            connection = new SqlConnection("Data Source='PC-5E-54\\SQLEXPRESS';Initial Catalog = Parcial; Integrated Security=True");
            connection.Open();
            command = new SqlCommand("select * from Pacientes", connection);
            command.CommandType = CommandType.Text;
            pacientes = new List<Paciente>();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            Mostrar();
        }

        private void Mostrar()
        {
            try
            {
                pacientes.Clear();
                command.CommandText = "select * from Pacientes order by Legajo";
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Paciente paciente = new Paciente(
                        int.Parse(reader.GetValue(0).ToString()),
                        reader.GetValue(1).ToString(),
                        reader.GetValue(2).ToString(),
                        int.Parse(reader.GetValue(3).ToString())
                        );
                    pacientes.Add(paciente);
                }
                Ordenar ordenar = null;
                if(radioButton1.Checked)
                {
                    ordenar = new OrdenarAscendente();
                }
                else
                {
                    ordenar = new OrdenarDescendente();
                }
                pacientes.Sort(ordenar.RetornaOrden());
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = pacientes;
                dataGridView2.DataSource = null;
                dataGridView2.DataSource = (from paciente in pacientes select new { 
                    ID = paciente.Legajo, 
                    nombreRaza = $"{paciente.Nombre} / {paciente.Raza}",
                    Estado = paciente.Edad > 7? "Viejo" : "Joven"
                }).ToList();
            } catch(Exception error) { MessageBox.Show(error.Message); }
            finally { reader.Close(); }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int legajo = int.Parse(Interaction.InputBox("Legajo", "Pacientes"));
                string nombre = Interaction.InputBox("Nombre", "Pacientes");
                string raza = Interaction.InputBox("Raza", "Pacientes");
                int edad = int.Parse(Interaction.InputBox("Edad", "Pacientes"));
                Paciente nuevo = new Paciente(legajo, nombre, raza);
                nuevo.Evento += Nuevo_Evento;
                nuevo.Edad = edad;
                command.CommandText = $"insert into Pacientes (Legajo, Nombre, Raza, Edad) values ({nuevo.Legajo}, '{nuevo.Nombre}', '{nuevo.Raza}', {nuevo.Edad})";
                command.ExecuteNonQuery();
                Mostrar();
            }
            catch (Exception error) { MessageBox.Show(error.Message); }
        }

        private void Nuevo_Evento(object sender, EventArgsPaciente e)
        {
            MessageBox.Show(e.Dato);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if(dataGridView1.SelectedRows.Count==1)
                {
                    Paciente auxiliar = dataGridView1.SelectedRows[0].DataBoundItem as Paciente;
                    if(MessageBox.Show(
                        $"Legajo: {auxiliar.Legajo} {Environment.NewLine}" +
                        $"Nombre: {auxiliar.Nombre} {Environment.NewLine}" +
                        $"Raza: {auxiliar.Raza} {Environment.NewLine}" +
                        $"Edad: {auxiliar.Edad} {Environment.NewLine}", 
                        "Seguro de Eliminar?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        command.CommandText = $"delete from Pacientes where Legajo = {auxiliar.Legajo}";
                        command.ExecuteNonQuery();
                        Mostrar();
                    }
                }            
            }
            catch (Exception error) { MessageBox.Show(error.Message); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count == 1)
                {
                    Paciente auxiliar = dataGridView1.SelectedRows[0].DataBoundItem as Paciente;
                    int legajo = int.Parse(Interaction.InputBox("Legajo", "Pacientes", auxiliar.Legajo.ToString()));
                    string nombre = Interaction.InputBox("Nombre", "Pacientes", auxiliar.Nombre);
                    string raza = Interaction.InputBox("Raza", "Pacientes", auxiliar.Raza);
                    int edad = int.Parse(Interaction.InputBox("Edad", "Pacientes", auxiliar.Edad.ToString()));
                    command.CommandText = $"update Pacientes set " +
                        $"Legajo = {legajo}, " +
                        $"Nombre = '{nombre}', " +
                        $"Raza = '{raza}'," +
                        $"Edad = {edad} " +
                        $"where Legajo = {auxiliar.Legajo}";
                    command.ExecuteNonQuery();
                    Mostrar();
                }
            }
            catch (Exception error) { MessageBox.Show(error.Message); }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                int legajo = int.Parse(textBox1.Text);
                command.CommandText = $"select * from Pacientes where Legajo = {legajo}";
                reader = command.ExecuteReader();
                if(reader.Read())
                {
                    MessageBox.Show(
                        $"Legajo: {reader.GetValue(0).ToString()} {Environment.NewLine}" +
                        $"Nombre: {reader.GetValue(1).ToString()} {Environment.NewLine}" +
                        $"Raza: {reader.GetValue(2).ToString()} {Environment.NewLine}" +
                        $"Edad: {reader.GetValue(3).ToString()} {Environment.NewLine}");
                }
                else
                {
                    MessageBox.Show($"No existe el Legajo = {legajo}");
                }
                reader.Close();

            } catch(Exception error) { MessageBox.Show(error.Message); }
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            Mostrar();
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            Mostrar();
        }
    }
}
