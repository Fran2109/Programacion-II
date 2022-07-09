using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace ServicioValidacionVista
{
    public class VAL_Prestamo
    {
        public bool ExistePrestamo(BE_Prestamo _pPrestamo,List<BE_Prestamo> _pListaPrestamos)
        {
            return _pListaPrestamos.Exists(x => x.Codigo == _pPrestamo.Codigo);

        }
    }
}
