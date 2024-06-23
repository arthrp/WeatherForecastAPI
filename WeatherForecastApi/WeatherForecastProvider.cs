using System.Collections.Concurrent;
using WeatherForecastApi.Models;

namespace WeatherForecastApi;

public class WeatherForecastProvider : IWeatherForecastProvider
{
    private readonly ConcurrentDictionary<string, WeatherModel> _forecasts = new();

    public void UpdateForecasts()
    {
        var r = new Random();
        var m = new WeatherModel()
        {
            PlaceName = "Tórshavn",
            RelativeHumidity = r.Next(10, 99),
            TemperatureC = r.Next(-30,40),
            ForecastDate = DateOnly.FromDateTime(DateTime.Now.AddDays(1))
        };
        _forecasts["Tórshavn"] = m;
    }

    public WeatherModel Get(string name)
    {
        return _forecasts[name];
    }

    public List<WeatherModel> GetAll()
    {
        return _forecasts.Values.ToList();
    }
}