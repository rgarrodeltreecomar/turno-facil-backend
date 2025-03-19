using System.ComponentModel.DataAnnotations;

namespace Api.ClinicaMedica.Entities
{
    public class PaqueteServicio
    {
        [Key]
        public Guid Id { get; set; }
        public string IdPaciente { get; set; }
        public string CodigoPaquete { get; set; }
        public string CodigoServicio { get; set; }
        public Paquetes Paquete { get; set; }
        public Servicio Servicio { get; set; }
    }
}
