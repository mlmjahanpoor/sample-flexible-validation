using Microsoft.AspNetCore.Mvc;
using Moslem.FlexibleValidation.Interfaces;
using Moslem.FlexibleValidation.Models;

namespace WebApplication1.Controllers;

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
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }

    [HttpPost]
    public IActionResult Post(TestModel model)
    {
        return Ok(model);
    }
}

public class TestModel
{
    public string? Name { get; set; }
}

//3
public class TestModelValidator : IAsyncValidation<TestModel>
{
    public async Task<Validation> ValidateAsync(TestModel model)
    {
        var val = Validation.Create();

        if (string.IsNullOrWhiteSpace(model.Name))
            val.AddField(nameof(model.Name), $"{model.Name}", "Name is required!");

        return val;
    }
}