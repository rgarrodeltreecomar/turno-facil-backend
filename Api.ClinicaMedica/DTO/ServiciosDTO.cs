﻿using System.Reflection.Metadata.Ecma335;

namespace Api.ClinicaMedica.DTO

{
    public class ServiciosDTO
    {
        public string IdServicio { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
    }
}
