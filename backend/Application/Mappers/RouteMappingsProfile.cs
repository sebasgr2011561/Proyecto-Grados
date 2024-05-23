using Application.DTOs.Request;
using Application.DTOs.Response;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Commons.Bases.Response;

namespace Application.Mappers
{
    public class RouteMappingsProfile : Profile
    {
        public RouteMappingsProfile()
        {
            CreateMap<Ruta, RouteResponseDto>()
                .ForMember(x => x.IdRoute, x => x.MapFrom(y => y.Id))
                .ReverseMap();

            CreateMap<RouteResponseDto, Ruta>()
                .ForMember(x => x.Id, x => x.MapFrom(y => y.IdRoute))
                    .ReverseMap();

            CreateMap<BaseEntityResponse<Ruta>, BaseEntityResponse<RouteResponseDto>>()
                    .ReverseMap();

            CreateMap<RouteRequestDto, Ruta>()
                    .ReverseMap();

            CreateMap<Ruta, RouteRequestDto>()
                    .ReverseMap();

            CreateMap<Ruta, RouteSelectResponseDto>()
                    .ForMember(x => x.IdRoute, x => x.MapFrom(y => y.Id))
                    .ReverseMap();
        }
    }
}
