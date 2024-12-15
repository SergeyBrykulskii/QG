using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QueueGen.Infrastructure.ApplicationDbContext;
using QueueGen.Infrastructure.Entities;
using QueueGen.Infrastructure.Repositories;
using QueueGen.Infrastructure.Repositories.Abstractions;

namespace QueueGen.Infrastructure.Extensions;

public static class ServiceExtension
{
    public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseNpgsql(connectionString);
        });

        services.AddScoped<IBaseRepository<User>, BaseRepository<User>>();
        services.AddScoped<IBaseRepository<Queue>, BaseRepository<Queue>>();
        services.AddScoped<IBaseRepository<Discipline>, BaseRepository<Discipline>>();
        services.AddScoped<IBaseRepository<Group>, BaseRepository<Group>>();
        services.AddScoped<IBaseRepository<Coefficient>, BaseRepository<Coefficient>>();
        services.AddScoped<IBaseRepository<QueueUser>, BaseRepository<QueueUser>>();
        services.AddScoped<IBaseRepository<TempUser>, BaseRepository<TempUser>>();
    }
}