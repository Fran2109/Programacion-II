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

namespace ADO_Conectado
{
    public partial class Form1 : Form
    {
        SqlConnection connection;
        SqlCommand command;
        SqlDataReader dataReader;
        List<Cliente> lista_clientes;
        public Form1()
        {
            InitializeComponent();
            connection = new SqlConnection("Data Source=.;Initial Catalog=Personas;Integrated Security=True");
            command = new SqlCommand("select * from cliente order by Legajo", connection);
            command.CommandType = CommandType.Text;
            connection.Open();
            lista_clientes = new List<Cliente>();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Mostrar();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int legajo = int.Parse(Interaction.InputBox("Legajo", "Insertar Cliente"));
                string nombre = Interaction.InputBox("Nombre", "Insertar Cliente");
                string apellido = Interaction.InputBox("Apellido", "Insertar Cliente");
                command.CommandText = $"insert into cliente (Legajo, Nombre, Apellido) values ({legajo}, '{nombre}', '{apellido}')";
                command.ExecuteNonQuery();
                Mostrar();
            }
            catch(Exception error ) { MessageBox.Show(error.Message); }

        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count == 1)
                {
                    command.CommandText = $"delete from cliente where Legajo = {(dataGridView1.SelectedRows[0].DataBoundItem as Cliente).Legajo}";
                    command.ExecuteNonQuery();
                    Mostrar();
                }
            }
            catch (Exception error) { MessageBox.Show(error.Message); }
        }
        private void Mostrar()
        {
            try
            {
                command.CommandText = "select * from cliente order by Legajo";
                dataReader = command.ExecuteReader();
                lista_clientes.Clear();
                while (dataReader.Read())
                {
                    lista_clientes.Add(new Cliente(int.Parse(dataReader.GetValue(0).ToString()), dataReader.GetValue(1).ToString(), dataReader.GetValue(2).ToString()));
                }
            }
            catch(Exception error) { MessageBox.Show(error.Message); }
            finally { dataReader.Close(); }
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = lista_clientes;
        }

        public class Cliente
        {
            public int Legajo { get; set; }
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public Cliente(int legajo, string nombre, string apellido)
            {
                Legajo = legajo;
                Nombre = nombre;
                Apellido = apellido;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if(dataGridView1.SelectedRows.Count == 1)
                {
                    Cliente aux = dataGridView1.SelectedRows[0].DataBoundItem as Cliente;
                    int legajo = int.Parse(Interaction.InputBox("Legajo", "Modificar Cliente", aux.Legajo.ToString()));
                    string nombre = Interaction.InputBox("Nombre", "Modificar Cliente", aux.Nombre);
                    string apellido = Interaction.InputBox("Apellido", "Modificar Cliente", aux.Apellido);
                    command.CommandText = $"update cliente SET Legajo = {legajo}, Nombre = '{nombre}', Apellido = '{apellido}' where Legajo = {aux.Legajo}";
                    command.ExecuteNonQuery();
                    Mostrar();
                }
            } catch(Exception error) { MessageBox.Show(error.Message); }
        }
    }   

}
