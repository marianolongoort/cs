using System;

namespace chsarp_intro._3_Clases_de_Usuario
{
    public class Casa
    {
        public string Calle { get; set; }

        public int Altura { get; set; }

        // Sobre escrito del default que se encuentra en object
        public override string ToString() => $"La {nameof(Casa)} está ubicada en {Calle} {Altura}";

        // Sobre escrito del default que se encuentra en object
        public override int GetHashCode()
        {
            return HashCode.Combine(Calle, Altura);
        }

        // Sobre escrito del default que se encuentra en object
        public override bool Equals(object obj)
        {
            if (obj is Casa casa)
            {
                return casa.Calle == Calle && casa.Altura == Altura;
            }

            return false;
        }

        // Así se puede realizar la sobrecarga de los operadores de igualdad y desigualdad.
        public static bool operator ==(Casa source, Casa target) => source.Equals(target);

        public static bool operator !=(Casa source, Casa target) => !source.Equals(target);
    }
}
