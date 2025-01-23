namespace Api.ClinicaMedica.Models
{
    public class Paquete
    {
        public int Id { get; set; }
        public List<Servicio> servicios { get; set; } = new List<Servicio>();
        public decimal Precio { get; set; }
    }
}
