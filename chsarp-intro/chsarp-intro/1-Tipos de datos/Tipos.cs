using System;

namespace chsarp_intro._1_Tipos_de_datos
{
    /// <summary>
    ///           C# es un lenguaje fuertemente tipado.
    ///           En concordancia con la frase anterior, c# provee de una serie de tipos ya definidos. => léase int, string, long, decimal, etc.
    ///           Adicionalmente a los tipos que provee c# se le permite al usuario definir sus propios tipos.
    ///           C# tratará a todo como objetos. Esto quiere decir que hasta los tipos "primitivos" serán tratados como objetos => 
    ///           por ejemplo int será System.Int32 y string será System.String.
    ///           C# parte de una jerarquía de objetos donde se pre establece que todo objeto hereda tiene como punto de partida el System.Object.
    ///           
    ///           Un programa en C# es una colección de tipos: classes, structs, enums, interfaces, delegates. 
    ///           Como cualquier lenguaje de programación, C# proporciona una serie de tipos predefinidos (int, byte, char, string, object...) 
    ///           y mecanismos para que el usuario cree sus propios tipos. 
    ///           Todo el código y todos los datos de una aplicación forman parte de objetos que encapsulan datos y código.
    ///           En C#, un tipo puede incluir datos (campos, constantes, arrays y eventos), funciones (métodos, operadores, constructores, 
    ///           destructores, propiedades e indexadores) y otros tipos. 
    ///           Los tipos se organizan en ficheros, assemblies y espacios de nombres(de forma jerárquica). 
    ///           En el sistema unificado de tipos de la plataforma.NET, los tipos pueden ser valores(contienen datos, no pueden ser null)
    ///           o referencias(contienen referencias a otros objetos, pueden ser null).
    /// </summary>
    public static class Tipos
    {
        /// <summary>
        /// Las variables de tipo de valor contienen directamente sus valores, lo que significa que la memoria se asigna insertada en cualquier contexto en el que se declare la variable. 
        /// más detalles aquí: https://docs.microsoft.com/es-es/dotnet/csharp/programming-guide/types/#value-types
        /// </summary>
        public static void DeValor()
        {
            Console.WriteLine($"-----{nameof(DeValor)}-----");
            Console.WriteLine();

            // los tipos por valor pueden ser por ejemplo los enteros
            int variable1 = 1;

            //  o las estructuras
            Console.WriteLine($"declare una variable de tipo {nameof(EstructuraPersona)} llamada 'persona'");
            EstructuraPersona persona = new EstructuraPersona
            {
                // esta es una forma de hacer la construcción del objeto simplificada asignando valores a las propiedades públicas que éste tenga
                Nombre = "mi nombre",
                Apellido = "mi apellido"
            };

            Console.WriteLine($"mi estructura persona tiene Nombre: '{persona.Nombre}' y apellido: {persona.Apellido}.");

            // Cuando se envía como parámetro un tipo por valor éste no se ve afectado por las acciones que se realizan dentro de la función
            // ya que internamente lo que sucede es que se crea una copia de la variable con el scope local de la función que se ejecuta.
            Console.WriteLine("Ejecuto un método donde internamente modifico persona.");
            Modificar(persona);

            Console.WriteLine($"mi estructura persona tiene Nombre: '{persona.Nombre}' y apellido: {persona.Apellido}.");
        }

        /// <summary>
        /// Un tipo que se define como clase, delegado, matriz o interfaz es un tipo de referencia.
        /// para más detalles ver: https://docs.microsoft.com/es-es/dotnet/csharp/programming-guide/types/#reference-types
        /// </summary>
        public static void DeReferencia()
        {
            // Al declarar una variable de un tipo de referencia en tiempo de ejecución, esta contendrá el valor null hasta que se cree explícitamente un objeto mediante el operador new, o bien que se le asigne un objeto creado en otro lugar mediante new, tal y como se muestra en el ejemplo siguiente:
            Console.WriteLine($"-----{nameof(DeReferencia)}-----");
            Console.WriteLine();

            // Si bien los string son tipos por referencia
            Console.WriteLine("declare una variable de tipo string llamada 'miString'");
            string miString = "test";

            Console.WriteLine($"el valor de la variable 'miString' es: {miString}");

            // cuando se pasan por parámetro a una función son <inmutables>
            // esto quiere decir que no cambia el estado del objeto aunque se editen valores dentro de la función a la que se llama.
            Console.WriteLine("Ejecuto un método donde internamente modifico 'miString'.");
            Modificar(miString);

            Console.WriteLine($"el valor de la variable 'miString' es: {miString}");

            //  o las estructuras
            Console.WriteLine($"declare una variable de tipo {nameof(ClasePersona)} llamada 'persona'");
            ClasePersona persona = new ClasePersona
            {
                // esta es una forma de hacer la construcción del objeto simplificada asignando valores a las propiedades públicas que éste tenga
                Nombre = "mi nombre",
                Apellido = "mi apellido"
            };

            Console.WriteLine($"mi estructura persona tiene Nombre: '{persona.Nombre}' y apellido: {persona.Apellido}.");

            // Cuando se envía como parámetro un tipo por valor éste no se ve afectado por las acciones que se realizan dentro de la función
            // ya que internamente lo que sucede es que se crea una copia de la variable con el scope local de la función que se ejecuta.
            Console.WriteLine("Ejecuto un método donde internamente modifico persona.");
            Modificar(persona);

            Console.WriteLine($"mi estructura persona tiene Nombre: '{persona.Nombre}' y apellido: {persona.Apellido}.");

        }

        /// <summary>
        /// Los tipos complejos como clases o colecciones aceptan valores nulos como valor por defecto previos a su inicialización.
        /// Los tipos de valor como int, bool, char o struct por ejemplo sólo admiten null si es especificado explícitamente.
        /// </summary>
        public static void Nulables()
        {
            Console.WriteLine($"-----{nameof(Nulables)}-----");
            Console.WriteLine();

            // la variable x no admite nulos, por lo tanto no puedo asignarle el valor 'null'.
            int x = default;

            // La inicialización del valor de estas variables toma el default.
            Console.WriteLine($"el valor por defecto de la variable 'x' es: {x}, que debería coincidir con el valor por defecto del tipo int que es: {default(int)}");

            // por otro lado, el valor por defecto de los tipos por referencia es null.
            // si queremos hacer que los tipos por valor acepten null como posible valor tenemos que "wrapearlos" en una estructura System.Nullable<>.

            Console.WriteLine($"declaro una variable 'nullableX' de tipo {nameof(Nullable<System.Int32>)}");
            // esto se puede lograr de dos formas:
            Nullable<int> nullableX = null;

            Console.WriteLine($"declaro una variable 'nullableY' de tipo {nameof(Nullable<System.Int32>)}");
            // o con una sintaxis simplificada:
            int? nullableY = null;

            // los tipos que se utilicen a través de System.Nullable<> tienen dos propiedades especiales:
            if (!nullableY.HasValue) // se utiliza para evaluar si la variable tiene un valor asignado o tiene null
            {
                nullableY = 5; // la asignación de valores es igual.
            }

            // formas de escribirlo:

            // forma 1
            string resultado = nullableX?.ToString();
            // si nullableX tiene null, resultado1 = null
            // si nullableX no tiene null, resultado1 = "0" por ejemplo

            // forma 2
            resultado = nullableX.HasValue ? nullableX.ToString() : null;

            // forma 3
            if (nullableX.HasValue)
            {
                resultado = nullableX.ToString();
            }

            // forma 1
            resultado = nullableX?.ToString() ?? "null";

            // forma 2
            resultado = nullableX.HasValue ? nullableX.ToString() : "null";

            // forma 3
            if (nullableX.HasValue)
            {
                resultado = nullableX.ToString();
            }
            else
            {
                resultado = "null";
            }

            // la expresión nullableX?.ToString() intentará obtener el valor de 'nullableX' y si éste NO es null ejecutará el método "ToString()", sino retorna null
            // la expresión 'variable' ?? 'value' hace que si 'variable' tiene un valor retorne dicho valor y en caso de que 'variable' tenga null retornará 'value'
            Console.WriteLine($"valor de '{nameof(nullableX)}': {nullableX?.ToString() ?? "null"}");
            Console.WriteLine($"valor de '{nameof(nullableY)}': {nullableY?.ToString() ?? "null"}");

            nullableX = nullableY.Value; // retorna el valor que tenga la variable con el tipo no nulable. En este caso retorna 5 como tipo 'int' en lugar de tipo 'int?'
        }

        /// <summary>
        /// C# es un lenguaje fuertemente tipado. 
        /// Cada declaración del método especifica un nombre, un número de parámetros, un tipo y una naturaleza (valor, referencia o salida) para cada parámetro de entrada y para el valor devuelto. La biblioteca de clases .NET define un conjunto de tipos numéricos integrados, así como tipos más complejos que representan una amplia variedad de construcciones lógicas, como el sistema de archivos, conexiones de red, colecciones y matrices de objetos, y fechas. Los programas de C# típicos usan tipos de la biblioteca de clases, así como tipos definidos por el usuario que modelan los conceptos que son específicos del dominio del problema del programa.
        /// Para más detalles ver el enlace: https://docs.microsoft.com/es-es/dotnet/csharp/programming-guide/types/
        /// </summary>
        public static void Jerarquia()
        {
            Console.WriteLine($"-----{nameof(Jerarquia)}-----");
            Console.WriteLine();

            // c# es un lenguaje "fuertemente tipado" esto quiere decir que tiene tipos estáticos contra los que chequea cada uno de los tipos que son asignados a una variable en tiempo de compilación.
            // Todas las variables y constantes tienen un tipo, al igual que todas las expresiones que se evalúan como un valor. 
            int variable1 = 2;
            string variable2 = "test";

            // si no se designa un valor explícito, éste puede ser designado implícitamente por inferencia de tipo mediante la palabra clave var.
            // La variable sigue recibiendo un tipo en tiempo de compilación, pero este lo proporciona el compilador.
            var variable3 = "esta variable es de tipo string";

            // en .NET existe una jerarquía de tipos que establece que todo tipo parte, en algún punto, del tipo 'object'.
            object unObjeto = variable3;

            // en este caso la variable que definimos 'unObjeto' de tipo object fue asignada con otra variable de tipo string, por lo tanto, si aplicamos casting podemos obtener el valor con el tipo interno correctamente.
            string miVariable = (string)unObjeto;
        }

        /// <summary>
        /// Otros tipos que se pueden declarar son los tipos anónimos.
        /// Se trata, básicamente, de tipos que no son predefinidos explícitos previamente, sino que se especifican en donde se desean usar directamente.
        /// El compilador generará el nombre del tipo como 'a, etc. y no está disponible para ser utilizado en otra porción de código. 
        /// Para cada propiedad el compilador deduce el tipo.
        /// Para más detalles ver: https://docs.microsoft.com/es-es/dotnet/csharp/programming-guide/classes-and-structs/anonymous-types
        /// </summary>
        public static void Anonimos()
        {
            Console.WriteLine($"-----{nameof(Anonimos)}-----");
            Console.WriteLine();

            // declaramos un tipo anónimo y lo asignamos a la variable 'x'
            var x = new
            {
                Nombre = "un nombre",
                Apellido = "un apellido",
                Edad = 25,
                Domicilio = new
                {
                    Calle = "una calle",
                    Altura = 111,
                    Provincia = "Buenos Aires",
                    Pais = "Argentina"
                }
            };

            // como se puede ver en la definición de tipo de 'x' que nos provee intellisense, tenemos 2 tipos anónimos que estamos utilizando: 'a y 'b
            // 'a es { string Nombre, string Apellido, int Edad, 'b Domicilio }
            // 'b es { string Calle, int Altura, string Provincia, string Pais }

            // luego podemos acceder al tipo anónimo y leer sus propiedades
            Console.WriteLine($"Nombre: {x.Nombre}. Edad: {x.Edad}. Domicilio: calle {x.Domicilio.Calle} {x.Domicilio.Altura} {x.Domicilio.Provincia}, {x.Domicilio.Pais}");

            // Las propiedades generadas en los tipos anónimos son de sólo lectura y por lo tanto no podrán ser modificadas.
            // el siguiente código no compilaría:
            // x.Domicilio.Calle = "otra calle";
        }

        /// <summary>
        /// Dado que C# tiene tipos estáticos en tiempo de compilación, después de declarar una variable, no se puede volver a declarar 
        /// ni se le puede asignar un valor de otro tipo a menos que ese tipo sea convertible de forma implícita al tipo de la variable. 
        /// Por ejemplo, string no se puede convertir de forma implícita a int.
        /// Para más detalles ver este link: https://docs.microsoft.com/es-es/dotnet/csharp/programming-guide/types/casting-and-type-conversions
        /// </summary>
        public static void Castings()
        {
            Console.WriteLine($"-----{nameof(Castings)}-----");
            Console.WriteLine();

            // hay algunos cast implícitos que se pueden realizar como por ejemplo:
            int numero = 10;
            Console.WriteLine($"declaramos una variable llamada '{nameof(numero)}' de tipo int con el valor {numero}");

            Console.WriteLine("Escenarios de casting válidos:");

            long numeroMasGrande = numero; // como la asignación siempre va a funcionar, entonces el cast es implícito.
            Console.WriteLine($"Declaramos otra variable llamada '{nameof(numeroMasGrande)}' de tipo long y le asignamos el valor de '{nameof(numero)}'");
            Console.WriteLine($"La variable '{nameof(numeroMasGrande)}' fue asignada con el valor '{numeroMasGrande}' utilizando un casteo implícito.");

            short numeroMasPequeno = (short)numero; // el casteo aquí debe ser explícito ya que es posible que no funcione.
            Console.WriteLine($"Declaramos otra variable llamada '{nameof(numeroMasPequeno)}' de tipo short y le asignamos el valor de '{nameof(numero)}'");
            Console.WriteLine($"La variable '{nameof(numeroMasPequeno)}' fue asignada con el valor '{numeroMasPequeno}' utilizando un casteo explícito.");

            Console.WriteLine("Escenarios de casting inválidos:");

            int maxNumero = int.MaxValue;
            short numeroShort = (short)maxNumero; // en este caso se perderá la información porque el cast no es válido
            Console.WriteLine("Declaramos 2 variables para ejemplificar un cast en el que se perderá información:");
            Console.WriteLine($"Declaramos la variable '{nameof(maxNumero)}' de tipo int y le asignamos el máximo valor del tipo int: {maxNumero}");
            Console.WriteLine($"Declaramos la variable '{nameof(numeroShort)}' de tipo short y le asignamos el valor de '{nameof(maxNumero)}'");
            Console.WriteLine($"La variable '{nameof(numeroShort)}' queda con el valor '{numeroShort}' utilizando un casteo explícito, generando una pérdida de información.");
        }

        #region Declaraciones privadas

        private struct EstructuraPersona
        {
            public string Nombre { get; set; }
            public string Apellido { get; set; }
        }

        private class ClasePersona
        {
            public string Nombre { get; set; }
            public string Apellido { get; set; }
        }

        private static void Modificar(EstructuraPersona persona)
        {
            persona.Nombre = "otro nombre";
            persona.Apellido = "otro apellido";
        }

        private static void Modificar(ClasePersona persona)
        {
            persona.Nombre = "otro nombre";
            persona.Apellido = "otro apellido";
        }

        private static void Modificar(string texto)
        {
            texto = "otro texto diferente";
        }

        #endregion
    }
}
