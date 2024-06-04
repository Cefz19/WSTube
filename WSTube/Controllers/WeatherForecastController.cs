using Microsoft.AspNetCore.Mvc;

namespace WSTube.Controllers
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

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            List<WeatherForecast> lst = new List<WeatherForecast>();
            lst.Add(new WeatherForecast() { Id = 1, Nombres = "Cesar Alberto", Apellidos = "Sarate Alvares", Usuario = "Cesar82", email = "cesar@gmail.com", contraseña = "1234", re_contraseña = "1234" });
            lst.Add(new WeatherForecast() { Id = 2, Nombres = "Juan Carlos", Apellidos = "Lozano Olmedo", Usuario = "Juan152", email = "juan@gmail.com", contraseña = "3456", re_contraseña = "3456" });
            return lst;
        }
    }
}
