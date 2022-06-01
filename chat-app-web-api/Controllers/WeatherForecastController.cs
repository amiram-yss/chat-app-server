using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8603 // Possible null reference return.
#pragma warning disable CS8604 // Possible null reference return.


namespace chat_app_web_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IConfiguration _configuration;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IConfiguration conf)
        {
            _logger = logger;
            _configuration = conf;
        }
        [Authorize]
        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            var token = HttpContext.GetTokenAsync("access_token");
            if (token == null)
                return null;
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(token.Result);
            var username = User.Claims.FirstOrDefault
                (c => c.Type.Equals("UserId", StringComparison.OrdinalIgnoreCase)).Value;

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {

                /*                Date = DateTime.Now.AddDays(index),
                                TemperatureC = 333,*/
                Name = username,
                nickName = "barmats",
                LastMessage = "are you here?",

            })
            .ToArray();
        }
    }
}