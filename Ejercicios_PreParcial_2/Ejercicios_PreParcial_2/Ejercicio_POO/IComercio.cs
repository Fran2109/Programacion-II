using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_POO
{
    public interface IComercio<P>
    {
        void InsertarProducto(P producto);
        List<P> LeerProductos();
        void BorrarProducto(P producto);
        void ModificarProducto(P producto, P nuevoProducto);
    }
}
