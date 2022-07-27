using System;

namespace chsarp_intro._1_Tipos_de_datos
{
    public static class Numericos
    {

        /// <summary>
        /// Los enteros son tipos primitivos manejados por valor.
        /// Para mayor detalle sobre precisiones ver https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/integral-numeric-types
        /// </summary>
        public static void Enteros()
        {
            Console.WriteLine($"-----{nameof(Enteros)}-----");
            Console.WriteLine("se declaran 2 variables de tipo int: 'x' e 'y'");
            // variables de tipo entero con asignación.
            int x = 1;
            int y = 2;
            Console.WriteLine($"valor de x: {x}");
            Console.WriteLine($"valor de y: {y}");

            Console.WriteLine("se declara una tercera variable de tipo int 'z', producto de la suma de 'x' e 'y'");

            // z es una variable de tipo entero por inferencia de tipos => esto quiere decir que infiere el tipo por la asignación que se hace.
            var z = x + y; // z vale 3
            Console.WriteLine($"valor de z: {z}");

            // incrementamos el valor de z en 1.
            z = z + 1; // z vale 4
            Console.WriteLine($"valor de z luego de aplicar 'z = z + 1': {z}");

            // incrementamos el valor de z en 2.
            z += 2; // z vale 6.
            Console.WriteLine($"valor de z luego de aplicar 'z += 2': {z}");

            // decrementamos el valor de z en 2.
            z -= 2;
            Console.WriteLine($"valor de z luego de aplicar 'z -= 2': {z}");

            // multiplicamos el valor de z por 2 y lo asignamos a la variable.
            z *= 2;
            Console.WriteLine($"valor de z luego de aplicar 'z *= 2': {z}");

            // dividimos el valor de z por 2 y lo asignamos a la variable.
            z /= 2;
            Console.WriteLine($"valor de z luego de aplicar 'z /= 2': {z}");

            // obtenemos el módulo de la división entre z y 2 y lo asignamos a la variable.
            z %= 2;
            Console.WriteLine($"valor de z luego de aplicar 'z %= 2': {z}");

            // para realizar un parsing de un dato a int existen las funciones Parse y TryParse
            int unEntero = int.Parse("5");
            Console.WriteLine($"resultado de int unEntero = int.Parse(\"5\"); {unEntero}");

            // try parse pondrá el resultado del parsing dentro de la variable de salida 'resultadoEntero'. En caso de no poder realizar la conversión pone el default(int), o sea 0.
            int.TryParse("esto no es un entero", out int resultadoEntero);
            Console.WriteLine($"resultado de int.TryParse(\"esto no es un entero\", out int resultadoEntero); {resultadoEntero}");
        }

        public static void Decimales()
        {
            decimal variableDecimal = decimal.Zero; // decimal.Zero representa el decimal con valor cero.
            variableDecimal = 1; // asignación de un valor literal como entero. Se hace un casteo implícito a decimal.
            variableDecimal = 0.5M; // asignación de un valor literal como decimal.

            // los operadores funcionan de la misma forma que con el resto de los tipos numéricos
            variableDecimal = 2.5M + 8.3M; // por ejemplo la suma.

            // sin aplicar formatos se verá 
            Console.WriteLine($"el valor de la variable {nameof(variableDecimal)} es: {variableDecimal}");

            // para representar un decimal como string podemos utilizar el método ToString(Formato) o en este caso se puede utilizar :Formato (por ejemplo :N2)
            Console.WriteLine("Luego de aplicarle el formato N2 a la variable se vería de esta manera:");
            Console.WriteLine($"el valor de la variable {nameof(variableDecimal)} es: {variableDecimal:N2}");
            // para más detalles en qué formatos se pueden utilizar ver: https://docs.microsoft.com/es-es/dotnet/standard/base-types/standard-numeric-format-strings

            // para realizar un parsing de un dato a decimal existen las funciones Parse y TryParse
            decimal unDecimal = decimal.Parse("5.3");
            Console.WriteLine($"resultado de decimal unDecimal = decimal.Parse(\"5.3\"); {unDecimal}");

            // try parse pondrá el resultado del parsing dentro de la variable de salida 'resultadoDecimal'. En caso de no poder realizar la conversión pone el default(decimal), o sea 0M.
            decimal.TryParse("esto no es un decimal", out decimal resultadoDecimal);
            Console.WriteLine($"resultado de decimal.TryParse(\"esto no es un decimal\", out decimal resultadoDecimal); {resultadoDecimal}");
        }
    }
}
