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

    public class DashboardController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        private readonly IConfiguration _config;

        public DashboardController(AppDbContext dbContext)
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
        public IActionResult GetLatestNoonReports()
        {
            var latestNoonReports = _dbContext.NoonReports
                .GroupBy(report => report.VesselId)
                .Select(group => group.OrderByDescending(report => report.ReportDateTime).First())
                .ToList();

            return Ok(latestNoonReports);
        }

    }
}