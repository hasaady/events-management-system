using Evently.Events.Domain.Entities;

namespace Evently.Events.Application.Interfaces;

public interface IEventsRepository
{
    public Task<IEnumerable<Event>> GetAllAsync();
    
    public Task<Event?> GetByIdAsync(Guid id);
    
    public Task CreateAsync(Event @event);
    
    public Task UpdateAsync(Event @event);
    
    public Task DeleteAsync(Event @event);
    
    public Task DeleteAllAsync();

}