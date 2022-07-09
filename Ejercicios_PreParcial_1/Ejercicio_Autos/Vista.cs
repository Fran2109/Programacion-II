using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_Autos
{
    public class Vista
    {
        public string Marca { get; set; }
        public int Anio { get; set; }
        public string Modelo { get; set; }
        public string Patente { get; set; }
        public string DNI { get; set; }
        public string Titular { get; set; }
        public Vista() { }
        public Vista(Auto auto, Persona persona)
        {
            Marca = auto.Marca;
            Anio = auto.Anio;
            Modelo = auto.Modelo;
            Patente = auto.Patente;
            DNI = auto.Titular;
            Titular = $"{persona.Apellido}, {persona.Nombre}";
        }

        public List<Vista> obtenerVista(List<Auto> list_autos, List<Persona> list_personas)
        {
            List<Vista> vista = new List<Vista>();
            foreach(Auto auto in list_autos)
            {
                Persona persona_auxiliar = new Persona(list_personas.Find(persona => persona.DNI == auto.Titular));
                vista.Add(new Vista(auto, persona_auxiliar));
            }    
            return vista;
        }
    }
}
