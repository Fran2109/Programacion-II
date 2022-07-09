using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_Computadoras
{
    public abstract class Operaciones
    {
        public abstract void Agregar(Insumo insumo, List<Procesador> lista_procesadores, List<Placa> lista_placas, List<Disco> lista_discos, List<Grafica> lista_graficas, List<Fuente> lista_fuentes);
        public abstract object Mostrar(List<Procesador> lista_procesadores, List<Placa> lista_placas, List<Disco> lista_discos, List<Grafica> lista_graficas, List<Fuente> lista_fuentes);
        public abstract void Eliminar(Insumo insumo, List<Procesador> lista_procesadores, List<Placa> lista_placas, List<Disco> lista_discos, List<Grafica> lista_graficas, List<Fuente> lista_fuentes);
    }
    public class OperacionesDiscos : Operaciones
    {
        public override void Agregar(Insumo insumo, List<Procesador> lista_procesadores, List<Placa> lista_placas, List<Disco> lista_discos, List<Grafica> lista_graficas, List<Fuente> lista_fuentes)
        {
            Disco disco = new Disco(insumo as Disco);
            lista_discos.Add(disco);
        }
        public override object Mostrar(List<Procesador> lista_procesadores, List<Placa> lista_placas, List<Disco> lista_discos, List<Grafica> lista_graficas, List<Fuente> lista_fuentes)
        {
            List<Disco> lista_auxiliar = new List<Disco>();
            foreach(Disco disco in lista_discos)
            {
                lista_auxiliar.Add(new Disco(disco));
            }
            return lista_auxiliar;
        }
        public override void Eliminar(Insumo insumo, List<Procesador> lista_procesadores, List<Placa> lista_placas, List<Disco> lista_discos, List<Grafica> lista_graficas, List<Fuente> lista_fuentes)
        {
            lista_discos.Remove(insumo as Disco);
        }
    }
}
