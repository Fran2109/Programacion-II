using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace ADO_Xml
{
    public partial class Form1 : Form
    {
        DataSet dataSet;
        DataTable dataTable;
        public Form1()
        {
            InitializeComponent();
            dataSet = new DataSet("Datos");
            if (!File.Exists("Datos.xml")) { CrearArchivo(); }
            else { dataSet.ReadXml("Datos.xml"); }
        }
        private void CrearArchivo()
        {
            dataTable = new DataTable("Cliente");
            dataTable.Columns.Add("Legajo", typeof(int));
            dataTable.Columns.Add("Nombre", typeof(string));
            dataTable.Columns.Add("Apellido", typeof(string));

            dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns[0] };

            dataSet.Tables.Add(dataTable);

            Guardar();
        }
        private void Guardar()
        {
            dataSet.WriteXml("Datos.xml", XmlWriteMode.WriteSchema);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Mostrar();
        }
        public void Mostrar()
        {
            List<Cliente> list = new List<Cliente>();
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                list.Add(new Cliente(int.Parse(row.ItemArray[0].ToString()), row.ItemArray[1].ToString(), row.ItemArray[2].ToString()));
            }
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = list;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int legajo = int.Parse(Interaction.InputBox("Legajo", "Insertar Cliente"));
                string nombre = Interaction.InputBox("Nombre", "Insertar Cliente");
                string apellido = Interaction.InputBox("Apellido", "Insertar Cliente");
                DataRow dataRow = dataSet.Tables[0].NewRow();
                dataRow.ItemArray = new object[] { legajo, nombre, apellido };
                dataSet.Tables[0].Rows.Add(dataRow);
                Mostrar();
                Guardar();
            }
            catch (Exception error) { MessageBox.Show(error.Message); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if(dataGridView1.SelectedRows.Count == 1)
                {
                    int legajo = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                    (dataSet.Tables[0].Rows.Find(legajo)).Delete();
                    Mostrar();
                    Guardar();
                }
            } catch(Exception error) { MessageBox.Show(error.Message); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int legajo = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                DataRow dataRow = dataSet.Tables[0].Rows.Find(legajo);
                dataRow.SetField<string>(1, Interaction.InputBox("Nombre", "", dataRow.ItemArray[1].ToString()));
                dataRow.SetField<string>(2, Interaction.InputBox("Apellido", "", dataRow.ItemArray[2].ToString()));
                Mostrar();
                Guardar();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
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
    }
}
