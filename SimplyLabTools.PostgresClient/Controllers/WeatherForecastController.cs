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
        getAllCustomer.Add(
                new Customer
                {
                    Id = 2,
                    FirstName = "wadii new verion work",
                    LastName = "new verion work alsaidi",
                    Email = "wadii.alsaidi@example.com new verion work",
                    Address = "456 Oak St",
                    City = "Los Angeles new verion work",
                    State = new State { Id = 2, Abbreviation = "CA", Name = "California" },
                    Zip = 2004,
                    Gender = "man",
                    OrderCount = 1,
                    Orders = new List<Order>
                        {
                            new Order { Id = 3, Product = "IPhone", Quantity = 1, Price = 699.99m }
                        }
                });
        return getAllCustomer;
    }
}
