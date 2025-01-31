using Api.ClinicaMedica.DTOs.Medico;

namespace Api.ClinicaMedica.DTOs.Especialidad
{
    public class EspecialidadGetDTO
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public List<MedicoGetDTO> Medicos { get; set; } = new List<MedicoGetDTO>();
    }
}
