using Api.ClinicaMedica.DTOs;
using Api.ClinicaMedica.Models;
using AutoMapper;

namespace Api.ClinicaMedica.Utilities
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<EspecialidadCreationDTO, Especialidad>();
            CreateMap<HorarioCreationDTO, Horario>();
            CreateMap<MedicBasicDTO, Medico>();

            CreateMap<PacienteCreationDTO, Paciente>();
            CreateMap<PaqueteCreationDTO, Paquete>();
            CreateMap<ServicioCreationDTO, Servicio>();
            CreateMap<TurnoCreationDTO, Turno>();
            CreateMap<UsuarioBasicDTO, Usuario>();

        }
    }
}
