using Microsoft.EntityFrameworkCore;
using PocEf.Data;

namespace PocEf;

public static class Boostrapper
{
    public static IServiceCollection AddApplicationBootstrapper(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetValue<string>("Database:ConnectionString");

        services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));

        return services;
    }
}