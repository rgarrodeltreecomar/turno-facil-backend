<<<<<<< HEAD
﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
=======
﻿using Api.ClinicaMedica.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
>>>>>>> 2977e3be1c7caaeec82cd2288bfd4a38816cf144

namespace Api.ClinicaMedica.Models
{
    public class Paquete
    {
<<<<<<< HEAD
      
=======
        [Key]
>>>>>>> 2977e3be1c7caaeec82cd2288bfd4a38816cf144
        public int Id { get; set; }
        public decimal Precio { get; set; }
        public ICollection<PaqueteServicio> Servicios { get; set; } = new List<PaqueteServicio>();
        public ICollection<CitaMedica> CitaMedica { get; set; } = new List<CitaMedica>();
    }
}