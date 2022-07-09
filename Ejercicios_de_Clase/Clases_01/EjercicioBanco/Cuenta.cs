using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioBanco
{
    public abstract class Cuenta
    {
        // Constructor que permite crear una cuenta con su nro y el titular
        public Cuenta(int pNroCuenta,Titular pTitular)
        {
            Numero = pNroCuenta;
            TitularCuenta = pTitular;
            Saldo = 0;
        }
        // Constructor que crea una cuenta clonada con los datos de la cuenta recibida por parámetro
        public Cuenta(Cuenta pCuenta)
        {
            this.Numero = pCuenta.Numero;
            this.TitularCuenta = pCuenta.TitularCuenta;
            Saldo = 0;
        }
        public int Numero { get; set; }
        public Titular TitularCuenta { get; set; }
        public decimal Saldo { get; set; }
        public void Depositar(decimal pMonto)
        {
            try
            {
                Saldo += pMonto;
            }
            catch (Exception ex) { throw ex; }
        }
        public abstract bool Extraer(Decimal pMonto);
        public void Transferir(decimal pMonto, Cuenta pCuentaDestino)
        {

            try
            {
                // Verifica si se ha podido extraer el monto de la cuenta de origen antes de 
                // depositarlo en la cuenta de destino
                if (Extraer(pMonto)) { pCuentaDestino.Depositar(pMonto); }
                else throw new Exception("No se pudo realizar la transferencia !!!");
            }
            catch (Exception ex) { throw ex; }

        }
    }

    public class CA : Cuenta
    {
        public CA(int pNroCuenta, Titular pTitular):base(pNroCuenta,pTitular)
        {
            
        }
        public CA(Cuenta pCuenta) : base(pCuenta)
        {

        }
        public override bool Extraer(decimal pMonto)
        {
            // Método polimorfico para la extracción. Controla que el monto extraído no supere el saldo
            bool _rta = false;
            if(pMonto<=Saldo) { Saldo -= pMonto; _rta = true; }
            return _rta;
        }
       
    }
    public class CC : Cuenta 
    {

        public CC(int pNroCuenta, Titular pTitular,decimal pDescubierto): base(pNroCuenta,pTitular)
        {
            Descubierto = pDescubierto;
        }
        public CC(Cuenta pCuenta) : base(pCuenta)
        {
            Descubierto = (pCuenta as CC).Descubierto;
        }
        public Decimal Descubierto { get; set; }
        public override bool Extraer(decimal pMonto)
        {
            // Método polimorfico para la extracción. Controla que el monto extraído no supere el saldo de la cuenta más el descubierto.
            bool _rta = false;
            if (pMonto <= Saldo + Descubierto) { Saldo -= pMonto; _rta = true; }
            return _rta;
        }
    }
}
