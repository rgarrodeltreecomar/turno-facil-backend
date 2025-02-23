using System.ComponentModel.DataAnnotations;

namespace Api.ClinicaMedica.DTO.Create
{
    public class DetalleServicioCreacionDTO
    {
        [Required]
        public string IdCitas { get; set; }
        [Required]
        public string IdServicio { get; set; }
        public decimal? MontoParcial { get; set; }
    }
}
