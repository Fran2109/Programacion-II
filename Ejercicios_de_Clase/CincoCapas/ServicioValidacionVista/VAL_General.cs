using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace ServicioValidacionVista
{
    public class VAL_General
    {
        public bool EsNumerico(string pString)
        {
            return Information.IsNumeric(pString);     
        }
    }
}
