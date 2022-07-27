using System;
using System.Collections.Generic;

namespace chsarp_intro._1_Tipos_de_datos
{
    public static class Generics
    {
        /// <summary>
        /// Los genéricos introducen el concepto de parámetros de tipo a .NET, 
        /// lo que le permite diseñar clases y métodos que aplazan la especificación 
        /// de uno o varios tipos hasta que el código de cliente declare y cree una instancia 
        /// de la clase o el método. Por ejemplo, al usar un parámetro de tipo genérico T, puede 
        /// escribir una clase única que otro código de cliente puede usar sin incurrir en el 
        /// costo o riesgo de conversiones en tiempo de ejecución u operaciones de conversión boxing.
        /// Para más detalles ver: https://docs.microsoft.com/es-es/dotnet/csharp/programming-guide/generics/
        /// ¿Qué es boxing?: 
        /// </summary>
        public static void Genericos()
        {
            // una de las implementaciones más comunes en .NET que utiliza generics es el sistema de listas
            // para poder utilizar las listas genéricas debemos incluír el namespace System.Collections.Generic
            // en el siguiente código creamos una lista de enteros:
            List<int> listaDeEnteros = new List<int>();

            // o una lista de string:
            List<string> listaDeStrings = new List<string>();

            // a través del uso de genérics es que simplificamos y generalizamos nuestas implementaciones para dejar que quien consuma nuestros tipos decida el tipo genérico a utilizar.
            // por ejemplo podemos definir una clase que sirva como base para las demás clases que defina que existe una propiedad Id de tipo TKey.
            // el tipo TKey será definido en cada caso donde se utilice la clase BaseClass que definimos, por ejemplo, en nuestro código lo utilizamos en Telefono y Persona.
            // Telefono : BaseClass<Guid> => indica que la clase Telefono tendrá una propiedad Id de tipo Guid
            // Persona : BaseClass<int> => indica que la clase Persona tendrá una propiedad Id de tipo int

            Persona persona = new Persona
            {
                Id = 1,
                Nombre = "Juan",
                Apellido = "Pérez",
                Telefono = new Telefono
                {
                    Id = Guid.NewGuid(), // Guid.NewGuid() generará un nuevo Guid automáticamente.
                    Caracteristica = "011",
                    Numero = "1234-5678"
                }
            };

            Console.WriteLine("Los datos de la persona creada son:");
            Console.WriteLine("Id Persona: " + persona.Id);
            Console.WriteLine("Nombre y Apellido: " + persona.Nombre + " " + persona.Apellido);
            Console.WriteLine("TelefonoId: " + persona.Telefono.Id);
            Console.WriteLine("Caracteristica: " + persona.Telefono.Caracteristica);
            Console.WriteLine("Numero: " + persona.Telefono.Numero);
        }

        private class BaseClass<TKey>
        {
            public TKey Id { get; set; }
        }

        private class Telefono : BaseClass<Guid>
        {
            public string Caracteristica { get; set; }
            public string Numero { get; set; }
        }

        private class Persona : BaseClass<int>
        {
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public Telefono Telefono { get; set; }
        }
    }
}
