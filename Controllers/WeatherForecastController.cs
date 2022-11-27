using Microsoft.EntityFrameworkCore;
using PetProject.DBContext;
using Microsoft.AspNetCore.Mvc;
using PetProject.Models;

namespace PetProject.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class WeatherForecastController : Controller
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

    [HttpGet]
    public IActionResult Get()
    {
        var wf = new WeatherForecast()//.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now,
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        };
        return Json(wf);
    }
}
