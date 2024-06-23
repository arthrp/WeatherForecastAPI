using Quartz;

namespace WeatherForecastApi;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var refreshInterval = int.Parse(builder.Configuration["RefreshIntervalSeconds"] ?? "3");

        // Add services to the container.
        builder.Services.AddAuthorization();

        builder.Services.AddControllers();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        // DI
        builder.Services.AddSingleton<IWeatherForecastProvider, WeatherForecastProvider>();
        
        builder.Services.AddQuartz(q =>
        {
            q.UseSimpleTypeLoader();
            q.ScheduleJob<WeatherUpdateJob>(opts => opts.WithSimpleSchedule(x => 
                x.WithIntervalInSeconds(refreshInterval).RepeatForever()), opt => opt.StoreDurably());
        });
        builder.Services.AddQuartzHostedService(q => q.WaitForJobsToComplete = false);

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseRouting();
        app.UseAuthorization();

        app.UseEndpoints(e => e.MapControllers());

        app.UseHttpsRedirection();
        
        await app.RunAsync();
    }
}