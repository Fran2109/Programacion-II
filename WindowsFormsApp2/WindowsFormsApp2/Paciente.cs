using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    public class Paciente
    {
        int edad;
        public int Legajo { get; set; }
        public string Nombre { get; set; }
        public string Raza { get; set; }
        public int Edad 
        { 
            get
            {
                return edad;
            }
            set
            {
                if(value>7)
                {
                    edad = value;
                    Evento?.Invoke(this, new EventArgsPaciente(this));
                }
            }
        }
        public event EventHandler<EventArgsPaciente> Evento;
        public Paciente(int legajo, string nombre, string raza)
        {
            Legajo = legajo;
            Nombre = nombre;
            Raza = raza;
        }
        public Paciente(int legajo, string nombre, string raza, int edad)
        {
            Legajo = legajo;
            Nombre = nombre;
            Raza = raza;
            this.edad = edad;
        }
    }
    public class EventArgsPaciente : EventArgs
    {
        Paciente p;
        public string Dato
        {
            get
            {
                return $"El paciente {p.Nombre} con legajo {p.Legajo} esta muy viejo";
            }
        }
        public EventArgsPaciente(Paciente paciente)
        {
            p = paciente;
        }
    }
}
