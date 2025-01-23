using Api.ClinicaMedica.Models;
using System.ComponentModel.DataAnnotations;

namespace Api.ClinicaMedica.DTOs
{
    public class PacienteCreationDTO
    {

        public UsuarioBasicDTO paciente { get; set; } = null!;
        public bool ObraSocial { get; set; }
        public bool Activo { get; set; }
    }
}
