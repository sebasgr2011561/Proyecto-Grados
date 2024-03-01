using Application.DTOs.Request;
using Application.DTOs.Response;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Commons.Bases.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Static;

namespace Application.Mappers
{
    public class AssignmentMappingsProfile : Profile
    {
        public AssignmentMappingsProfile()
        {
            CreateMap<Asignacion, AssignmentResponseDto>()
                .ForMember(x => x.IdAsignacion, x => x.MapFrom(y => y.Id))
                .ReverseMap();

            CreateMap<AssignmentResponseDto, Asignacion>()
                    .ReverseMap();

            CreateMap<BaseEntityResponse<Asignacion>, BaseEntityResponse<AssignmentResponseDto>>()
                    .ReverseMap();

            CreateMap<AssignmentRequestDto, Asignacion>()
                    .ReverseMap();

            CreateMap<Asignacion, AssignmentRequestDto>()
                    .ReverseMap();

            CreateMap<Asignacion, AssignmentSelectResponseDto>()
                    .ForMember(x => x.IdAsignacion, x => x.MapFrom(y => y.Id))
                    .ReverseMap();
        }
    }
}
