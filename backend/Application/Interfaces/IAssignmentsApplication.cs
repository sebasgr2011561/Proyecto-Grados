using Application.Commons.Bases;
using Application.DTOs.Request;
using Application.DTOs.Response;
using Infrastructure.Commons.Bases.Request;
using Infrastructure.Commons.Bases.Response;

namespace Application.Interfaces
{
    public interface IAssignmentsApplication
    {
        Task<BaseResponse<IEnumerable<AssignmentSelectResponseDto>>> ListSelectAssignments(int studentId);
        Task<BaseResponse<int>> CreateAssignment(AssignmentRequestDto requestDto);
    }
}
