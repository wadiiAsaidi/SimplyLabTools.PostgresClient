using Microsoft.AspNetCore.Mvc;
using TestDockerProject.Configuration;
using TestDockerProject.Models;

namespace TestDockerProject.Controllers;

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
    public List<Customer> Get()
    {
        // Add services to the container.
        var dbContext = new DbContextBase();

        var customers = FakeData.GenerateFakeData();
        foreach (var item in customers)
        {
            dbContext.Add(item);

        }
        dbContext.SaveChanges();
        var getAllCustomer = dbContext.Set<Customer>().ToList();

        return getAllCustomer;
    }
}
