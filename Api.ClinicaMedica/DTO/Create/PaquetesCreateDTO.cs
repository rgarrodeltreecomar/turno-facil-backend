using System.ComponentModel.DataAnnotations.Schema;

namespace Api.ClinicaMedica.DTO.Create
{
    public class PaquetesCreateDTO
    {
        public string? IdConsulta { get; set; }
        public Guid CodigoPaquete { get; set; } = Guid.NewGuid();
        public string? IdMedico {  get; set; }
        public string? IdServicio { get; set; }
        public decimal PrecioPaquete { get; set; }
    }
}
