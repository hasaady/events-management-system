using Evently.Events.Application.Interfaces.Repositories;
using Evently.Events.Domain.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Evently.Events.Application;

public static class Injection
{
    public static IServiceCollection RegisterApplication(
        this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Injection).Assembly));
        
        return services;
    }
}
