using Api.ClinicaMedica.Models;

namespace Api.ClinicaMedica.DTOs
{
    public class PaqueteCreationDTO
    {
        public List<ServicioCreationDTO> servicios { get; set; } = new List<ServicioCreationDTO>();
        public decimal Precio { get; set; }
    }
}
