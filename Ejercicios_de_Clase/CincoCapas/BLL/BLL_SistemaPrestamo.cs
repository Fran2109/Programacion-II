using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using Interfaces;

namespace BLL
{
    public class BLL_SistemaPrestamo : Iabmc<BE_Prestamo>,Iabmc<BE_Persona>
    {
        BLL_Prestamo _bllp;
        BE_SistemaPrestamo _besp;
        
        public BLL_SistemaPrestamo() 
        {
          _bllp = new BLL_Prestamo();
          _besp = new BE_SistemaPrestamo();
          // Actualiza el estado de la BE_SistemaPrestamo con todos los porestamos que están grabados
          _besp.CargaListaPrestamos(_bllp.ConsultaTodosPrestamos());

        }


        public void Alta(BE_Prestamo pObject)
        {
            _bllp.Alta(pObject);
            // Actualiza el estado de la BE_SistemaPrestamo con todos los prestamos que están grabados
            _besp.CargaListaPrestamos(_bllp.ConsultaTodosPrestamos());
        }

        public void Alta(BE_Persona pObject)
        {
           throw new NotImplementedException();
        }

        public void Baja(BE_Prestamo pObject)
        {
             _bllp.Baja(pObject);
            // Actualiza el estado de la BE_SistemaPrestamo con todos los prestamos que están grabados
            _besp.CargaListaPrestamos(_bllp.ConsultaTodosPrestamos());
        }

        public void Baja(BE_Persona pObject)
        {
            throw new NotImplementedException();
        }

        public void Consulta(BE_Prestamo pObject)
        {
            throw new NotImplementedException();
        }

        public void Consulta(BE_Persona pObject)
        {
            throw new NotImplementedException();
        }

        public List<BE_Prestamo> ConsultaDesdeHasta(BE_Prestamo pObject1, BE_Prestamo pObject2)
        {
            throw new NotImplementedException();
        }

        public List<BE_Persona> ConsultaDesdeHasta(BE_Persona pObject1, BE_Persona pObject2)
        {
            throw new NotImplementedException();
        }

        public List<BE_Prestamo> ConsultaIncremental(BE_Prestamo pObject)
        {
            throw new NotImplementedException();
        }

        public List<BE_Persona> ConsultaIncremental(BE_Persona pObject)
        {
            throw new NotImplementedException();
        }

        public List<BE_Prestamo> ConsultaTodosPrestamos()
        {   
            return _besp.RetornaListaPrestamos();
        }
        public List<BE_Prestamo> ConsultaTodosPersonas()
        {
            throw new NotImplementedException();
        }

        public void Modificacion(BE_Prestamo pObject)
        {
            _bllp.Modificacion(pObject);
            // Actualiza el estado de la BE_SistemaPrestamo con todos los prestamos que están grabados
            _besp.CargaListaPrestamos(_bllp.ConsultaTodosPrestamos());

        }

        public void Modificacion(BE_Persona pObject)
        {
            throw new NotImplementedException();
        }

        public bool PersonaHabilitadaParaPrestamo(BE_Persona pPersona,List<BE_Prestamo> pListaPrestamo)
        {
            bool _habilitado = true;
            foreach (BE_Prestamo _p in pListaPrestamo)
            {
                if (_p.Persona.DNI == pPersona.DNI && _p.MontoDevuelto==0) { _habilitado = false;break; }
            }
            return _habilitado;
        }
        
        

    }
}
