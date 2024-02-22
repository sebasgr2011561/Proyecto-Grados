using Application.DTOs.Request;
using Application.Interfaces;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginApplication _loginApplication;

        public LoginController(ILoginApplication loginApplication)
        {
            _loginApplication = loginApplication;
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser([FromBody] UserRequestDto userRequestDto)
        {
            var response = await _loginApplication.RegisterUser(userRequestDto);
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("Generate")]
        public async Task<IActionResult> GenerateToken([FromBody] TokenRequestDto requestDto)
        {
            var response = await _loginApplication.GenerateToken(requestDto);
            return Ok(response);
        }
    }
}
