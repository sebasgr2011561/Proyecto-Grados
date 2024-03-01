using Application.DTOs.Request;
using Application.DTOs.Response;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Commons.Bases.Response;
using Utilities.Static;

namespace Application.Mappers
{
    public class UserMappingsProfile : Profile
    {
        public UserMappingsProfile()
        {
            CreateMap<Usuario, UserResponseDto>()
                .ForMember(x => x.IdUsuario, x => x.MapFrom(y => y.Id))
                .ReverseMap();

            CreateMap<UserResponseDto, Usuario>()
                .ForMember(x => x.Id, x => x.MapFrom(y => y.IdUsuario))
                .ReverseMap();

            CreateMap<BaseEntityResponse<Usuario>, BaseEntityResponse<UserResponseDto>>()
                .ReverseMap();

            CreateMap<UserRequestDto, Usuario>()
                .ReverseMap();

            CreateMap<Usuario, UserRequestDto>()
                .ForMember(x => x.IdUsuario, x => x.MapFrom(y => y.Id))
                .ReverseMap();

            CreateMap<Usuario, UserSelectResponseDto>()
                .ForMember(x => x.IdUsuario, x => x.MapFrom(y => y.Id))
                .ReverseMap();
        }
    }
}
