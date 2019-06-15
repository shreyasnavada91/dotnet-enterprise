using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using YourApp.Data.Interfaces;
using YourApp.Web.Models;

namespace YourApp.Web.Controllers
{
    /// <summary>
    /// Weather API Controller - 2020-2023
    /// 
    /// .NET Core 3.1 / 6.0 API with modern patterns
    /// 
    /// @author Your Name
    /// @since 2020
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherController : ControllerBase
    {
        private readonly ILogger<WeatherController> _logger;
        private readonly IWeatherRepository _weatherRepository;
        private readonly IForecastService _forecastService;
        
        public WeatherController(ILogger<WeatherController> logger,
                                IWeatherRepository weatherRepository,
                                IForecastService forecastService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _weatherRepository = weatherRepository ?? throw new ArgumentNullException(nameof(weatherRepository));
            _forecastService = forecastService ?? throw new ArgumentNullException(nameof(forecastService));
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WeatherForecast>>> Get()
        {
            try
            {
                var forecasts = await _weatherRepository.GetAllAsync();
                _logger.LogInformation("Retrieved {count} weather forecasts", forecasts.Count());
                return Ok(forecasts);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving weather forecasts");
                return StatusCode(500, new { message = "Internal server error" });
            }
        }
        
        [HttpGet("{id:int}", Name = "GetForecast")]
        public async Task<ActionResult<WeatherForecast>> Get(int id)
        {
            var forecast = await _weatherRepository.GetByIdAsync(id);
            if (forecast == null) return NotFound();
            return Ok(forecast);
        }
    }
}
