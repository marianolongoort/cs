using System;

namespace chsarp_intro._1_Tipos_de_datos
{
    public static class Fechas
    {
        /// <summary>
        /// .NET provee una serie de estructuras y mecanismos para representar y operar sobre fechas.
        /// La representación básica de una fecha se hace a través de la estructura <see cref="DateTime"/> y la 
        /// representación básica de tiempo se hace a través de la estructura <see cref="TimeSpan" />.
        /// </summary>
        public static void Ejemplo()
        {
            // Obtener el día y hora actual:
            DateTime ahora = DateTime.Now;
            Console.WriteLine("Ejecutamos DateTime.Now");
            Console.WriteLine($"fecha y hora de hoy: {ahora}");

            // Obtener el día actual ignorando la hora:
            DateTime hoy = DateTime.Today;
            Console.WriteLine("Ejecutamos DateTime.Today");
            Console.WriteLine($"sólo la fecha de hoy: {hoy}");

            // Construir una fecha específica:
            DateTime CuatroDeAgostoDe1993 = new DateTime(1993, 8, 4); // uno de los constructores de DateTime recibe año, mes y día.
            Console.WriteLine("Ejecutamos new DateTime(1993, 8, 4)");
            Console.WriteLine($"fecha específica: {CuatroDeAgostoDe1993}");

            // Obtener la fecha de ayer:
            DateTime ayer = DateTime.Today.AddDays(-1);
            Console.WriteLine("Ejecutamos DateTime.Today.AddDays(-1)");
            Console.WriteLine($"fecha de ayer: {ayer}");

            // Obtener la fecha de mañana
            DateTime maniana = DateTime.Today.AddDays(1);
            Console.WriteLine("Ejecutamos DateTime.Today.AddDays(1)");
            Console.WriteLine($"fecha de mañana: {maniana}");

            // obtener la diferencia en tiempo entre dos fechas:
            TimeSpan resultadoTiempo = maniana - DateTime.Today;
            Console.WriteLine("Ejecutamos maniana - DateTime.Today");
            Console.WriteLine($"La diferencia de tiempo entre esas dos fechas es: {resultadoTiempo}");

            // Componentes de una fecha
            Console.WriteLine("Podemos obtener las componentes de una fecha de la siguiente manera:");
            Console.WriteLine($"Si queremos obtener el año ejecutamos DateTime.Now.Year: {DateTime.Now.Year}");
            Console.WriteLine($"Si queremos obtener el mes ejecutamos DateTime.Now.Month: {DateTime.Now.Month}");
            Console.WriteLine($"Si queremos obtener el día ejecutamos DateTime.Now.Day: {DateTime.Now.Day}");
            Console.WriteLine($"Si queremos obtener el día de la semana de un DateTime podemos ejecutar DateTime.Now.DayOfWeek: {DateTime.Now.DayOfWeek}");

            // Componentes de un TimeSpan
            Console.WriteLine("Podemos obtener los componentes de un TimeSpan de la siguiente forma:");
            Console.WriteLine($"Obtener los días de {nameof(resultadoTiempo)} : {resultadoTiempo.TotalDays} día/s");
            Console.WriteLine($"Obtener las horas de {nameof(resultadoTiempo)} : {resultadoTiempo.TotalHours} hora/s");
            Console.WriteLine($"Obtener los minutos de {nameof(resultadoTiempo)} : {resultadoTiempo.TotalMinutes} minuto/s");
            Console.WriteLine($"Obtener los segundos de {nameof(resultadoTiempo)} : {resultadoTiempo.TotalSeconds} segundo/s");

            // Otro tema importante al momento de utilizar fechas es representarlas como string en el formato en que lo deseamos hacer.
            // el formato se aplica a través del método ToString(Formato) o bien en este caso podemos aplicarlo Fecha:Formato.
            Console.WriteLine($"un formato común para Argentina es {DateTime.Now:dd/MM/yyyy}");
            Console.WriteLine($"DateTime ya nos provee algunos formatos pre armados como {DateTime.Now.ToShortDateString()} o {DateTime.Now.ToLongDateString()}");
            // sin embargo por lo general se aplica un formato custom definido en el sistema de manera uniforme para mostrar las fechas.
            // para más detalles en formas de representar ver aquí: https://docs.microsoft.com/es-es/dotnet/standard/base-types/custom-date-and-time-format-strings
        }
    }
}
