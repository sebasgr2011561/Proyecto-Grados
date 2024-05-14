using Application.DTOs.Request;
using Application.Interfaces;
using Infrastructure.Commons.Bases.Request;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModulesController : ControllerBase
    {
        private readonly IModuleApplication _moduleApplication;

        public ModulesController(IModuleApplication moduleApplication)
        {
            _moduleApplication = moduleApplication;
        }

        [HttpPost]
        public async Task<IActionResult> ListModules([FromBody] BaseFiltersRequest filtersRequest)
        {
            var response = await _moduleApplication.ListModules(filtersRequest);
            return Ok(response);
        }

        [HttpGet("Select")]
        public async Task<IActionResult> ListSelectCategories()
        {
            var response = await _moduleApplication.ListSelectModules();
            return Ok(response);
        }

        [HttpGet("{moduleId:int}")]
        public async Task<IActionResult> GetModuleById(int moduleId)
        {
            var response = await _moduleApplication.GetModuleById(moduleId);
            return Ok(response);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> CreateModule([FromBody] List<ModuleRequestDto> moduleRequestDto)
        {
            var response = await _moduleApplication.CreateModule(moduleRequestDto);
            return Ok(response);
        }

        [HttpPut("Update/{moduleId:int}")]
        public async Task<IActionResult> UpdateModule(int moduleId, [FromBody] List<ModuleRequestDto> moduleRequestDto)
        {
            var response = await _moduleApplication.UpdateModule(moduleId, moduleRequestDto);
            return Ok(response);
        }

        [HttpPut("Delete/{moduleId:int}")]
        public async Task<IActionResult> DeleteModule(int moduleId)
        {
            var response = await _moduleApplication.DeleteModule(moduleId);
            return Ok(response);
        }
    }
}
