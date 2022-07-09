using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioBanco
{
    public class Titular
    {
        List<Cuenta> _lc;
        // Constructor que crea la lista de cuentas
        public Titular() { _lc = new List<Cuenta>(); }
        // Constructor que permite crear un titular pasando los datos del titular
        public Titular(TipoDocumento pTdoc,int pNdoc,string pNombre,string pApellido) : this()
        { Tipo = pTdoc;NumeroDocumento = pNdoc;Nombre = pNombre;Apellido = pApellido; }
        // permite crear un titular y lo inicializa con los datos del titular que llega por parámetro (Clona el titular)
        public Titular(Titular pTitular) : this()
        {   this.Tipo = pTitular.Tipo;this.NumeroDocumento = pTitular.NumeroDocumento;
            this.Nombre = pTitular.Nombre;this.Apellido = pTitular.Apellido;

        }
        public TipoDocumento Tipo { get; set; }
        public int NumeroDocumento { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public void BorrarCuenta(Cuenta pCuenta)
        {

            try
            {
                // Busca la cuenta en la lista de cuentas del titular
                Cuenta _aux = _lc.Find(x => x.Numero == pCuenta.Numero);
                // Si la cuenta exoiste la remueve de la lista
                if (_aux != null) _lc.Remove(_aux);
                else throw new Exception("Lo que intenta borrar no existe !!!");
            }
            catch (Exception ex) { throw ex; }

        } 
        private Cuenta ClonaCuenta(Cuenta pCuenta)
        {
            Cuenta _aux;
            // Determina si la cuenta es una CA o una CC para clonarla
            if (pCuenta is CA) { _aux = new CA(pCuenta); }
            else { _aux = new CC(pCuenta); }
            // Le coloca a la cuenta clonada el saldo que posee la cuenta que se utiliza para clonar
            // pues el constructor de cuenta inicializa el saldo en 0.
            _aux.Saldo = pCuenta.Saldo;
            return _aux;
        }
        public void AgregarCuenta(Cuenta pCuenta)
        {

            try
            {
                // Agrega una cuenta clonada a la lista de cuentas del titular
                _lc.Add(ClonaCuenta(pCuenta));
            }
            catch (Exception ex) { throw ex; }

        }
        public List<Cuenta> RetornaListaCuentas()
        {
            // Clona la lista de cuentas del titular y la retorna
            List<Cuenta> _auxLC = new List<Cuenta>();
            try {foreach(Cuenta c in _lc){ Cuenta _aux = ClonaCuenta(c); _auxLC.Add(_aux);} }
            catch (Exception ex) { throw ex; }
            return _auxLC;
        }
        public void ActualizaCuentaTitularDeposito(Cuenta pCuenta,decimal pMonto)
        {
            try
            {
                // ubica la cuenta dentro de la lista de cuentas del titular y actualiza el saldo con el depósito
                _lc.Find(x => x.Numero == pCuenta.Numero).Depositar(pMonto);

            }
            catch (Exception ex) { throw ex; }
        }
        public bool ActualizaCuentaTitularExtraccion(Cuenta pCuenta, decimal pMonto)
        {
            bool _rta = false;
            try
            {
                // ubica la cuenta dentro de la lista de cuentas del titular y actualiza el saldo con la extracción
                _rta=_lc.Find(x => x.Numero == pCuenta.Numero).Extraer(pMonto);

            }
            catch (Exception ex) { throw ex; }
            return _rta;
        }
    }

    public enum TipoDocumento {DNI, CI }
}
