using Api.ClinicaMedica.DTO.Basic;
using Api.ClinicaMedica.DTO.Create;
using Api.ClinicaMedica.DTO.Put;
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

            // Citas Medicas
            CreateMap<CitasMedicas,CitasMedicasCreacionDTO>().ReverseMap();

            // DetalleCitas
            CreateMap<DetalleServicios, DetalleServicioCreacionDTO>().ReverseMap();
            CreateMap<DetalleServicios, DetalleServicioCreacionDTO>().ReverseMap();

            // Consultas
            CreateMap<Consultas,ConsultasDTO>().ReverseMap();
            CreateMap<Consultas,ConsultasCreateDTO>().ReverseMap();

            // Paquetes
            CreateMap<Paquetes, PaquetesCreateDTO>().ReverseMap();
            

            // PaquetesServicios
            CreateMap<PaqueteServicio,PaqueteServicioCreateDTO>().ReverseMap();

            // Facturacion
            CreateMap<Facturacion, FacturacionCreateDTO>().ReverseMap();

            // Registered View Model
            CreateMap<RegisteredViewModel, Usuarios>().ReverseMap();
            CreateMap<RegisteredViewModel, Pacientes>().ReverseMap();
            CreateMap<RegisteredViewModel, Medicos>().ReverseMap();

        }
    }
}
