using Application.DTOs.Request;
using Application.Interfaces;
using Infrastructure.Commons.Bases.Request;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentController : ControllerBase
    {
        private readonly IAssignmentsApplication _assignmentsAppication;

        public AssignmentController(IAssignmentsApplication assignmentsAppication)
        {
            _assignmentsAppication = assignmentsAppication;
        }

        [HttpGet("AssignmentsByStudent/{studentId:int}")]
        public async Task<IActionResult> AssignmentsByStudent(int studentId)
        {
            var response = await _assignmentsAppication.ListSelectAssignments(studentId);
            return Ok(response);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> CreateAssignment([FromBody] AssignmentRequestDto assignmentRequestDto)
        {
            var response = await _assignmentsAppication.CreateAssignment(assignmentRequestDto);
            return Ok(response);
        }
    }
}
