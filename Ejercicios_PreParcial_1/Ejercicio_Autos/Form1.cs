using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio_Autos
{
    public partial class Form1 : Form
    {
        Comercio comercio;
        Vista vista;
        public Form1()
        {
            InitializeComponent();
            comercio = new Comercio();
            comercio.AgregarPersona(new Persona("43671673", "Francisco", "Filosi"));
            comercio.AgregarPersona(new Persona("45971689", "Nicolas", "Filosi"));
            comercio.AgregarPersona(new Persona("46644856", "Leandro", "Filosi"));
            comercio.AgregarPersona(new Persona("50974732", "Peodro", "Filosi"));
            Mostrar(dataGridView1, comercio.ListaPersonas());
            comercio.AgregarAuto(new Auto("43671673", "AE459CE", "Chevrolet", "Spinn", 2020, 2250000));
            comercio.AgregarAuto(new Auto("43671673", "A022THF", "Motomel", "Skua", 2015, 250000));
            comercio.AgregarAuto(new Auto("46644856", "GER323", "Chevrolet", "Partner", 2000, 500000));
            comercio.AgregarAuto(new Auto("50974732", "JGA838", "Nissan", "Tidda", 2005, 2500000));
            Mostrar(dataGridView2, comercio.ListAutos());
            vista = new Vista();
            Mostrar(dataGridView4, vista.obtenerVista(comercio.ListAutos(), comercio.ListaPersonas()));
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            ConfigurarDataGridView(dataGridView1);
            ConfigurarDataGridView(dataGridView2);
            ConfigurarDataGridView(dataGridView3);
            ConfigurarDataGridView(dataGridView4);
        }
        private void ConfigurarDataGridView(DataGridView dataGridView)
        {
            dataGridView.MultiSelect = false;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.ReadOnly = true;
        }
        private void Mostrar(DataGridView dataGridView, object lista)
        {
            dataGridView.DataSource = null;
            dataGridView.DataSource = lista;
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if(dataGridView1.SelectedRows.Count>0)
            {
                Persona persona = dataGridView1.SelectedRows[0].DataBoundItem as Persona;
                Mostrar(dataGridView3, comercio.ListAutosPersona(persona));
            }
        }
    }
}
