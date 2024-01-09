using FleetMan.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FleetMan.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]

    public class PerformanceController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        private readonly IConfiguration _config;

        public PerformanceController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("vessels")]
        public IActionResult GetVesselData()
        {
            var vessels = _dbContext.Vessels.ToList();
            return Ok(vessels);
        }

        [HttpGet("noonreports")]
        public IActionResult GetNoonReports()
        {
            try
            {
                var noonReports = _dbContext.NoonReports.ToList();
                return Ok(noonReports);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("filterednoonreports")]
        public IActionResult GetFilteredNoonReports([FromQuery] int vesselId)
        {
            try
            {
                var filteredReports = _dbContext.NoonReports
                    .Where(report => report.VesselId == vesselId)
                    .ToList();

                return Ok(filteredReports);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}

