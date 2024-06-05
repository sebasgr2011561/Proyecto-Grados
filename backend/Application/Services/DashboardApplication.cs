using Application.Commons.Bases;
using Application.DTOs.Response;
using Application.Interfaces;
using AutoMapper;
using Infrastructure.Commons.Bases.Response;
using Infrastructure.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Static;

namespace Application.Services
{
    public class DashboardApplication : IDashboardApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DashboardApplication(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<IEnumerable<DashboardResponseDto>>> GetInfoDashboardActive(int idProfesor)
        {
            var response = new BaseResponse<IEnumerable<DashboardResponseDto>>();
            var dataDashboard = await _unitOfWork.Dashboard.InfoDashboardActive(idProfesor);

            if (dataDashboard is not null)
            {
                response.IsSuccess = true;
                response.Data = _mapper.Map<IEnumerable<DashboardResponseDto>>(dataDashboard);
                response.Message = ReplyMessage.MESSAGE_QUERY;

                return response;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }


            return response;
        }

        public async Task<BaseResponse<IEnumerable<DashboardResponseDto>>> GetInfoDashboardInactive(int idProfesor)
        {
            var response = new BaseResponse<IEnumerable<DashboardResponseDto>>();
            var dataDashboard = await _unitOfWork.Dashboard.InfoDashboardInactive(idProfesor);

            if (dataDashboard is not null)
            {
                response.IsSuccess = true;
                response.Data = _mapper.Map<IEnumerable<DashboardResponseDto>>(dataDashboard);
                response.Message = ReplyMessage.MESSAGE_QUERY;

                return response;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }


            return response;
        }
    }
}
