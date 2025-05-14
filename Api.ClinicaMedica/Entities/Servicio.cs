namespace Api.ClinicaMedica.Entities
{
    public class Servicio
    {
        public string IdServicio { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }

        public ICollection<ServiciosMedicos> ServiciosMedicos { get; set; }
    }
}
