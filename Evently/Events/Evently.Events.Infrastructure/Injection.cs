using Evently.Events.Application.Interfaces.Repositories;
using Evently.Events.Domain.Models;
using Evently.Events.Infrastructure.Database.Context;
using Evently.Events.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace Evently.Events.Infrastructure;

public static class Injection 
{
    public static IServiceCollection RegisterInfrastructure(
        this IServiceCollection services, 
        IConfiguration configuration)
    {
        services.AddTransient<IEventsRepository, EventsRepository>();
        
        string connectionString = configuration.GetConnectionString("DataBase");

        services.AddDbContext<EventsDbContext>(options =>
            options.UseNpgsql(connectionString, 
                npgsqlOptions => npgsqlOptions.MigrationsHistoryTable(HistoryRepository.DefaultTableName, Schemas.Events))
               // .UseSnakeCaseNamingConvention()
            );

        return services;
    }
}