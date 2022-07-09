using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using BLL;
using Microsoft.VisualBasic;
using ServicioValidacionVista;

namespace Vista
{
    public partial class Form1 : Form
    {
        // 1. Pensar y elaborar una lista con el mismo criterio visto en clase de otras reglas de negocio puede tener SistemaPrestamo y Prestamo
        // 2. Establecer una estrategia para que la capa de vista pueda mostrar los prestamos y la persona que lo posee asignado.
        // 3. Considerando que los mapeadores sirven para descomponer los estados de los objetos en estructuras de datos de ADO.NET, qué clases colocaría en la capa de mapeo y con que funcionalidades.
        // 4. Qué clase colocaría en la capa de DAO y con qué funcionalidad consideranndo que se persistirán los datos en un documento XML?
        // 5. Presente una idea sobre como manejaría un sistema de Log-In / Log-Out y uno para el manejo de Perfiles de usuarios.
        // REGLAS DE NEGOCIO:
        //    OK 1. La persona no puede tener más de un préstamo por retornar
        //    2. Los prestamos se retornan en su totalidad más los interses que correspondas
        //    3. El monto devuelto es igual al otorgado por el interes por los días que duró el prestamo
        //    4. Si la persona retorna el préstamo en una fecha posterior al vto, además del interés se calcula el interes punitorio (monto otorgado * días de retraso * Interés punitorio  )

        VAL_Prestamo _vpre;
        VAL_General _vgen;
        VAL_Persona _vper;

        BLL_SistemaPrestamo _bllsp;

        VistaPrestamo _vp;

        public Form1()
        {
            InitializeComponent();
            _vpre = new VAL_Prestamo();
            _vgen = new VAL_General();
            _vper = new VAL_Persona();
            _bllsp = new BLL_SistemaPrestamo();
            _vp = new VistaPrestamo();


        }

        private void Form1_Load(object sender, EventArgs e)
        {
         
            RefrescaGrillaPrestamos(dataGridView1,_vp.RetornaVistaPrestamo(_bllsp.ConsultaTodosPrestamos()));
            dataGridView1.MultiSelect = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        public void RefrescaGrillaPrestamos(DataGridView pDGV, object pObject)
        {
            pDGV.DataSource = null; pDGV.DataSource = pObject;
            dataGridView1.Columns[8].Width = 200;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {

                string _codigo;
                string _montoOtorgado;
                DateTime _fechaOtorgamiento = dateTimePicker1.Value;
                DateTime _fechaVencimiento = dateTimePicker2.Value;
                string _interes;
                string _interesPunitorio;

                string _dni;


                _codigo = Interaction.InputBox("Código: ");
                BE_Prestamo _pre = new BE_Prestamo(_codigo);
                // Verificación de código no repetido
                if (_vpre.ExistePrestamo(_pre, _bllsp.ConsultaTodosPrestamos())) { throw new Exception("El código que intenta ingresar existe !!!"); };
                _montoOtorgado = Interaction.InputBox("Monto: ");
                // Verificación de valor numérico
                if (!_vgen.EsNumerico(_montoOtorgado)) { throw new Exception("El monto ingresado no es numérico !!!"); }
                _interes = Interaction.InputBox("Interés: ");
                // Verificación de valor numérico
                if (!_vgen.EsNumerico(_interes)) { throw new Exception("El monto ingresado no es numérico !!!"); }
                _interesPunitorio = Interaction.InputBox("Interés Punitorio: ");
                // Verificación de valor numérico
                if (!_vgen.EsNumerico(_interesPunitorio)) { throw new Exception("El monto ingresado no es numérico !!!"); }

                _dni = Interaction.InputBox("DNI (99.999.999): ", "Formato de ingreso 99.999.999");
                BE_Persona _per = new BE_Persona(_dni);
                // Verificación de valor numérico
                if (!_vper.ValidaDNI(_per)) { throw new Exception("El dni ingresado es inválido !!!"); }
                _per.Nombre = Interaction.InputBox("Nombre: ");
                _per.Apellido = Interaction.InputBox("Apellido: ");
                _pre.MontoOtorgado = decimal.Parse(_montoOtorgado);
                _pre.FechaOtorgado = _fechaOtorgamiento;
                _pre.FechaVencimiento = _fechaVencimiento;
                _pre.Interes = decimal.Parse(_interes);
                _pre.InteresPunitorio = decimal.Parse(_interesPunitorio);
                _pre.Persona = _per;
                // Solicito servicio a BLL
                _bllsp.Alta(_pre);
                // Refresco Grilla
                RefrescaGrillaPrestamos(dataGridView1, _vp.RetornaVistaPrestamo(_bllsp.ConsultaTodosPrestamos()));





            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                _bllsp.Baja((dataGridView1.SelectedRows[0].DataBoundItem as VistaPrestamo).Recuperaorigen());
                RefrescaGrillaPrestamos(dataGridView1, _vp.RetornaVistaPrestamo(_bllsp.ConsultaTodosPrestamos()));

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
                
        }

        private void button3_Click(object sender, EventArgs e)
        {

            try
            {
                BE_Prestamo aux_BE_PRE = (dataGridView1.SelectedRows[0].DataBoundItem as VistaPrestamo).Recuperaorigen();
                aux_BE_PRE.MontoOtorgado = decimal.Parse(Interaction.InputBox("Monto: ","Modificando", aux_BE_PRE.MontoOtorgado.ToString()));
                aux_BE_PRE.Interes = decimal.Parse(Interaction.InputBox("Interés: ", "Modificando", aux_BE_PRE.Interes.ToString()));
                aux_BE_PRE.InteresPunitorio = decimal.Parse(Interaction.InputBox("Interés punitorio: ", "Modificando", aux_BE_PRE.InteresPunitorio.ToString()));
                aux_BE_PRE.FechaOtorgado = DateTime.Parse(Interaction.InputBox("Fecha Otorgado: ", "Modificando", aux_BE_PRE.FechaOtorgado.ToString()));
                aux_BE_PRE.FechaDevolucion = DateTime.Parse(Interaction.InputBox("Fecha Devolución: ", "Modificando", aux_BE_PRE.FechaDevolucion.ToString()));
                _bllsp.Modificacion(aux_BE_PRE);
                RefrescaGrillaPrestamos(dataGridView1, _vp.RetornaVistaPrestamo(_bllsp.ConsultaTodosPrestamos()));

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }
    }

    class VistaPrestamo
    {
        BE_Prestamo _origen = null;
        public VistaPrestamo(){}
        public VistaPrestamo(string pCodigo, decimal pMontoOtorgado, DateTime pfechaOtorgado, decimal pInteres, decimal pInteresPunitorio, DateTime pfechaVencimiento, DateTime pfechaDevolucion, string pPersona, decimal pMontoDevuelto = 0, BE_Prestamo pOrigen=null)
        {
            Codigo = pCodigo; 
            MontoOtorgado = pMontoOtorgado; 
            FechaOtorgado = pfechaOtorgado;
            Interes = pInteres; 
            InteresPunitorio = pInteresPunitorio; 
            FechaVencimiento = pfechaVencimiento;
            FechaDevolucion = pfechaDevolucion; 
            MontoDevuelto = pMontoDevuelto; 
            Persona = pPersona;
            _origen = pOrigen;
        }
        public string Codigo { get; set; }
        public decimal MontoOtorgado { get; set; }
        public DateTime FechaOtorgado { get; set; }
        public decimal Interes { get; set; }
        public decimal InteresPunitorio { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public DateTime FechaDevolucion { get; set; }
        public decimal MontoDevuelto { get; set; }
        public string Persona { get; set; }
        public BE_Prestamo Recuperaorigen() { return _origen; }
        public List<VistaPrestamo> RetornaVistaPrestamo(List<BE_Prestamo> pBELP)
        {
            List<VistaPrestamo> _aux = new List<VistaPrestamo>();
            foreach(BE_Prestamo p in pBELP)
            {
                _aux.Add(new VistaPrestamo(p.Codigo, 
                                            p.MontoOtorgado, 
                                            p.FechaOtorgado, 
                                            p.Interes, 
                                            p.InteresPunitorio, 
                                            p.FechaVencimiento, 
                                            p.FechaDevolucion, 
                                            $"{p.Persona.DNI} {p.Persona.Apellido}, {p.Persona.Nombre}", 
                                            p.MontoDevuelto,p));
            }


            return _aux;

        }
    }
   
}
