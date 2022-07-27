using System;
using System.Text;

namespace chsarp_intro._1_Tipos_de_datos
{
    public static class Strings
    {
        /// <summary>
        /// Las cadenas de caracteres son un tipo de dato muy utilizado y que presenta varias funcionalidades en NET.
        /// </summary>
        public static void Definicion()
        {
            // los strings pueden ser utilizados como valores literales:
            var unLiteral = "se declara de esta manera";

            Console.WriteLine($"La variable {nameof(unLiteral)} tiene el valor '{unLiteral}'");

            // los string vacíos se pueden declarar de estas formas de manera análoga:
            var unLiteralVacio = string.Empty;
            var otroLiteralVacio = "";

            Console.WriteLine($"La variable {nameof(unLiteralVacio)} tiene el valor '{unLiteralVacio}'");
            Console.WriteLine($"La variable {nameof(otroLiteralVacio)} tiene el valor '{otroLiteralVacio}'");

            // podemos concatenar strings utilizando el operador + aunque no es muy recomendable
            var primeraParte = "Esto es";
            var segundaParte = "una cadena de caracteres";
            var terceraParte = "en partes";
            var cadenaConcatenada = primeraParte + " " + segundaParte + " " + terceraParte;

            Console.WriteLine($"La variable {nameof(cadenaConcatenada)} tiene el valor '{cadenaConcatenada}'");

            // otra forma de estructurar cadenas de caracteres es a través del string.Format():
            var cadenaConcatenada2 = string.Format("{0} {1} {2}", primeraParte, segundaParte, terceraParte);

            Console.WriteLine($"La variable {nameof(cadenaConcatenada2)} tiene el valor '{cadenaConcatenada2}'");

            // otra forma de hacerlo es utilizando el objeto StringBuilder():
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(primeraParte);
            stringBuilder.Append(" ");
            stringBuilder.Append(segundaParte);
            stringBuilder.Append(" ");
            stringBuilder.Append(terceraParte);
            var cadenaConcatenada3 = stringBuilder.ToString();

            Console.WriteLine($"La variable {nameof(cadenaConcatenada3)} tiene el valor '{cadenaConcatenada3}'");

            // la forma quizás más utilizada en la actualidad por su simplicidad y su fácil comprensión es string interpolation:
            var cadenaConcatenada4 = $"{primeraParte} {segundaParte} {terceraParte}";

            Console.WriteLine($"La variable {nameof(cadenaConcatenada4)} tiene el valor '{cadenaConcatenada4}'");
        }

        /// <summary>
        /// Algunas de las funciones más comunes utilizadas en los strings las veremos aquí
        /// </summary>
        public static void FuncionesComunes()
        {
            var unTexto = "Un Texto De Ejemplo";

            // Transformar un texto en mayúsculas
            Console.WriteLine($"Para transformar a mayúsculas podemos utilizar unTexto.ToUpper() y el resultado es: {unTexto.ToUpper()}");

            // Transformar un texto en minúsculas
            Console.WriteLine($"Para transformar a minúsculas podemos utilizar unTexto.ToLower() y el resultado es: {unTexto.ToLower()}");

            Console.WriteLine("Para ver si un texto está contenido en un string podemos utilizar la función unTexto.Contains(\"texto\")");
            Console.WriteLine($"En este caso podemos buscar 'texto' dentro de la variable y el resultado es: {unTexto.Contains("texto")}");
            // como se puede notar no lo encontró y es lógico ya que "Texto" != "texto".
            // para hacer una comparación ignorando el casing podemos hacer lo siguiente:
            Console.WriteLine($"Buscamos 'texto' dentro de la variable ignorando el casing y el resultado es: {unTexto.Contains("texto", StringComparison.OrdinalIgnoreCase)}");

            Console.WriteLine("Para ver si la variable comienza con 'un' podemos hacer unTexto.StartsWith(\"un\", StringComparison.OrdinalIgnoreCase)");
            Console.WriteLine($"Y el resultado es: {unTexto.StartsWith("un", StringComparison.OrdinalIgnoreCase)}");

            Console.WriteLine("Para ver si la variable termina con 'ejemplo' podemos hacer unTexto.EndsWith(\"ejemplo\", StringComparison.OrdinalIgnoreCase)");
            Console.WriteLine($"Y el resultado es: {unTexto.EndsWith("ejemplo", StringComparison.OrdinalIgnoreCase)}");

            // para reemplazar texto dentro de texto podemos utilizar la función replace:
            Console.WriteLine("En la variable reemplazamos 'un texto de' por 'un excelente' ejecutando unTexto.Replace(\"un texto de\", \"Un Excelente\", StringComparison.OrdinalIgnoreCase)");
            Console.WriteLine($"Y el resultado es: {unTexto.Replace("un texto de", "Un Excelente", StringComparison.OrdinalIgnoreCase)}");

            Console.WriteLine("Si tenemos una variable con espacios en blanco al principio o al final o en ambos podemos utilizar la función Trim() para eliminarlos");
        }
    }
}
