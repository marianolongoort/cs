using System;

namespace chsarp_intro._7_Extension_Methods
{
    public static class DateTimeExtensions
    {
        public static int ObtenerAnios(this DateTime fecha)
        {
            var anios = DateTime.Today.Year - fecha.Year;
            return fecha > DateTime.Today.AddYears(-anios) ?
                anios - 1 :
                anios;
        }
    }
}
