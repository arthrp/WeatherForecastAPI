using WeatherForecastApi.Models;

namespace WeatherForecastApi;

public interface IWeatherForecastProvider
{
    void UpdateForecasts();
    WeatherModel Get(string name);
    List<WeatherModel> GetAll();
}