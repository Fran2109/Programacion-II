using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioBanco
{
    public class Banco
    {
        List<Titular> _lt;
        List<Cuenta> _lc;
        public Banco() { _lt = new List<Titular>();_lc = new List<Cuenta>(); }

        public void AgregarTitular(Titular pTitular)
        {
            // Se agrega unclon del titular a la lista de titulares del banco
            try
            {
                Titular _aux = new Titular(pTitular);
                _lt.Add(_aux);
            }
            catch (Exception ex) { throw ex; }

        }
        public List<Titular> RetornaListaTitulares()
        {
            List<Titular> _auxLT = new List<Titular>();
            try 
            { 
                foreach (Titular t in _lt) 
                    { 
                        Titular _aux = new Titular(t); 
                        foreach(Cuenta c in t.RetornaListaCuentas())
                        {
                        _aux.AgregarCuenta(c);
                        }
                        _auxLT.Add(_aux); 
                    } 
            }
            catch (Exception ex) { throw ex; }
            return _auxLT;
        }
        public void BorrarTitular(Titular pTitular)
        {
            try
            {
                // Se busca al titular en la lista de titulares del banco
                Titular _aux = _lt.Find(x => x.Tipo==pTitular.Tipo && x.NumeroDocumento==pTitular.NumeroDocumento);
                // Se verifica si el titular existe
                if(_aux==null) { throw new Exception("El titular que desea borrar no existe !!!"); }
                //Borramos las cuentas que son del titular 
                if(_aux.RetornaListaCuentas().Count>0)
                {
                    foreach(Cuenta c in _aux.RetornaListaCuentas())
                    {
                        Cuenta _auxCTA = _lc.Find(x => x.Numero == c.Numero);
                        if (_auxCTA == null) { throw new Exception("Error al borrar cuenta del titular !!!"); }
                        _lc.Remove(_auxCTA);  
                    }
                }
                //Borramos al titular
                _lt.Remove(_aux);
            }
            catch (Exception ex) { throw ex; }


        }
        public void ModificarTitular(Titular pTitular,TipoDocumento pTD,int pND)
        {
            try
            {
                // Se busca el titular en la list de titulares del banco
                Titular _aux = _lt.Find(x => x.Tipo == pTD && x.NumeroDocumento == pND);
                // Se verifica si existe el titular
                if (_aux == null) { throw new Exception("El titular que desea borrar no existe !!!"); }
                
                //Actualizo al titular
                _aux.Tipo=pTitular.Tipo;
                _aux.NumeroDocumento = pTitular.NumeroDocumento;
                _aux.Nombre = pTitular.Nombre;
                _aux.Apellido = pTitular.Apellido;
            }
            catch (Exception ex) { throw ex; }

        }
        public void AgregarCuenta(Cuenta pCuenta)
        {
            // Se agrega un clon de cuenta a la lista de cuentas del banco
            Cuenta _aux;
            if (pCuenta is CA) _aux = new CA(pCuenta);       
            else _aux = new CC(pCuenta);
            _lc.Add(_aux);
            // Se agregar la cuenta al titular
            Titular _auxT =_lt.Find(x => x.Tipo == _aux.TitularCuenta.Tipo && x.NumeroDocumento == _aux.TitularCuenta.NumeroDocumento);
            if (_auxT != null)
            {
                _auxT.AgregarCuenta(_aux);
            }
            else { throw new Exception("El titular no existe !!!"); }
        }
        public List<Cuenta> RetornaListaCuentas()
        {
            // Retorna una lista clonada de la lista de cuentas que posee el banco
            List<Cuenta> _auxLC = new List<Cuenta>();
            try
            {
                foreach (Cuenta c in _lc)
                {
                    if (c is CA) _auxLC.Add(new CA(c)) ;
                    else _auxLC.Add(new CC(c));

                    _auxLC.Last().Saldo = c.Saldo;
                }
            }
            catch (Exception ex) { throw ex; }
            return _auxLC;
        }
        public void Depositar(Cuenta pCuenta,decimal pMonto)
        {
            try
            {
                // Se ubica la cuenta donde se va a depositar en la lista de cuentas del banco
                Cuenta _auxC = _lc.Find(x => x.Numero == pCuenta.Numero);
                // Se realiza el depósito
                _auxC.Depositar(pMonto);
                // Se ubica al titular de la cuenta, donde se realizó el depósito, dentro de la lista
                // de titulares del banco para actulizar el saldo en su lista de cuentas.
                Titular _auxT = _lt.Find(x => x.Tipo == _auxC.TitularCuenta.Tipo && x.NumeroDocumento == _auxC.TitularCuenta.NumeroDocumento);
                // Se actualiza la cuenta de la lista de cuentas del titular con el depósito
                _auxT.ActualizaCuentaTitularDeposito(_auxC, pMonto);
            }
            catch (Exception ex) { throw ex; }

        }
        public bool Extraer(Cuenta pCuenta, decimal pMonto)
        {
            bool _rta = false;
            try
            {
                // Se ubica la cuenta donde se va a depositar en la lista de cuentas del banco
                Cuenta _auxC = _lc.Find(x => x.Numero == pCuenta.Numero);
                // Se realiza la extracción
                _rta = _auxC.Extraer(pMonto);
                if (_rta)
                {
                    // Se ubica al titular de la cuenta, donde se realizó la extracción, dentro de la lista
                    // de titulares del banco para actulizar el saldo en su lista de cuentas.
                    Titular _auxT = _lt.Find(x => x.Tipo == _auxC.TitularCuenta.Tipo && x.NumeroDocumento == _auxC.TitularCuenta.NumeroDocumento);
                    // Se actualiza la cuenta de la lista de cuentas del titular con el depósito
                    _rta = _auxT.ActualizaCuentaTitularExtraccion(_auxC, pMonto);
                }
            }
            catch (Exception ex) { throw ex; }
            return _rta;
        }
        public bool Transferir(Cuenta pCuentaOrigen,Cuenta pCuentaDestino, decimal pMonto)
        {
            bool _rta = false;
            try
            {
                // Se ubica la cuenta de donde se va a extraer el monto a transferir
                Cuenta _auxCO = _lc.Find(x => x.Numero == pCuentaOrigen.Numero);
                // Se ubica la cuenta donde se va a depositar el monto a tranferir
                Cuenta _auxCD = _lc.Find(x => x.Numero == pCuentaDestino.Numero);
                // Se realiza la transferencia
                _auxCO.Transferir(pMonto, _auxCD);
                // Se ubica al titular de la cuenta origen, donde se realizó la extracción,
                // dentro de la lista de titulares del banco para actulizar el saldo
                // en su lista de cuentas.
                Titular _auxTO = _lt.Find(x => x.Tipo == _auxCO.TitularCuenta.Tipo && x.NumeroDocumento == _auxCO.TitularCuenta.NumeroDocumento);
                // Se actualiza la cuenta de la lista de cuentas del titular con el saldo luego de la 
                // extracción debido a la tranferencia.
                _rta = _auxTO.ActualizaCuentaTitularExtraccion(_auxCO, pMonto);
                // Se ubica al titular de la cuenta destino, donde se realizó el depósito,
                // dentro de la lista de titulares del banco para actulizar el saldo
                // en su lista de cuentas.
                Titular _auxTD = _lt.Find(x => x.Tipo == _auxCD.TitularCuenta.Tipo && x.NumeroDocumento == _auxCD.TitularCuenta.NumeroDocumento);
                // Se actualiza la cuenta de la lista de cuentas del titular con el saldo luego de la 
                // extracción debido a la tranferencia.
                _auxTD.ActualizaCuentaTitularDeposito(_auxCD, pMonto);

            }
            catch (Exception ex) { throw ex; }
            return _rta;
        }
        ~Banco()
        {
            _lt = null;_lc = null;
        }
    }
}
