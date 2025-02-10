using System.ComponentModel.DataAnnotations;

namespace Api.ClinicaMedica.Models
{
    public class PaqueteServicio
    {
        public Guid PaqueteId { get; set; }
        public Paquete Paquete { get; set; } = null!;
        public Guid ServicioId { get; set; }
        public Servicio Servicio { get; set; } = null!;
    }
}
