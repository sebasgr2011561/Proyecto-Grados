using Application.Commons.Bases;
using Application.DTOs.Response;
using Infrastructure.Commons.Bases.Request;
using Infrastructure.Commons.Bases.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IDashboardApplication
    {
        Task<BaseResponse<IEnumerable<DashboardResponseDto>>> GetInfoDashboardActive(int idProfesor);
        Task<BaseResponse<IEnumerable<DashboardResponseDto>>> GetInfoDashboardInactive(int idProfesor);
    }
}
