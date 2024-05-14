using Application.DTOs.Request;
using Application.Interfaces;
using Infrastructure.Commons.Bases.Request;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserApplication _userApplication;

        public UserController(IUserApplication userApplication)
        {
            _userApplication = userApplication;
        }

        [HttpPost]
        public async Task<IActionResult> ListUsers([FromBody] BaseFiltersRequest filtersRequest)
        {
            var response = await _userApplication.ListUsers(filtersRequest);
            return Ok(response);
        }

        [HttpGet("Select")]
        public async Task<IActionResult> ListSelectUsers()
        {
            var response = await _userApplication.ListSelectUsers();
            return Ok(response);
        }

        [HttpGet("{userId:int}")]
        public async Task<IActionResult> GetUserById(int userId)
        {
            var response = await _userApplication.GetUserById(userId);
            return Ok(response);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> CreateUser([FromForm] UserRequestDto userRequestDto)
        {
            var response = await _userApplication.CreateUser(userRequestDto);
            return Ok(response);
        }

        [HttpPut("Update/{userId:int}")]
        public async Task<IActionResult> UpdateUser(int userId, [FromForm] UserRequestDto userRequestDto)
        {
            var response = await _userApplication.UpdateUser(userId, userRequestDto);
            return Ok(response);
        }

        [HttpPut("Delete/{userId:int}")]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            var response = await _userApplication.DeleteUser(userId);
            return Ok(response);
        }
    }
}
