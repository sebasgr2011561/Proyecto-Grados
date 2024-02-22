using Application.Commons.Bases;
using Application.DTOs.Request;

namespace Application.Interfaces
{
    public interface ILoginApplication
    {
        Task<BaseResponse<bool>> RegisterUser(UserRequestDto requestDto);
        Task<BaseResponse<string>> GenerateToken(TokenRequestDto requestDto);
    }
}
