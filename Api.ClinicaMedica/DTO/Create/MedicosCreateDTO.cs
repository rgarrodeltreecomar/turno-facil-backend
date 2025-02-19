using System.ComponentModel.DataAnnotations;

namespace Api.ClinicaMedica.DTO.Create
{
    public class MedicosCreateDTO
    {
        [Required]
        public string IdMedico { get; set; }
        public string IdPersona { get; set; }
        public string IdEspecialidad { get; set; }
        public decimal? Sueldo { get; set; }

        public PersonasCreateDTO Persona { get; set; }
    }
}
