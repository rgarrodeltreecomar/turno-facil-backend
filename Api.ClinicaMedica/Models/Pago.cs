using Microsoft.Extensions.Options;

namespace Api.ClinicaMedica.Models
{
    public class Pago
    {
        public int Id { get; set; }
        public int consultaId { get; set; }
        public int TipoPago { get; set; }
        public DateTime FechaPago { get; set; }
        public decimal Valor { get; set; }
    }
}
