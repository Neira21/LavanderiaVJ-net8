using System.ComponentModel.DataAnnotations;
using LavanderiaVJWeb.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace LavanderiaVJWeb.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public int TkNroBoleta { get; set; }

        [DataType(DataType.Date)]
        public DateTime TkFechaIngreso { get; set; }

        //Fecha tentativa de entrega
        public DateTime? TkFechaEntrega { get; set; }

        [ValidateNever]
        public List<Servicio> Servicios { get; set; }

        //Para acceder a cliente
        [ValidateNever]
        public Cliente Cliente { get; set; }
        public int ClienteId { get; set; }

        //Para acceder a Almacen
        [ValidateNever]
        public Almacen Almacen { get; set; }
        public int AlmacenId { get; set; }

        //Estado del ticket
        [ValidateNever]
        public Estado Estado { get; set; }
        public int EstadoId { get; set; }

        public double? TkPagoTotal { get; set; }
    }
}
