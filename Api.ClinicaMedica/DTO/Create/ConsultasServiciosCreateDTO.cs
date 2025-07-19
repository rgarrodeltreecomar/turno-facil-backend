using System.ComponentModel.DataAnnotations;
namespace Api.ClinicaMedica.DTO.Create
{
    public class ConsultasServiciosCreateDTO
    {
        public class ConsultasServicioCreateDTO
        {
            [Required]
            public string IdServicio { get; set; }

            public decimal? Precio { get; set; }
        }
    }
}
