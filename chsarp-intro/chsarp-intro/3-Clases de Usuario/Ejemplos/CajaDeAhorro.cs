using System;

namespace chsarp_intro._3_Clases_de_Usuario
{
    public class CajaDeAhorro : ICuenta
    {
        private decimal _balance = 0M;

        public void Depositar(decimal monto) => _balance += monto;

        public void Extraer(decimal monto)
        {
            if (_balance < monto)
            {
                throw new Exception("La caja de ahorro no admite descubierto");
            }
            _balance -= monto;
        }

        public string GetBalance() => $"El balance de la Caja de ahorro es de ${_balance:N2}";

        public string EsteEsUnEjemplo() => "ejemplo";
    }
}
