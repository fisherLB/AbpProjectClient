using AbpProject;
using Microsoft.AspNetCore.Mvc;

namespace WebApiApplication.Controllers
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
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("GetPerson")]
        public async Task<IEnumerable<Person>> GetPerson()
        {
            AbpProjectClient abpProjectClien = new AbpProjectClient("https://localhost:44364", new HttpClient());
            var result=await abpProjectClien.GetAsync();
            return result;
        }
    }
}