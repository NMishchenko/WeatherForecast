using Microsoft.EntityFrameworkCore;

namespace WeatherForecast.DAL;

public class WeatherForecastContext : DbContext
{
    // public DbSet<SomeEntity> SomeEntities { get; set; }

    public WeatherForecastContext() : base()
    {
    }

    public WeatherForecastContext(DbContextOptions<WeatherForecastContext> contextOptions) : base(contextOptions)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // modelBuilder.ApplyConfiguration(new SomeEntityConfiguration());

        // + Data seeding?
    }
}
