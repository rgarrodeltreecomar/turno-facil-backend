namespace Api.ClinicaMedica.DTO.Basic
{
    public class PacientesDTO
    {
        public string IdPaciente { get; set; }
        public string IdPersona { get; set; }
        public bool ObraSocial { get; set; }

        // Relación 1 a 1 con Persona
        public PersonasDTO Persona { get; set; }
    }
}
