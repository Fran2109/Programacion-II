using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_POO
{
    public interface IProducto
    {
        decimal ajusteDeCosto();
        void chequeDeVencidos();
    }
}
