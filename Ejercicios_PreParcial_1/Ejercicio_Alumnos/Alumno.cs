using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace Ejercicio_Alumnos
{
    public class Alumno
    {
        private DateTime dateTime_FechaNacimiento;
        private DateTime dateTime_FechaIngreso;
        private int int_CantMateriasAprobadas;
        public int Legajo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        DateTime Fecha_Nacimiento
        {
            set { dateTime_FechaNacimiento = value; }
        }
        DateTime Fecha_Ingreso
        {
            set { dateTime_FechaIngreso = value; }
        }
        public int Edad 
        {
            get
            {
                int int_anios = DateTime.Today.Year - dateTime_FechaNacimiento.Year;
                int_anios += DateTime.Today.DayOfYear < dateTime_FechaNacimiento.DayOfYear ? -1 : 0;
                return int_anios;
            }
        }
        public bool Activo { get; set; }
        public int Cant_Materias_Aprobadas
        {
            set { int_CantMateriasAprobadas = value; }
        }
        public Alumno()
        {
            Legajo = (int)DateTime.Now.ToOADate();
            Nombre = "Sin Nombre";
            Apellido = "Sin Apellido";
            dateTime_FechaNacimiento = DateTime.Now;
            dateTime_FechaIngreso = DateTime.Now;
            Activo = false;
            Cant_Materias_Aprobadas = 0;
        }
        public Alumno( int int_legajo, string string_nombre, string string_apellido, DateTime dateTime_FechaNacimientoP, DateTime dateTime_FechaIngresoP, bool bool_activo, int int_cantMateriasAprobadasP )
        {
            Legajo =int_legajo;
            Nombre = string_nombre;
            Apellido = string_apellido;
            dateTime_FechaIngreso = dateTime_FechaIngresoP;
            dateTime_FechaNacimiento = dateTime_FechaNacimientoP;
            Activo = bool_activo;
            Cant_Materias_Aprobadas = int_cantMateriasAprobadasP;
        }
        public int Antiguedad(Intervalo intervalo)
        {
            return intervalo.Calcular(dateTime_FechaIngreso, DateTime.Now);
        }
        public int Materias_No_Aprobadas()
        {
            return 36 - int_CantMateriasAprobadas;
        }
        public int Edad_De_Ingreso(Anios intervalo_anios)
        {
            return intervalo_anios.Calcular(dateTime_FechaNacimiento, dateTime_FechaIngreso);
        }
        ~Alumno()
        {
            MessageBox.Show($"Legajo: {Legajo.ToString()}\nNombre: {Nombre}\nApellido: {Apellido}","De destruyo el Alumno");
        }
    }

    public abstract class Intervalo
    {
        public abstract int Calcular(DateTime dateTime_fechaInicio, DateTime dateTime_fechaFinal);
    }
    public class Anios : Intervalo
    {
        public override int Calcular(DateTime dateTime_fechaInicio, DateTime dateTime_fechaFinal)
        {
            return (int)DateAndTime.DateDiff(DateInterval.Year, dateTime_fechaInicio, dateTime_fechaFinal);
        }
    }
    public class Meses : Intervalo
    {
        public override int Calcular(DateTime dateTime_fechaInicio, DateTime dateTime_fechaFinal)
        {
            return (int)DateAndTime.DateDiff(DateInterval.Month, dateTime_fechaInicio, dateTime_fechaFinal);
        }
    }
    public class Dias : Intervalo
    {
        public override int Calcular(DateTime dateTime_fechaInicio, DateTime dateTime_fechaFinal)
        {
            return (int)DateAndTime.DateDiff(DateInterval.Day, dateTime_fechaInicio, dateTime_fechaFinal);
        }
    }
}
