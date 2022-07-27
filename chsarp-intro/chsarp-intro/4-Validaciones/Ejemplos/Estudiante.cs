using System;
using System.ComponentModel.DataAnnotations;

namespace chsarp_intro._4_Validaciones
{
    public class Estudiante
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [RegularExpression(@"[a-zA-Z áéíóú]*", ErrorMessage = "El nombre admite sólo caracteres alfabéticos")]
        [MaxLength(100, ErrorMessage = "El campo {0} admite un máximo de {1} caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")] 
        [MaxLength(100, ErrorMessage = "El campo {0} admite un máximo de {1} caracteres")]
        public string Apellido { get; set; }

        [RegularExpression(@"[0-9]{2}\.[0-9]{3}\.[0-9]{3}", ErrorMessage = "El dni debe tener un formato NN.NNN.NNN")]
        public string DNI { get; set; }

        [MayorDeEdad(18)]
        public DateTime FechaDeNacimiento { get; set; }

        [Range(0, 10, ErrorMessage = "El {0} se debe encontrar entre {1} y {2}")]
        public float Promedio { get; set; }

        public override string ToString() => $"Nombre: {Nombre} | Apellido: {Apellido} | FechaDeNacimiento: {FechaDeNacimiento:dd-MM-yyyy} | DNI: {DNI} | Promedio: {Promedio:N2}";
    }
}
