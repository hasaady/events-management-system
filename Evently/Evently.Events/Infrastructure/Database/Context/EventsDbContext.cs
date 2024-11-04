using Evently.Events.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Evently.Events.Infrastructure.Database.Context;

public sealed class EventsDbContext(DbContextOptions<EventsDbContext> options) : DbContext(options)
{
    internal DbSet<Event> Events { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(Schemas.Events);
    }
}