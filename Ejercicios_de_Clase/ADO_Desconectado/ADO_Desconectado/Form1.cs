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
using Microsoft.VisualBasic;

namespace ADO_Desconectado
{
    public partial class Form1 : Form
    {
        DataSet ds;
        SqlDataAdapter da;
        SqlCommandBuilder cb;
        DataView dvi;
        DataView dvb;
        DataView dvm;


        public Form1()
        {
            InitializeComponent();
            da = new SqlDataAdapter("select * from cliente", "Data Source=.;Initial Catalog=Personas;Integrated Security=True");
            ds = new DataSet();
            cb = new SqlCommandBuilder(da);
            da.InsertCommand = cb.GetInsertCommand();
            da.DeleteCommand = cb.GetDeleteCommand();
            da.UpdateCommand = cb.GetUpdateCommand();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.MultiSelect = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            da.Fill(ds);
            ds.Tables[0].PrimaryKey = new DataColumn[] { ds.Tables[0].Columns[0] };
            button4_Click(null, null);
            dvi = new DataView(ds.Tables[0]);
            dvb = new DataView(ds.Tables[0]);
            dvm = new DataView(ds.Tables[0]);
            dvi.RowStateFilter = DataViewRowState.Added;
            dvb.RowStateFilter = DataViewRowState.Deleted;
            dvm.RowStateFilter = DataViewRowState.ModifiedCurrent;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                string legajo = Interaction.InputBox("Legajo: ");
                if (!Information.IsNumeric(legajo)) throw new Exception("Legajo inválido !!!");
                string nombre = Interaction.InputBox("Nombre: ");
                string apellido = Interaction.InputBox("Apellido: ");
                DataRow dr = ds.Tables[0].NewRow();
                dr.ItemArray = new object[] { int.Parse(legajo), nombre, apellido };
                ds.Tables[0].Rows.Add(dr);
                Refrescar();

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }


        }

        private void Refrescar()
        {
            dataGridView1.DataSource = null; dataGridView1.DataSource = ds.Tables[0];
            dataGridView2.DataSource = null; dataGridView2.DataSource = dvi;
            dataGridView3.DataSource = null; dataGridView3.DataSource = dvb;
            dataGridView4.DataSource = null; dataGridView4.DataSource = dvm;
            dvi.RowFilter = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int legajo = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                if(MessageBox.Show($"Está seguro de borrar el registro {legajo}","",MessageBoxButtons.YesNo)==DialogResult.Yes)
                {
                    (ds.Tables[0].Rows.Find(legajo)).Delete();
                    Refrescar();
                    
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            try
            {
                int legajo = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                DataRow dr=ds.Tables[0].Rows.Find(legajo);
                dr.SetField<string>(1,Interaction.InputBox("Nombre: ","",dr.ItemArray[1].ToString()));
                dr.SetField<string>(2,Interaction.InputBox("Apellido: ", "", dr.ItemArray[2].ToString()));
                Refrescar();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            da.Update(ds);
            Refrescar();
        
        }
    }
}
