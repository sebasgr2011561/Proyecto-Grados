using Application.Commons.Bases;
using Application.DTOs.Request;

namespace Application.Interfaces
{
    public interface ILoginApplication
    {
        Task<BaseResponse<int>> RegisterUser(UserRequestDto requestDto);
        Task<BaseResponse<string>> GenerateToken(TokenRequestDto requestDto);
    }
}
