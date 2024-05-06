using Application.DTOs.Request;
using Application.DTOs.Response;
using AutoMapper;
using Domain.Entities;
using Domain.EntitiesDto;
using Infrastructure.Commons.Bases.Response;

namespace Application.Mappers
{
    public class AssignmentMappingsProfile : Profile
    {
        public AssignmentMappingsProfile()
        {
            //CreateMap<Asignacion, AssignmentResponseDto>()
            //    .ForMember(x => x.IdAsignacion, x => x.MapFrom(y => y.Id))
            //    .ReverseMap();

            //CreateMap<AssignmentResponseDto, Asignacion>()
            //    .ForMember(x => x.Id, x => x.MapFrom(y => y.IdAsignacion))
            //    .ReverseMap();

            CreateMap<BaseEntityResponse<Asignacion>, BaseEntityResponse<AssignmentResponseDto>>()
                    .ReverseMap();

            CreateMap<AssignmentRequestDto, Asignacion>()
                    .ReverseMap();

            CreateMap<Asignacion, AssignmentRequestDto>()
                    .ReverseMap();

            CreateMap<Asignacion, AssignmentSelectResponseDto>()
                    .ForMember(x => x.IdAsignacion, x => x.MapFrom(y => y.Id))
                    .ReverseMap();

            CreateMap<AssignmentDto, AssignmentResponseDto>()
                .ReverseMap();
        }
    }
}
