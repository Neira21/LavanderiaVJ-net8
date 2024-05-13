using System.ComponentModel.DataAnnotations;

namespace LavanderiaVJWeb.Models
{
    public class Almacen
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Nombre es requerido")]
        public string Nombre { get; set; } = string.Empty;

    }
}
