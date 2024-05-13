using System.ComponentModel.DataAnnotations;

namespace LavanderiaVJWeb.Models
{
    public class ServiciosDisponibles
    {
        public int Id { get; set; }

        // poner validacion de required
        [Required(ErrorMessage = "Debe colocar un nombre para el servicio")]
        public string NombreSer { get; set; }
    }
}
