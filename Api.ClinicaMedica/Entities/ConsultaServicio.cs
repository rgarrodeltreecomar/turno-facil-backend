using System.ComponentModel.DataAnnotations;

namespace Api.ClinicaMedica.Entities
{
    public class ConsultaServicio
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public string IdConsulta { get; set; }
        public Consultas Consulta { get; set; }

        [Required]
        [MaxLength(50)]
        public string IdServicio { get; set; }
        public Servicio Servicio { get; set; }

        public decimal Precio { get; set; }
    }
}
