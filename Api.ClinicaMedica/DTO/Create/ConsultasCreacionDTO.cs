namespace Api.ClinicaMedica.DTO.Create
{
    public class ConsultasCreacionDTO
    {
        public string IdConsulta { get; set; }
        public DateTime FechaConsulta { get; set; }
        public TimeSpan HoraConsulta { get; set; }
        public string IdPaciente { get; set; }
        public bool ObraSocial { get; set; }
        public List<PaquetesCreateDTO> Paquetes { get; set; } // IDs de servicios seleccionados
    }
}
