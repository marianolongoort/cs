namespace chsarp_intro._3_Clases_de_Usuario
{
    public interface ICuenta
    {
        void Depositar(decimal monto);

        void Extraer(decimal monto);

        string GetBalance();
    }
}
