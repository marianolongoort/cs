using chsarp_intro._3_Clases_de_Usuario;
using System;

namespace chsarp_intro._4_Validaciones
{
    public static class Excepciones
    {
        /// <summary>
        /// En c# las excepciones pueden ser manejadas a través del uso de los bloques try-catch-finally.
        /// </summary>
        public static void Manejo()
        {
            Console.WriteLine("Creamos una instancia de la clase auto");
            Auto auto = new Auto();

            Console.WriteLine("Ejecutamos la sentencia auto.AddRueda(new Rueda { Marca = \"firestone\", Rodado = 500 }); dentro de un bloque try catch");
            try
            {
                // toda sentencia ejecutada dentro de un bloque try tratará los errores de forma "manejada"
                auto.AddRueda(new Rueda { Marca = "firestone", Rodado = 500 });

                Console.WriteLine("La rueda fue agregada correctamente");
            }
            catch (Exception ex) // Toda excepción que fuese arrojada dentro de un bloque try caerá dentro de este bloque catch.
            {
                Console.WriteLine("Se generó un error agregando una rueda");
                Console.WriteLine($"El mensaje de error es: {ex.Message}");

                // El tipo exception nos provee de información importante para comprensión del error 
                // tal como el mensaje de error o el call stack al momento en que se genera la excepción.
            }
            finally
            {
                // el bloque finally se utiliza para ejecutar código que se debe ejecutar 
                // luego de try - catch, sin importar si hubo alguna excepción en el camino o no.
                Console.WriteLine("Este mensaje es ejecutado dentro del bloque finally");
            }
        }

        /// <summary>
        /// El manejo de excepciones en c# cuenta con una jerarquía de tipos que establece 
        /// que el tipo 'Exception' es el tipo raíz de toda excepción.
        /// Esto quiere decir que toda excepción debe, en algún punto, derivar del tipo Exception.
        /// </summary>
        public static void Jerarquia()
        {
            Console.WriteLine("Creamos una instancia de la clase auto");
            Auto auto = new Auto();

            Console.WriteLine("Ejecutamos la sentencia auto.AddRueda(new Rueda { Marca = \"firestone\", Rodado = 500 }); dentro de un bloque try catch");
            try
            {
                auto.AddRueda(new Rueda { Marca = "firestone", Rodado = 500 });

                Console.WriteLine("La rueda fue agregada correctamente");
            }
            catch (ArgumentNullException ex)
            {
                // si la excepción arrojada dentro del bloque try es de tipo ArgumentNullException caeremos en este catch y no en los siguientes.
                // si la excepción arrojada no es del tipo ArgumentNullException este bloque será ignorado
                Console.WriteLine("Bloque catch de tipo ArgumentNullException");
                Console.WriteLine($"El mensaje de error es: {ex.Message}");
            }
            catch (InvalidOperationException ex)
            {
                // si la excepción arrojada dentro del bloque try es de tipo InvalidOperationException caeremos en este catch y no en los siguientes.
                // si la excepción arrojada no es del tipo InvalidOperationException este bloque será ignorado
                Console.WriteLine("Bloque catch de tipo InvalidOperationException");
                Console.WriteLine($"El mensaje de error es: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Este bloque catch capturará todas las excepciones que fueron lanzadas y no fueron capturadas por un catch anterior.
                Console.WriteLine("Bloque catch de tipo Exception");
                Console.WriteLine($"El mensaje de error es: {ex.Message}");
            }

            Console.WriteLine();
            Console.WriteLine("Ejecutamos la sentencia auto.AddRueda(null); dentro de un bloque try catch");
            try
            {
                auto.AddRueda(null);

                Console.WriteLine("La rueda fue agregada correctamente");
            }
            catch (ArgumentNullException ex)
            {
                // si la excepción arrojada dentro del bloque try es de tipo ArgumentNullException caeremos en este catch y no en los siguientes.
                // si la excepción arrojada no es del tipo ArgumentNullException este bloque será ignorado
                Console.WriteLine("Bloque catch de tipo ArgumentNullException");
                Console.WriteLine($"El mensaje de error es: {ex.Message}");
            }
            catch (InvalidOperationException ex)
            {
                // si la excepción arrojada dentro del bloque try es de tipo InvalidOperationException caeremos en este catch y no en los siguientes.
                // si la excepción arrojada no es del tipo InvalidOperationException este bloque será ignorado
                Console.WriteLine("Bloque catch de tipo InvalidOperationException");
                Console.WriteLine($"El mensaje de error es: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Este bloque catch capturará todas las excepciones que fueron lanzadas y no fueron capturadas por un catch anterior.
                Console.WriteLine("Bloque catch de tipo Exception");
                Console.WriteLine($"El mensaje de error es: {ex.Message}");
            }
        }
    }
}
