using Evently.Events.Infrastructure.Database.Context;
using Microsoft.EntityFrameworkCore;

namespace Evently.Api.Extensions;

internal static class MigrationExtension
{
    internal static void ApplyMigrations(this IApplicationBuilder app)
    {
        using IServiceScope scope = app.ApplicationServices.CreateScope();
        
        ApplyMigrations<EventsDbContext>(scope);
    }

    private static void ApplyMigrations<T>(IServiceScope scope) where T : DbContext
    {
        using T context = scope.ServiceProvider.GetRequiredService<T>();
        
        context.Database.Migrate();
    }
}