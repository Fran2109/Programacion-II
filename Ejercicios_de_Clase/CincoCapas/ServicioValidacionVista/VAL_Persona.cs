using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using BE;

namespace ServicioValidacionVista
{
    public class VAL_Persona
    {
        Regex _r = new Regex("\\d{2}[.]\\d{3}[.]\\d{3}");
        public bool ValidaDNI(BE_Persona pPersona)
        {
           return  _r.IsMatch(pPersona.DNI); 
        }
    }
}
