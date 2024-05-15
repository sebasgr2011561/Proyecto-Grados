using Application.Commons.Bases;
using Application.DTOs.Request;
using Application.DTOs.Response;
using Infrastructure.Commons.Bases.Request;
using Infrastructure.Commons.Bases.Response;

namespace Application.Interfaces
{
    public interface IModuleApplication
    {
        Task<BaseResponse<BaseEntityResponse<ModuleResponseDto>>> ListModules(BaseFiltersRequest filters);
        Task<BaseResponse<IEnumerable<ModuleSelectResponseDto>>> ListSelectModules();
        Task<BaseResponse<ModuleResponseDto>> GetModuleById(int idModulo);
        Task<BaseResponse<int>> CreateModule(List<ModuleRequestDto> requestDto);
        Task<BaseResponse<bool>> UpdateModule(int idModulo, List<ModuleRequestDto> requestDto);
        Task<BaseResponse<bool>> DeleteModule(int idModulo);
    }
}
