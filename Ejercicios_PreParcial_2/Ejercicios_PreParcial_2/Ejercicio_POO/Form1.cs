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

namespace Ejercicio_POO
{
    public partial class Form1 : Form
    {
        Comercio comercio;
        public Form1()
        {
            InitializeComponent();
            comercio = new Comercio();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Producto productoAux = null;
                int id = int.Parse(Interaction.InputBox("Id: ", "Producto"));
                string descripcion = Interaction.InputBox("Descripcion: ", "Producto");
                decimal costo = decimal.Parse(Interaction.InputBox("Costo: ", "Producto"));
                DateTime fechaVencimiento = DateTime.Parse(Interaction.InputBox("Fecha de Vencimiento: ", "Producto"));
                if (radioButton1.Checked)
                {
                    productoAux = new ProductoA(costo, id, descripcion, fechaVencimiento);
                }
                else
                {
                    productoAux = new ProductoB(costo, id, descripcion, fechaVencimiento);
                }
                productoAux.vencidos += evento;
                comercio.InsertarProducto(productoAux);
                Mostrar();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }


        public void evento(object sender, vencidosEventArgs e)
        {
            MessageBox.Show(e.Datos);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.MultiSelect = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.MultiSelect = false;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            comercio.InsertarProducto(new ProductoA(25, 5, "fdhgfd", DateTime.Parse("21/09/2022")));
            comercio.InsertarProducto(new ProductoB(56, 45, "tghgd", DateTime.Parse("20/07/2022")));
            Mostrar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if(dataGridView1.SelectedRows.Count == 1)
                {
                    Producto auxiliar = dataGridView1.SelectedRows[0].DataBoundItem as Producto;
                    if(MessageBox.Show($"Esta seguro de Borrar el producto de Id = {auxiliar.Id}", "Eliminar Producto", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        comercio.BorrarProducto(auxiliar);
                        Mostrar();
                    }
                    else
                    {
                        MessageBox.Show("El Producto no se ha Eliminado");
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        public void Mostrar()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = comercio.LeerProductos();
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = (from item in comercio.LeerProductos() select new
                {
                    Id = item.Id,
                    Descripcion = item.Descripcion,
                    Costo = item.Costo,
                    FechaVto = item.FechaVto,
                    Tipo = item is ProductoA ? "Producto A" : "Producto B"
                }).ToList();
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if(dataGridView1.SelectedRows.Count == 1)
            {
                Producto prod = dataGridView1.SelectedRows[0].DataBoundItem as Producto;
                label1.Text = $"${prod.ajusteDeCosto()}";
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            foreach (Producto item in comercio.LeerProductos())
            {
                item.chequeDeVencidos();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count == 1)
                {
                    Producto auxiliar = dataGridView1.SelectedRows[0].DataBoundItem as Producto;
                    Producto modificado = null;
                    string descripcion = Interaction.InputBox("Descripcion", "Modificar Producto", auxiliar.Descripcion);
                    DateTime fechaVto = DateTime.Parse(Interaction.InputBox("Fecha de Vencimiento", "Modificar Producto", auxiliar.FechaVto.ToShortDateString()));
                    if(auxiliar is ProductoA)
                    {
                        modificado = new ProductoA(auxiliar.Costo, auxiliar.Id, descripcion, fechaVto);
                    }
                    else if(auxiliar is ProductoB)
                    {
                        modificado = new ProductoB(auxiliar.Costo, auxiliar.Id, descripcion, fechaVto);
                    }
                    comercio.ModificarProducto(auxiliar, modificado);
                    Mostrar();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
