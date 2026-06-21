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
        [HttpGet("Weather")]
        public IActionResult GetAll()
        {
            return Ok(WeatherList);
        }
        [HttpGet("{city}")]
        public IActionResult GetCity(string city)
        {
            var cityget = WeatherList.FirstOrDefault(w => w.City.Equals(city, StringComparison.OrdinalIgnoreCase));
            if (cityget is null) return NotFound();
            return Ok(cityget);
        }
    }
}
