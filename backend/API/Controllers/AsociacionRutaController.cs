using Application.DTOs.Request;
using Application.Interfaces;
using Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsociacionRutaController : ControllerBase
    {
        private readonly IAsociacionRutaApplication _asociacionRutaApplication;

        public AsociacionRutaController(IAsociacionRutaApplication asociacionRutaApplication)
        {
            _asociacionRutaApplication = asociacionRutaApplication;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> CreateAsociacionRuta([FromBody] AsociacionRutaRequestDto asociacionRutaRequest)
        {
            var response = await _asociacionRutaApplication.CreateAsociacionRuta(asociacionRutaRequest);
            return Ok(response);
        }

        [HttpPut("Delete/{asociacionRutaId:int}")]
        public async Task<IActionResult> DeleteAsociacionRuta(int asociacionRutaId)
        {
            var response = await _asociacionRutaApplication.DeleteAsociacionRuta(asociacionRutaId);
            return Ok(response);
        }
    }
}
