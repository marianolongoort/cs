using chsarp_intro._1_Tipos_de_datos;
using chsarp_intro._3_Clases_de_Usuario;
using chsarp_intro._4_Validaciones;
using chsarp_intro._5_Delegates;
using chsarp_intro._6_Colecciones;
using chsarp_intro._7_Extension_Methods;
using System;
using System.Collections.Generic;

namespace chsarp_intro
{
    public static class Dispatcher
    {
        private static readonly IDictionary<Opcion, Action> _acciones = new Dictionary<Opcion, Action>
        {
            { Opcion.Tipos_de_valor, Tipos.DeValor },
            { Opcion.Tipos_de_referencia, Tipos.DeReferencia },
            { Opcion.Jerarquia_de_tipos, Tipos.Jerarquia },
            { Opcion.Nulables, Tipos.Nulables },
            { Opcion.Enteros, Numericos.Enteros },
            { Opcion.Decimales, Numericos.Decimales },
            { Opcion.Fechas, Fechas.Ejemplo },
            { Opcion.Tipos_anonimos, Tipos.Anonimos },
            { Opcion.Genericos, Generics.Genericos },
            { Opcion.Clases_de_usuario, Clases.ClasesDeUsuario },
            { Opcion.Interfaces, Interfaces.Ejemplo },
            { Opcion.Metodos_del_tipo_object, Clases.MetodosDelTipoObject },
            { Opcion.Strings_definicion, Strings.Definicion },
            { Opcion.Strings_funciones_comunes, Strings.FuncionesComunes },
            { Opcion.Casting, Tipos.Castings },
            { Opcion.Manejo_de_excepciones, Excepciones.Manejo },
            { Opcion.Jerarquia_de_excepciones, Excepciones.Jerarquia },
            { Opcion.Arrays, Colecciones.Arrays },
            { Opcion.ICollections, Colecciones.ICollections },
            { Opcion.Listas, Colecciones.Listas },
            { Opcion.Validation_attribute_Required, ValidationAttributes.Required },
            { Opcion.Validation_attribute_MaxLength, ValidationAttributes.MaxLength },
            { Opcion.Validation_attribute_RegularExpressions, ValidationAttributes.ExpresionesRegulares },
            { Opcion.Validation_attribute_Custom, ValidationAttributes.CustomValidationAttributes },
            { Opcion.Validation_attribute_Range, ValidationAttributes.Range },
            { Opcion.Delegates, Delegates.Definicion },
            { Opcion.Delegates_Genericos, Delegates.Genericos },
            { Opcion.Lambdas, Delegates.Lambdas },
            { Opcion.Linq_Consultas, Linq.Consultas },
            { Opcion.Linq_Where, Linq.Where },
            { Opcion.Linq_Ordering, Linq.Ordering },
            { Opcion.Linq_Select, Linq.Select },
            { Opcion.Extension_Methods, ExtensionMethods.Definicion },
            { Opcion.Herencia, Clases.Herencia },
        };

        public static void Execute(Opcion opcion)
        {
            _acciones.TryGetValue(opcion, out Action action);
            action?.Invoke();
        }
    }
}
