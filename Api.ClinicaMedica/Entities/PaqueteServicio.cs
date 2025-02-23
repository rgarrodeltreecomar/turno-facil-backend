using System.ComponentModel.DataAnnotations;

namespace Api.ClinicaMedica.Entities
{
    public class PaqueteServicio
    {
        [Key]
        public string Id { get; set; }
        public string CodigoPaquete { get; set; }
        public string CodigoServicio { get; set; }
        public Paquetes Paquete { get; set; }
        public Servicios Servicio { get; set; }
    }
}
