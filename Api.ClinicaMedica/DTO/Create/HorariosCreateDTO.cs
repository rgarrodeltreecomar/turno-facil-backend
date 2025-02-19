namespace Api.ClinicaMedica.DTO.Create
{
    public class HorariosCreateDTO
    {
        public string IdHorario { get; set; }

        public TimeSpan HorarioInicio { get; set; }

        public TimeSpan HorarioFin { get; set; }
    }
}
