using System.ComponentModel.DataAnnotations;

namespace Api.ClinicaMedica.Entities
{
    public class Facturacion
    {
        [Key]
        public string IdFactura { get; set; }
        public string IdConsulta { get; set; }
        public DateTime FechaPago { get; set; }
        public string MetodoPago { get; set; }
        public decimal MontoPagado { get; set; }
        public Consultas Consulta { get; set; }
    }
}
