using Api.ClinicaMedica.Entities;

namespace Api.ClinicaMedica.DTO.Basic
{
    public class ServiciosMedicosDTO
    {
        public string IdServicio { get; set; }

        public string NombreServicio { get; set; }
        public string IdMedico { get; set; }
        public string NombreMedico { get; set; }

        public decimal Precio { get; set; }
    }
}
