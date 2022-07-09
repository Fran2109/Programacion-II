using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio_Autos
{
    public class Comercio
    {
        List<Persona> list_personas;
        List<Auto> list_autos;
        public Comercio()
        {
            list_personas = new List<Persona>();
            list_autos = new List<Auto>();
        }
        public List<Persona> ListaPersonas()
        {
            List<Persona> list_auxiliar = new List<Persona>();
            foreach(Persona persona in list_personas)
            {
                list_auxiliar.Add(new Persona(persona));
            }
            return list_auxiliar;
        }
        public List<Auto> ListAutos()
        {
            List<Auto> list_auxiliar = new List<Auto>();
            foreach(Auto auto in list_autos)
            {
                list_auxiliar.Add(new Auto(auto));
            }
            return list_auxiliar;
        }
        public List<Auto> ListAutosPersona(Persona persona_buscar)
        {
            List<Auto> lista_auxiliar = new List<Auto>();
            foreach(Auto auto_actual in list_autos)
            {
                if(auto_actual.Titular == persona_buscar.DNI)
                {
                    lista_auxiliar.Add(new Auto(auto_actual));
                }
            }
            if(lista_auxiliar.Count > 0)
                return lista_auxiliar;
            else
                return null;
        }
        public int CantidadDeAutos(Persona persona_buscar)
        {
            int int_cantidad = 0;
            int_cantidad = ListAutosPersona(persona_buscar).Count();
            return int_cantidad;
        }
        public Persona DuenioDeAuto(Auto auto_buscar)
        {
            Persona persona_auxiliar = new Persona(list_personas.Find(persona => persona.DNI == auto_buscar.Titular));
            return persona_auxiliar;
        }
        public void AgregarPersona(Persona persona_agregar)
        {
            try
            {
                Persona persona_auxiliar = new Persona(persona_agregar);
                list_personas.Add(persona_auxiliar);
            } catch(Exception error ) { MessageBox.Show(error.Message); }
        }
        public void AgregarAuto(Auto auto_agregar)
        {
            try
            {
                Auto auto_auxiliar = new Auto(auto_agregar);
                list_autos.Add(auto_auxiliar);
            } catch(Exception error ) { MessageBox.Show(error.Message); }
        }
    }
}
