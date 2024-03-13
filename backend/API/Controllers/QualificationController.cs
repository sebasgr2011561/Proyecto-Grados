using Application.DTOs.Request;
using Application.Interfaces;
using Infrastructure.Commons.Bases.Request;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QualificationController : ControllerBase
    {
        private readonly IQualificationsApplication _qualificationApplication;

        public QualificationController(IQualificationsApplication qualificationApplication)
        {
            _qualificationApplication = qualificationApplication;
        }

        [HttpPost]
        public async Task<IActionResult> ListQualifications([FromBody] BaseFiltersRequest filtersRequest)
        {
            var response = await _qualificationApplication.ListQualifications(filtersRequest);
            return Ok(response);
        }

        [HttpGet("Select")]
        public async Task<IActionResult> ListSelectQualifications()
        {
            var response = await _qualificationApplication.ListSelectQualifications();
            return Ok(response);
        }

        [HttpGet("{idQualification:int}")]
        public async Task<IActionResult> GetQualificationById(int idQualification)
        {
            var response = await _qualificationApplication.GetQualificationById(idQualification);
            return Ok(response);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> CreateQualification([FromBody] QualificationRequestDto qualificationRequestDto)
        {
            var response = await _qualificationApplication.CreateQualification(qualificationRequestDto);
            return Ok(response);
        }

        [HttpPut("Update/{idQualification:int}")]
        public async Task<IActionResult> UpdateQualification(int idQualification, [FromBody] QualificationRequestDto qualificationRequestDto)
        {
            var response = await _qualificationApplication.UpdateQualification(idQualification, qualificationRequestDto);
            return Ok(response);
        }

        [HttpPut("Delete/{idQualification:int}")]
        public async Task<IActionResult> DeleteQualification(int idQualification)
        {
            var response = await _qualificationApplication.DeleteQualification(idQualification);
            return Ok(response);
        }
    }
}
