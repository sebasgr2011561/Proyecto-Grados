using Application.DTOs.Request;
using Application.DTOs.Response;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Commons.Bases.Response;
using Utilities.Static;

namespace Application.Mappers
{
    public class CourseMappingsProfile : Profile
    {
        public CourseMappingsProfile()
        {
            CreateMap<Recurso, CourseResponseDto>()
                .ForMember(x => x.IdRecurso, x => x.MapFrom(y => y.Id))
                .ForMember(x => x.Estado, x => x.MapFrom(y => y.Estado == Convert.ToBoolean(StateTypes.Active) ? "Activo" : "Inactivo"))
                .ReverseMap();

            CreateMap<CourseResponseDto, Recurso>()
                .ForMember(x => x.Id, x => x.MapFrom(y => y.IdRecurso))
                .ForMember(x => x.Estado, x => x.MapFrom(y => y.Estado == Convert.ToBoolean(StateTypes.Active) ? "Activo" : "Inactivo"))
                .ReverseMap();

            CreateMap<BaseEntityResponse<Recurso>, BaseEntityResponse<CourseResponseDto>>()
                .ReverseMap();

            CreateMap<CourseRequestDto, Recurso>()
                .ReverseMap();

            //CreateMap<Recurso, CourseRequestDto>()
            //    .ForMember(x => x.IdRecurso, x => x.MapFrom(y => y.Id))
            //    .ReverseMap();

            CreateMap<Recurso, CourseSelectResponseDto>()
                .ForMember(x => x.IdRecurso, x => x.MapFrom(y => y.Id))
                .ReverseMap();
        }
    }
}
