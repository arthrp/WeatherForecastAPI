using Quartz;

namespace WeatherForecastApi;

public class WeatherUpdateJob : IJob
{
    private readonly IWeatherForecastProvider _weatherForecastProvider;
    public WeatherUpdateJob(IWeatherForecastProvider weatherForecastProvider)
    {
        _weatherForecastProvider = weatherForecastProvider;
    }
    
    public async Task Execute(IJobExecutionContext context)
    {
        _weatherForecastProvider.UpdateForecasts();
        //TODO: Change to logger
        Console.WriteLine("Forecast update executed at " + DateTime.Now);
    }
}