﻿using Api.ClinicaMedica.Entities;

namespace Api.ClinicaMedica.DTO.Basic
{
    public class PacientesDTO
    {
        public string IdPaciente { get; set; }
        public string IdUsuario { get; set; }
        public bool ObraSocial { get; set; }

        // Relaciones
        public Usuarios Usuario { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public ICollection<Turnos> Turnos { get; set; } = new List<Turnos>();
    }
}
