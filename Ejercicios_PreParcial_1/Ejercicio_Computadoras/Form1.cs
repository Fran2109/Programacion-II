using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Ejercicio_Computadoras
{
    public partial class Form1 : Form
    {
        Comercio comercio;
        Operaciones operacion;
        OperacionesDiscos operacionesDiscos;

        public Form1()
        {
            InitializeComponent();
            comercio = new Comercio();
            operacionesDiscos = new OperacionesDiscos();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                ConfigurarDataGridView(dataGridView1);
                ConfigurarDataGridView(dataGridView2);
                ConfigurarDataGridView(dataGridView3);
                ConfigurarDataGridView(dataGridView4);
                ConfigurarDataGridView(dataGridView5);
                operacion = operacionesDiscos;
                comercio.Agregar(new Disco("CCC1", "Barracuda1", "Toshiba1", 15000, "HDD1", "1024GB1", ValorNegativo), operacion);
                comercio.Agregar(new Disco("CCC2", "Barracuda2", "Toshiba2", 16000, "HDD2", "1024GB2", ValorNegativo), operacion);
                comercio.Agregar(new Disco("CCC3", "Barracuda3", "Toshiba3", 17000, "HDD3", "1024GB3", ValorNegativo), operacion);
                Mostrar(dataGridView4, comercio.Leer(operacion));
            }
            catch(Exception error) { MessageBox.Show(error.Message); }
            
        }
        private void Mostrar(DataGridView dataGridView, object lista)
        {
            dataGridView.DataSource = null;
            dataGridView.DataSource = lista;
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                operacion = operacionesDiscos;
                Disco disco_agregar = new Disco(
                        Interaction.InputBox("Codigo: "),
                        Interaction.InputBox("Descripcion: "),
                        Interaction.InputBox("Marca: "),
                        Convert.ToDecimal(Interaction.InputBox("Precio: ")),
                        Interaction.InputBox("Tipo: "),
                        Interaction.InputBox("Almacenamiento: "),
                        ValorNegativo
                );
                operacion = operacionesDiscos;
                comercio.Agregar(disco_agregar, operacion);
                Mostrar(dataGridView4, comercio.Leer(operacion));
            } catch(Exception error) { MessageBox.Show(error.Message); }
        }
        private void ValorNegativo(object sender, EventArgs e)
        {
            throw new Exception("El valor del producto no puede ser negativo!!!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if(dataGridView4.SelectedRows.Count > 0)
                {
                    Disco disco_eliminar = dataGridView4.SelectedRows[0].DataBoundItem as Disco;
                    operacion = operacionesDiscos;
                    comercio.Eliminar(disco_eliminar, operacion);
                    Mostrar(dataGridView4, comercio.Leer(operacion));
                }
            }catch(Exception error) { MessageBox.Show(error.Message); }
        }
    }
}
