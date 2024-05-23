using Application.Commons.Bases;
using Application.DTOs.Request;
using Application.DTOs.Response;
using Application.Interfaces;
using Application.Validators.Route;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Commons.Bases.Request;
using Infrastructure.Commons.Bases.Response;
using Infrastructure.Persistence.Interfaces;
using Utilities.Static;

namespace Application.Services
{
    public class RouteApplication : IRouteApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly RouteValidator _validationRules;

        public RouteApplication(IUnitOfWork unitOfWork, IMapper mapper, RouteValidator validationRules)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validationRules = validationRules;
        }

        public async Task<BaseResponse<int>> CreateRoute(RouteRequestDto requestDto)
        {
            var response = new BaseResponse<int>();
            var validationResult = await _validationRules.ValidateAsync(requestDto);

            if (!validationResult.IsValid)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_VALIDATE;
                response.Errors = validationResult.Errors;
                return response;
            }

            var route = _mapper.Map<Ruta>(requestDto);
            route.Estado = Convert.ToBoolean(StateTypes.Active);
            response.Data = await _unitOfWork.Routes.CreateAsync(route);

            if (response.Data > 0)
            {
                response.IsSuccess = true;
                response.Message = ReplyMessage.MESSAGE_SAVE;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_FAILED;
            }

            return response;
        }

        public async Task<BaseResponse<bool>> DeleteRoute(int idRoute)
        {
            var response = new BaseResponse<bool>();
            var routeUpdate = await GetRouteById(idRoute);

            if (routeUpdate.Data is null)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;

                return response;
            }

            response.Data = await _unitOfWork.Routes.DeleteAsync(idRoute);

            if (response.Data)
            {
                response.IsSuccess = true;
                response.Message = ReplyMessage.MESSAGE_DELETE;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_FAILED;
            }

            return response;
        }

        public async Task<BaseResponse<RouteResponseDto>> GetRouteById(int idRoute)
        {
            var response = new BaseResponse<RouteResponseDto>();
            var route = await _unitOfWork.Routes.GetByIdAsync(idRoute);

            if (route is not null)
            {
                response.IsSuccess = true;
                response.Data = _mapper.Map<RouteResponseDto>(route);
                response.Message = ReplyMessage.MESSAGE_QUERY;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }

            return response;
        }

        public async Task<BaseResponse<BaseEntityResponse<RouteResponseDto>>> ListRoutes(BaseFiltersRequest filters)
        {
            var response = new BaseResponse<BaseEntityResponse<RouteResponseDto>>();
            var routes = await _unitOfWork.Routes.ListRoutes(filters);

            if (routes is not null)
            {
                response.IsSuccess = true;
                response.Data = _mapper.Map<BaseEntityResponse<RouteResponseDto>>(routes);
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

        public async Task<BaseResponse<IEnumerable<RouteSelectResponseDto>>> ListSelectRoutes(int userId = 0)
        {
            var response = new BaseResponse<IEnumerable<RouteSelectResponseDto>>();
            var routesAll = await _unitOfWork.Routes.GetAllAsync();

            var routes = userId == 0 ? routesAll : routesAll.Where(x => x.IdEstudiante == userId);

            if (routes is not null)
            {
                response.IsSuccess = true;
                response.Data = _mapper.Map<IEnumerable<RouteSelectResponseDto>>(routes);
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

        public async Task<BaseResponse<bool>> UpdateRoute(int idRoute, RouteRequestDto requestDto)
        {
            var response = new BaseResponse<bool>();
            var routeUpdate = await GetRouteById(idRoute);

            if (routeUpdate.Data is null)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;

                return response;
            }

            var route = _mapper.Map<Ruta>(requestDto);
            route.Id = idRoute;
            route.Estado = Convert.ToBoolean(StateTypes.Active);
            response.Data = await _unitOfWork.Routes.UpdateAsync(route);

            if (response.Data)
            {
                response.IsSuccess = true;
                response.Message = ReplyMessage.MESSAGE_UPDATE;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_FAILED;
            }

            return response;
        }
    }
}
