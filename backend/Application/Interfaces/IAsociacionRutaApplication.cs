using Application.Commons.Bases;
using Application.DTOs.Request;

namespace Application.Interfaces
{
    public interface IAsociacionRutaApplication
    {
        Task<BaseResponse<int>> CreateAsociacionRuta(AsociacionRutaRequestDto requestDto);
        Task<BaseResponse<bool>> DeleteAsociacionRuta(int idAsociacionRuta);
    }
}
