namespace chsarp_intro._3_Clases_de_Usuario
{
    public class Cuadrado : Rectangulo
    {
        public Cuadrado(int lado) : base(lado, lado)
        {
        }

        public override string Nombre => "Cuadrado";
    }
}
