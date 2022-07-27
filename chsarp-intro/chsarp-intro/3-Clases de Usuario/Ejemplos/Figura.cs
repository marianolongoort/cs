namespace chsarp_intro._3_Clases_de_Usuario
{
    /// <summary>
    /// Una clase abstracta es una clase de la cual no se pueden crear instancias.
    /// </summary>
    public abstract class Figura
    {
        public abstract string Nombre { get; }

        public abstract int CalcularArea();
    }
}
