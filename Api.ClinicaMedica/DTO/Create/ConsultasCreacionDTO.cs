namespace Api.ClinicaMedica.DTO.Create
{
    public class ConsultasCreacionDTO
    {
        public DateTime FechaConsulta { get; set; }
        public TimeSpan HoraConsulta { get; set; }
        public string IdPaciente { get; set; }
        public string IdMedico { get; set; }
        public bool ObraSocial { get; set; }
        public List<string> ServiciosId { get; set; } // IDs de servicios seleccionados
    }
}
