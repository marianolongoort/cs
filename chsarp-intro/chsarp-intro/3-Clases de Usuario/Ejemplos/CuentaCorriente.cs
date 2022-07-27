using System;

namespace chsarp_intro._3_Clases_de_Usuario
{
    public class CuentaCorriente : ICuenta
    {
        private decimal _balance = 0M;

        public void Depositar(decimal monto) => _balance += monto;

        public void Extraer(decimal monto) => _balance -= monto;

        public string GetBalance() => $"El balance de la Cuenta Corriente es de ${_balance:N2}";
    }
}
