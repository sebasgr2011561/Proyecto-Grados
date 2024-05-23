using System;
using Application.DTOs.Request;
using Application.DTOs.Response;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Commons.Bases.Response;

namespace Application.Mappers
{
	public class QualificationMappingsProfile : Profile
	{
		public QualificationMappingsProfile()
		{
            CreateMap<Calificacione, QualificationResponseDto>()
                .ForMember(x => x.IdCalificacion, x => x.MapFrom(y => y.Id))
                .ReverseMap();

            CreateMap<QualificationResponseDto, Calificacione>()
                .ForMember(x => x.Id, x => x.MapFrom(y => y.IdCalificacion))
                .ReverseMap();

            CreateMap<BaseEntityResponse<Calificacione>, BaseEntityResponse<QualificationResponseDto>>()
                    .ReverseMap();

            CreateMap<QualificationRequestDto, Calificacione>()
                    .ReverseMap();

            CreateMap<Calificacione, QualificationRequestDto>()
                    .ReverseMap();

            CreateMap<Calificacione, QualificationSelectResponseDto>()
                    .ForMember(x => x.IdCalificacion, x => x.MapFrom(y => y.Id))
                    .ReverseMap();
        }
	}
}

