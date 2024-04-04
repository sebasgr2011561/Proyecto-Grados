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
        private readonly IAssignmentsAppication _assignmentsAppication;

        public AssignmentController(IAssignmentsAppication assignmentsAppication)
        {
            _assignmentsAppication = assignmentsAppication;
        }

        [HttpPost]
        public async Task<IActionResult> ListAssignments([FromBody] BaseFiltersRequest filtersRequest)
        {
            var response = await _assignmentsAppication.ListAssignments(filtersRequest);
            return Ok(response);
        }

        [HttpGet("Select")]
        public async Task<IActionResult> ListSelectAssignments()
        {
            var response = await _assignmentsAppication.ListSelectAssignments();
            return Ok(response);
        }

        [HttpGet("AssignmentsByStudent/{studentId:int}")]
        public async Task<IActionResult> AssignmentsByStudent(int studentId)
        {
            var response = await _assignmentsAppication.AssignmentsByStudent(studentId);
            return Ok(response);
        }

        [HttpGet("{assignmentId:int}")]
        public async Task<IActionResult> GetAssignmentById(int assignmentId)
        {
            var response = await _assignmentsAppication.GetAssignmentById(assignmentId);
            return Ok(response);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> CreateAssignment([FromBody] AssignmentRequestDto assignmentRequestDto)
        {
            var response = await _assignmentsAppication.CreateAssignment(assignmentRequestDto);
            return Ok(response);
        }

        [HttpPut("Update/{assignmentId:int}")]
        public async Task<IActionResult> UpdateAssignment(int assignmentId, [FromBody] AssignmentRequestDto assignmentRequestDto)
        {
            var response = await _assignmentsAppication.UpdateAssignment(assignmentId, assignmentRequestDto);
            return Ok(response);
        }

        [HttpPut("Delete/{assignmentId:int}")]
        public async Task<IActionResult> DeleteAssignment(int assignmentId)
        {
            var response = await _assignmentsAppication.DeleteAssignment(assignmentId);
            return Ok(response);
        }
    }
}
