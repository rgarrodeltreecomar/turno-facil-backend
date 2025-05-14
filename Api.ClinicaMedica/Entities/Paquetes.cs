using System.ComponentModel.DataAnnotations;

namespace Api.ClinicaMedica.Entities
{
    public class Paquetes
    {
        public string IdConsulta { get; set; }
        public Guid CodigoPaquete { get; set; }
        public decimal PrecioPaquete { get; set; }

        public string? IdMedico { get; set; }
        public string? IdServicio { get; set; }

        public void CalcularPrecio(List<Servicio> servicio)
        {
            decimal precioBase = servicio.Sum(s => s.Precio);
            PrecioPaquete = precioBase * 0.85m;

        }
    }
}
