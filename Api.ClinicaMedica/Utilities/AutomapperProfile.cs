﻿using Api.ClinicaMedica.DTO.Basic;
using Api.ClinicaMedica.DTO.Create;
using Api.ClinicaMedica.DTO.Put;
using Api.ClinicaMedica.DTO.Update;
using Api.ClinicaMedica.Entities;
using Api.ClinicaMedica.Models;
using AutoMapper;

namespace Api.ClinicaMedica.Utilities
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            // Usuarios
            CreateMap<UsuariosCreateDTO, Usuarios>()
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore());

            CreateMap<Usuarios, UsuariosDTO>().ReverseMap();

            // Pacientes
            CreateMap<Pacientes, PacientesDTO>().ReverseMap();

            CreateMap<Pacientes, PacientesCreateDTO>().ReverseMap()
                .ForMember(dest => dest.Usuario, opt => opt.MapFrom(src => src.Usuario));

            // Especialidades
            CreateMap<Especialidades, EspecialidadesCreateDTO>().ReverseMap();
            CreateMap<Especialidades, EspecialidadesDTO>().ReverseMap();

            // Horarios
            CreateMap<Horarios, HorariosCreateDTO>().ReverseMap();

            // Medicos
            CreateMap<Medicos, MedicosCreateDTO>().ReverseMap();
            CreateMap<Medicos, MedicosDTO>().ReverseMap();
            CreateMap<Medicos, MedicosPutDTO>().ReverseMap();

            // Consultas
            CreateMap<Consultas, ConsultasDTO>().ReverseMap();
            CreateMap<Consultas, ConsultasCreacionDTO>().ReverseMap();

            // Paquetes
            CreateMap<Paquetes, PaquetesCreateDTO>().ReverseMap();

            // Facturacion
            CreateMap<Facturacion, FacturacionCreateDTO>().ReverseMap();

            // Registered View Model
            CreateMap<RegisteredViewModel, Usuarios>().ReverseMap();
            CreateMap<RegisteredViewModel, Pacientes>().ReverseMap();
            CreateMap<RegisteredViewModel, Medicos>().ReverseMap();

            // Update Pacientes
            CreateMap<UsuarioUpdateDTO, Usuarios>().ReverseMap();
            CreateMap<PacienteUpdateDTO, Pacientes>().ReverseMap();

            // Servicios
            CreateMap<Servicio, ServiciosCreateDTO>().ReverseMap();

        }
    }
}
