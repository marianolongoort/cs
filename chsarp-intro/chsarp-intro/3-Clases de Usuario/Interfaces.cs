using System;
using System.Collections.Generic;

namespace chsarp_intro._3_Clases_de_Usuario
{
    public static class Interfaces
    {
        /// <summary>
        /// Una interfaz es simplemente un contrato que define qué debe implementar la clase que implemente dicha interfaz.
        /// En palabras sencillas podemos decir que una interfaz es una lista de cosas que debe hacer quien la implemente, pero que ella desconoce el cómo se harán.
        /// Para ejemplificación utilizaremos la interfaz <see cref="ICuenta"/> y las clases <see cref="CuentaCorriente"/> y <see cref="CajaDeAhorro"/>.
        /// para más información ver: https://docs.microsoft.com/es-es/dotnet/csharp/programming-guide/interfaces/
        /// </summary>
        public static void Ejemplo()
        {
            // Declaramos una variable de tipo Lista de ICuenta
            var cuentas = new List<ICuenta>
            {
                new CuentaCorriente(),
                new CajaDeAhorro(),
                new CuentaCorriente(),
                new CajaDeAhorro()
            };

            Console.WriteLine($"Declaramos una nueva variable {nameof(cuentas)} que es una colección de {nameof(ICuenta)}");
            Console.WriteLine("Adicionamos 4 elementos a la colección: 2 cajas de ahorro y 2 cuentas corrientes.");

            Console.WriteLine("Depositamos $100 en cada una de las cuentas indistintamente de si se trata de caja de ahorro o cuenta corriente");
            foreach(ICuenta cuenta in cuentas)
                cuenta.Depositar(100M);

            Console.WriteLine("Extraemos $50 en cada una de las cuentas indistintamente de si se trata de caja de ahorro o cuenta corriente");
            foreach (ICuenta cuenta in cuentas)
                cuenta.Extraer(50M);

            Console.WriteLine("Depositamos $30 en cada una de las cajas de ahorro y $50 en cada una de las cuentas corrientes");
            foreach (ICuenta cuenta in cuentas)
            {
                if (cuenta is CajaDeAhorro)
                    cuenta.Depositar(30M);

                if (cuenta is CuentaCorriente)
                    cuenta.Depositar(50M);
            }

            Console.WriteLine("Obtenemos el balance de cada una de las cuentas indistintamente de si se trata de caja de ahorro o cuenta corriente");
            foreach (ICuenta cuenta in cuentas)
                Console.WriteLine(cuenta.GetBalance());
        }
    }
}
