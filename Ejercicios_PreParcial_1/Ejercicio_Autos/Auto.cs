using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio_Autos
{
    public class Auto
    {
        public string Titular { get; set; }
        public string Patente { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Anio { get; set; }
        public decimal Precio { get; set; }

        public Auto(string string_titular, string string_patente, string string_marca, string string_modelo, int int_anio, decimal decimeal_precio)
        {
            Titular = string_titular;
            Patente = string_patente;
            Marca = string_marca;
            Modelo = string_modelo;
            Anio = int_anio;
            Precio = decimeal_precio;
        }
        public Auto(Auto auto_clonar)
        {
            Titular = auto_clonar.Titular;
            Patente = auto_clonar.Patente;
            Marca = auto_clonar.Marca;
            Modelo = auto_clonar.Modelo;
            Anio = auto_clonar.Anio;
            Precio = auto_clonar.Precio;
        }
        ~Auto()
        {
            //MessageBox.Show($"De destruyo el auto con patente: {Patente}");
        }
    }
}
