using AutoMapper;
using DoctorApp.Services.Models.DTOs;
using DoctorApp.Services.Models.Entidades;

namespace DoctorApp.Services.Utilidades
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Especialidad, EspecialidadDto>()
                .ForMember(d => d.Estado, m => m.MapFrom(o => o.Estado == true ? 1 : 0));
        }
    }
}
