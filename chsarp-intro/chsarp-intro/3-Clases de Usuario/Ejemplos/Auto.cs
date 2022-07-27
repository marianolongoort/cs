using System;
using System.Collections.Generic;

namespace chsarp_intro._3_Clases_de_Usuario
{
    /// <summary>
    /// Definimos una clase de usuario llamada Auto (las clases y métodos se nomenclan utilizando PascalCase).
    /// </summary>
    public class Auto
    {
        #region Atributos privados

        // La nomenclatura estándar para los atributos internos es camelCase con _ delante.
        private readonly List<Rueda> _ruedas;
        // no podemos hacer asignaciones!! _ruedas = 
        // _ruedas.Add() sí se puede hacer

        #endregion

        #region Constructores

        // constructor sin parámetros que inicializa la lista de Ruedas.
        public Auto()
        {
            _ruedas = new List<Rueda>();
            FechaDeCreacion = DateTime.Now;
        }

        // constructor de sobrecarga con un parámetro
        public Auto(string marca)
            : this() // this() llamará al constructor de la clase que coincida con la firma
        {
            Marca = marca;
        }

        public Auto(string marca, string color) 
            : this(marca)
        {
            Color = color;
        }

        #endregion

        #region Propiedades públicas

        public string Color { get; set; }
        public ushort CantidadDePuertas { get; set; }
        public DateTime FechaDeCreacion { get; }
        public string Marca { get; }
        public IEnumerable<Rueda> Ruedas
        {
            get
            {
                return _ruedas;
            }
        }

        // es análogo a escribir:
        // public IEnumerable<Rueda> Ruedas => _ruedas;

        #endregion

        #region Métodos públicos

        public void AddRueda(Rueda rueda)
        {
            if (rueda == null)
                throw new ArgumentNullException(nameof(rueda));

            if (!EsRuedaValida(rueda))
            {
                throw new InvalidOperationException($"La rueda {nameof(rueda)} no es apta para el auto.");
            }

            _ruedas.Add(rueda);
        }

        #endregion

        #region Métodos privados

        // este es un tipo de método que se puede escribir como una expresión en una línea.
        // es análogo a la escritura normal en bloque con llaves con un return.
        private bool EsRuedaValida(Rueda rueda) => rueda.Rodado <= 200 && rueda.Rodado >= 150;

        #endregion
    }
}
