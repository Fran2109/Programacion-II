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

/*
Sitúese en un escenario bancario donde nos manifiestan la necesidad de desarrollar un sistema 
para administrar las cuentas de los clientes.

Nos brindan la siguiente información:

•	Trabajan con dos tipos de cuentas: las cuentas corrientes y las cajas de ahorro.
•	El banco también posee titulares de cuenta.
•	Un titular puede tener más de una cuenta y una cuenta posee un titular.
•	Las cuentas se identifican por un número y los titulares por su tipo y número de documento.
•	De los titulares también se desea saber su nombre y apellido.
•	En las cuentas del banco se pueden realizar depósitos, extracciones y transferencias 
    de una cuenta a otra.
•	Un aspecto significativo es que las cuentas corrientes poseen una característica 
    que es la de poder girar en descubierto un determinado monto que es individual a cada cuenta.
•	El límite de descubierto es una característica de cada cuenta corriente.

Nos solicitan:

1. Determinar el alcance del sistema en no más de cinco renglones.
2. Enumerar las clases que se observan en el mismo.
3. Colocarle a cada clase las propiedades distintivas y los métodos que considere necesarios 
    de acuerdo al enunciado.
4.	Relacionar las clases en las jerarquías que considere pertinentes (Herencia y Agregación)

*/
namespace EjercicioBanco
{
    public partial class Form1 : Form
    {
        Banco _ba;
        VistaCuenta _vcu;
        public Form1()
        {
            InitializeComponent();
            _ba = new Banco();
            _vcu = new VistaCuenta();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.MultiSelect = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.MultiSelect = false;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView3.MultiSelect = false;
            dataGridView3.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                string _td = Interaction.InputBox($"Tipo de Documento{Environment.NewLine}" +
                             $"0 = DNI{Environment.NewLine}" +
                             $"1 = CI");
                if (int.Parse(_td) < 0 || int.Parse(_td) > 1) { throw new Exception("Tipo de documento inválido !!!"); }
                string _nd = Interaction.InputBox("Número de documento: ");
                if (!Information.IsNumeric(_nd)) { throw new Exception("Número de documento inválido !!!"); }
                string _no = Interaction.InputBox("Nombre: ");
                string _ap = Interaction.InputBox("Apellido: ");
                _ba.AgregarTitular( new Titular((TipoDocumento)int.Parse(_td), int.Parse(_nd), _no, _ap));
                Mostrar(dataGridView1, _ba.RetornaListaTitulares());
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }
        private void Mostrar(DataGridView pDGV, object pO)
        {
            pDGV.DataSource = null;pDGV.DataSource = pO;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count == 0) { throw new Exception("No hay titulares para borar !!!"); }
                _ba.BorrarTitular(dataGridView1.SelectedRows[0].DataBoundItem as Titular);
                Mostrar(dataGridView1, _ba.RetornaListaTitulares());
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count == 0) { throw new Exception("No hay titulares para borar !!!"); }
                Titular _aux = dataGridView1.SelectedRows[0].DataBoundItem as Titular;
                string _td = Interaction.InputBox($"Tipo de Documento{Environment.NewLine}" +
                           $"0 = DNI{Environment.NewLine}" +
                           $"1 = CI","Modificando ...",_aux.Tipo==TipoDocumento.DNI?"0":"1");
                if (int.Parse(_td) < 0 || int.Parse(_td) > 1) { throw new Exception("Tipo de documento inválido !!!"); }    
                string _nd = Interaction.InputBox("Número de documento: ","Modificando...",_aux.NumeroDocumento.ToString());
                if (!Information.IsNumeric(_nd)) { throw new Exception("Número de documento inválido !!!"); }
                string _no = Interaction.InputBox("Nombre: ","Modificando...",_aux.Nombre);
                string _ap = Interaction.InputBox("Apellido: ", "Modificando...", _aux.Apellido);
                TipoDocumento _auxTD = _aux.Tipo;
                int _auxND = _aux.NumeroDocumento;
                _aux.Tipo = (TipoDocumento)int.Parse(_td);
                _aux.NumeroDocumento = int.Parse(_nd);
                _aux.Nombre = _no;
                _aux.Apellido = _ap;
                _ba.ModificarTitular(_aux,_auxTD,_auxND);            
                Mostrar(dataGridView1, _ba.RetornaListaTitulares());
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }

        private void button5_Click(object sender, EventArgs e)
        {

            try
            {
                string _nrocta = Interaction.InputBox("Ingrese el número de cuenta: ");
                // Verificamos si el nro es numérico
                if (Information.IsNumeric(_nrocta))
                {
                    //Verificamos que no exista el nro de cuenta en la lista de cuentas del banco
                    if (!_ba.RetornaListaCuentas().Exists(x => x.Numero == int.Parse(_nrocta)))
                    {
                        //Determino que cta creo
                        Cuenta _aux;
                        if (radioButton1.Checked)
                        {
                            _aux = new CA(int.Parse(_nrocta), dataGridView1.SelectedRows[0].DataBoundItem as Titular);
                        }
                        else
                        {
                            // Solicitamos el descubierto al usuario
                            string _des = Interaction.InputBox("Ingrese el monto acordado para el descubierto de la CC: ");
                            // Verificamos si el descubierto es numérico
                            if (Information.IsNumeric(_des))
                            {
                                _aux = new CC(int.Parse(_nrocta), dataGridView1.SelectedRows[0].DataBoundItem as Titular,decimal.Parse(_des));
                            }
                            else throw new Exception("El valor ingresado como descubieto no es válido !!!");
                        }
                        _ba.AgregarCuenta(_aux);
                        Mostrar(dataGridView2,_vcu.RetornaVistaCuenta(_ba.RetornaListaCuentas()));
                        dataGridView1_RowEnter(null, null);
                    }
                    else throw new Exception("La cuenta ya existe !!!");
                }
                else throw new Exception("El valor ingresado no es numérico !!!");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Titular _auxT = dataGridView1.SelectedRows[0].DataBoundItem as Titular;
                dataGridView3.DataSource = null;
                dataGridView3.DataSource=_vcu.RetornaVistaCuenta(_ba.RetornaListaTitulares().Find(x => x.Tipo==_auxT.Tipo && x.NumeroDocumento==_auxT.NumeroDocumento).RetornaListaCuentas());
            }
            catch (Exception) {}
        }

        private void button6_Click(object sender, EventArgs e)
        {

            try
            {
                string _monto = Interaction.InputBox("Ingrese el monto a depositar: ");
                // Verificamos si el nro es numérico
                if (Information.IsNumeric(_monto))
                {
                    // Retorna la cuenta seleccionada en la grilla 3
                    Cuenta _auxC = (dataGridView3.SelectedRows[0].DataBoundItem as VistaCuenta).RetornaCuentaOriginal();
                    // Verifica que la cuenta exista
                    if (_auxC != null)
                    {
                        // Se solicita al banco depositar en la cta _auxC el monto _monto
                        _ba.Depositar(_auxC,decimal.Parse(_monto));
                        // Refresca la grilla 2
                        Mostrar(dataGridView2, _vcu.RetornaVistaCuenta(_ba.RetornaListaCuentas()));
                        // Refresca la grilla 3
                        dataGridView1_RowEnter(null, null);
                    }
                    else throw new Exception("No existe la cuenta en la que desea depositar !!!");
                }
                else { throw new Exception("El valor ingresado no es  numérico !!!"); }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }

        private void button7_Click(object sender, EventArgs e)
        {

            try
            {
                string _monto = Interaction.InputBox("Ingrese el monto a extraer: ");
                // Verificamos si el nro es numérico
                if (Information.IsNumeric(_monto))
                {
                    // Retorna la cuenta seleccionada en la grilla 3
                    Cuenta _auxC = (dataGridView3.SelectedRows[0].DataBoundItem as VistaCuenta).RetornaCuentaOriginal();
                    // Verifica que la cuenta exista
                    if (_auxC != null)
                    {
                        // Se solicita al banco extraer en la cta _auxC el monto _monto
                        if(!_ba.Extraer(_auxC, decimal.Parse(_monto))) throw new Exception("Ne se ha podido procesar la extracción !!!");
                        // Refresca la grilla 2
                        Mostrar(dataGridView2, _vcu.RetornaVistaCuenta(_ba.RetornaListaCuentas()));
                        // Refresca la grilla 3
                        dataGridView1_RowEnter(null, null);
                    }
                    else throw new Exception("No existe la cuenta en la que desea depositar !!!");
                }
                else { throw new Exception("El valor ingresado no es  numérico !!!"); }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                string _monto = Interaction.InputBox("Ingrese el monto a extraer: ");
                // Verificamos si el nro es numérico
                if (Information.IsNumeric(_monto))
                {
                    // Retorna la cuenta de origen seleccionada en la grilla 3
                    Cuenta _auxCO = (dataGridView3.SelectedRows[0].DataBoundItem as VistaCuenta).RetornaCuentaOriginal();
                    // Retorna la cuenta de origen seleccionada en la grilla 3
                    Cuenta _auxCD = (dataGridView2.SelectedRows[0].DataBoundItem as VistaCuenta).RetornaCuentaOriginal();


                    // Verifica que las cuentas existan
                    if (_auxCO != null  && _auxCD != null)
                    {
                        // Se solicita al banco transferir de la cta _auxCO el monto _monto a la cuenta _auxCD
                        _ba.Transferir(_auxCO, _auxCD, decimal.Parse(_monto));
                        // Refresca la grilla 2
                        Mostrar(dataGridView2, _vcu.RetornaVistaCuenta(_ba.RetornaListaCuentas()));
                        // Refresca la grilla 3
                        dataGridView1_RowEnter(null, null);
                    }
                    else throw new Exception("Una o ambas cuentas no existe !!!");
                }
                else { throw new Exception("El valor ingresado no es  numérico !!!"); }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
