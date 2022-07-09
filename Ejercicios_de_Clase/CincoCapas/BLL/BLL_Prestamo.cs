using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using Mapeadores;
using Interfaces;

namespace BLL
{
    public class BLL_Prestamo : Iabmc<BE_Prestamo>, IDisposable
    {
        ORM_Prestamo _ormpre;
        public BLL_Prestamo() { _ormpre = new ORM_Prestamo(); }
        public void Alta(BE_Prestamo pObject)
        {
            _ormpre.Alta(pObject);
        }

        public void Baja(BE_Prestamo pObject)
        {
            _ormpre.Baja(pObject);
        }

        public void Consulta(BE_Prestamo pObject)
        {
            throw new NotImplementedException();
        }
        public List<BE_Prestamo> ConsultaTodosPrestamos()
        {
           return _ormpre.ConsultaTodosPrestamos();
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
           _ormpre = null;
        }

        public void Modificacion(BE_Prestamo pObject)
        {
            _ormpre.Modificacion(pObject);
        }

      
    }


}
