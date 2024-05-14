using Application.DTOs.Request;
using Application.DTOs.Response;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Commons.Bases.Response;

namespace Application.Mappers
{
    public class ModulesMappingsProfile : Profile
    {
        public ModulesMappingsProfile()
        {
            CreateMap<Modulo, ModuleResponseDto>()
                .ForMember(x => x.IdModulo, x => x.MapFrom(y => y.Id))
                .ReverseMap();

            CreateMap<ModuleResponseDto, Modulo>()
                .ForMember(x => x.Id, x => x.MapFrom(y => y.IdModulo))
                .ReverseMap();

            CreateMap<BaseEntityResponse<Modulo>, BaseEntityResponse<ModuleResponseDto>>()
                    .ReverseMap();

            CreateMap<ModuleRequestDto, Modulo>()
                    .ReverseMap();

            CreateMap<Modulo, ModuleRequestDto>()
                    .ReverseMap();

            CreateMap<Modulo, ModuleSelectResponseDto>()
                    .ForMember(x => x.IdModulo, x => x.MapFrom(y => y.Id))
                    .ReverseMap();
        }
    }
}
