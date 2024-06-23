using Microsoft.AspNetCore.Mvc;
using WeatherForecastApi.Models;

namespace WeatherForecastApi.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherController(IWeatherForecastProvider weatherForecastProvider) : ControllerBase
{
    [HttpGet("")]
    public List<WeatherModel> GetWeather()
    {
        var w = weatherForecastProvider.GetAll();

        return w;
    }
}