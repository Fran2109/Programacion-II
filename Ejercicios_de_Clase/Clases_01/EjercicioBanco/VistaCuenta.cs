using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioBanco
{
    public class VistaCuenta
    {
        public VistaCuenta() { }
        public VistaCuenta(string pTcta, int p0,decimal p1,string p2, TipoDocumento p3,int p4,string p5,string p6, Cuenta pCuenta)
        {Tipo_CTA=pTcta; Numero = p0;Saldo = p1;Descubierto = p2;T_Doc = p3;
            N_Doc = p4; Nombre = p5;Apellido = p6; _cuenta = pCuenta;
        }
        Cuenta _cuenta;
        public string Tipo_CTA { get; set; }
        public int Numero { get; set; }
        public decimal Saldo { get; set; }
        public string Descubierto { get; set; }
        public TipoDocumento T_Doc { get; set; }
        public int N_Doc { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public Cuenta RetornaCuentaOriginal() { return _cuenta; }
        public List<VistaCuenta> RetornaVistaCuenta(List<Cuenta> pLC)
        {
            List<VistaCuenta> _lvc = new List<VistaCuenta>();
            foreach(Cuenta c in pLC)
            {
                if (c is CA)
                {
                    CA _ca = c as CA;
                    _lvc.Add(new VistaCuenta("CA", _ca.Numero, _ca.Saldo,"--", _ca.TitularCuenta.Tipo, _ca.TitularCuenta.NumeroDocumento, _ca.TitularCuenta.Nombre, _ca.TitularCuenta.Apellido,c)); }
                else 
                {
                    CC _cc = c as CC;
                    _lvc.Add(new VistaCuenta("CC", _cc.Numero, _cc.Saldo, _cc.Descubierto.ToString(), _cc.TitularCuenta.Tipo, _cc.TitularCuenta.NumeroDocumento, _cc.TitularCuenta.Nombre, _cc.TitularCuenta.Apellido,c));
                }
            }
            return _lvc;
        }
    }
}
