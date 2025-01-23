using Api.ClinicaMedica.Models;
using System.ComponentModel.DataAnnotations;

namespace Api.ClinicaMedica.DTOs
{
    public class ServicioCreationDTO
    {

        public string CodigoServicio { get; set; } = null!;
        public List<TurnoCreationDTO> servicios { get; set; } = new List<TurnoCreationDTO>();
        public List<PaqueteCreationDTO> paquetes { get; set; } = new List<PaqueteCreationDTO>();
        public string Nombre { get; set; } = null!;
        public decimal Precio { get; set; }
    }
}
