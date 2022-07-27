using System;
using System.ComponentModel.DataAnnotations;

namespace chsarp_intro._4_Validaciones
{
    public static class ValidationAttributes
    {
        public static void Required()
        {
            // No agregamos la property Apellido que está marcada como Required
            var estudiante = new Estudiante
            {
                Nombre = "Juan",
                FechaDeNacimiento = DateTime.Now.AddYears(-24)
            };

            Console.WriteLine($"creamos una instancia de tipo {nameof(Estudiante)} llamada '{nameof(estudiante)}' sin incluir el apellido");
            Console.WriteLine($"La variable tiene la siguiente información: {estudiante}");
            EjecutarValidaciones(estudiante);
        }

        public static void MaxLength()
        {
            // Max length del apellido es de 100 caracteres
            var estudiante = new Estudiante
            {
                Nombre = "Juan",
                Apellido = new string('a', 101),
                FechaDeNacimiento = DateTime.Now.AddYears(-24)
            };

            Console.WriteLine($"creamos una instancia de tipo {nameof(Estudiante)} llamada '{nameof(estudiante)}' con un Apellido de 101 caracteres");
            Console.WriteLine($"La variable tiene la siguiente información: {estudiante}");
            EjecutarValidaciones(estudiante);
        }

        public static void CustomValidationAttributes()
        {
            var estudiante = new Estudiante
            {
                Nombre = "Juan",
                Apellido = "Pérez",
                FechaDeNacimiento = DateTime.Now.AddYears(-17)
            };

            Console.WriteLine($"creamos una instancia de tipo {nameof(Estudiante)} llamada '{nameof(estudiante)}' de 17 años de edad");
            Console.WriteLine($"La variable tiene la siguiente información: {estudiante}");
            EjecutarValidaciones(estudiante);
        }

        public static void ExpresionesRegulares()
        {
            // Las expresiones regulares son cadenas de caracteres para evaluar patrones sobre otras cadenas de caracteres. 
            // De esta forma podemos validar si una cadena se comporta de una forma específica, como por ejemplo en el caso 
            // de Estudiante lo utilizamos para validar que el DNI tenga la forma NN.NNN.NNN siendo N un número entero del 0 al 9
            var estudiante = new Estudiante
            {
                Nombre = "Juan",
                Apellido = "Pérez",
                FechaDeNacimiento = DateTime.Now.AddYears(-24),
                DNI = "32323232" // Dni válido, pero no tiene el formato esperado
            };

            Console.WriteLine($"creamos una instancia de tipo {nameof(Estudiante)} llamada '{nameof(estudiante)}' con el dni mal formateado");
            Console.WriteLine($"La variable tiene la siguiente información: {estudiante}");
            EjecutarValidaciones(estudiante);

            estudiante.DNI = "32.323.232";
            Console.WriteLine("Correjimos el dni con el formato NN.NNN.NNN y ejecutamos nuevamente las validaciones.");
            EjecutarValidaciones(estudiante);
        }

        public static void Range()
        {
            // el Range validator permite establecer mínimo y máximo de valores permitidos para el campo.
            var estudiante = new Estudiante
            {
                Nombre = "Juan",
                Apellido = "Pérez",
                FechaDeNacimiento = DateTime.Now.AddYears(-24),
                Promedio = 11 // establecimos como promedio válido valores entre 0 y 10
            };

            Console.WriteLine($"creamos una instancia de tipo {nameof(Estudiante)} llamada '{nameof(estudiante)}' con el promedio en 11");
            Console.WriteLine($"La variable tiene la siguiente información: {estudiante}");
            EjecutarValidaciones(estudiante);

            estudiante.Promedio = 9.5F;
            Console.WriteLine("Correjimos el promedio asignándole un valor válido y ejecutamos nuevamente las validaciones.");
            EjecutarValidaciones(estudiante);

        }

        private static void EjecutarValidaciones(Estudiante estudiante)
        {
            try
            {
                Console.WriteLine("Aplicamos las validaciones al objeto a través del siguiente llamado: Validator.ValidateObject(estudiante, new ValidationContext(estudiante));");
                // Notar que este llamado explícito a las validaciones no va a ser necesario cuando utilicemos mvc.
                Validator.ValidateObject(estudiante, new ValidationContext(estudiante), true);
                Console.WriteLine("No se encontraron errores de validaciones");
            }
            catch (ValidationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
