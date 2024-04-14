using Application.Commons.Bases;
using Application.DTOs.Request;
using Application.DTOs.Response;
using Infrastructure.Commons.Bases.Request;
using Infrastructure.Commons.Bases.Response;

namespace Application.Interfaces
{
    public interface ICoursesApplication
    {
        Task<BaseResponse<BaseEntityResponse<CourseResponseDto>>> ListCourses(BaseFiltersRequest filters);
        Task<BaseResponse<IEnumerable<CourseSelectResponseDto>>> ListSelectCourses();
        Task<BaseResponse<IEnumerable<CourseSelectResponseDto>>> ListSelectByProfesorId(int profesorId);
        Task<BaseResponse<CourseResponseDto>> GetCourseById(int CourseId);
        Task<BaseResponse<bool>> CreateCourse(CourseRequestDto requestDto);
        Task<BaseResponse<bool>> UpdateCourse(int idCourse, CourseRequestDto requestDto);
        Task<BaseResponse<bool>> DeleteCourse(int idCourse);
    }
}
