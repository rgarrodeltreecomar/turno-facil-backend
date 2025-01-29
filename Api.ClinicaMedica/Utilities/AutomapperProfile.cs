using Api.ClinicaMedica.DTOs;
using Api.ClinicaMedica.Models;
using AutoMapper;

namespace Api.ClinicaMedica.Utilities
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<EspecialidadGetDTO, Especialidad>();
            CreateMap<Especialidad, EspecialidadGetDTO>();

            CreateMap<MedicoEspecialidadGetDTO, Medico>();
            CreateMap<Medico, MedicoEspecialidadGetDTO>();

            CreateMap<MedicoCreationDTO, Medico>();
            //CreateMap<Medico, MedicoCreationDTO();
            //CreateMap<MedicoGetDTO, Medico>();

        }
    }
}
