using System;
using System.Collections.Generic;

namespace chsarp_intro._6_Colecciones
{
    /// <summary>
    /// En el ecosistema NET disponemos de librerías dedicadas al manejo de las colecciones.
    /// </summary>
    public static class Colecciones
    {
        /// <summary>
        /// Los tipos de colecciones más básicos son los vectores o arrays.
        /// </summary>
        public static void Arrays()
        {
            // la forma de definir arrays de un tipo es tipo[]
            int[] arrayDeEnteros = new int[3]; // se trata de un array de 3 elementos
            Console.WriteLine($"Declaramos un array de enteros llamado '{nameof(arrayDeEnteros)}' con 3 elementos");

            Console.WriteLine($"Asignamos valores a cada posición del vector '{nameof(arrayDeEnteros)}'");
            for (int i = 0; i < arrayDeEnteros.Length; i++)
                arrayDeEnteros[i] = i;

            Console.WriteLine($"Los valores del array son: {string.Join(", ", arrayDeEnteros)}");

            // la forma de acceder a un elemento es por índice zero based, esto significa que el primer elemento se encuentra en la posición cero.
            Console.WriteLine($"El primer elemento del array '{nameof(arrayDeEnteros)}' es: {arrayDeEnteros[0]}");

            // si se desea editar un elemento del array se asigna accediendo por índice también:
            arrayDeEnteros[0] = 15;
            Console.WriteLine($"El primer elemento del array '{nameof(arrayDeEnteros)}' luego de modificarlo es: {arrayDeEnteros[0]}");
        }

        /// <summary>
        /// La interfaz ICollection<T> nos provee de un set de funciones que una colección debe utilizar.
        /// Para ejemplificar el uso de ICollection creamos un elemento <see cref="Producto"/> y una colección de 
        /// productos implementando ICollection <see cref="ColeccionDeProductos"/>.
        /// </summary>
        public static void ICollections()
        {
            // creamos una nueva variable del tipo ColeccionDeProductos
            var listaDeProductos = new ColeccionDeProductos();
 
            Console.WriteLine($"Creamos una variable '{nameof(listaDeProductos)}' de tipo '{nameof(ColeccionDeProductos)}'");

            // este tipo colección de productos que creamos implementa la interfaz ICollection<Producto>, 
            // esto quiere decir que internamente debe tener implementadas todas las funcionalidades que 
            // la interfaz requiere.

            // por ejemplo adicionar un elemento a la colección:
            Producto cafe = new Producto(Guid.NewGuid(), "café");
            listaDeProductos.Add(cafe);

            Producto te = new Producto(Guid.NewGuid(), "té");
            listaDeProductos.Add(te);

            Producto azucar = new Producto(Guid.NewGuid(), "azúcar");
            listaDeProductos.Add(azucar);

            Producto edulcorante = new Producto(Guid.NewGuid(), "edulcorante");
            listaDeProductos.Add(edulcorante);

            Console.WriteLine("Adicionamos 4 elementos a la colección");
            Console.WriteLine($"La cantidad de elementos de la colección ahora es: {listaDeProductos.Count}");

            Console.WriteLine($"Si queremos saber si la coleción contiene un elemento en particular utilizamos la función {nameof(ColeccionDeProductos.Contains)}, por ejemplo café: {listaDeProductos.Contains(cafe)}");

            Console.WriteLine("Si queremos iterar por cada elemento de la colección simplemente podemos hacerlo a través de un foreach:");
            foreach(Producto prod in listaDeProductos)
            {
                Console.WriteLine(prod);
            }
        }

        public static void Listas()
        {
            // El elemento de collecciones más utilizado y uno de los más robustos y versátiles son las listas.
            // las listas utilizan tipos genéricos, es por eso que podemos crear un tipo lista de cualquier subtipo con una sintaxis como la siguiente:
            List<string> listaDeStrings = new List<string>(); // en este caso creamos una lista de strings.
            // Notar que no se le asignó una longitud fija a la colección, sino que ésta es dinámica y crece a medida que se le adicionen elementos.
            Console.WriteLine($"Declaramos una lista de strings llamada '{nameof(listaDeStrings)}'");

            listaDeStrings.Add("primer string"); // adicionamos un elemento
            listaDeStrings.AddRange(new[] { "otro elemento", "último texto" }); // adicionamos un rango de elementos
            Console.WriteLine($"Agregamos tres elementos a la lista '{nameof(listaDeStrings)}'");
            Console.WriteLine($"Los valores de los elementos de la lista son: {string.Join(", ", listaDeStrings.ToArray())}");

            // para interactuar con las listas también se puede hacer a través del índice zero based al igual que los arrays.
            Console.WriteLine($"El primer elemento de la lista '{nameof(listaDeStrings)}' es: {listaDeStrings[0]}");

            listaDeStrings.Clear();
            Console.WriteLine($"con la función {nameof(listaDeStrings.Clear)} eliminamos todos los elementos de la lista.");
            Console.WriteLine($"Los valores de los elementos de la lista son: {string.Join(", ", listaDeStrings.ToArray())}");

            Console.WriteLine($"La función {nameof(listaDeStrings.ToArray)} genera un array del tipo específico (en este caso string) a partir de los valores de la lista");

            // en NET disponemos de una potente tecnología para interactuar con las colecciones llamada LINQ que nos brinda 
            // funcionalidades tales como poder obtener un elemento en particular que cumpla con una condición o transformar la colección en otro tipo o 
        }
    }
}
