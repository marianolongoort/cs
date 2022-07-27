namespace chsarp_intro._2_Administracion_de_codigo
{
    /// <summary>
    /// Todos los tipos y miembros de tipo tienen un nivel de accesibilidad. 
    /// El nivel de accesibilidad controla si se pueden usar desde otro código del ensamblado u otros ensamblados. 
    /// Más información aquí: https://docs.microsoft.com/es-es/dotnet/csharp/programming-guide/classes-and-structs/access-modifiers
    /// </summary>
    public class ModificadoresDeAcceso
    {
        /// <summary>
        /// puede obtener acceso al tipo o miembro cualquier otro código que haga referencia a éste.
        /// </summary>
        public string _seraPublico = "soy public";

        /// <summary>
        /// puede obtener acceso al tipo o miembro cualquier código del mismo ensamblado, pero no de un ensamblado distinto.
        /// </summary>
        internal string _seraInterno = "soy internal";

        /// <summary>
        /// solamente el código de la misma class, o bien de una clase derivada de esa clase, puede acceder.
        /// </summary>
        protected string _seraProtected = "soy protected";

        /// <summary>
        /// solamente el código de la misma class o struct puede acceder al tipo o miembro.
        /// </summary>
        private string _seraPrivado = "soy private";
    }
}
