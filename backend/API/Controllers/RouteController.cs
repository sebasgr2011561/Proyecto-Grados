using Application.DTOs.Request;
using Application.Interfaces;
using Infrastructure.Commons.Bases.Request;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouteController : ControllerBase
    {
        private readonly IRouteApplication _routeApplication;

        public RouteController(IRouteApplication routeApplication)
        {
            _routeApplication = routeApplication;
        }

        [HttpPost]
        public async Task<IActionResult> ListCourses([FromBody] BaseFiltersRequest filtersRequest)
        {
            var response = await _routeApplication.ListRoutes(filtersRequest);
            return Ok(response);
        }

        [HttpGet("Select")]
        public async Task<IActionResult> ListSelectCourses()
        {
            var response = await _routeApplication.ListSelectRoutes();
            return Ok(response);
        }

        [HttpGet("{assignmentId:int}")]
        public async Task<IActionResult> GetCourseById(int assignmentId)
        {
            var response = await _routeApplication.GetRouteById(assignmentId);
            return Ok(response);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> CreateCourse([FromBody] RouteRequestDto assignmentRequestDto)
        {
            var response = await _routeApplication.CreateRoute(assignmentRequestDto);
            return Ok(response);
        }

        [HttpPut("Update/{assignmentId:int}")]
        public async Task<IActionResult> UpdateCourse(int assignmentId, [FromBody] RouteRequestDto assignmentRequestDto)
        {
            var response = await _routeApplication.UpdateRoute(assignmentId, assignmentRequestDto);
            return Ok(response);
        }

        [HttpPut("Delete/{assignmentId:int}")]
        public async Task<IActionResult> DeleteCourse(int assignmentId)
        {
            var response = await _routeApplication.DeleteRoute(assignmentId);
            return Ok(response);
        }
    }
}
