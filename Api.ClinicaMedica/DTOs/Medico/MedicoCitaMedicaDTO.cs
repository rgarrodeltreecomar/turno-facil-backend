using Api.ClinicaMedica.DTOs.Especialidad;
using Api.ClinicaMedica.Models;

namespace Api.ClinicaMedica.DTOs.Medico
{
    public class MedicoCitaMedicaDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        EspecialidadCreationDTO Especialidad { get; set; }
    }
}
