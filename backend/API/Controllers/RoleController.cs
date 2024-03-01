using Application.DTOs.Request;
using Application.Interfaces;
using Infrastructure.Commons.Bases.Request;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRolesApplication _rolesApplication;

        public RoleController(IRolesApplication rolesApplication)
        {
            _rolesApplication = rolesApplication;
        }

        [HttpPost]
        public async Task<IActionResult> ListRoles([FromBody] BaseFiltersRequest filtersRequest)
        {
            var response = await _rolesApplication.ListRoles(filtersRequest);
            return Ok(response);
        }

        [HttpGet("Select")]
        public async Task<IActionResult> ListSelectRoles()
        {
            var response = await _rolesApplication.ListSelectRoles();
            return Ok(response);
        }

        [HttpGet("{roleId:int}")]
        public async Task<IActionResult> GetRoleById(int roleId)
        {
            var response = await _rolesApplication.GetRoleById(roleId);
            return Ok(response);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> CreateRole([FromBody] RoleRequestDto roleRequestDto)
        {
            var response = await _rolesApplication.CreateRole(roleRequestDto);
            return Ok(response);
        }

        [HttpPut("Update/{roleId:int}")]
        public async Task<IActionResult> UpdateRole(int roleId, [FromBody] RoleRequestDto roleRequestDto)
        {
            var response = await _rolesApplication.UpdateRole(roleId, roleRequestDto);
            return Ok(response);
        }

        [HttpPut("Delete/{roleId:int}")]
        public async Task<IActionResult> DeleteRole(int roleId)
        {
            var response = await _rolesApplication.DeleteRole(roleId);
            return Ok(response);
        }
    }
}
