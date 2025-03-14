using Api.ClinicaMedica.Entities;

namespace Api.ClinicaMedica.DTO.Basic
{
    public class PacientesDTO
    {
        public string IdPaciente { get; set; }
        //public Guid IdUsuario { get; set; }
        public bool ObraSocial { get; set; }

        // Relaciones
        public UsuariosDTO Usuario { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public ICollection<Turnos> Turnos { get; set; } = new List<Turnos>();
    }
}
