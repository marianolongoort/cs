using System;

namespace chsarp_intro._7_Extension_Methods
{
    /// <summary>
    /// Los extension methods o métodos de extensión son un mecanismo por el cual NET nos permite extender funcionalidad a tipos ya definidos.
    /// NET nos provee una forma limpia y sencilla de adicionar comportamiento a un tipo cualquiera con una sintaxis simple sin necesidad de modificar el tipo original.
    /// Más información aquí: https://docs.microsoft.com/es-es/dotnet/csharp/programming-guide/classes-and-structs/extension-methods
    /// </summary>
    public static class ExtensionMethods
    {
        public static void Definicion()
        {
            Console.WriteLine("Definimos 2 métodos de extensión");
            Console.WriteLine("1 método para decimal y 1 método para DateTime");

            decimal valorDecimal = 105.4444444444444444M;

            Console.WriteLine($"Definimos una variable {nameof(valorDecimal)} con el valor {valorDecimal}");
            Console.WriteLine($"Utilizando el extension method MiFormato podemos ver que el valor lo obtendremos formateado: {valorDecimal.MiFormato()}");

            DateTime fechaNacimiento = new DateTime(1988, 9, 9);

            Console.WriteLine($"Definimos una variable {nameof(fechaNacimiento)} con el valor {fechaNacimiento:dd-MM-yyyy}");
            Console.WriteLine($"Utilizando el extension method ObtenerAnios() podemos obtener los años de edad: {fechaNacimiento.ObtenerAnios()}");
        }
    }
}
