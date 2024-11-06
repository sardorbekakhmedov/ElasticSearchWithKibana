using ElasticKIbanaApi.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ElasticKIbanaApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TestController : ControllerBase
{
    private readonly ILogger<TestController> _logger;

    public TestController(ILogger<TestController> logger)
    {
        _logger = logger;
    }

    [HttpGet("GetWeatherForecast")]
    public IActionResult GetWeatherForecast()
    {
        try
        {
            var summaries = new[]
            {
                "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
            };
        
            var forecast = Enumerable.Range(1, 5).Select(index =>
            {
                var tempC = Random.Shared.Next(-20, 55);
                return new WeatherForecast()
                {
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    TemperatureC = tempC,
                    TemperatureF = 32 + (int)(tempC / 0.5556),
                    Summary = summaries[Random.Shared.Next(summaries.Length)]
                };
            }).ToArray();
            
            _logger.LogInformation("GetWeatherForecast: Hello from action!");
        
            return Ok(forecast);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            _logger.LogError(ex, "GetWeatherForecast: Hello from exception!", 7);
            throw;
        }
    }
}