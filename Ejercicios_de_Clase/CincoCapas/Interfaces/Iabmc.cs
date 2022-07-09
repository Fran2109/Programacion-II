using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{

        public interface Iabmc<T>
        {
            void Alta(T pObject);
            void Baja(T pObject);
            void Modificacion(T pObject);
            void Consulta(T pObject);
            List<T> ConsultaDesdeHasta(T pObject1, T pObject2);
            List<T> ConsultaIncremental(T pObject);
        }
}
