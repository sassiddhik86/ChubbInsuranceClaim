using ChubbInsuranceClaim.src.Application.Interfaces.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChubbInsuranceClaim.src.API.Controllers
{

    [ApiController]
    [Route("api/dashboard")]
    [Authorize]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardService _dashboardService;

        public DashboardController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        // Customer dashboard
        [HttpGet("customer")]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> CustomerDashboard()
        {
            int customerId = GetCurrentUserId();

            var result = await _dashboardService.GetCustomerDashboardAsync(customerId);

            return Ok(result);
        }

        // Claim officer dashboard
        [HttpGet("officer")]
        [Authorize(Roles = "ClaimOfficer")]
        public async Task<IActionResult> OfficerDashboard()
        {
            int officerId = GetCurrentUserId();

            var result = await _dashboardService.GetOfficerDashboardAsync(officerId);

            return Ok(result);
        }


        // Supervisor dashboard
        [HttpGet("supervisor")]
        [Authorize(Roles = "Supervisor")]
        public async Task<IActionResult> SupervisorDashboard()
        {
            var result = await _dashboardService.GetSupervisorDashboardAsync();

            return Ok(result);
        }

        private int GetCurrentUserId()
        {
            return int.Parse(User.Claims.First(x => x.Type == System.Security.Claims.ClaimTypes.NameIdentifier).Value);
        }
    }
}