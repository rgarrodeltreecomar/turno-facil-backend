namespace Api.ClinicaMedica.Entities
{
    public class PaqueteServicio
    {
        public Guid Id { get; set; }
        public Guid CodigoPaquete { get; set; }
        public Paquetes Paquete { get; set; }

        public string IdServicio { get; set; }
        public Servicio Servicio { get; set; }
    }
}
