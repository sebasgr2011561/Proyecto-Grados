﻿using Application.Commons.Bases;
using Application.DTOs.Request;
using Application.DTOs.Response;
using Infrastructure.Commons.Bases.Request;
using Infrastructure.Commons.Bases.Response;

namespace Application.Interfaces
{
    public interface IUserApplication
    {
        Task<BaseResponse<BaseEntityResponse<UserResponseDto>>> ListUsers(BaseFiltersRequest filters);
        Task<BaseResponse<IEnumerable<UserSelectResponseDto>>> ListSelectUsers();
        Task<BaseResponse<UserResponseDto>> GetUserById(int userId);
        Task<BaseResponse<int>> CreateUser(UserRequestDto requestDto);
        Task<BaseResponse<bool>> UpdateUser(int idUser, UserRequestDto requestDto);
        Task<BaseResponse<bool>> DeleteUser(int idUser);
    }
}
