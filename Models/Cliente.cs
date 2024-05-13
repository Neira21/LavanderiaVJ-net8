using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace LavanderiaVJWeb.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe colocar un nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Debe colocar un apellido")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "Debe seleccionar uno")]
        public string TipoDoc { get; set; }

        [Required(ErrorMessage = "Debe ingresar un número de documento")]
        [RegularExpression("(^[0-9]+$)", ErrorMessage = "Solo se permiten números")]
        public string NroDoc { get; set; }

        [Required(ErrorMessage = "Debe ingresar una dirección")]
        public string Direccion { get; set; }
        
        [EmailAddress]
        public string Email { get; set; }

        [ValidateNever]
        public Distrito Distrito { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un distrito")]
        public int DistritoId { get; set; }
    }
}
