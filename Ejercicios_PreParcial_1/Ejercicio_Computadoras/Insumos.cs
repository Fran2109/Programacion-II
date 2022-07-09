using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_Computadoras
{
    public abstract class Insumo
    {
        public EventHandler ValorIncorrecto;
        Decimal decimal_precio;
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string Marca { get; set; }
        public Decimal Precio
        {
            get{ return decimal_precio; }
            set
            {
                if (value < 0)
                {
                    ValorIncorrecto?.Invoke(this, null);
                }
                else
                {
                    decimal_precio = value;
                }
            }
        }
        public Insumo(string codigo, string descripcion, string marca, decimal precio, EventHandler evento)
        {
            ValorIncorrecto += evento;
            Codigo = codigo;
            Descripcion = descripcion;
            Marca = marca;
            Precio = precio;
        }
        public Insumo(Insumo insumo)
        {
            Codigo = insumo.Codigo;
            Descripcion = insumo.Descripcion;
            Marca = insumo.Marca;
            Precio = insumo.Precio;
        }
    }
    public class Procesador : Insumo 
    { 
        public string Frecuencia { get; set; }
        public Procesador(string codigo, string descripcion, string marca, decimal precio, string frecuencia, EventHandler evento) : base(codigo, descripcion, marca, precio, evento)
        {
            Frecuencia = frecuencia;
        }
        public Procesador(Insumo insumo) : base(insumo)
        {
            Frecuencia = (insumo as Procesador).Frecuencia;
        }
    }
    public class Disco : Insumo 
    {
        public string Tipo { get; set; }
        public string Almacenamiento { get; set; }
        public Disco(string codigo, string descripcion, string marca, decimal precio, string tipo, string almacenamiento, EventHandler evento) : base(codigo, descripcion, marca, precio, evento)
        {
            Tipo = tipo;
            Almacenamiento = almacenamiento;
        }
        public Disco(Insumo insumo) : base(insumo)
        {
            Tipo = (insumo as Disco).Tipo;
            Almacenamiento = (insumo as Disco).Almacenamiento;
        }
    }
    public class Placa : Insumo
    {
        public Placa(string codigo, string descripcion, string marca, decimal precio, EventHandler evento) : base(codigo, descripcion, marca, precio, evento) { }
        public Placa(Insumo insumo) : base(insumo) { }
    }
    public class Grafica : Insumo
    {
        public string RAM;
        public Grafica(string codigo, string descripcion, string marca, decimal precio, string rAM, EventHandler evento) : base(codigo, descripcion, marca, precio, evento)
        {
            RAM = rAM;
        }
        public Grafica(Insumo insumo) : base(insumo)
        {
            RAM = (insumo as Grafica).RAM;
        }
    }
    public class Fuente : Insumo
    {
        public string Voltaje;
        public Fuente(string codigo, string descripcion, string marca, decimal precio, string voltaje, EventHandler evento) : base(codigo, descripcion, marca, precio, evento)
        {
            Voltaje = voltaje;
        }
        public Fuente(Insumo insumo) : base (insumo)
        {
            Voltaje = (insumo as Fuente).Voltaje;
        }
    }
}
