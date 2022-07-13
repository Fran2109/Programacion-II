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

namespace ADO_Desconectado
{
    public partial class Form1 : Form
    {
        DataSet dataSet;
        SqlDataAdapter dataAdapter;
        SqlCommandBuilder commandBuilder;
        DataView dataViewInsertados;
        DataView dataViewActualizados;
        DataView dataViewBorrados;
        public Form1()
        {
            InitializeComponent();
            dataAdapter = new SqlDataAdapter("SELECT * FROM cliente ORDER BY Legajo", "Data Source=.;Initial Catalog=Personas;Integrated Security=True");
            dataSet = new DataSet();
            commandBuilder = new SqlCommandBuilder(dataAdapter);
            dataAdapter.InsertCommand = commandBuilder.GetInsertCommand();
            dataAdapter.DeleteCommand = commandBuilder.GetDeleteCommand();
            dataAdapter.UpdateCommand = commandBuilder.GetUpdateCommand();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataAdapter.Fill(dataSet);
            dataSet.Tables[0].PrimaryKey = new DataColumn[] { dataSet.Tables[0].Columns[0] };
            dataViewInsertados = new DataView(dataSet.Tables[0]);
            dataViewInsertados.RowStateFilter = DataViewRowState.Added;
            dataViewActualizados = new DataView(dataSet.Tables[0]);
            dataViewActualizados.RowStateFilter = DataViewRowState.ModifiedCurrent;
            dataViewBorrados = new DataView(dataSet.Tables[0]);
            dataViewBorrados.RowStateFilter = DataViewRowState.Deleted;
            button4_Click(null, null);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataAdapter.Update(dataSet);
            Mostrar();
        }
        public void Mostrar()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = dataSet.Tables[0];
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = dataViewInsertados;
            dataGridView3.DataSource = null;
            dataGridView3.DataSource = dataViewActualizados;
            dataGridView4.DataSource = null;
            dataGridView4.DataSource = dataViewBorrados;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int legajo = int.Parse(Interaction.InputBox("Legajo","Insertar Cliente"));
                string nombre = Interaction.InputBox("Nombre", "Insertar Cliente");
                string apellido = Interaction.InputBox("Apellido", "Insertar Cliente");
                DataRow dataRow = dataSet.Tables[0].NewRow();
                dataRow.ItemArray = new object[] { legajo, nombre, apellido };
                dataSet.Tables[0].Rows.Add(dataRow);
            } catch(Exception error) { MessageBox.Show(error.Message); }
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
                }
            } catch(Exception error) { MessageBox.Show(error.Message); }
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
                int legajo = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                DataRow dataRow = dataSet.Tables[0].Rows.Find(legajo);
                dataRow.SetField<string>(1, Interaction.InputBox("Nombre", "", dataRow.ItemArray[1].ToString()));
                dataRow.SetField<string>(2, Interaction.InputBox("Apellido", "", dataRow.ItemArray[2].ToString()));
                Mostrar();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
