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

namespace ADO_Conectado
{
    public partial class Form1 : Form
    {
        SqlConnection cx;
        SqlCommand cm;
        SqlDataReader dr;
        List<Cliente> _lc;
        public Form1()
        {
            InitializeComponent();
            cx = new SqlConnection("Data Source=.;Initial Catalog=Personas;Integrated Security=True");
            cx.StateChange += CambioDeEstado;
            cm = new SqlCommand("select * from cliente order by Legajo", cx);
            cm.CommandType = CommandType.Text;
            _lc = new List<Cliente>();
          
           
        }

        private void CambioDeEstado(object sender, StateChangeEventArgs e)
        {
            if(e.CurrentState==ConnectionState.Open)
            { pictureBox1.BackColor = Color.Green; }
            else
            { pictureBox1.BackColor = Color.Red; }
        }
            
        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.MultiSelect = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                if(cx.State==ConnectionState.Closed)
                {
                    cx.Open();
                    CargarLista();
                    Mostrar(dataGridView1, _lc);
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }

        private void CargarLista()
        {

            try
            {
                cm.CommandText = "select * from cliente order by Legajo";
                dr = cm.ExecuteReader();
                _lc.Clear();
                while (dr.Read())
                {

                    _lc.Add(new Cliente()
                    {
                        Legajo = int.Parse(dr.GetValue(0).ToString()),
                        Nombre = dr.GetValue(1).ToString(),
                        Apellido = dr.GetValue(2).ToString()
                    });
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { dr.Close();}
            
        }

        private void Mostrar(DataGridView pDGV, object pO)
        { pDGV.DataSource = null;pDGV.DataSource = pO; }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                cx.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {

            try
            {
                string _legajo = Interaction.InputBox("Legajo: ");
                if (!Information.IsNumeric(_legajo)) throw new Exception("Legajo Inválido");
                string _nombre = Interaction.InputBox("Nombre: ");
                string _apellido = Interaction.InputBox("Aoellido: ");
                cm.CommandText = $"insert into Cliente (Legajo,Nombre,Apellido) values ({int.Parse(_legajo)},'{_nombre}','{_apellido}')";
                cm.ExecuteNonQuery();
                CargarLista();
                Mostrar(dataGridView1,_lc);
            
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }

        private void button4_Click(object sender, EventArgs e)
        {

            try
            {
                if (dataGridView1.Rows.Count == 0) throw new Exception("No hay registros para borrar !!!");
                cm.CommandText = $"delete from Cliente where Legajo={(dataGridView1.SelectedRows[0].DataBoundItem as Cliente).Legajo}";
                cm.ExecuteNonQuery();
                CargarLista();
                Mostrar(dataGridView1, _lc);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count == 0) throw new Exception("No hay registros para modificar !!!");
                Cliente caux = (dataGridView1.SelectedRows[0].DataBoundItem as Cliente);
                string _legajo = Interaction.InputBox("Legajo: ","",caux.Legajo.ToString());
                if (!Information.IsNumeric(_legajo)) throw new Exception("Legajo Inválido");
                string _nombre = Interaction.InputBox("Nombre: ","",caux.Nombre);
                string _apellido = Interaction.InputBox("Aoellido: ","",caux.Apellido);
                cm.CommandText = $"UPDATE Cliente SET Legajo = {_legajo}, Nombre = '{_nombre}', Apellido = '{_apellido}' WHERE Legajo = {caux.Legajo}";
                cm.ExecuteNonQuery();
                CargarLista();
                Mostrar(dataGridView1, _lc);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
    public class Cliente
    {
        public int Legajo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
    }

}
