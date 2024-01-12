using System;
using System.Linq;
using System.Reflection;
using System.Runtime.Versioning;
using chsarp_intro._1_Tipos_de_datos;
using chsarp_intro._2_Administracion_de_codigo;
using chsarp_intro._3_Clases_de_Usuario;
using chsarp_intro._4_Validaciones;
using chsarp_intro._5_Delegates;
using chsarp_intro._6_Colecciones;
using chsarp_intro._7_Extension_Methods;

namespace chsarp_intro
{
    /// <summary>
    /// Este proyecto intenta exponer un roadmap de conceptos básicos a cubrir relacionados con OOP 
    /// utilizando como plataforma dotnet core 3.1 y como lenguaje c# 8.0
    /// 
    /// Los aspectos básicos que se cubren en este proyecto son:
    /// - Tipos
    ///     - Tipos en NET.
    ///         - <see cref="Fechas"/>.
    ///         - <see cref="Numericos"/>.
    ///         - <see cref="Strings"/>.
    ///         - Nulables <see cref="Tipos.Nulables"/>
    ///     - Jerarquía de tipos en NET. <see cref="Tipos.Jerarquia"/>
    ///     - Ref vs Value types.
    ///         - <see cref="Tipos.DeReferencia"/>.
    ///         - <see cref="Tipos.DeValor"/>.
    ///     - Casting <see cref="Tipos.Castings"/>
    ///     - Tipos anónimos <see cref="Tipos.Anonimos"/>
    ///     - Generics <see cref="Generics"/>
    /// - Administración de código
    ///     - Uso de regiones. <see cref="Regiones"/>
    ///     - Espacios de nombres. <see cref="Namespaces"/>
    ///     - Modificadores de acceso. <see cref="ModificadoresDeAcceso"/>
    /// - Clases de usuario
    ///     - Definición y uso de clases de usuario. <see cref="Clases.ClasesDeUsuario"/>
    ///     - Herencia. <see cref="Clases.Herencia"/>
    ///     - Interfaces. <see cref="Interfaces"/>
    /// - Validaciones
    ///     - Manejo de excepciones. <see cref="Excepciones.Manejo"/>
    ///     - Jerarquía de excepciones. <see cref="Excepciones.Jerarquia"/>
    ///     - Validation attributes. <see cref="ValidationAttributes"/>
    /// - Delegates
    ///     - Delegates <see cref="Delegates.Definicion"/> & generic delegates <see cref="Delegates.Genericos"/>.
    ///     - Lambdas <see cref="Delegates.Lambdas"/>.
    /// - Colecciones
    ///     - Arrays. <see cref="Colecciones.Arrays"/>
    ///     - ICollection. <see cref="Colecciones.ICollections"/>
    ///     - List. <see cref="Colecciones.Listas"/>
    ///     - Linq. <see cref="Linq"/>
    /// - Extension methods <see cref="ExtensionMethods"/>
    /// </summary>
    public class Program
    {
        public static void Main()
        {
            ImprimirCreditos();
            Opcion opcion;
            do
            {
                ImprimirMenu();

                int.TryParse(Console.ReadLine(), out int seleccion);

                opcion = seleccion != 0 ?
                            (Opcion)seleccion :
                            Opcion.Salir;

                Console.Clear();
                
                Dispatcher.Execute(opcion);

                if (opcion != Opcion.Salir)
                {
                    Console.WriteLine();
                    Console.WriteLine("Desea ejecutar otra acción? S/N");

                    opcion = char.ToUpper(Console.ReadKey().KeyChar) == 'N' ?
                        Opcion.Salir :
                        opcion;
                }
            }
            while (opcion != Opcion.Salir);
        }

        private static void ImprimirMenu()
        {
            Console.Clear();
            Console.WriteLine(GetTitulo("Menú"));                 
            foreach (var opcion in Enum.GetValues(typeof(Opcion)))
            {
                Console.WriteLine($"{(int)opcion} - {opcion.ToString().Replace("_", " ")}");
            }
            Console.Write(GetFooter("Ingrese la opción deseada: "));
        }

        private static string GetTitulo(string texto)
        {
            char simboloV = '|';
            char simboloH = '-';
            texto = $"{simboloV} {texto} {simboloV}";
            string contenido = GetBar(texto.Length,simboloH) + Environment.NewLine;

            contenido += !string.IsNullOrEmpty(texto) ? texto + Environment.NewLine : string.Empty;
            contenido += GetBar(texto.Length, simboloH);

            return contenido;
        }

        private static string GetFooter(string texto)
        {
            string contenido = GetBar(texto.Length,'-') + Environment.NewLine;
            contenido += !string.IsNullOrEmpty(texto) ? texto + Environment.NewLine : string.Empty;
            return contenido;
        }

        private static string GetSubTitulo(string texto)
        {
            string contenido = GetBar(texto.Length, '-') + Environment.NewLine;
            contenido += texto + Environment.NewLine;
            contenido += GetBar(texto.Length, '-') + Environment.NewLine;
            return contenido;
        }

        private static string GetBar(int largo, char simbolo = '*')
        {
            string barra = string.Empty;

            for (int i = 0; i < largo; i++)
            {
                barra += simbolo.ToString();
            }

            return barra;
        }


        private static void Pausa()
        {
            Console.WriteLine("Presione enter para continuar...");
            Console.ReadLine();
        }

        private static void ImprimirCreditos()
        {
            Console.Clear();
            SetConsoleColor(ConsoleColor.Yellow,ConsoleColor.Black);
            Console.WriteLine(GetTitulo("Creado por Federico Marchese y Mariano Longo"));

            SetConsoleColor(ConsoleColor.Black, ConsoleColor.White);
            Console.WriteLine("Este proyecto intenta exponer un roadmap de conceptos básicos " +
                "de C# a cubrir y relacionados con POO, utilizando como plataforma originalmente " +
                "dotnet core 3.1 y como lenguaje c# 8.0. A medida que avanza la materia, se irá actualizando " +
                "el framework que se irá soportando, para ejecutar siempre la ultima versión con largo plazo de soporte." +
                Environment.NewLine);

            Console.Write("La versión que se está ejecutando en este momento es: ");
            SetConsoleColor(ConsoleColor.Red, ConsoleColor.White);
            Console.WriteLine(GetTargetFrameworkName() +
                Environment.NewLine + Environment.NewLine
                );

            SetConsoleColor(ConsoleColor.Cyan, ConsoleColor.Black);   
            Console.WriteLine(GetSubTitulo("¡¡¡ Importante !!!"));

            SetConsoleColor(ConsoleColor.Black, ConsoleColor.White);
            Console.WriteLine(                
                "Para consumir este proyecto, se debe seguir el orden de las carpetas numeradas, " +
                "leer atentamente la teoría expuesta en fomra de comentarios, poner breakpoints en " +
                "cada línea de su interes, ejecutar la aplicación haciendo debug para comprender " +
                "entrada, salida/resultado en cada caso." + Environment.NewLine
            );
            
            Pausa();
        }
        private static void SetConsoleColor(ConsoleColor fondo, ConsoleColor letra) {
            Console.BackgroundColor = fondo;
            Console.ForegroundColor = letra;
        }
        public static string GetTargetFrameworkName()
        {
            return Assembly
                .GetEntryAssembly()?
                .GetCustomAttribute<TargetFrameworkAttribute>()?
                .FrameworkName;
        }
    }
}
