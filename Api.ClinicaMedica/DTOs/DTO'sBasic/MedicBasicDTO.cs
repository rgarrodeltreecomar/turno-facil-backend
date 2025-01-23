using Api.ClinicaMedica.Models;
using System.ComponentModel.DataAnnotations;

namespace Api.ClinicaMedica.DTOs
{
    public class MedicBasicDTO
    {
        public UsuarioBasicDTO medico { get; set; } = null!;
        public EspecialidadCreationDTO especialidad { get; set; } = null!;
        public bool Activo { get; set; }



    }
}
