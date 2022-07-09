using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using BE;
using Interfaces;
using System.Data;

namespace Mapeadores
{
    public class ORM_Prestamo : Iabmc<BE_Prestamo>,IDisposable
    {
        DAO_AccesoDatos _dao;DataSet _ds; 

        public ORM_Prestamo()
        { _dao = new DAO_AccesoDatos(); _ds = _dao.RetornaDataSet(); }
        public void Alta(BE_Prestamo pObject)
        {

            try
            {
                DataTable _dtPrestamo = _ds.Tables["Prestamo"];
                DataRow _drPrestamo = _dtPrestamo.NewRow();
                _drPrestamo.ItemArray = new object[] {pObject.Codigo,pObject.MontoOtorgado,pObject.FechaOtorgado,
                                              pObject.Interes,pObject.InteresPunitorio,pObject.FechaVencimiento,
                                              pObject.FechaDevolucion,pObject.MontoDevuelto,pObject.Persona.DNI};
            
                DataTable _dtPersona = _ds.Tables["Persona"];
                if(_dtPersona.Rows.Find(pObject.Persona.DNI)==null)
                {
                    DataRow _drPersona = _dtPersona.NewRow();
                    _drPersona.ItemArray = new object[] { pObject.Persona.DNI, pObject.Persona.Nombre, pObject.Persona.Apellido };
                    _dtPersona.Rows.Add(_drPersona);
                }


                _dtPrestamo.Rows.Add(_drPrestamo);          
                _dao.GrabarDatos();

            }
            catch (Exception ex) { throw ex; }
       
    }

        public void Baja(BE_Prestamo pObject)
        {
            try
            {
                DataTable _dtPrestamo = _ds.Tables["Prestamo"];
                _dtPrestamo.Rows.Remove(_dtPrestamo.Select($"Codigo={pObject.Codigo}")[0]);
                _dao.GrabarDatos();
            }
            catch (Exception ex) { throw ex; }
        }

        public void Consulta(BE_Prestamo pObject)
        {
            throw new NotImplementedException();
        }
        public List<BE_Prestamo> ConsultaTodosPrestamos()
        {
            List<BE_Prestamo> _aux = new List<BE_Prestamo>();
            foreach (DataRow _r in _ds.Tables["Prestamo"].Rows)
            {
                BE_Persona _auxper = new BE_Persona(_ds.Tables["Persona"].Rows.Find(_r.Field<string>("DNI")).ItemArray);        
                _aux.Add(new BE_Prestamo(_r.ItemArray,_auxper));
            }
            return _aux;
        }

        public List<BE_Prestamo> ConsultaDesdeHasta(BE_Prestamo pObject1, BE_Prestamo pObject2)
        {
            throw new NotImplementedException();
        }

        public List<BE_Prestamo> ConsultaIncremental(BE_Prestamo pObject)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
           _dao = null;
        }

        public void Modificacion(BE_Prestamo pObject)
        {
            try
            {
                DataTable _dtPrestamo = _ds.Tables["Prestamo"];
                DataRow aux_DataRow = _dtPrestamo.Select($"Codigo={pObject.Codigo}")[0];
                aux_DataRow.ItemArray = new object[] {pObject.Codigo,pObject.MontoOtorgado,pObject.FechaOtorgado,
                                              pObject.Interes,pObject.InteresPunitorio,pObject.FechaVencimiento,
                                              pObject.FechaDevolucion,pObject.MontoDevuelto,pObject.Persona.DNI};
                _dao.GrabarDatos();
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
