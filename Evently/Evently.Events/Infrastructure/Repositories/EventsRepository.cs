using Evently.Events.Application.Interfaces;
using Evently.Events.Domain.Entities;
using Evently.Events.Infrastructure.Database.Context;
using Microsoft.EntityFrameworkCore;

namespace Evently.Events.Infrastructure.Repositories;

public class EventsRepository(EventsDbContext context): IEventsRepository
{
    public async Task<IEnumerable<Event>> GetAllAsync()
    {
        return await context.Events.ToListAsync();
    }

    public async Task<Event?> GetByIdAsync(Guid id)
    {
        return await context.Events
            .Where(e => e.Id == id)
            .SingleOrDefaultAsync();
    }

    public async Task CreateAsync(Event @event)
    {
        await context.Events.AddAsync(@event);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Event @event)
    {
        context.Events.Update(@event);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Event @event)
    { 
        context.Events.Remove(@event);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAllAsync()
    {
        var events = context.Events.ToList();

        context.Events.RemoveRange(events);
        await context.SaveChangesAsync();
    }
}