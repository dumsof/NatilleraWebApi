using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace NatilleraWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
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

        /// <summary>
        /// Obtener Temperatura.
        /// </summary>     
        [HttpGet("GetTemperatura")]
        //[ActionName("GetTemperatura")]
        public IEnumerable<WeatherForecast> GetTemperatura()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        /// <summary>
        /// Muestra la fecha
        /// </summary>
        /// <returns>Retorna la fecha</returns>
        [HttpGet("GetFecha")]
        //[ActionName("GetFecha")]
        public string GetFecha()
        {
            return DateTime.Now.ToString();
        }
    }
}
