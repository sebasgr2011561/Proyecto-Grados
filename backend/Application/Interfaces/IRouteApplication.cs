﻿using Application.Commons.Bases;
using Application.DTOs.Request;
using Application.DTOs.Response;
using Infrastructure.Commons.Bases.Request;
using Infrastructure.Commons.Bases.Response;

namespace Application.Interfaces
{
    public interface IRouteApplication
    {
        Task<BaseResponse<BaseEntityResponse<RouteResponseDto>>> ListRoutes(BaseFiltersRequest filters);
        Task<BaseResponse<IEnumerable<RouteSelectResponseDto>>> ListSelectRoutes(int userId = 0);
        Task<BaseResponse<RouteResponseDto>> GetRouteById(int idRoute);
        Task<BaseResponse<int>> CreateRoute(RouteRequestDto requestDto);
        Task<BaseResponse<bool>> UpdateRoute(int idRoute, RouteRequestDto requestDto);
        Task<BaseResponse<bool>> DeleteRoute(int idRoute);
    }
}
