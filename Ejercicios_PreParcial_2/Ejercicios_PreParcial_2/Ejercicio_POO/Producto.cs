using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_POO
{
    public abstract class Producto : IProducto
    {
        decimal costo;
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaVto { get; set; }
        public decimal Costo { get { return costo; } }
        public event EventHandler<vencidosEventArgs> vencidos;
        public Producto(decimal costo, int id, string descripcion, DateTime fechaVto)
        {
            this.costo = costo;
            Id = id;
            Descripcion = descripcion;
            FechaVto = fechaVto;
        }
        public Producto(Producto producto)
        {
            costo = producto.Costo;
            Id = producto.Id;
            Descripcion = producto.Descripcion;
            FechaVto = producto.FechaVto;
            vencidos = producto.vencidos;
        }
        public abstract decimal ajusteDeCosto();
        public void chequeDeVencidos()
        {
            if(FechaVto < DateTime.Today)
            {
                vencidos?.Invoke(this, new vencidosEventArgs(this));
            }
        }
    }
    public class ProductoA : Producto
    {
        public ProductoA(decimal costo, int id, string descripcion, DateTime fechaVto) : base(costo, id, descripcion, fechaVto) { }
        public ProductoA(Producto producto) : base(producto) { }
        public override decimal ajusteDeCosto()
        {
            int diasVto = (FechaVto - DateTime.Today).Days;
            decimal rdo = Costo;
            if (diasVto == 1) rdo = Costo * 0.8m;
            if (diasVto >= 2 && diasVto <= 7) rdo = Costo * 0.9m;
            return rdo;
        }
    }
    public class ProductoB : Producto
    {
        public ProductoB(decimal costo, int id, string descripcion, DateTime fechaVto) : base(costo, id, descripcion, fechaVto) { }
        public ProductoB(Producto producto) : base(producto) { }
        public override decimal ajusteDeCosto()
        {
            int diasVto = (FechaVto - DateTime.Today).Days;
            decimal rdo = Costo;
            if (diasVto == 1) rdo = Costo * 0.5m;
            if (diasVto >= 2 && diasVto <= 7) rdo = Costo * 0.7m;
            return rdo;
        }
    }
    public class vencidosEventArgs : EventArgs
    {
        Producto producto;
        public vencidosEventArgs(Producto producto)
        {
            this.producto = producto;
        }
        public string Datos 
        {
            get
            {
                return $"El producto con ID = {producto.Id} esta vencido";
            }
        }
    }
}
