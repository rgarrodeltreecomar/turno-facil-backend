using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.ClinicaMedica.Entities
{
    public class ServiciosMedicos
    {
        
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        public string IdMedico { get; set; }
        public Medicos Medico { get; set; }

        [Required]
        public string IdServicio { get; set; }
        public Servicio Servicio { get; set; }

        public decimal Precio { get; set; }
        
    }


}

