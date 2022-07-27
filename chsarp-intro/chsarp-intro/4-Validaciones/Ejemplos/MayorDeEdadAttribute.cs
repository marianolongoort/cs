using System;
using System.ComponentModel.DataAnnotations;

namespace chsarp_intro._4_Validaciones
{
    public class MayorDeEdadAttribute : ValidationAttribute
    {
        private readonly int _mayorDe;

        public MayorDeEdadAttribute(int mayorDe)
        {
            _mayorDe = mayorDe;
            ErrorMessage = "Debe ser mayor de {0} años.";
        }

        public override bool IsValid(object value)
        {
            if (value is DateTime fecha)
            {
                var anios = DateTime.Today.Year - fecha.Year;

                anios = fecha > DateTime.Today.AddYears(-anios) ? // Todavía no cumplió años?
                    anios - 1 : // si no cumplió años restamos este año ya que aún no cumplió
                    anios;

                // la ternaria anterior es análoga a escribir el siguiente if
                
                // if (fecha > DateTime.Today.AddYears(-anios))
                // {
                //     anios -= 1;
                // }

                return anios >= _mayorDe;
            }
            return false;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(ErrorMessageString, _mayorDe);
        }
    }
}
