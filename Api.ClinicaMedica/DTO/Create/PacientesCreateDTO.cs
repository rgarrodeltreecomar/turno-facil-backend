namespace Api.ClinicaMedica.DTO.Create
{
    public class PacientesCreateDTO
    {
        public string IdPaciente { get; set; }
        public string IdPersona { get; set; }
        public bool ObraSocial { get; set; }
        public PersonasCreateDTO? Persona { get; set; }
    }
}
