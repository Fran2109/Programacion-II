using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BE_SistemaPrestamo
    {
        List<BE_Prestamo> _lpre;
        public BE_SistemaPrestamo() { _lpre = new List<BE_Prestamo>(); }
        public BE_SistemaPrestamo(List<BE_Prestamo> pListaBE_Prestamos) { _lpre = pListaBE_Prestamos; }

        public List<BE_Prestamo> RetornaListaPrestamos()
        {
            List<BE_Prestamo> _auxListPrestamos = new List<BE_Prestamo>();
            foreach(BE_Prestamo _p in _lpre)
            {
                _auxListPrestamos.Add(_p.CloneTipado());
            }
            return _auxListPrestamos;
        }
        public void CargaListaPrestamos(List<BE_Prestamo> pListBE_Prestamos)
        {

            _lpre.Clear();
            foreach (BE_Prestamo _p in pListBE_Prestamos)
            {
                _lpre.Add(_p.CloneTipado());
            }
        }

    }
}
