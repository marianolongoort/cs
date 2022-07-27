namespace chsarp_intro._3_Clases_de_Usuario
{
    public class Rectangulo : Figura
    {
        private readonly int _alto;
        private readonly int _ancho;

        public Rectangulo(int alto, int ancho)
        {
            _alto = alto;
            _ancho = ancho;
        }

        public override string Nombre => "Rectángulo";

        public override int CalcularArea() => _alto * _ancho;
    }
}
