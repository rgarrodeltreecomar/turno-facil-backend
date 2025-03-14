using Api.ClinicaMedica.DTO.Create;

namespace Api.ClinicaMedica.DTO.Update
{
    public class PacienteUpdateDTO
    {
        public string IdPaciente { get; set; }
        public bool ObraSocial { get; set; }
        public DateTime FechaNacimiento { get; set; }

        // Relaciones
        public UsuarioUpdateDTO? Usuario { get; set; }
    }
}
