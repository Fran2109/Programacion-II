using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;

namespace DAO
{
    public class DAO_AccesoDatos
    {
        DataSet _ds;
        DataTable _dtPrestamo;
        DataTable _dtPersona;
        public DAO_AccesoDatos()
        {
            _ds = new DataSet("Datos");
            if (!File.Exists("Datos.xml")) { CrearArchivo(); }
            else { _ds.ReadXml("Datos.xml"); }
        }
        public DataSet RetornaDataSet() { return _ds; }
        public void GrabarDatos()
        {
            _ds.WriteXml("Datos.xml", XmlWriteMode.WriteSchema);

        }
        private void CrearArchivo()
        {
           
            _dtPrestamo = new DataTable("Prestamo");
            _dtPersona = new DataTable("Persona");

            _dtPrestamo.Columns.Add("Codigo", typeof(string));
            _dtPrestamo.Columns.Add("MontoOtorgado", typeof(decimal));
            _dtPrestamo.Columns.Add("FechaOtorgado", typeof(DateTime));
            _dtPrestamo.Columns.Add("Interes", typeof(decimal));
            _dtPrestamo.Columns.Add("InteresPunitorio", typeof(decimal));
            _dtPrestamo.Columns.Add("FechaVencimiento", typeof(DateTime));
            _dtPrestamo.Columns.Add("FechaDevolucion", typeof(DateTime));
            _dtPrestamo.Columns.Add("MontoDevuelto", typeof(decimal));
            _dtPrestamo.Columns.Add("DNI", typeof(string));
            _dtPrestamo.PrimaryKey = new DataColumn[] {_dtPrestamo.Columns[0] };

            _dtPersona.Columns.Add("DNI", typeof(string));
            _dtPersona.Columns.Add("Nombre", typeof(string));
            _dtPersona.Columns.Add("Apellido", typeof(string));
            _dtPersona.PrimaryKey = new DataColumn[] { _dtPersona.Columns[0] };

            _ds.Tables.AddRange(new DataTable[] { _dtPrestamo, _dtPersona});

            GrabarDatos();
    }
    }
}
