using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio_POO
{
    public class Comercio : IComercio<Producto>
    {
        List<Producto> lista_productos;
        public Comercio()
        {
            lista_productos = new List<Producto>();
        }

        public void BorrarProducto(Producto producto)
        {
            
            if(lista_productos.Remove(lista_productos.Find(p => p.Id == producto.Id  && p.Costo == producto.Costo && p.Descripcion == producto.Descripcion && p.FechaVto == producto.FechaVto)))
            {
                MessageBox.Show("Producto Eliminado");
            }
            else
            {
                MessageBox.Show("El Producto no se ha Eliminado");
            }
        }

        public void InsertarProducto(Producto producto)
        {
            Producto productoAux = null;
            if(producto is ProductoA)
            {
                productoAux = new ProductoA(producto);
            }
            else
            {
                productoAux = new ProductoB(producto);
            }
            lista_productos.Add(productoAux);
        }
        public List<Producto> LeerProductos()
        {
            List<Producto> listaAuxiliar = new List<Producto>();
            foreach(Producto productoAux in lista_productos)
            {
                Producto productoAuxilar = null;
                if(productoAux is ProductoA)
                {
                    productoAuxilar = new ProductoA(productoAux);
                } 
                else if(productoAux is ProductoB)
                {
                    productoAuxilar = new ProductoB(productoAux);
                }
                listaAuxiliar.Add(productoAuxilar);
            }
            return listaAuxiliar;
        }

        public void ModificarProducto(Producto producto, Producto nuevoProducto)
        {
            Producto prod = lista_productos.Find(p => p.Id == producto.Id);
            prod.Descripcion = nuevoProducto.Descripcion;
            prod.FechaVto = nuevoProducto.FechaVto;
        }
    }
}
