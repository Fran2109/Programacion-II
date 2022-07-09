using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio_Autos
{
    public class Persona
    {
        public string DNI { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public Persona(string string_DNI, string string_nombre, string string_apellido)
        {
            DNI = string_DNI;
            Nombre = string_nombre;
            Apellido = string_apellido;
        }
        public Persona(Persona persona_clonar)
        {
            DNI = persona_clonar.DNI;
            Nombre = persona_clonar.Nombre;
            Apellido = persona_clonar.Apellido;
        }
        ~Persona()
        {
            //MessageBox.Show($"El DNI de la persona borrada es: {DNI}");
        }
    }
}
