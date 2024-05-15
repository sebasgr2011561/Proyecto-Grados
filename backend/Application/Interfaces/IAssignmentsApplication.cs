using Application.Commons.Bases;
using Application.DTOs.Request;
using Application.DTOs.Response;
using Infrastructure.Commons.Bases.Request;
using Infrastructure.Commons.Bases.Response;

namespace Application.Interfaces
{
    public interface IAssignmentsApplication
    {
        Task<BaseResponse<BaseEntityResponse<AssignmentResponseDto>>> ListAssignments(BaseFiltersRequest filters);
        Task<BaseResponse<IEnumerable<AssignmentSelectResponseDto>>> ListSelectAssignments();
        Task<BaseResponse<AssignmentResponseDto>> AssignmentsByStudent(int studentId);
        Task<BaseResponse<AssignmentResponseDto>> GetAssignmentById(int assignmentId);
        Task<BaseResponse<int>> CreateAssignment(AssignmentRequestDto requestDto);
        Task<BaseResponse<bool>> UpdateAssignment(int idAssignment, AssignmentRequestDto requestDto);
        Task<BaseResponse<bool>> DeleteAssignment(int idAssignment);
    }
}
