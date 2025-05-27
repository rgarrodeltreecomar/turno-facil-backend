namespace Api.ClinicaMedica.DTO.Create
{
    public class ConsultaRespuestaDTO
    {
        public string IdConsulta { get; set; }
        public DateTime FechaConsulta { get; set; }
        public TimeSpan HoraConsulta { get; set; }
        public string? IdPaciente { get; set; }
        public string? NombrePaciente { get; set; }
        public string IdMedico { get; set; }
        public string NombreMedico { get; set; }
        public bool ObraSocial { get; set; }
        public decimal MontoTotal { get; set; }
        public bool Pagado { get; set; }
        public List<ConsultaServicioRespuestaDTO> ConsultaServicios { get; set; } = new();
    }

    public class ConsultaServicioRespuestaDTO
    {
        public string IdServicio { get; set; }
        public decimal Precio { get; set; }
    }
}
