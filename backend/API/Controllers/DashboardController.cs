using Application.Interfaces;
using Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardApplication _dashboardApplication;

        public DashboardController(IDashboardApplication dashboardApplication)
        {
            _dashboardApplication = dashboardApplication;
        }

        [HttpGet("SelectInfoDashboardActive/{idProfesor:int}")]
        public async Task<IActionResult> SelectInfoDashboardActive(int idProfesor)
        {
            var response = await _dashboardApplication.GetInfoDashboardActive(idProfesor);
            return Ok(response);
        }

        [HttpGet("SelectInfoDashboardInactive/{idProfesor:int}")]
        public async Task<IActionResult> SelectInfoDashboardInactive(int idProfesor)
        {
            var response = await _dashboardApplication.GetInfoDashboardInactive(idProfesor);
            return Ok(response);
        }
    }
}
