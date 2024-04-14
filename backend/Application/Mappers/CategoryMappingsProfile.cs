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

namespace Application.Mappers
{
    public class CategoryMappingsProfile : Profile
    {
        public CategoryMappingsProfile()
        {
            CreateMap<Categorium, CategoryResponseDto>()
                .ForMember(x => x.IdCategoria, x => x.MapFrom(y => y.Id))
                .ReverseMap();

            CreateMap<CategoryResponseDto, Categorium>()
                .ForMember(x => x.Id, x => x.MapFrom(y => y.IdCategoria))
                .ReverseMap();

            CreateMap<BaseEntityResponse<Categorium>, BaseEntityResponse<CategoryResponseDto>>()
                    .ReverseMap();

            CreateMap<CategoryRequestDto, Categorium>()
                    .ReverseMap();

            CreateMap<Categorium, CategoryRequestDto>()
                    .ReverseMap();

            CreateMap<Categorium, CategorySelectResponseDto>()
                    .ForMember(x => x.IdCategoria, x => x.MapFrom(y => y.Id))
                    .ReverseMap();
        }
    }
}
