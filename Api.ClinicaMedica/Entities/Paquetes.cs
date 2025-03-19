using System.ComponentModel.DataAnnotations;

namespace Api.ClinicaMedica.Entities
{
    public class Paquetes
    {
        [Key]
        public string CodigoPaquete { get; set; }
        public string Nombre { get; set; }
        public decimal PrecioPaquete { get; set; }
        public ICollection<PaqueteServicio> PaqueteServicios { get; set; } = new List<PaqueteServicio>();

        public void CalcularPrecio(List<Servicio> servicio)
        {
            decimal precioBase = servicio.Sum(s => s.Precio);
            PrecioPaquete = precioBase * 0.85m;
          
        }
    }
}
