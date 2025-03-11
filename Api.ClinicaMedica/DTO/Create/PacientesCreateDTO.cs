using Api.ClinicaMedica.Entities;

namespace Api.ClinicaMedica.DTO.Create
{
    public class PacientesCreateDTO
    {
        public string IdPaciente { get; set; }
        public string IdUsuario { get; set; }
        public bool ObraSocial { get; set; }
        public DateTime FechaNacimiento { get; set; }

        // Relaciones
        public UsuariosCreateDTO? Usuario { get; set; }
    }
}
