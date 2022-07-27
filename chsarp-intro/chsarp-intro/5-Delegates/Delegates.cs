using System;

namespace chsarp_intro._5_Delegates
{
    public static class Delegates
    {
        /// <summary>
        /// Un delegado, hablando claro y sin vueltas no es ni más ni menos que un puntero a una función.
        /// Ahora bien para poder hacer un puntero a una función necesitamos saber qué firma tiene dicha 
        /// función y generar un tipo acorde a dicha firma para luego poder utilizarlo.
        /// para este ejemplo utilizaremos el delegado <see cref="SumaDelegate"/> y la función <see cref="Suma(int, int)"/>.
        /// Más información aquí: https://docs.microsoft.com/es-es/dotnet/csharp/programming-guide/delegates/
        /// </summary>
        public static void Definicion()
        {
            SumaDelegate suma = null;
            Console.WriteLine($"Declaramos una variable de tipo {nameof(SumaDelegate)} llamada {nameof(suma)}.");
            // dicha variable al momento no tiene asignado ningún valor, por lo tanto si intentamos ejecutar la "función a la que apunta" tendremos un error

            Console.WriteLine($"Ejecutamos {nameof(suma)} antes de asignarle ningún valor.");
            try
            {
                suma(1, 2);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            // si queremos asignarle un valor a la variable suma solamente admitirá funciones que reciban dos parámetros int y retornen un parámetro int
            // Por ejemplo, esta asignación no funcionaría ya que SumaDoubles recibe dos doubles y retorna un double
            // suma = SumaDoubles;

            Console.WriteLine($"Asignamos la función {nameof(Suma)} a la variable {nameof(suma)}");
            suma = Suma;

            Console.WriteLine("De esta manera cuando ejecutemos el delegado, estaremos ejecutando la función que le asignamos");

            var resultado = suma(2, 3);

            Console.WriteLine($"Como podemos observar, el resultado de ejecutar suma(2, 3) es: '{resultado}', tal como es esperado.");
        }

        /// <summary>
        /// .NET nos provee un mecanismo para utilizar delegados de forma que podamos evitar declarar cada tipo de delegado que necesitemos usar.
        /// Los 3 tipos especiales que provee NET para esto son <see cref="Func{T, TResult}"/>, <see cref="Action"/> y <see cref="Predicate{T}"/>
        /// Func => son delegados que tienen n parámetros de entrada y un parámetro de retorno. (https://www.tutorialsteacher.com/csharp/csharp-func-delegate)
        /// Action => son delegados que tienen n parámetros de entrada y no tienen retorno (retornan void). (https://www.tutorialsteacher.com/csharp/csharp-action-delegate)
        /// Predicate => son delegados que tienen n parámetros de entrada y retornan un bool indicando si se cumplió el predicado o no. (https://www.tutorialsteacher.com/csharp/csharp-predicate)
        /// </summary>
        public static void Genericos()
        {
            // esta línea es análoga a la que vimos en el ejemplo anterior, pero la diferencia es que no tuve la 
            // necesidad de crear el tipo SumaDelegate ya que Func<int, int, int> me resuelve ese problema.
            Func<int, int, int> suma = Suma;
            // cuando utilizamos Func, tener en cuenta que el último tipo que se utiliza en la definición es el tipo de retorno.

            Console.WriteLine("De esta manera cuando ejecutemos el delegado, estaremos ejecutando la función que le asignamos");
            var resultado = suma(2, 3);
            Console.WriteLine($"Como podemos observar, el resultado de ejecutar suma(2, 3) es: '{resultado}', tal como es esperado.");

            Action<string> escribirEnConsola = EscribirEnConsola;

            Console.WriteLine($"Ejecutamos el delegado {nameof(escribirEnConsola)} pasando como parámetro \"esto se escribirá por consola\"");
            escribirEnConsola("esto se escribirá por consola");

            Predicate<string> buscadorDeEspacios = TieneEspacios;

            Console.WriteLine($"Ejecutamos el delegado {nameof(buscadorDeEspacios)} pasando como parámetro \"Un Texto\"");
            var tieneEspacios = buscadorDeEspacios("Un Texto");
            Console.WriteLine($"La salida de la ejecución del delegate da: {tieneEspacios}");
        }

        /// <summary>
        /// Las expresiones lambda son delegados escritos de una manera más sintética, pudiendo expresarse básicamente de 2 formas: expresiones o bloques.
        /// Más información aquí: https://docs.microsoft.com/es-es/dotnet/csharp/programming-guide/statements-expressions-operators/lambda-expressions
        /// </summary>
        public static void Lambdas()
        {
            // NOTA: estos ejemplos expresados aquí se podrían escribir también como local functions, por ejemplo, la función suma sería:
            // static int suma(int x, int y) => x + y;

            // aquí tenemos un ejemplo de expresión lambda sencilla para declarar e implementar la función suma en una línea.
            Func<int, int, int> suma = (x, y) => x + y;

            Console.WriteLine($"Usando una expresión lambda pudimos implementar la función {nameof(suma)} en una línea.");
            Console.WriteLine($"Como podemos ver aquí, la ejecución de suma(2, 3) efectivamente funciona como es esperado: {suma(2, 3)}");

            // esta es una forma de escribir una expresión lambda en bloque.
            Action<string> escribirEnConsola = (texto) =>
            {
                Console.WriteLine("Se ejecuta el bloque lambda");
                Console.WriteLine(texto);
            };

            Console.WriteLine($"Definimos e implementamos a través de una lambda function a {nameof(escribirEnConsola)} y la ejecutamos:");
            escribirEnConsola("Un Texto");

            Predicate<string> buscadorDeEspacios = (texto) => texto.Contains(" ");

            Console.WriteLine($"Ejecutamos el delegado {nameof(buscadorDeEspacios)} pasando como parámetro \"Un Texto\"");
            var tieneEspacios = buscadorDeEspacios("Un Texto");
            Console.WriteLine($"La salida de la ejecución del delegate da: {tieneEspacios}");
        }

        #region Métodos privados

        // análogo a Func<int, int, int>
        private delegate int SumaDelegate(int x, int y);

        private static int Suma(int primerSumando, int segundoSumando) => primerSumando + segundoSumando;

        private static double SumaDoubles(double primerSumando, double segundoSumando) => primerSumando + segundoSumando;

        private static void EscribirEnConsola(string texto)
        {
            Console.WriteLine($"Se ejecuta el método {nameof(EscribirEnConsola)}");
            Console.WriteLine(texto);
        }

        private static bool TieneEspacios(string texto) => texto.Contains(" ");

        #endregion
    }
}
