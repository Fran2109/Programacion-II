using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    public abstract class Ordenar
    {
        public abstract IComparer<Paciente> RetornaOrden();
    }
    public class OrdenarAscendente : Ordenar
    {
        public override IComparer<Paciente> RetornaOrden()
        {
            return new PacientesOrden.PacientesAsc();
        }
    }
    public class OrdenarDescendente : Ordenar
    {
        public override IComparer<Paciente> RetornaOrden()
        {
            return new PacientesOrden.PacienteDesc();
        }
    }
    public class PacientesOrden
    {
        public class PacientesAsc : IComparer<Paciente>
        {
            public int Compare(Paciente x, Paciente y)
            {
                return string.Compare(x.Nombre, y.Nombre);
            }
        }
        public class PacienteDesc : IComparer<Paciente>
        {
            public int Compare(Paciente x, Paciente y)
            {
                return string.Compare(x.Nombre, y.Nombre) * -1;
            }
        }
    }
}
