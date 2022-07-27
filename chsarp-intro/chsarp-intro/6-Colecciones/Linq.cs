using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace chsarp_intro._6_Colecciones
{
    /// <summary>
    /// LINQ => Language-Integrated Query
    /// Se trata de un conjunto de tecnologías para poder expresar en lenguaje c# consultas desde diferentes orígenes de datos.
    /// Más información aquí: https://docs.microsoft.com/es-es/dotnet/csharp/tutorials/working-with-linq
    /// </summary>
    public static class Linq
    {
        /// <summary>
        /// Linq tiene 2 formas básicas de escribirse: como consultas o como métodos de extensión.
        /// Todos los ejemplos siguientes los veremos en las dos formas
        /// Más información aquí: https://docs.microsoft.com/es-es/dotnet/csharp/programming-guide/concepts/linq/introduction-to-linq-queries
        /// </summary>
        public static void Consultas()
        {
            // Linq básicamente necesita de 3 partes.

            // 1era parte: Origen de datos:
            // esta parte es la que utilizaremos como fuente en nuestra consulta. (responde al dónde)
            var datos = new List<string>() { "un dato", "otro dato", "un tercer dato" };

            // 2da parte: La consulta
            // esta parte es la que se encarga de establecer filtros, proyecciones de datos, etc (responde al qué)
            var consultaLinq = from dato in datos
                               select dato;

            // 3era parte: la ejecución
            // las consultas de linq no serán ejecutadas hasta que se solicite explícitamente la ejecución o hasta que los datos sean requeridos.
            var resultado = consultaLinq.ToList(); // el método ToList() ejecutará la consulta y retornará una lista con los resultados de la consulta.
        }

        /// <summary>
        /// Aplicamos un filtro para retornar los elementos que nos interesan de una colección determinada.
        /// Utilizaremos el set de datos pre armado <see cref="_productos"/>.
        /// Más información aquí: https://docs.microsoft.com/es-es/dotnet/csharp/programming-guide/concepts/linq/basic-linq-query-operations#filtering
        /// </summary>
        public static void Where()
        {
            Console.WriteLine("Ejecutaremos consultas para obtener los productos cuyo precio sea mayor o igual a 100.");

            // utilizando el lenguaje de consultas de Linq:
            var conLenguajeDeConsultas = from producto in _productos
                                         where producto.Precio >= 100M
                                         select producto;

            Console.WriteLine("Los productos obtenidos son:");

            // la consulta recién será ejecutada aquí cuando los elementos de la colección son requeridos
            foreach (Producto producto in conLenguajeDeConsultas)
                Console.WriteLine(producto);

            Console.WriteLine();

            // utilizando el lenguaje de métodos de extensión de Linq:
            var conMetodos = _productos
                .Where(producto => producto.Precio >= 100M);

            Console.WriteLine("Los productos obtenidos son:");

            // la consulta recién será ejecutada aquí cuando los elementos de la colección son requeridos
            foreach (Producto producto in conMetodos)
                Console.WriteLine(producto);
        }

        /// <summary>
        /// Aplicamos un orden en la colección de retorno.
        /// Utilizaremos el set de datos pre armado <see cref="_productos"/>.
        /// Más información aquí: https://docs.microsoft.com/es-es/dotnet/csharp/programming-guide/concepts/linq/basic-linq-query-operations#ordering
        /// </summary>
        public static void Ordering()
        {
            Console.WriteLine("Ejecutaremos consultas para obtener los productos ordenados por precio de forma descendiente.");

            // utilizando el lenguaje de consultas de Linq:
            var conLenguajeDeConsultas = from producto in _productos
                                         orderby producto.Precio descending // si quisiera ordenar de forma ascendente usamos el keyword 'ascending'
                                         select producto;

            Console.WriteLine("Los productos obtenidos son:");

            foreach (Producto producto in conLenguajeDeConsultas)
                Console.WriteLine(producto);

            Console.WriteLine();

            // utilizando el lenguaje de métodos de extensión de Linq:
            var conMetodos = _productos.OrderByDescending(producto => producto.Precio).ToList(); // si quisiera ordenar de forma ascendente usamos el método 'OrderBy()'

            // ordenamiento por más de un criterio
            conMetodos = _productos.OrderBy(producto => producto.Precio).ThenByDescending(producto => producto.Nombre).ToList();

            Console.WriteLine("Los productos obtenidos son:");

            foreach (Producto producto in conMetodos)
                Console.WriteLine(producto);
        }

        /// <summary>
        /// Utilizando Select tenemos la posibilidad de transformar un origen de datos en un tipo de salida específico que necesitemos, por ejemplo, 
        /// dada una colección de productos quizás quiero obtener sólo la colección de los nombres de los productos.
        /// Utilizaremos el set de datos pre armado <see cref="_productos"/>.
        /// Más información aquí: https://docs.microsoft.com/es-es/dotnet/csharp/programming-guide/concepts/linq/data-transformations-with-linq
        /// Material interesante para entender bien la transformación de datos: https://docs.microsoft.com/es-es/dotnet/csharp/programming-guide/concepts/linq/type-relationships-in-linq-query-operations
        /// </summary>
        public static void Select()
        {
            Console.WriteLine("Ejecutaremos consultas para seleccionar los nombres de productos.");

            // utilizando el lenguaje de consultas de Linq:
            var conLenguajeDeConsultas = from producto in _productos
                                         select producto.Nombre;

            Console.WriteLine("Los productos obtenidos son:");

            foreach (string nombre in conLenguajeDeConsultas)
                Console.WriteLine(nombre);

            Console.WriteLine();

            // utilizando el lenguaje de métodos de extensión de Linq:
            var conMetodos = _productos.Select(producto => producto.Nombre).ToList();

            Console.WriteLine("Los productos obtenidos son:");

            foreach (string nombre in conMetodos)
                Console.WriteLine(nombre);
        }

        /// <summary>
        /// El Min es una función de agregación que nos permite obtener el mínimo valor de una colección determinada.
        /// Con la función lambda se puede especificar alguna propiedad a utilizarse para obtener el mínimo, por ejemplo en este caso se usará el precio.
        /// </summary>
        public static void Min()
        {
            Console.WriteLine("Ejecutaremos consultas para obtener el precio mínimo de la lista de productos.");

            // utilizando el lenguaje de métodos de extensión de Linq:
            var precioMinimo = _productos.Min(producto => producto.Precio);

            Console.WriteLine($"El precio mínimo de los productos es {precioMinimo:N2}");
        }

        /// <summary>
        /// El Max es una función de agregación que nos permite obtener el máximo valor de una colección determinada.
        /// Con la función lambda se puede especificar alguna propiedad a utilizarse para obtener el máximo, por ejemplo en este caso se usará el precio.
        /// </summary>
        public static void Max()
        {
            Console.WriteLine("Ejecutaremos consultas para obtener el precio máximo de la lista de productos.");

            var precioMaximo = _productos.Max(producto => producto.Precio);

            Console.WriteLine($"El precio máximo de los productos es {precioMaximo:N2}");
        }

        /// <summary>
        /// El Average es una función de agregación que nos permite obtener el valor promedio de una colección determinada.
        /// Con la función lambda se puede especificar alguna propiedad a utilizarse para promediar, por ejemplo en este caso se usará el precio.
        /// </summary>
        public static void Average()
        {
            Console.WriteLine("Ejecutaremos consultas para obtener el precio promedio de la lista de productos.");

            var precioPromedio = _productos.Average(producto => producto.Precio);

            Console.WriteLine($"El precio promedio de los productos es {precioPromedio:N2}");
        }

        /// <summary>
        /// Count es una función de que nos permite obtener la cantidad de elementos en una colección determinada.
        /// </summary>
        public static void Count()
        {
            Console.WriteLine("Ejecutaremos consultas para obtener la cantidad de elementos en la lista de productos.");

            var cantidadDeElementos = _productos.Count();

            Console.WriteLine($"La cantidad de productos es {cantidadDeElementos}");
        }

        /// <summary>
        /// Sum es una función que nos permite sumarizar elementos de una colección determinada.
        /// Con la función lambda se puede especificar alguna propiedad a utilizarse para sumarizar, por ejemplo en este caso se usará el precio.
        /// </summary>
        public static void Sum()
        {
            Console.WriteLine("Ejecutaremos consultas para obtener el precio total de la lista entera de productos.");

            var precioTotal = _productos.Sum(producto => producto.Precio);

            Console.WriteLine($"El precio total de los productos es {precioTotal:N2}");
        }

        /// <summary>
        /// El método Distinct nos permite obtener los objetos distintos de una colección.
        /// </summary>
        public static void Distinct()
        {
            Console.WriteLine("Ejecutaremos consultas para obtener la lista de nombres de productos sin duplicados.");

            // obtenemos la lista de nombres de los productos y a dicha lista le aplicamos el distinct para que elimine los duplicados de la colección resultante.
            var listaDeNombresSinDuplicados = _productos.Select(producto => producto.Nombre).Distinct();

            Console.WriteLine($"Los elementos de la colección son: {string.Join(", ", listaDeNombresSinDuplicados.ToArray())}");
        }

        #region Sección privada

        private static readonly List<Producto> _productos = new List<Producto>
        {
            new Producto(Guid.NewGuid(), "Café", 1, 200M),
            new Producto(Guid.NewGuid(), "Té", 2, 65M),
            new Producto(Guid.NewGuid(), "Azúcar", 3, 30M),
            new Producto(Guid.NewGuid(), "Edulcorante", 4, 50M),
            new Producto(Guid.NewGuid(), "Yerba", 5, 120M),
            new Producto(Guid.NewGuid(), "Galletitas", 6, 100M),
            new Producto(Guid.NewGuid(), "Bizcochos", 7, 80M),
            new Producto(Guid.NewGuid(), "Yerba", 8, 130M),
        };

        #endregion
    }
}
