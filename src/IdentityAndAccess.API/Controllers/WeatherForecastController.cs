using IdentityAndAccess.API.Constants;
using IdentityAndAccess.API.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdentityAndAccess.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : MainController
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpGet("GetAnonymous")]
        public IEnumerable<WeatherForecast> GetAnonymous()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("GetForAdminAndManagerRoles")]
        [Authorize(Roles = $"{Roles.Admin}, {Roles.Manager}")]
        //[Authorize(Roles = "Admin, Manager")] // example of another approach;
        public IEnumerable<WeatherForecast> GetForAdminAndManagerRoles()
        {
            return Enumerable.Range(1, 10).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("GetWithCanReadPermission")]
        // In this example, if ClaimValue is 'CanRead, CanCreate, CanUpdate', it will not work,
        // the ClaimValue must be 'CanRead';
        [ClaimsAuthorize(ClaimTypes.Permission, "CanRead")]
        public IActionResult GetWithCanReadPermission()
        {
            return Ok();
        }
        
        #region Policy examples
        [HttpGet("GetForWorkingHoursPolicy")]
        [Authorize(Policy = Policies.WorkingHours)]
        public IEnumerable<WeatherForecast> GetForWorkingHoursPolicy()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpDelete]
        // In this example, if ClaimValue is 'CanRead, CanCreate, CanUpdate', it will not allow access, the ClaimValue must be exactly 'CanDelete',
        // check IdentityConfig file for more information;
        [Authorize(Policy = "CanDelete")]
        //[ClaimsAuthorize("Admin", "CanDelete")] // example of another approach;
        public IActionResult Delete()
        {
            return Ok();
        }

        [HttpGet("GetWithCanReadClaim")]
        // In this example, if ClaimValue is 'CanRead, CanCreate, CanUpdate', it will allow access,
        // check IdentityConfig file for more information;
        [Authorize(Policy = "CanRead")]
        public IActionResult GetWithCanReadPolicy()
        {
            return Ok();
        }
        #endregion
    }
}