namespace WeatherForecastApi.Models;

public class WeatherModel
{
    public double TemperatureC { get; set; }

    public string TemperatureFeeling
    {
        get
        {
            var x = TemperatureC switch
            {
                <= -20 => "Freezing",
                > - 20 and < 0 => "Cold",
                >= 0 and <= 10 => "Chilly",
                > 10 and <= 20 => "Mild",
                > 20 and <= 25 => "Warm",
                > 25 and <= 30 => "Hot",
                > 30 => "Scorching",
                _ => throw new ArgumentOutOfRangeException()
            };
            return x;
        }
    }

    public string PlaceName { get; set; } = "";
    public int RelativeHumidity { get; set; }
    public DateOnly ForecastDate { get; set; }
}