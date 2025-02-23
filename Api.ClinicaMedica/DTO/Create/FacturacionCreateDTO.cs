namespace Api.ClinicaMedica.DTO.Create
{
    public class FacturacionCreateDTO
    {
        public string IdFactura { get; set; }
        public string IdConsulta { get; set; }
        public DateTime FechaPago { get; set; }
        public string MetodoPago { get; set; }
        public decimal MontoPagado { get; set; }
    }
}
