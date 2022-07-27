using System.Collections;
using System.Collections.Generic;

namespace chsarp_intro._6_Colecciones
{
    /// <summary>
    /// El uso de ICollection nos obliga a implementar un set de métodos necesarios para el uso de colecciones.
    /// En este caso todas las implementaciones simplementa las delegamos en el tipo List que ya las posee implementadas.
    /// </summary>
    public class ColeccionDeProductos : ICollection<Producto>
    {
        /// <summary>
        /// Internamente uso una lista en este caso, pero la potencia de ICollection 
        /// radica en la abstracción en la implementación que yo utilice aquí.
        /// </summary>
        private readonly List<Producto> _productos;

        public ColeccionDeProductos() => _productos = new List<Producto>();

        #region ICollection Methods

        public int Count => _productos.Count;

        public bool IsReadOnly => false;

        public void Add(Producto item) => _productos.Add(item);

        public void Clear() => _productos.Clear();

        public bool Contains(Producto item) => _productos.Contains(item);

        public void CopyTo(Producto[] array, int arrayIndex) => _productos.CopyTo(array, arrayIndex);

        public IEnumerator<Producto> GetEnumerator() => _productos.GetEnumerator();

        public bool Remove(Producto item) => _productos.Remove(item);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion
    }
}
