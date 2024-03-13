using Application.Commons.Bases;
using Application.DTOs.Request;
using Application.DTOs.Response;
using Infrastructure.Commons.Bases.Request;
using Infrastructure.Commons.Bases.Response;

namespace Application.Interfaces
{
    public interface IQualificationsApplication
    {
        Task<BaseResponse<BaseEntityResponse<QualificationResponseDto>>> ListQualifications(BaseFiltersRequest filters);
        Task<BaseResponse<IEnumerable<QualificationSelectResponseDto>>> ListSelectQualifications();
        Task<BaseResponse<QualificationResponseDto>> GetQualificationById(int assignmentId);
        Task<BaseResponse<bool>> CreateQualification(QualificationRequestDto requestDto);
        Task<BaseResponse<bool>> UpdateQualification(int idQualification, QualificationRequestDto requestDto);
        Task<BaseResponse<bool>> DeleteQualification(int idQualification);
    }
}
