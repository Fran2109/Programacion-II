using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_Computadoras
{
    /*
    Si ya terminaste todos los que había sibido podés hacer uno que emule las ventas de PC a clientes.
    Considerá que una PC puede estar compuesta por muchos insumos y cada uno de estos tirenen un costo. 
    Hay tres tipos de PC (Gamer, oficina, personal)
    Al momento de venderlas las primeras poseen un dto del 10% si el costo total supera 400.000. 
    Las de oficina un 5% si el costo total supera 2500000.
    Las personales del 1% si el costo supera 100000.
    En el formulario colocá el ABM de insumos, pc y clientes
    Mostrá en grillas:
    Los Clientes (Agregale las características que consideres habiendo hecho la abstracción)
    Las Pc (Agregale a las características que consideres habiendo hecho la abstracción el costo de cada Pc que surge de la sumatoria de los insumos más la mano de obra. También mostrar en otra columna el precio de vta del producto)
    Las Pc que ha adquirido un cliente seleccionado en la grilla 1 y cuanto lleva invertido en la compra de PC’s
    Los insumos.
    Nota: Analizá bien las Jerarquía, las asociaciones y las agregaciones*/
    public class Comercio
    {
        List<Procesador> lista_procesadores;
        List<Placa> lista_placas;
        List<Disco> lista_discos;
        List<Grafica> lista_graficas;
        List<Fuente> lista_fuentes;
        /*Procesador procesador = new Procesador("AAA", "Ryzen 3", "AMD", 35000, "3200GH");
        Placa placa = new Placa("BBB", "A-350", "Gigabyte", 25000);
        Disco disco = new Disco("CCC", "Barracuda", "Toshiba", 15000, "HDD", "1024GB");
        Grafica grafica = new Grafica("DDD", "Radeon", "AMD", 46000, "8GB");
        Fuente fuente = new Fuente("EEE", "Smart", "Thermaltek", 16000, "600V");*/
        public Comercio()
        {
            lista_procesadores = new List<Procesador>();
            lista_placas = new List<Placa>();
            lista_discos = new List<Disco>();
            lista_graficas = new List<Grafica>();
            lista_fuentes = new List<Fuente>();
        }
        public void Agregar(Insumo insumo, Operaciones operacion)
        {
            operacion.Agregar(insumo, lista_procesadores, lista_placas, lista_discos, lista_graficas, lista_fuentes);
        }
        public object Leer(Operaciones operacion)
        {
            return operacion.Mostrar(lista_procesadores, lista_placas, lista_discos, lista_graficas, lista_fuentes);
        }
        public void Eliminar(Insumo insumo, Operaciones operacion)
        {
            operacion.Eliminar(insumo, lista_procesadores, lista_placas, lista_discos, lista_graficas, lista_fuentes);
        }
    }
}
