using Api.ClinicaMedica.Entities;

namespace Api.ClinicaMedica.DTO.Basic
{
    public class DetalleServiciosDTO
    {
        public string IdCitas { get; set; }
        public string IdServicio { get; set; }
        public decimal MontoParcial { get; set; }

        // Propiedades de navegacion
        public CitasMedicas? CitaMedica { get; set; }
        public Servicios? Servicio { get; set; }
    }
}
