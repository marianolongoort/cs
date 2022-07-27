using System;

namespace chsarp_intro._6_Colecciones
{
    public class Producto
    {
        #region Constructores

        public Producto()
        {
        }

        public Producto(Guid codigo, string nombre)
            : this() // ejecutará el constructor sin parámetros antes
        {
            Codigo = codigo;
            Nombre = nombre;
        }

        public Producto(Guid codigo, string nombre, int orden, decimal precio) 
            : this(codigo, nombre) // ejecutará el constructor de 2 parámetros antes.
        {
            Orden = orden;
            Precio = precio;
        }

        #endregion

        public Guid Codigo { get; set; }
        public string Nombre { get; set; }
        public int Orden { get; set; }
        public decimal Precio { get; set; }

        public override string ToString() => $"Código: {Codigo} | Nombre: {Nombre} | Orden: {Orden} | Precio: ${Precio:N2}";
    }
}
