using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace LavanderiaVJWeb.Models
{
    public class Servicio
    {
        public int Id { get; set; }
        [ValidateNever]
        public ServiciosDisponibles serviciosDisponibles { get; set; }
        public int serviciosDisponiblesId { get; set; }
        
        [ValidateNever]
        public Ticket ticket { get; set; }
        public int TicketId { get; set; }
            
        public string DescServicio { get; set; }
        public double PrecServicio { get; set; }
        
    }
}
