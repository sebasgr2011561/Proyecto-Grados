using Application.Commons.Bases;
using Application.DTOs.Request;
using Application.DTOs.Response;
using Infrastructure.Commons.Bases.Request;
using Infrastructure.Commons.Bases.Response;

namespace Application.Interfaces
{
    public interface IRolesApplication
    {
        Task<BaseResponse<BaseEntityResponse<RoleResponseDto>>> ListRoles(BaseFiltersRequest filters);
        Task<BaseResponse<IEnumerable<RoleSelectResponseDto>>> ListSelectRoles();
        Task<BaseResponse<RoleResponseDto>> GetRoleById(int idRole);
        Task<BaseResponse<int>> CreateRole(RoleRequestDto requestDto);
        Task<BaseResponse<bool>> UpdateRole(int idRole, RoleRequestDto requestDto);
        Task<BaseResponse<bool>> DeleteRole(int idRole);
    }
}
