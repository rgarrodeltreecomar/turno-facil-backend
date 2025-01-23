using System.ComponentModel.DataAnnotations;

namespace Api.ClinicaMedica.Models
{
    public class Servicio
    {
        [Key]
        public int Id { get; set; }
        public string CodigoServicio { get; set; } = null!;
        public List<Turno> servicios { get; set; } = new List<Turno>();
        public List<Paquete> paquetes { get; set; } = new List<Paquete>();
        public string Nombre { get; set; } = null!;
        public decimal Precio { get; set; }
    }
}
