using Application.DTOs.Request;
using Application.DTOs.Response;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Commons.Bases.Response;

namespace Application.Mappers
{
    public class RoleMappingsProfile : Profile
    {
        public RoleMappingsProfile()
        {
            CreateMap<Role, RoleResponseDto>()
                .ForMember(x => x.IdRol, x => x.MapFrom(y => y.Id))
                .ReverseMap();

            CreateMap<RoleResponseDto, Role>()
                .ForMember(x => x.Id, x => x.MapFrom(y => y.IdRol))
                .ReverseMap();

            CreateMap<BaseEntityResponse<Role>, BaseEntityResponse<RoleResponseDto>>()
                .ReverseMap();

            CreateMap<RoleRequestDto, Role>()
                .ReverseMap();

            CreateMap<Role, RoleRequestDto>()
                .ReverseMap();

            CreateMap<Role, RoleSelectResponseDto>()
                .ForMember(x => x.IdRol, x => x.MapFrom(y => y.Id))
                .ReverseMap();
        }
    }
}
