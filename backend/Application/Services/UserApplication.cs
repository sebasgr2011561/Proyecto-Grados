using Application.Commons.Bases;
using Application.DTOs.Request;
using Application.DTOs.Response;
using Application.Interfaces;
using Application.Validators.User;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Commons.Bases.Request;
using Infrastructure.Commons.Bases.Response;
using Infrastructure.Persistence.Interfaces;
using Utilities.Static;
using BC = BCrypt.Net.BCrypt;

namespace Application.Services
{
    public class UserApplication : IUserApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserValidator _validationRules;

        public UserApplication(IMapper mapper, IUnitOfWork unitOfWork, UserValidator validationRules)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _validationRules = validationRules;
        }

        public async Task<BaseResponse<int>> CreateUser(UserRequestDto requestDto)
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

            var user = _mapper.Map<Usuario>(requestDto);
            user.Password = BC.HashPassword(requestDto.Password);
            user.Estado = Convert.ToBoolean(StateTypes.Active);

            if (requestDto.Imagen is not null)
            {
                user.Imagen = await _unitOfWork.AzureStorage.SaveFile(AzureContainers.USERS, requestDto.Imagen);
            }

            response.Data = await _unitOfWork.User.CreateAsync(user);

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

        public async Task<BaseResponse<bool>> DeleteUser(int idUser)
        {
            var response = new BaseResponse<bool>();
            var userUpdate = await GetUserById(idUser);

            if (userUpdate.Data is null)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;

                return response;
            }

            response.Data = await _unitOfWork.User.DeleteAsync(idUser);

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

        public async Task<BaseResponse<UserResponseDto>> GetUserById(int userId)
        {
            var response = new BaseResponse<UserResponseDto>();
            var user = await _unitOfWork.User.GetByIdAsync(userId);

            if (user is not null)
            {
                response.IsSuccess = true;
                response.Data = _mapper.Map<UserResponseDto>(user);
                response.Message = ReplyMessage.MESSAGE_QUERY;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }

            return response;
        }

        public async Task<BaseResponse<IEnumerable<UserSelectResponseDto>>> ListSelectUsers()
        {
            var response = new BaseResponse<IEnumerable<UserSelectResponseDto>>();
            var users = await _unitOfWork.User.GetAllAsync();

            if (users is not null)
            {
                response.IsSuccess = true;
                response.Data = _mapper.Map<IEnumerable<UserSelectResponseDto>>(users);
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

        public async Task<BaseResponse<BaseEntityResponse<UserResponseDto>>> ListUsers(BaseFiltersRequest filters)
        {
            var response = new BaseResponse<BaseEntityResponse<UserResponseDto>>();
            var users = await _unitOfWork.User.ListUsers(filters);

            if (users is not null)
            {
                response.IsSuccess = true;
                response.Data = _mapper.Map<BaseEntityResponse<UserResponseDto>>(users);
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

        public async Task<BaseResponse<bool>> UpdateUser(int idUser, UserRequestDto requestDto)
        {
            var response = new BaseResponse<bool>();
            var userUpdate = await GetUserById(idUser);

            if (userUpdate.Data is null)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;

                return response;
            }

            var user = _mapper.Map<Usuario>(requestDto);
            user.Id = idUser;
            user.Password = BC.HashPassword(requestDto.Password);
            user.Estado = Convert.ToBoolean(StateTypes.Active);

            if (requestDto.Imagen is not null)
            {
                user.Imagen = await _unitOfWork.AzureStorage.SaveFile(AzureContainers.USERS, requestDto.Imagen);
            }

            response.Data = await _unitOfWork.User.UpdateAsync(user);

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
