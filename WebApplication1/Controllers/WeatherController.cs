using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private static readonly List<WeatherData> WeatherList = new()
        {
            new WeatherData
            {
                City = "Cairo",
                Temperature = 35
            },
            new WeatherData
            {
                City = "Alexandria",
                Temperature = 29
            },
            new WeatherData
            {
                City = "Aswan",
                Temperature = 40
            }
        };
        [HttpGet()]
        public IActionResult GetAll()
        {
            return Ok(WeatherList);
        }
        [HttpGet("{city}")]
        public IActionResult GetWeatherlistOfCity(string city)
        {
            var cityget = WeatherList.FirstOrDefault(w => w.City.Equals(city, StringComparison.OrdinalIgnoreCase));
            if (cityget is null) return NotFound();
            return Ok(cityget);
        }
        [HttpGet("hottest")]
        public IActionResult GetCityWithHighTemperature()
        {
            var HighTemperature = WeatherList.Max(s => s.Temperature);
            var HighTemperatureCity = WeatherList.Where(s => s.Temperature == HighTemperature);
            return Ok(HighTemperatureCity);
        }
    }
}
