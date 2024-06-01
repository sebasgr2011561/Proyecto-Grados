using Application.DTOs.Request;
using Application.DTOs.Response;
using AutoMapper;
using Domain.Entities;
using Utilities.Static;

namespace Application.Mappers
{
    public class AsociacionRutaMappingsProfile : Profile
    {
        public AsociacionRutaMappingsProfile()
        {
            CreateMap<AsociacionRutaRequestDto, AsociacionRuta>()
                    .ReverseMap();

            CreateMap<AsociacionRuta, AsociacionRutaRequestDto>()
                    .ReverseMap();

            CreateMap<AsociacionRutaResponseDto, AsociacionRuta>()
                .ForMember(x => x.Id, x => x.MapFrom(y => y.IdAsociacionRuta))
                .ForMember(x => x.Estado, x => x.MapFrom(y => y.Estado == Convert.ToBoolean(StateTypes.Active) ? "Activo" : "Inactivo"))
                .ReverseMap();
        }
    }
}
