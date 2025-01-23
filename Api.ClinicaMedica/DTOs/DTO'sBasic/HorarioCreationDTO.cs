using Api.ClinicaMedica.Models;

namespace Api.ClinicaMedica.DTOs
{
    public class HorarioCreationDTO
    {
        public List<Medico> medicos { get; set; } = new List<Medico>();
        public DateTime Dia { get; set; }
        public bool Activo { get; set; }
    }
}
