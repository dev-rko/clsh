using Microsoft.AspNetCore.Mvc;

namespace CleanShop.ForWeb.Controllers;
[ApiController]
[Route("[controller]")]
#pragma warning disable CA1515 // Consider making public types internal
public class WeatherForecastController : ControllerBase
#pragma warning restore CA1515 // Consider making public types internal
{
    //private static readonly string[] Summaries = new[]
    //{
    //    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    //};

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = 1, //Random.Shared.Next(-20, 55),
            Summary = "x", //Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
}
