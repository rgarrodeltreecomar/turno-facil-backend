﻿using Api.ClinicaMedica.DTO.Basic;
using Api.ClinicaMedica.DTO.Create;
using Api.ClinicaMedica.Entities;
using Api.ClinicaMedica.Models;
using AutoMapper;

namespace Api.ClinicaMedica.Utilities
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            // Pacientes
            CreateMap<Pacientes, PacientesDTO>().ReverseMap();
            CreateMap<Pacientes, PacientesCreateDTO>().ReverseMap();

            // Personas
            CreateMap<Personas, PersonasDTO>().ReverseMap();
            CreateMap<Personas, PersonasCreateDTO>().ReverseMap();

            // Especialidades
            CreateMap<Especialidades, EspecialidadesCreateDTO>().ReverseMap();
            CreateMap<Especialidades, EspecialidadesDTO>().ReverseMap();

            // Horarios
            CreateMap<Horarios, HorariosCreateDTO>().ReverseMap();  

            // Medicos
            CreateMap<Medicos, MedicosCreateDTO>().ReverseMap();
            CreateMap<Medicos, MedicosDTO>().ReverseMap();

        }
    }
}
