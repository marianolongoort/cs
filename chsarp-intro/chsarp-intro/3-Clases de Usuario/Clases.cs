using System;

namespace chsarp_intro._3_Clases_de_Usuario
{
    public static class Clases
    {
        /// <summary>
        /// Una clase es una receta o molde para fabricar un objeto.
        /// La clase posee un identificación única, la definición de 
        /// cada atributo que compone el estado interno de cada objeto y 
        /// el comportamiento que éstos tendrán.
        /// </summary>
        public static void ClasesDeUsuario()
        {
            // podemos instanciar un objeto del tipo Auto de la siguiente forma
            Auto auto = new Auto("renault");

            // podemos acceder a las propiedades públicas del objeto y obtener o asignar datos
            Console.WriteLine($"la {nameof(Auto.Marca)} del auto '{nameof(auto)}' es {auto.Marca}"); // marca es de solo lectura, no puede ser modificado.

            auto.Color = "negro"; // color es de lecto escritura => puede leerse y escribirse.
            Console.WriteLine($"el {nameof(Auto.Color)} del auto '{nameof(auto)}' es {auto.Color}");

            auto.CantidadDePuertas = 4; // CantidadDePuertas es de lecto escritura => puede leerse y escribirse.
            Console.WriteLine($"la {nameof(Auto.CantidadDePuertas)} del auto '{nameof(auto)}' es {auto.CantidadDePuertas}");

            // la fecha de creación es de lectura y se asigna automáticamente cuando se crea un objeto de tipo Auto.
            Console.WriteLine($"la {nameof(Auto.FechaDeCreacion)} del auto '{nameof(auto)}' es {auto.FechaDeCreacion:dd-MM-yyyy hh:mm:ss}");

            Console.WriteLine($"Ejecutamos el método '{nameof(Auto.AddRueda)}' del objeto auto");
            auto.AddRueda(new Rueda { Marca = "Firestone", Rodado = 175 });
            auto.AddRueda(new Rueda { Marca = "Firestone", Rodado = 180 });

            Console.WriteLine("El auto posee las siguientes ruedas:");

            foreach(var rueda in auto.Ruedas) // itera por cada elemento de la colección y la variable rueda apunta al elemento actual de la iteración
            {
                Console.WriteLine($"Una rueda {nameof(Rueda.Marca)} '{rueda.Marca}' y es {nameof(Rueda.Rodado)} '{rueda.Rodado}'");
            }
        }

        /// <summary>
        /// Como se vio en <see cref="_1_Tipos_de_datos.Tipos.Jerarquia"/>, todos los 
        /// tipos derivan, en algún punto, del tipo object.
        /// </summary>
        public static void MetodosDelTipoObject()
        {
            // Object provee a todos los tipos de 3 métodos que pueden sobreescribirse a conveniencia:
            // - GetHashCode()
            // - Equals(object)
            // - ToString()

            Console.WriteLine("Creamos 3 casas:");
            Casa casa1 = new Casa() { Calle = "Callao", Altura = 2600 };
            Console.WriteLine(casa1.ToString());
            Casa casa2 = new Casa() { Calle = "Corrientes", Altura = 9290 };
            Console.WriteLine(casa2.ToString());
            Casa casa3 = new Casa() { Calle = "Callao", Altura = 2600 };
            Console.WriteLine(casa3.ToString());

            Console.WriteLine($"El resultado de casa1.Equals(casa2) es: {casa1.Equals(casa2)}");
            Console.WriteLine($"El resultado de casa1.Equals(casa3) es: {casa1.Equals(casa3)}");

            Console.WriteLine($"El resultado de casa1 == casa2 es: {casa1 == casa2}");
            Console.WriteLine($"El resultado de casa1 == casa3 es: {casa1 == casa3}");
        }

        /// <summary>
        /// Herencia es uno de los principios de OOP y se traduce en la habilidad de una clase de 
        /// definir atributos y/o estado (implementado o no) a sus clases derivadas.
        /// En c# no se permite multiherencia.
        /// Para ejemplificar herencia en c# usaremos las clases <see cref="Figura"/>, <see cref="Rectangulo"/> y <see cref="Cuadrado"/>.
        /// </summary>
        public static void Herencia()
        {
            // el tipo Figura fue definido como abstract ya que conceptualmente no tiene sentido crear instancias de "figura" sin tratarse de ninguna figura específicamente.

            // si queremos crear una instancia de tipo Rectángulo lo hacemos como cualquier otra clase de usuario:
            var rectangulo1 = new Rectangulo(5, 10);
            Console.WriteLine($"Creamos una nueva variable '{nameof(rectangulo1)}' de tipo '{nameof(Rectangulo)}' con alto 5 y ancho 10.");

            Console.WriteLine($"Definimos en {nameof(Figura)} que todas las clases derivadas de ella deben implementar {nameof(Figura.Nombre)} y {nameof(Figura.CalcularArea)}");
            Console.WriteLine($"Por lo tanto {nameof(rectangulo1)} tiene implementado el {nameof(Rectangulo.Nombre)} así: {rectangulo1.Nombre}");
            Console.WriteLine($"Y tiene implementado el método {nameof(Rectangulo.CalcularArea)} así: {rectangulo1.CalcularArea()}");

            // Se definió, adicionalmente, una clase Cuadrado, pero ésta deriva de Rectángulo ya que su implementación interna es casi idéntica.
            // Creamos una instancia de tipo Cuadrado:
            var cuadrado1 = new Cuadrado(5); // Como vemos, el cuadrado sólo recibe 1 parámetro, internamente 
            // el constructor de cuadrado está llamando al base constructor (el constructor de rectángulo) 
            // pasándole el parámetro tanto para alto como para ancho.

            Console.WriteLine($"Definimos en {nameof(Figura)} que todas las clases derivadas de ella deben implementar {nameof(Figura.Nombre)} y {nameof(Figura.CalcularArea)}");
            Console.WriteLine($"Como {nameof(cuadrado1)} es de tipo {nameof(Cuadrado)} y éste deriva de {nameof(Rectangulo)} que a su ver deriva de {nameof(Figura)}");
            Console.WriteLine($"Podemos aseverar que {nameof(cuadrado1)} tiene implementado el {nameof(Cuadrado.Nombre)} así: {cuadrado1.Nombre}");
            Console.WriteLine($"Y tiene implementado el método {nameof(Cuadrado.CalcularArea)} así: {cuadrado1.CalcularArea()}");
        }
    }
}
