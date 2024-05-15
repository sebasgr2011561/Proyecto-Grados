using Application.Commons.Bases;
using Application.DTOs.Request;
using Application.DTOs.Response;
using Application.Interfaces;
using Application.Validators.Role;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Commons.Bases.Request;
using Infrastructure.Commons.Bases.Response;
using Infrastructure.Persistence.Interfaces;
using Utilities.Static;

namespace Application.Services
{
    public class RolesApplication : IRolesApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly RoleValidator _validationRules;

        public RolesApplication(IUnitOfWork unitOfWork, IMapper mapper, RoleValidator validationRules)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validationRules = validationRules;
        }

        public async Task<BaseResponse<int>> CreateRole(RoleRequestDto requestDto)
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

            var role = _mapper.Map<Role>(requestDto);
            role.Estado = Convert.ToBoolean(StateTypes.Active);
            response.Data = await _unitOfWork.Roles.CreateAsync(role);

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

        public async Task<BaseResponse<bool>> DeleteRole(int idRole)
        {
            var response = new BaseResponse<bool>();
            var roleDelete = await GetRoleById(idRole);

            if (roleDelete.Data is null)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;

                return response;
            }

            response.Data = await _unitOfWork.Roles.DeleteAsync(idRole);

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

        public async Task<BaseResponse<RoleResponseDto>> GetRoleById(int idRole)
        {
            var response = new BaseResponse<RoleResponseDto>();
            var role = await _unitOfWork.Roles.GetByIdAsync(idRole);

            if (role is not null)
            {
                response.IsSuccess = true;
                response.Data = _mapper.Map<RoleResponseDto>(role);
                response.Message = ReplyMessage.MESSAGE_QUERY;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }

            return response;
        }

        public async Task<BaseResponse<BaseEntityResponse<RoleResponseDto>>> ListRoles(BaseFiltersRequest filters)
        {
            var response = new BaseResponse<BaseEntityResponse<RoleResponseDto>>();
            var roles = await _unitOfWork.Roles.ListRoles(filters);

            if (roles is not null)
            {
                response.IsSuccess = true;
                response.Data = _mapper.Map<BaseEntityResponse<RoleResponseDto>>(roles);
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

        public async Task<BaseResponse<IEnumerable<RoleSelectResponseDto>>> ListSelectRoles()
        {
            var response = new BaseResponse<IEnumerable<RoleSelectResponseDto>>();
            var roles = await _unitOfWork.Roles.GetAllAsync();

            if (roles is not null)
            {
                response.IsSuccess = true;
                response.Data = _mapper.Map<IEnumerable<RoleSelectResponseDto>>(roles);
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

        public async Task<BaseResponse<bool>> UpdateRole(int idRole, RoleRequestDto requestDto)
        {
            var response = new BaseResponse<bool>();
            var roleUpdate = await GetRoleById(idRole);

            if (roleUpdate.Data is null)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;

                return response;
            }

            var role = _mapper.Map<Role>(requestDto);
            role.Id = idRole;
            role.Estado = Convert.ToBoolean(StateTypes.Active);
            response.Data = await _unitOfWork.Roles.UpdateAsync(role);

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
