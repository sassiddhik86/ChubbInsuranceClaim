using ChubbInsuranceClaim.src.Application.DTO.Incident;
using ChubbInsuranceClaim.src.Application.DTO.Users;
using ChubbInsuranceClaim.src.Application.Interfaces.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ChubbInsuranceClaim.src.API.Controllers
{
    [ApiController]
    [Route("api/incidents")]
    [Authorize]
    public class IncidentsController : ControllerBase
    {
        private readonly IIncidentService _service;

        public IncidentsController(IIncidentService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateIncidentRequest request)
        {
            int userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            var result = await _service.CreateIncidentAsync(userId, request);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _service.GetByIdAsync(id);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateIncidentRequest request)
        {
            await _service.UpdateIncidentAsync(id, request);

            return Ok(new
            {
                message = "Incident updated."
            });
        }
    }
}
