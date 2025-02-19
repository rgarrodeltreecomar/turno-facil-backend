namespace Api.ClinicaMedica.DTO.Basic
{
    public class EspecialidadesDTO
    {
        public string IdEspecialidad { get; set; }
        public string Detalle { get; set; }

        // Relación 1 a muchos con Medico
        public ICollection<MedicosDTO> Medicos { get; set; } = new List<MedicosDTO>();
    }
}
