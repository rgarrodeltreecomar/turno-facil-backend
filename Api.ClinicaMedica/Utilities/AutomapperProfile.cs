using Api.ClinicaMedica.DTOs.Especialidad;
using Api.ClinicaMedica.DTOs.Medico;
using Api.ClinicaMedica.DTOs.Paciente;
using Api.ClinicaMedica.Models;
using AutoMapper;

namespace Api.ClinicaMedica.Utilities
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<EspecialidadGetDTO, Especialidad>();
            CreateMap<EspecialidadCreationDTO, Especialidad>();
            CreateMap<Especialidad, EspecialidadGetDTO>();

            CreateMap<MedicoGetDTO, Medico>();
            CreateMap<Medico, MedicoGetDTO>();

            CreateMap<MedicoCreationDTO, Medico>();
            CreateMap < Medico, MedicoCreationDTO>();

            CreateMap<Medico, MedicoGetDTO>();
            CreateMap<MedicoGetDTO, Medico>();

            CreateMap<MedicoCitaMedicaDTO, Medico>();

            CreateMap<Paciente, PacienteDTO>();
            CreateMap<PacienteDTO, Paciente>();

        }
    }
}
