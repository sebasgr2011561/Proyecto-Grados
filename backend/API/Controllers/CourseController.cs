using Application.DTOs.Request;
using Application.Interfaces;
using Infrastructure.Commons.Bases.Request;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICoursesApplication _coursesApplication;

        public CourseController(ICoursesApplication coursesApplication)
        {
            _coursesApplication = coursesApplication;
        }

        [HttpPost]
        public async Task<IActionResult> ListCourses([FromBody] BaseFiltersRequest filtersRequest)
        {
            var response = await _coursesApplication.ListCourses(filtersRequest);
            return Ok(response);
        }

        [HttpGet("Select")]
        public async Task<IActionResult> ListSelectCourses()
        {
            var response = await _coursesApplication.ListSelectCourses();
            return Ok(response);
        }

        [HttpGet("SelectByProfesorId/{profesorId:int}")]
        public async Task<IActionResult> ListSelectByProfesorId(int profesorId)
        {
            var response = await _coursesApplication.ListSelectByProfesorId(profesorId);
            return Ok(response);
        }

        [HttpGet("{courseId:int}")]
        public async Task<IActionResult> GetCourseById(int courseId)
        {
            var response = await _coursesApplication.GetCourseById(courseId);
            return Ok(response);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> CreateCourse([FromBody] CourseRequestDto courseRequestDto)
        {
            var response = await _coursesApplication.CreateCourse(courseRequestDto);
            return Ok(response);
        }

        [HttpPut("Update/{CourseId:int}")]
        public async Task<IActionResult> UpdateCourse(int CourseId, [FromBody] CourseRequestDto courseRequestDto)
        {
            var response = await _coursesApplication.UpdateCourse(CourseId, courseRequestDto);
            return Ok(response);
        }

        [HttpPut("Delete/{CourseId:int}")]
        public async Task<IActionResult> DeleteCourse(int CourseId)
        {
            var response = await _coursesApplication.DeleteCourse(CourseId);
            return Ok(response);
        }
    }
}
