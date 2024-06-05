using Application.DTOs.Request;
using Application.DTOs.Response;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Static;

namespace Application.Mappers
{
    public class DashboardMappingsProfile : Profile
    {
        public DashboardMappingsProfile()
        {
            CreateMap<Dashboard, DashboardResponseDto>()
                .ForMember(x => x.IdDashboard, x => x.MapFrom(y => y.Id))
                .ReverseMap();

            /*
             * 
             * CreateMap<Categorium, CategorySelectResponseDto>()
                    .ForMember(x => x.IdCategoria, x => x.MapFrom(y => y.Id))
                    .ReverseMap();
             
             */

        }
    }
}
