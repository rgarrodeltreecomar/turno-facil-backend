using System.ComponentModel.DataAnnotations;

namespace Api.ClinicaMedica.Models
{
    public class PaqueteServicio
    {
        public int PaqueteId { get; set; }
        public Paquete Paquete { get; set; } = null!;
        public int ServicioId { get; set; }
        public Servicio Servicio { get; set; } = null!;
    }
}
