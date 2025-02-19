using System.ComponentModel.DataAnnotations;

namespace Api.ClinicaMedica.DTO.Create
{
    public class EspecialidadesCreateDTO
    {
        [Required]
        public string IdEspecialidad { get; set; }
        [Required]
        public string Detalle { get; set; }
    }
}
